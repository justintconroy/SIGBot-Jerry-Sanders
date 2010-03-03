using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Jerry_Sanders_2010
{
	public partial class jerry5Form : Form
	{

		// Serial Port variables
		string RxString;
		string TxString;


		public jerry5Form()
		{
			InitializeComponent();
		}

		/* jerry5Form_Load
		 * Event handler for when jerry5Form first loads.
		 */
		private void jerry5Form_Load(object sender, EventArgs e)
		{

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
		
		/* serialArduino_DataRecieved
		 * Event handler for processing data from the serial port as it is recieved.
		 */
		private void serialArduino_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
		{
			RxString += serialArduino.ReadExisting();
			this.Invoke(new EventHandler(serialArduinoProcessRx));
		}

		/* serialArduinoProcessRx
		 * Reads recieved data and does something with it (probably just displays it)
		 */
		private void serialArduinoProcessRx(object sender, EventArgs e)
		{
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
			string TxBuffer = '\xFD' + TxData + '\xFF';
			serialArduino.Write(TxBuffer);
		}

		

		private void btnStartSerial_Click(object sender, EventArgs e)
		{
			while (!serialArduino.IsOpen)
			{
				serialArduino.Open();
				if (serialArduino.IsOpen)
				{
					btnStartSerial.Enabled = false;
					btnStopSerial.Enabled = true;
					serialDisplay.ReadOnly = false;
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
	}
}
