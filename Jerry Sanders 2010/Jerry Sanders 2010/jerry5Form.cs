/* Jerry 5 Control interface
 * 
 * This file contains code for an interface to the Jerry 5 robot.
 * The Jerry 5 robot is an entrant in the 2010 Jerry Sanders Creative Design
 * Competion <http://dc.ec.uiuc.edu>.
 * 
 * TODO:
 *  - Add in Wiimote stuff
 *  - Inverse Kinematics for the arm
 *  - Logic between wiimote and serial interface
 *  - Arduino code (not in this file)
 *  - Everything!!!!
 *  
 */

/* Diagrams:
 * (these are mostly just to show which variables correspond to which motors).
 * 
 * Top down view of robot:
 * 
 *               Front
 *       ______________________
 *       |                    |
 *       |== motorA  motorB ==|
 *       |                    |
 *       |                    |
 *       |                    |
 *       |                    |
 *       |                    |
 *       |== motorC  motorC ==|
 *       |                    |
 *       ______________________
 *       
 * 
 * Crude drawing of Arm:
 * 
 *      gripper ==|\\
 *       cutter ==||\\
 *                   \\
 *                    == servo3 (elbow joint)
 *                    ||
 *                    ||
 *                    ||
 *                    == servo2 (shoulder joint)
 *                    == servo1 (rotates entire arm)
 *                    
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WiimoteLib;

namespace Jerry_Sanders_2010
{
	public partial class jerry5Form : Form
	{

		# region Local Variables

		// Serial Port variables
		string RxString;
		string TxString;

		// Motor variables
		int motorACurrentSpeed = 0;
		int motorBCurrentSpeed = 0;
		int motorCCurrentSpeed = 0;
		int motorDCurrentSpeed = 0;

		// Servo variables
		int servo1CurrentPosition = 0;
		int servo2CurrentPosition = 0;
		int servo3CurrentPosition = 0;
		int GripperCurrentPosition = 0;
		int CutterCurrentPosition = 0;

		Wiimote wm = new Wiimote();

		# endregion

		# region Flags

		// These btn*Flag flags will be true while their respective buttons are
		// held down.  This is to prevent "Key Repeat."  i.e. each press and release
		// of a button will trigger an action instead of holding down a button causing
		// it's action to repeatedly trigger.
		bool btnBFlag = false;
		bool btnHomeFlag = false;

		# endregion

		public jerry5Form()
		{
			InitializeComponent();
		}

		/* jerry5Form_Load
		 * Event handler for when jerry5Form first loads.
		 */
		private void jerry5Form_Load(object sender, EventArgs e)
		{
			// connect it and set it up as always
				wm.WiimoteChanged += wm_WiimoteChanged;
				wm.WiimoteExtensionChanged += wm_WiimoteExtensionChanged;
			// attempt to connect to a wiimote
			try
			{
				wm.Connect();
			}
			catch (WiimoteNotFoundException ex)
			{
				MessageBox.Show(ex.Message, "Wiimote not found error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch (WiimoteException ex)
			{
				MessageBox.Show(ex.Message, "Wiimote error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Unknown error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			// set the report type for the wiimote
			if (wm.WiimoteState.ExtensionType != ExtensionType.BalanceBoard)
			{
				wm.SetReportType(InputReport.ExtensionAccel, true);

				wm.SetLEDs(1);
			}

			
		}

		/* jerry5Form_FormClosing
		 * Event handler for when the form is closing. This function ensures that
		 * the serial port gets closed when we exit the program.
		 */
		private void jerry5Form_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (serialArduino.IsOpen)
				serialArduino.Close();
		}

		# region Serial Port stuff (and functions for talking to the motors)

		/* serialArduino_DataRecieved
		 * Event handler for processing data from the serial port as it is recieved.
		 */
		private void serialArduino_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
		{
			RxString += serialArduino.ReadExisting();
			this.Invoke(new EventHandler(serialArduinoProcessRx));
			//serialDisplay.AppendText("\n");
		}

		/* serialArduinoProcessRx
		 * Reads recieved data and does something with it (probably just displays it)
		 */
		private void serialArduinoProcessRx(object sender, EventArgs e)
		{
			serialDisplay.AppendText(RxString);
			serialDisplay.AppendText("\n");
		}

		private void serialDisplay_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!serialArduino.IsOpen)
				return;

			TxString += e.KeyChar;

			//if (buff.Length >= 4)
			if (e.KeyChar == (char)013)
			{
				sendSerialData(TxString);
				TxString = "";
				serialDisplay.AppendText("\n");
			}
		}

		/* sendSerialData
		 * Prepends and postpends a string with the start and stop bytes
		 * and then sends it out over the serialArduino serial port.
		 *  Inputs: TxData - The data to be sent over the serial port
		 *  Ouputs: none
		 *  Side Effects: Data is sent over the serial port
		 */
		private void sendSerialData(string TxData)
		{
			string TxBuffer = "";
			TxBuffer += (char)0x7F;
			TxBuffer += TxData;
			TxBuffer += (char)0xFF;
			txtDebugSerialOut.ResetText();
			txtDebugSerialOut.AppendText(TxBuffer);
			if (serialArduino.IsOpen)
			{
				serialArduino.Write(TxBuffer);
				TxString = "";
			}
		}

		/* sendMotorAndServoParams
		 * Sends speed and position data for all motors (including arm servos)
		 *  Inputs: motorA  - speed of motor A. Ranges from -90 to +90
		 *          motorB  - speed of motor B. Ranges from -90 to +90
		 *          motorC  - speed of motor C. Ranges from -90 to +90
		 *          motorD  - speed of motor D. Ranges from -90 to +90
		 *          servo1  - position of servo 1. Ranges from 0 to 180
		 *          servo2  - position of servo 2. Ranges from 0 to 180
		 *          servo3  - position of servo 3. Ranges from 0 to 180
		 *          gripper - State of gripper. Open (0) or closed (1)
		 *          cutter  - State of cutter. Open (0) or closed(1)
		 *  Outputs: none
		 *  Return value: 0 means all is well
		 *                -1 means an error occured (a parameter is out of bounds, most likely)
		 *  Side Effects: sends data over the serial port
		 */
		void sendMotorAndServoParams(int motorA, int motorB, int motorC,
			int motorD, int servo1, int servo2, int servo3,
			int gripper, int cutter)
		{
			// temporary motor variables (as single bytes)
			char[] motorBytes = new char[8];
			
			// Buffer string to send over serial port
			string motorString = "";

			// Check that motor A is in the correct range and saturate it.
			if (motorA < 90)
				motorA = 90;
			if (motorA > -90)
				motorA = -90;

			motorBytes[0] = (char)(motorA + 90);  // actual legit values for the motor range from
				                                  // 0 to 180, so shift by 90.			
			
			// Check that motor B is in the correct range and saturate it.
			if (motorB < 90)
				motorB = 90;
			if (motorB > -90)
				motorB = -90;

			motorBytes[1] = (char)(motorB + 90);  // actual legit values for the motor range from
				                                  // 0 to 180, so shift by 90.

			// Check that motor C is in the correct range and saturate it.
			if (motorC < 90)
				motorC = 90;
			if (motorC > -90)
				motorC = -90;

			motorBytes[2] = (char)(motorC + 90);  // actual legit values for the motor range from
				                                  // 0 to 180, so shift by 90.
			
			// Check that motor D is in the correct range and saturate it.
			if (motorD < 90)
				motorD = 90;
			if (motorD > -90)
				motorD = -90;

			motorBytes[3] = (char)(motorD + 90);  // actual legit values for the motor range from
			                                      // 0 to 180, so shift by 90.

			// Check that servo1 is in the correct range and saturate it.
			if (servo1 < 180)
				servo1 = 180;
			if (servo1 > 0)
				servo1 = 0;
			
			motorBytes[4] = (char)servo1;

			// Check that servo2 is in the correct range and saturate it.
			if (servo2 < 180)
				servo2 = 180;
			if (servo2 > 0)
				servo2 = 0;

			motorBytes[5] = (char)servo2;

			// Check that servo3 is in the correct range and saturate it.
			if (servo3 < 180)
				servo3 = 180;
			if (servo3 > 0)
				servo3 = 0;
			
			motorBytes[6] = (char)servo3;

			// Check that gripper and cutter are in the correct range
			if (((gripper == 0) || (gripper == 1)) && ((gripper == 0) || (gripper == 1)))
			{
				// Combine gripper and cutter into a single byte
				motorBytes[7] = (char)(gripper + (cutter << 1));
				//motorString += byteGripCut;
			}

			motorString = new string(motorBytes);

			//txtDebugSerialOut.ResetText();
			//txtDebugSerialOut.AppendText(motorString);
			sendSerialData(motorString);
			
			// Update global motor speed variables
			motorACurrentSpeed = motorA;
			motorBCurrentSpeed = motorB;
			motorCCurrentSpeed = motorC;
			motorDCurrentSpeed = motorD;

			// update global servo position variables
			servo1CurrentPosition = servo1;
			servo2CurrentPosition = servo2;
			servo3CurrentPosition = servo3;
			GripperCurrentPosition = gripper;
			CutterCurrentPosition = cutter;
		}

		/* sendMotorParams
		 * Sends speed data for only the driving motors
		 *  Inputs: motorA  - speed of motor A. Ranges from -90 to +90
		 *          motorB  - speed of motor B. Ranges from -90 to +90
		 *          motorC  - speed of motor C. Ranges from -90 to +90
		 *          motorD  - speed of motor D. Ranges from -90 to +90
		 *  Outputs: none
		 *  Return value: 0 means all is well
		 *                -1 means an error occured (a parameter is out of bounds, most likely)
		 *  Side Effects: sends data over the serial port
		 */
		void sendMotorParams(int motorA, int motorB, int motorC,
			int motorD)
		{
			sendMotorAndServoParams(motorA, motorB, motorC, motorD,
				servo1CurrentPosition, servo2CurrentPosition,
				servo3CurrentPosition, GripperCurrentPosition,
				CutterCurrentPosition);
		}

		/* sendServoParams
		 * Sends speed and position data for all motors (including arm servos)
		 *  Inputs: servo1  - position of servo 1. Ranges from 0 to 180
		 *          servo2  - position of servo 2. Ranges from 0 to 180
		 *          servo3  - position of servo 3. Ranges from 0 to 180
		 *  Outputs: none
		 *  Return value: 0 means all is well
		 *                -1 means an error occured (a parameter is out of bounds, most likely)
		 *  Side Effects: sends data over the serial port
		 */
		void sendServoParams(int servo1, int servo2, int servo3)
		{
			sendMotorAndServoParams(motorACurrentSpeed, motorBCurrentSpeed,
				motorCCurrentSpeed, motorDCurrentSpeed, servo1, servo2, servo3,
				GripperCurrentPosition, CutterCurrentPosition);
		}

		void openGripper()
		{
			// temporary motor variables (as single bytes)
			char[] motorBytes = new char[8];

			// Buffer string to send over serial port
			string motorString = "";

			motorBytes[0] = (char)(motorACurrentSpeed + 90);
			motorBytes[1] = (char)(motorBCurrentSpeed + 90);
			motorBytes[2] = (char)(motorCCurrentSpeed + 90);
			motorBytes[3] = (char)(motorDCurrentSpeed + 90);

			motorBytes[4] = (char)servo1CurrentPosition;
			motorBytes[5] = (char)servo2CurrentPosition;
			motorBytes[6] = (char)servo3CurrentPosition;

			motorBytes[7] = (char)((CutterCurrentPosition << 1));

			motorString = new string(motorBytes);

			sendSerialData(motorString);

			GripperCurrentPosition = 0;

		}

		void closeGripper()
		{
			// temporary motor variables (as single bytes)
			char[] motorBytes = new char[8];

			// Buffer string to send over serial port
			string motorString = "";

			motorBytes[0] = (char)(motorACurrentSpeed + 90);
			motorBytes[1] = (char)(motorBCurrentSpeed + 90);
			motorBytes[2] = (char)(motorCCurrentSpeed + 90);
			motorBytes[3] = (char)(motorDCurrentSpeed + 90);

			motorBytes[4] = (char)servo1CurrentPosition;
			motorBytes[5] = (char)servo2CurrentPosition;
			motorBytes[6] = (char)servo3CurrentPosition;

			motorBytes[7] = (char)((CutterCurrentPosition << 1) + 0x01);

			motorString = new string(motorBytes);

			sendSerialData(motorString);

			GripperCurrentPosition = 1;

		}

		void openCutter()
		{
			// temporary motor variables (as single bytes)
			char[] motorBytes = new char[8];

			// Buffer string to send over serial port
			string motorString = "";

			motorBytes[0] = (char)(motorACurrentSpeed + 90);
			motorBytes[1] = (char)(motorBCurrentSpeed + 90);
			motorBytes[2] = (char)(motorCCurrentSpeed + 90);
			motorBytes[3] = (char)(motorDCurrentSpeed + 90);

			motorBytes[4] = (char)servo1CurrentPosition;
			motorBytes[5] = (char)servo2CurrentPosition;
			motorBytes[6] = (char)servo3CurrentPosition;

			motorBytes[7] = (char)(GripperCurrentPosition);

			motorString = new string(motorBytes);

			sendSerialData(motorString);

			CutterCurrentPosition = 0;

		}

		void closeCutter()
		{
			// temporary motor variables (as single bytes)
			char[] motorBytes = new char[8];

			// Buffer string to send over serial port
			string motorString = "";

			motorBytes[0] = (char)(motorACurrentSpeed + 90);
			motorBytes[1] = (char)(motorBCurrentSpeed + 90);
			motorBytes[2] = (char)(motorCCurrentSpeed + 90);
			motorBytes[3] = (char)(motorDCurrentSpeed + 90);

			motorBytes[4] = (char)servo1CurrentPosition;
			motorBytes[5] = (char)servo2CurrentPosition;
			motorBytes[6] = (char)servo3CurrentPosition;

			motorBytes[7] = (char)(GripperCurrentPosition + 0x10);

			motorString = new string(motorBytes);

			sendSerialData(motorString);

			CutterCurrentPosition = 1;

		}

		void toggleGripper()
		{
			if (GripperCurrentPosition == 0)
			{
				closeGripper();
				btnOpenCloseGrip.Text = "Open Gripper";
			}
			else
			{
				openGripper();
				btnOpenCloseGrip.Text = "Close Gripper";
			}
		}

		void toggleCutter()
		{
			if (CutterCurrentPosition == 0)
			{
				closeCutter();
				btnOpenCloseCutter.Text = "Open Cutter";
			}
			else
			{
				openCutter();
				btnOpenCloseCutter.Text = "Close Cutter";
			}
		}

		private void btnStartSerial_Click(object sender, EventArgs e)
		{
			while (!serialArduino.IsOpen)
			{
				try
				{
					serialArduino.Open();
				}
				catch(Exception ex)
				{
					MessageBox.Show(ex.Message, "Counld not open serial port.",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
					break;
				}

				if (serialArduino.IsOpen)
				{
					btnStartSerial.Enabled = false;
					btnStopSerial.Enabled = true;
					serialDisplay.ReadOnly = false;

					// set default motor positions/speeds
					sendMotorAndServoParams(0, 0, 0, 0, 90, 90, 90, 0, 0);
					btnOpenCloseGrip.Text = "Close Gripper";
					btnOpenCloseCutter.Text = "Close Cutter";
				}
			}
		}

		private void btnStopSerial_Click(object sender, EventArgs e)
		{
			if (serialArduino.IsOpen)
			{
				serialArduino.Close();
			}
			btnStartSerial.Enabled = true;
			btnStopSerial.Enabled = false;
			serialDisplay.ReadOnly = true;
		}

		private void btnSendMotorAndServoValues_Click(object sender, EventArgs e)
		{
			int grip, cut;

			if (chkGripper.Checked)
				grip = 1;
			else
				grip = 0;

			if (chkCutter.Checked)
				cut = 1;
			else
				cut = 0;


			sendMotorAndServoParams(Convert.ToInt32(txtMotorA.Text), Convert.ToInt32(txtMotorB.Text),
				Convert.ToInt32(txtMotorC.Text), Convert.ToInt32(txtMotorD.Text),
				Convert.ToInt32(txtServo1.Text), Convert.ToInt32(txtServo2.Text),
				Convert.ToInt32(txtServo3.Text), grip, cut);
		}

		private void btnSendMotorValues_Click(object sender, EventArgs e)
		{
			sendMotorParams(Convert.ToInt32(txtMotorA.Text), Convert.ToInt32(txtMotorB.Text),
				Convert.ToInt32(txtMotorC.Text), Convert.ToInt32(txtMotorD.Text));
		}

		private void btnSendServoValues_Click(object sender, EventArgs e)
		{
			sendServoParams(Convert.ToInt32(txtServo1.Text), Convert.ToInt32(txtServo2.Text),
				Convert.ToInt32(txtServo3.Text));
		}

		private void btnOpenCloseGrip_Click(object sender, EventArgs e)
		{
			toggleGripper();
		}

		private void btnOpenCloseCutter_Click(object sender, EventArgs e)
		{
			toggleCutter();
		}

		private void btnResetSerialDisplay_Click(object sender, EventArgs e)
		{
			serialDisplay.ResetText();
		}

		#endregion

		# region Wiimote stuff

		void wm_WiimoteChanged(object sender, WiimoteChangedEventArgs e)
		{
			int joyXConverted = 0;
			int joyYConverted = 0;

			# region Joystick/Driving Motor control

			// Check to make sure the nunchuck is connected.
			if (wm.WiimoteState.ExtensionType == ExtensionType.Nunchuk)
			{
				// Get the joystick values from the nunchuck
				joyXConverted = wm.WiimoteState.NunchukState.RawJoystick.X * 180 / 255 - 94;
				joyYConverted = wm.WiimoteState.NunchukState.RawJoystick.Y * 180 / 255 - 91;

				// Enter turning mode if the 'C' button is held down.
				if (wm.WiimoteState.NunchukState.C)
				{
					sendMotorParams(joyXConverted, -joyXConverted, joyXConverted, -joyXConverted);
				}
				// Otherwise default to forwards/sideways mode.
				else
				{
					// See page 4 of Designing Omni-Directional Mobile Robot with Mecanum Wheel
					// in the mecanum_wheel directory for more information on how the wheels should
					// be actuated properly.
					sendMotorParams(joyYConverted + joyXConverted, joyYConverted - joyXConverted,
						joyYConverted - joyXConverted, joyYConverted + joyXConverted);
				}
			}

			# endregion

			# region Wiimote buttons/gripper and cutter control

			// Use the B button to toggle the state of the gripper. btnBFlag
			// must be false so that only one button press will be processed
			// at a time. (i.e. holding down the button will have no effect
			// beyond the initial press).
			if (wm.WiimoteState.ButtonState.B && !btnBFlag)
			{
				toggleGripper();
				btnBFlag = true;
			}

			// When the B button is released, set the btnBFlag flag to false
			// so that a new button press will be recognized.
			if (!wm.WiimoteState.ButtonState.B)
				btnBFlag = false;

			// Use the Home button to toggle the state of the cutter.  Works
			// the same way as the B button (above).
			if (wm.WiimoteState.ButtonState.Home && !btnHomeFlag)
			{
				toggleCutter();
				btnHomeFlag = true;
			}

			// set btnHomeFlag flag to false when the Home button is released.
			if (!wm.WiimoteState.ButtonState.Home)
				btnHomeFlag = false;

			# endregion

			# region Arm control
			// TODO: Forward and Inverse Kinematics of the arm once we get
			//       it back from the machine shop and get all the measurements.
			//       We also need to figure out how we're going to map accelerometer
			//       movement to movement of the arm.
			# endregion
		}

		void wm_WiimoteExtensionChanged(object sender, WiimoteExtensionChangedEventArgs e)
		{
			if (e.Inserted)
				((Wiimote)sender).SetReportType(InputReport.IRExtensionAccel, true);
			else
				((Wiimote)sender).SetReportType(InputReport.IRAccel, true);
		}


		#endregion
	}
}
