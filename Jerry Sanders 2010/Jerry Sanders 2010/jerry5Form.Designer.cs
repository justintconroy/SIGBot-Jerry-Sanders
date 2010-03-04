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
			this.btnSendMotorValues = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// serialArduino
			// 
			this.serialArduino.PortName = "COM41";
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
			this.serialDisplay.Size = new System.Drawing.Size(156, 153);
			this.serialDisplay.TabIndex = 12;
			this.serialDisplay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.serialDisplay_KeyPress);
			// 
			// txtDebugSerialOut
			// 
			this.txtDebugSerialOut.Location = new System.Drawing.Point(12, 213);
			this.txtDebugSerialOut.Name = "txtDebugSerialOut";
			this.txtDebugSerialOut.Size = new System.Drawing.Size(156, 20);
			this.txtDebugSerialOut.TabIndex = 14;
			// 
			// txtMotorA
			// 
			this.txtMotorA.Location = new System.Drawing.Point(224, 78);
			this.txtMotorA.Name = "txtMotorA";
			this.txtMotorA.Size = new System.Drawing.Size(50, 20);
			this.txtMotorA.TabIndex = 0;
			this.txtMotorA.Text = "-38";
			// 
			// txtMotorB
			// 
			this.txtMotorB.Location = new System.Drawing.Point(224, 104);
			this.txtMotorB.Name = "txtMotorB";
			this.txtMotorB.Size = new System.Drawing.Size(50, 20);
			this.txtMotorB.TabIndex = 1;
			this.txtMotorB.Text = "-37";
			// 
			// txtMotorC
			// 
			this.txtMotorC.Location = new System.Drawing.Point(224, 130);
			this.txtMotorC.Name = "txtMotorC";
			this.txtMotorC.Size = new System.Drawing.Size(50, 20);
			this.txtMotorC.TabIndex = 2;
			this.txtMotorC.Text = "-36";
			// 
			// txtMotorD
			// 
			this.txtMotorD.Location = new System.Drawing.Point(224, 156);
			this.txtMotorD.Name = "txtMotorD";
			this.txtMotorD.Size = new System.Drawing.Size(50, 20);
			this.txtMotorD.TabIndex = 3;
			this.txtMotorD.Text = "-35";
			// 
			// txtServo1
			// 
			this.txtServo1.Location = new System.Drawing.Point(334, 84);
			this.txtServo1.Name = "txtServo1";
			this.txtServo1.Size = new System.Drawing.Size(50, 20);
			this.txtServo1.TabIndex = 4;
			this.txtServo1.Text = "56";
			// 
			// txtServo2
			// 
			this.txtServo2.Location = new System.Drawing.Point(334, 110);
			this.txtServo2.Name = "txtServo2";
			this.txtServo2.Size = new System.Drawing.Size(50, 20);
			this.txtServo2.TabIndex = 5;
			this.txtServo2.Text = "57";
			// 
			// txtServo3
			// 
			this.txtServo3.Location = new System.Drawing.Point(334, 136);
			this.txtServo3.Name = "txtServo3";
			this.txtServo3.Size = new System.Drawing.Size(50, 20);
			this.txtServo3.TabIndex = 6;
			this.txtServo3.Text = "58";
			// 
			// lblMotorA
			// 
			this.lblMotorA.AutoSize = true;
			this.lblMotorA.Location = new System.Drawing.Point(174, 78);
			this.lblMotorA.Name = "lblMotorA";
			this.lblMotorA.Size = new System.Drawing.Size(44, 13);
			this.lblMotorA.TabIndex = 5;
			this.lblMotorA.Text = "Motor A";
			// 
			// lblMotorB
			// 
			this.lblMotorB.AutoSize = true;
			this.lblMotorB.Location = new System.Drawing.Point(174, 104);
			this.lblMotorB.Name = "lblMotorB";
			this.lblMotorB.Size = new System.Drawing.Size(44, 13);
			this.lblMotorB.TabIndex = 5;
			this.lblMotorB.Text = "Motor B";
			// 
			// lblMotorC
			// 
			this.lblMotorC.AutoSize = true;
			this.lblMotorC.Location = new System.Drawing.Point(174, 130);
			this.lblMotorC.Name = "lblMotorC";
			this.lblMotorC.Size = new System.Drawing.Size(44, 13);
			this.lblMotorC.TabIndex = 5;
			this.lblMotorC.Text = "Motor C";
			// 
			// lblMotorD
			// 
			this.lblMotorD.AutoSize = true;
			this.lblMotorD.Location = new System.Drawing.Point(174, 156);
			this.lblMotorD.Name = "lblMotorD";
			this.lblMotorD.Size = new System.Drawing.Size(45, 13);
			this.lblMotorD.TabIndex = 5;
			this.lblMotorD.Text = "Motor D";
			// 
			// lblServo1
			// 
			this.lblServo1.AutoSize = true;
			this.lblServo1.Location = new System.Drawing.Point(284, 81);
			this.lblServo1.Name = "lblServo1";
			this.lblServo1.Size = new System.Drawing.Size(42, 13);
			this.lblServo1.TabIndex = 5;
			this.lblServo1.Text = "servo 1";
			// 
			// lblServo2
			// 
			this.lblServo2.AutoSize = true;
			this.lblServo2.Location = new System.Drawing.Point(284, 107);
			this.lblServo2.Name = "lblServo2";
			this.lblServo2.Size = new System.Drawing.Size(42, 13);
			this.lblServo2.TabIndex = 5;
			this.lblServo2.Text = "servo 2";
			// 
			// lblServo3
			// 
			this.lblServo3.AutoSize = true;
			this.lblServo3.Location = new System.Drawing.Point(284, 133);
			this.lblServo3.Name = "lblServo3";
			this.lblServo3.Size = new System.Drawing.Size(42, 13);
			this.lblServo3.TabIndex = 5;
			this.lblServo3.Text = "servo 3";
			// 
			// chkGripper
			// 
			this.chkGripper.AutoSize = true;
			this.chkGripper.Location = new System.Drawing.Point(287, 159);
			this.chkGripper.Name = "chkGripper";
			this.chkGripper.Size = new System.Drawing.Size(60, 17);
			this.chkGripper.TabIndex = 7;
			this.chkGripper.Text = "Gripper";
			this.chkGripper.UseVisualStyleBackColor = true;
			// 
			// chkCutter
			// 
			this.chkCutter.AutoSize = true;
			this.chkCutter.Location = new System.Drawing.Point(353, 159);
			this.chkCutter.Name = "chkCutter";
			this.chkCutter.Size = new System.Drawing.Size(54, 17);
			this.chkCutter.TabIndex = 8;
			this.chkCutter.Text = "Cutter";
			this.chkCutter.UseVisualStyleBackColor = true;
			// 
			// btnSendMotorValues
			// 
			this.btnSendMotorValues.Location = new System.Drawing.Point(177, 184);
			this.btnSendMotorValues.Name = "btnSendMotorValues";
			this.btnSendMotorValues.Size = new System.Drawing.Size(106, 23);
			this.btnSendMotorValues.TabIndex = 9;
			this.btnSendMotorValues.Text = "Send Motor Values";
			this.btnSendMotorValues.UseVisualStyleBackColor = true;
			this.btnSendMotorValues.Click += new System.EventHandler(this.btnSendMotorValues_Click);
			// 
			// jerry5Form
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(499, 356);
			this.Controls.Add(this.btnSendMotorValues);
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
		private System.Windows.Forms.Button btnSendMotorValues;
	}
}

