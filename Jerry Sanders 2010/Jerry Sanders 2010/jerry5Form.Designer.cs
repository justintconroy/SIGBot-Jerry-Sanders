namespace Jerry_Sanders_2010
{
	partial class jerry5Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.serialArduino = new System.IO.Ports.SerialPort(this.components);
			this.label1 = new System.Windows.Forms.Label();
			this.btnStartSerial = new System.Windows.Forms.Button();
			this.btnStopSerial = new System.Windows.Forms.Button();
			this.serialDisplay = new System.Windows.Forms.TextBox();
			this.txtDebugSerialOut = new System.Windows.Forms.TextBox();
			this.txtMotorA = new System.Windows.Forms.TextBox();
			this.txtMotorB = new System.Windows.Forms.TextBox();
			this.txtMotorC = new System.Windows.Forms.TextBox();
			this.txtMotorD = new System.Windows.Forms.TextBox();
			this.txtServo1 = new System.Windows.Forms.TextBox();
			this.txtServo2 = new System.Windows.Forms.TextBox();
			this.txtServo3 = new System.Windows.Forms.TextBox();
			this.lblMotorA = new System.Windows.Forms.Label();
			this.lblMotorB = new System.Windows.Forms.Label();
			this.lblMotorC = new System.Windows.Forms.Label();
			this.lblMotorD = new System.Windows.Forms.Label();
			this.lblServo1 = new System.Windows.Forms.Label();
			this.lblServo2 = new System.Windows.Forms.Label();
			this.lblServo3 = new System.Windows.Forms.Label();
			this.chkGripper = new System.Windows.Forms.CheckBox();
			this.chkCutter = new System.Windows.Forms.CheckBox();
			this.btnSendMotorAndServoValues = new System.Windows.Forms.Button();
			this.btnSendMotorValues = new System.Windows.Forms.Button();
			this.btnSendServoValues = new System.Windows.Forms.Button();
			this.btnOpenCloseGrip = new System.Windows.Forms.Button();
			this.btnOpenCloseCutter = new System.Windows.Forms.Button();
			this.btnResetSerialDisplay = new System.Windows.Forms.Button();
			this.lblSerialOutputDebug = new System.Windows.Forms.Label();
			this.tmr_SendSerial = new System.Windows.Forms.Timer(this.components);
			this.txtQ1 = new System.Windows.Forms.TextBox();
			this.txtQ3 = new System.Windows.Forms.TextBox();
			this.txtQ2 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.txtY = new System.Windows.Forms.TextBox();
			this.txtZ = new System.Windows.Forms.TextBox();
			this.txtX = new System.Windows.Forms.TextBox();
			this.btnSetArmPos = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// serialArduino
			// 
			this.serialArduino.BaudRate = 115200;
			this.serialArduino.PortName = "COM17";
			this.serialArduino.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialArduino_DataReceived);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(98, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Arduino Serial Data";
			// 
			// btnStartSerial
			// 
			this.btnStartSerial.Location = new System.Drawing.Point(12, 25);
			this.btnStartSerial.Name = "btnStartSerial";
			this.btnStartSerial.Size = new System.Drawing.Size(75, 23);
			this.btnStartSerial.TabIndex = 10;
			this.btnStartSerial.Text = "Start";
			this.btnStartSerial.UseVisualStyleBackColor = true;
			this.btnStartSerial.Click += new System.EventHandler(this.btnStartSerial_Click);
			// 
			// btnStopSerial
			// 
			this.btnStopSerial.Enabled = false;
			this.btnStopSerial.Location = new System.Drawing.Point(93, 25);
			this.btnStopSerial.Name = "btnStopSerial";
			this.btnStopSerial.Size = new System.Drawing.Size(75, 23);
			this.btnStopSerial.TabIndex = 11;
			this.btnStopSerial.Text = "Stop";
			this.btnStopSerial.UseVisualStyleBackColor = true;
			this.btnStopSerial.Click += new System.EventHandler(this.btnStopSerial_Click);
			// 
			// serialDisplay
			// 
			this.serialDisplay.Location = new System.Drawing.Point(12, 54);
			this.serialDisplay.Multiline = true;
			this.serialDisplay.Name = "serialDisplay";
			this.serialDisplay.ReadOnly = true;
			this.serialDisplay.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.serialDisplay.Size = new System.Drawing.Size(156, 183);
			this.serialDisplay.TabIndex = 12;
			this.serialDisplay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.serialDisplay_KeyPress);
			// 
			// txtDebugSerialOut
			// 
			this.txtDebugSerialOut.Location = new System.Drawing.Point(15, 290);
			this.txtDebugSerialOut.Name = "txtDebugSerialOut";
			this.txtDebugSerialOut.Size = new System.Drawing.Size(156, 20);
			this.txtDebugSerialOut.TabIndex = 14;
			// 
			// txtMotorA
			// 
			this.txtMotorA.Location = new System.Drawing.Point(225, 28);
			this.txtMotorA.Name = "txtMotorA";
			this.txtMotorA.Size = new System.Drawing.Size(50, 20);
			this.txtMotorA.TabIndex = 0;
			this.txtMotorA.Text = "0";
			// 
			// txtMotorB
			// 
			this.txtMotorB.Location = new System.Drawing.Point(225, 54);
			this.txtMotorB.Name = "txtMotorB";
			this.txtMotorB.Size = new System.Drawing.Size(50, 20);
			this.txtMotorB.TabIndex = 1;
			this.txtMotorB.Text = "0";
			// 
			// txtMotorC
			// 
			this.txtMotorC.Location = new System.Drawing.Point(225, 80);
			this.txtMotorC.Name = "txtMotorC";
			this.txtMotorC.Size = new System.Drawing.Size(50, 20);
			this.txtMotorC.TabIndex = 2;
			this.txtMotorC.Text = "0";
			// 
			// txtMotorD
			// 
			this.txtMotorD.Location = new System.Drawing.Point(225, 106);
			this.txtMotorD.Name = "txtMotorD";
			this.txtMotorD.Size = new System.Drawing.Size(50, 20);
			this.txtMotorD.TabIndex = 3;
			this.txtMotorD.Text = "0";
			// 
			// txtServo1
			// 
			this.txtServo1.Location = new System.Drawing.Point(335, 34);
			this.txtServo1.Name = "txtServo1";
			this.txtServo1.Size = new System.Drawing.Size(50, 20);
			this.txtServo1.TabIndex = 4;
			this.txtServo1.Text = "90";
			// 
			// txtServo2
			// 
			this.txtServo2.Location = new System.Drawing.Point(335, 59);
			this.txtServo2.Name = "txtServo2";
			this.txtServo2.Size = new System.Drawing.Size(50, 20);
			this.txtServo2.TabIndex = 5;
			this.txtServo2.Text = "74";
			// 
			// txtServo3
			// 
			this.txtServo3.Location = new System.Drawing.Point(335, 86);
			this.txtServo3.Name = "txtServo3";
			this.txtServo3.Size = new System.Drawing.Size(50, 20);
			this.txtServo3.TabIndex = 6;
			this.txtServo3.Text = "90";
			// 
			// lblMotorA
			// 
			this.lblMotorA.AutoSize = true;
			this.lblMotorA.Location = new System.Drawing.Point(175, 28);
			this.lblMotorA.Name = "lblMotorA";
			this.lblMotorA.Size = new System.Drawing.Size(44, 13);
			this.lblMotorA.TabIndex = 5;
			this.lblMotorA.Text = "Motor A";
			// 
			// lblMotorB
			// 
			this.lblMotorB.AutoSize = true;
			this.lblMotorB.Location = new System.Drawing.Point(175, 54);
			this.lblMotorB.Name = "lblMotorB";
			this.lblMotorB.Size = new System.Drawing.Size(44, 13);
			this.lblMotorB.TabIndex = 5;
			this.lblMotorB.Text = "Motor B";
			// 
			// lblMotorC
			// 
			this.lblMotorC.AutoSize = true;
			this.lblMotorC.Location = new System.Drawing.Point(175, 80);
			this.lblMotorC.Name = "lblMotorC";
			this.lblMotorC.Size = new System.Drawing.Size(44, 13);
			this.lblMotorC.TabIndex = 5;
			this.lblMotorC.Text = "Motor C";
			// 
			// lblMotorD
			// 
			this.lblMotorD.AutoSize = true;
			this.lblMotorD.Location = new System.Drawing.Point(175, 106);
			this.lblMotorD.Name = "lblMotorD";
			this.lblMotorD.Size = new System.Drawing.Size(45, 13);
			this.lblMotorD.TabIndex = 5;
			this.lblMotorD.Text = "Motor D";
			// 
			// lblServo1
			// 
			this.lblServo1.AutoSize = true;
			this.lblServo1.Location = new System.Drawing.Point(285, 31);
			this.lblServo1.Name = "lblServo1";
			this.lblServo1.Size = new System.Drawing.Size(42, 13);
			this.lblServo1.TabIndex = 5;
			this.lblServo1.Text = "servo 1";
			// 
			// lblServo2
			// 
			this.lblServo2.AutoSize = true;
			this.lblServo2.Location = new System.Drawing.Point(285, 57);
			this.lblServo2.Name = "lblServo2";
			this.lblServo2.Size = new System.Drawing.Size(42, 13);
			this.lblServo2.TabIndex = 5;
			this.lblServo2.Text = "servo 2";
			// 
			// lblServo3
			// 
			this.lblServo3.AutoSize = true;
			this.lblServo3.Location = new System.Drawing.Point(285, 83);
			this.lblServo3.Name = "lblServo3";
			this.lblServo3.Size = new System.Drawing.Size(42, 13);
			this.lblServo3.TabIndex = 5;
			this.lblServo3.Text = "servo 3";
			// 
			// chkGripper
			// 
			this.chkGripper.AutoSize = true;
			this.chkGripper.Location = new System.Drawing.Point(288, 109);
			this.chkGripper.Name = "chkGripper";
			this.chkGripper.Size = new System.Drawing.Size(60, 17);
			this.chkGripper.TabIndex = 7;
			this.chkGripper.Text = "Gripper";
			this.chkGripper.UseVisualStyleBackColor = true;
			// 
			// chkCutter
			// 
			this.chkCutter.AutoSize = true;
			this.chkCutter.Location = new System.Drawing.Point(354, 109);
			this.chkCutter.Name = "chkCutter";
			this.chkCutter.Size = new System.Drawing.Size(54, 17);
			this.chkCutter.TabIndex = 8;
			this.chkCutter.Text = "Cutter";
			this.chkCutter.UseVisualStyleBackColor = true;
			// 
			// btnSendMotorAndServoValues
			// 
			this.btnSendMotorAndServoValues.Location = new System.Drawing.Point(178, 134);
			this.btnSendMotorAndServoValues.Name = "btnSendMotorAndServoValues";
			this.btnSendMotorAndServoValues.Size = new System.Drawing.Size(158, 23);
			this.btnSendMotorAndServoValues.TabIndex = 9;
			this.btnSendMotorAndServoValues.Text = "Send Motor and Servo Values";
			this.btnSendMotorAndServoValues.UseVisualStyleBackColor = true;
			this.btnSendMotorAndServoValues.Click += new System.EventHandler(this.btnSendMotorAndServoValues_Click);
			// 
			// btnSendMotorValues
			// 
			this.btnSendMotorValues.Location = new System.Drawing.Point(178, 163);
			this.btnSendMotorValues.Name = "btnSendMotorValues";
			this.btnSendMotorValues.Size = new System.Drawing.Size(158, 23);
			this.btnSendMotorValues.TabIndex = 9;
			this.btnSendMotorValues.Text = "Send Only Motor Values";
			this.btnSendMotorValues.UseVisualStyleBackColor = true;
			this.btnSendMotorValues.Click += new System.EventHandler(this.btnSendMotorValues_Click);
			// 
			// btnSendServoValues
			// 
			this.btnSendServoValues.Location = new System.Drawing.Point(178, 192);
			this.btnSendServoValues.Name = "btnSendServoValues";
			this.btnSendServoValues.Size = new System.Drawing.Size(158, 23);
			this.btnSendServoValues.TabIndex = 9;
			this.btnSendServoValues.Text = "Send Only Servo Values";
			this.btnSendServoValues.UseVisualStyleBackColor = true;
			this.btnSendServoValues.Click += new System.EventHandler(this.btnSendServoValues_Click);
			// 
			// btnOpenCloseGrip
			// 
			this.btnOpenCloseGrip.Location = new System.Drawing.Point(342, 132);
			this.btnOpenCloseGrip.Name = "btnOpenCloseGrip";
			this.btnOpenCloseGrip.Size = new System.Drawing.Size(134, 23);
			this.btnOpenCloseGrip.TabIndex = 15;
			this.btnOpenCloseGrip.Text = "Open/Close Gripper";
			this.btnOpenCloseGrip.UseVisualStyleBackColor = true;
			this.btnOpenCloseGrip.Click += new System.EventHandler(this.btnOpenCloseGrip_Click);
			// 
			// btnOpenCloseCutter
			// 
			this.btnOpenCloseCutter.Location = new System.Drawing.Point(342, 163);
			this.btnOpenCloseCutter.Name = "btnOpenCloseCutter";
			this.btnOpenCloseCutter.Size = new System.Drawing.Size(134, 23);
			this.btnOpenCloseCutter.TabIndex = 15;
			this.btnOpenCloseCutter.Text = "Open/Close Cutter";
			this.btnOpenCloseCutter.UseVisualStyleBackColor = true;
			this.btnOpenCloseCutter.Click += new System.EventHandler(this.btnOpenCloseCutter_Click);
			// 
			// btnResetSerialDisplay
			// 
			this.btnResetSerialDisplay.Location = new System.Drawing.Point(15, 243);
			this.btnResetSerialDisplay.Name = "btnResetSerialDisplay";
			this.btnResetSerialDisplay.Size = new System.Drawing.Size(95, 23);
			this.btnResetSerialDisplay.TabIndex = 16;
			this.btnResetSerialDisplay.Text = "Clear Console";
			this.btnResetSerialDisplay.UseVisualStyleBackColor = true;
			this.btnResetSerialDisplay.Click += new System.EventHandler(this.btnResetSerialDisplay_Click);
			// 
			// lblSerialOutputDebug
			// 
			this.lblSerialOutputDebug.AutoSize = true;
			this.lblSerialOutputDebug.Location = new System.Drawing.Point(15, 269);
			this.lblSerialOutputDebug.Name = "lblSerialOutputDebug";
			this.lblSerialOutputDebug.Size = new System.Drawing.Size(103, 13);
			this.lblSerialOutputDebug.TabIndex = 17;
			this.lblSerialOutputDebug.Text = "Serial Output Debug";
			// 
			// tmr_SendSerial
			// 
			this.tmr_SendSerial.Enabled = true;
			this.tmr_SendSerial.Interval = 50;
			this.tmr_SendSerial.Tick += new System.EventHandler(this.tmr_SendSerial_Tick);
			// 
			// txtQ1
			// 
			this.txtQ1.Location = new System.Drawing.Point(335, 249);
			this.txtQ1.Name = "txtQ1";
			this.txtQ1.Size = new System.Drawing.Size(152, 20);
			this.txtQ1.TabIndex = 18;
			// 
			// txtQ3
			// 
			this.txtQ3.Location = new System.Drawing.Point(335, 301);
			this.txtQ3.Name = "txtQ3";
			this.txtQ3.Size = new System.Drawing.Size(152, 20);
			this.txtQ3.TabIndex = 19;
			// 
			// txtQ2
			// 
			this.txtQ2.Location = new System.Drawing.Point(335, 275);
			this.txtQ2.Name = "txtQ2";
			this.txtQ2.Size = new System.Drawing.Size(152, 20);
			this.txtQ2.TabIndex = 20;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(306, 253);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(21, 13);
			this.label2.TabIndex = 21;
			this.label2.Text = "Q1";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(308, 279);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(21, 13);
			this.label3.TabIndex = 22;
			this.label3.Text = "Q2";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(308, 305);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(21, 13);
			this.label4.TabIndex = 23;
			this.label4.Text = "Q3";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(184, 306);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(14, 13);
			this.label5.TabIndex = 29;
			this.label5.Text = "Z";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(184, 280);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(14, 13);
			this.label6.TabIndex = 28;
			this.label6.Text = "Y";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(182, 254);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(14, 13);
			this.label7.TabIndex = 27;
			this.label7.Text = "X";
			// 
			// txtY
			// 
			this.txtY.Location = new System.Drawing.Point(211, 276);
			this.txtY.Name = "txtY";
			this.txtY.Size = new System.Drawing.Size(89, 20);
			this.txtY.TabIndex = 26;
			// 
			// txtZ
			// 
			this.txtZ.Location = new System.Drawing.Point(211, 302);
			this.txtZ.Name = "txtZ";
			this.txtZ.Size = new System.Drawing.Size(89, 20);
			this.txtZ.TabIndex = 25;
			// 
			// txtX
			// 
			this.txtX.Location = new System.Drawing.Point(211, 250);
			this.txtX.Name = "txtX";
			this.txtX.Size = new System.Drawing.Size(89, 20);
			this.txtX.TabIndex = 24;
			// 
			// btnSetArmPos
			// 
			this.btnSetArmPos.Location = new System.Drawing.Point(205, 328);
			this.btnSetArmPos.Name = "btnSetArmPos";
			this.btnSetArmPos.Size = new System.Drawing.Size(95, 23);
			this.btnSetArmPos.TabIndex = 30;
			this.btnSetArmPos.Text = "Set Arm Position";
			this.btnSetArmPos.UseVisualStyleBackColor = true;
			this.btnSetArmPos.Click += new System.EventHandler(this.btnSetArmPos_Click);
			// 
			// jerry5Form
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(499, 356);
			this.Controls.Add(this.btnSetArmPos);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.txtY);
			this.Controls.Add(this.txtZ);
			this.Controls.Add(this.txtX);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtQ2);
			this.Controls.Add(this.txtQ3);
			this.Controls.Add(this.txtQ1);
			this.Controls.Add(this.lblSerialOutputDebug);
			this.Controls.Add(this.btnResetSerialDisplay);
			this.Controls.Add(this.btnOpenCloseCutter);
			this.Controls.Add(this.btnOpenCloseGrip);
			this.Controls.Add(this.btnSendServoValues);
			this.Controls.Add(this.btnSendMotorValues);
			this.Controls.Add(this.btnSendMotorAndServoValues);
			this.Controls.Add(this.chkCutter);
			this.Controls.Add(this.chkGripper);
			this.Controls.Add(this.lblServo3);
			this.Controls.Add(this.lblServo2);
			this.Controls.Add(this.lblServo1);
			this.Controls.Add(this.lblMotorD);
			this.Controls.Add(this.lblMotorC);
			this.Controls.Add(this.lblMotorB);
			this.Controls.Add(this.lblMotorA);
			this.Controls.Add(this.txtServo3);
			this.Controls.Add(this.txtServo2);
			this.Controls.Add(this.txtServo1);
			this.Controls.Add(this.txtMotorD);
			this.Controls.Add(this.txtMotorC);
			this.Controls.Add(this.txtMotorB);
			this.Controls.Add(this.txtMotorA);
			this.Controls.Add(this.txtDebugSerialOut);
			this.Controls.Add(this.serialDisplay);
			this.Controls.Add(this.btnStopSerial);
			this.Controls.Add(this.btnStartSerial);
			this.Controls.Add(this.label1);
			this.Name = "jerry5Form";
			this.Text = "Jerry 5 Remote Interface";
			this.Load += new System.EventHandler(this.jerry5Form_Load);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.jerry5Form_FormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.IO.Ports.SerialPort serialArduino;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnStartSerial;
		private System.Windows.Forms.Button btnStopSerial;
		private System.Windows.Forms.TextBox serialDisplay;
		private System.Windows.Forms.TextBox txtDebugSerialOut;
		private System.Windows.Forms.TextBox txtMotorA;
		private System.Windows.Forms.TextBox txtMotorB;
		private System.Windows.Forms.TextBox txtMotorC;
		private System.Windows.Forms.TextBox txtMotorD;
		private System.Windows.Forms.TextBox txtServo1;
		private System.Windows.Forms.TextBox txtServo2;
		private System.Windows.Forms.TextBox txtServo3;
		private System.Windows.Forms.Label lblMotorA;
		private System.Windows.Forms.Label lblMotorB;
		private System.Windows.Forms.Label lblMotorC;
		private System.Windows.Forms.Label lblMotorD;
		private System.Windows.Forms.Label lblServo1;
		private System.Windows.Forms.Label lblServo2;
		private System.Windows.Forms.Label lblServo3;
		private System.Windows.Forms.CheckBox chkGripper;
		private System.Windows.Forms.CheckBox chkCutter;
		private System.Windows.Forms.Button btnSendMotorAndServoValues;
		private System.Windows.Forms.Button btnSendMotorValues;
		private System.Windows.Forms.Button btnSendServoValues;
		private System.Windows.Forms.Button btnOpenCloseGrip;
		private System.Windows.Forms.Button btnOpenCloseCutter;
		private System.Windows.Forms.Button btnResetSerialDisplay;
		private System.Windows.Forms.Label lblSerialOutputDebug;
		private System.Windows.Forms.Timer tmr_SendSerial;
		private System.Windows.Forms.TextBox txtQ1;
		private System.Windows.Forms.TextBox txtQ3;
		private System.Windows.Forms.TextBox txtQ2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtY;
		private System.Windows.Forms.TextBox txtZ;
		private System.Windows.Forms.TextBox txtX;
		private System.Windows.Forms.Button btnSetArmPos;
	}
}

