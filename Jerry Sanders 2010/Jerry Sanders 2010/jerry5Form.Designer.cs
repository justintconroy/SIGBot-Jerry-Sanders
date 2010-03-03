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
			this.btnStartSerial.TabIndex = 1;
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
			this.btnStopSerial.TabIndex = 1;
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
			this.serialDisplay.TabIndex = 2;
			this.serialDisplay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.serialDisplay_KeyPress);
			// 
			// jerry5Form
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(499, 356);
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
	}
}

