namespace Jerry_Sanders_2010
{
	class SerialCom
	{

		// Serial Port variables
		string RxString;
		string TxString = "";

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

		int timeElapsed = 0;

		string motorString = "";

		Wiimote wm = new Wiimote();

		# region joystick vars

		int JoyXOld = 0;
		int JoyYOld = 0;

		# endregion

//		# endregion

	
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
			//if (TxData)
			{
				byte[] TxBuffer = new byte[TxData.Length + 2];
				TxBuffer[0] = 0xFD;
				for (int i = 1; i < TxData.Length; i++)
				{
					TxBuffer[i] = (byte)TxData[i - 1];
				}
				TxBuffer[TxData.Length + 1] = 0xFF;
				this.Invoke(this.m_DelegateDebugText, new object[] { TxData });
				if (serialArduino.IsOpen)
				{
					serialArduino.Write(TxBuffer, 0, TxBuffer.Length);
					//serialArduino.Write(TxData);
					TxString = "";
				}
			}
		}
	}
}