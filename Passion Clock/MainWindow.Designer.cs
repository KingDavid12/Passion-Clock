namespace Passion_Clock
{
	partial class MainWindow
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
			this.SlotPicture = new System.Windows.Forms.PictureBox();
			this.SlotDescription = new System.Windows.Forms.Label();
			this.SlotPrayer = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.SlotPicture)).BeginInit();
			this.SuspendLayout();
			// 
			// SlotPicture
			// 
			this.SlotPicture.BackColor = System.Drawing.Color.Black;
			this.SlotPicture.Dock = System.Windows.Forms.DockStyle.Fill;
			this.SlotPicture.Location = new System.Drawing.Point(0, 0);
			this.SlotPicture.Name = "SlotPicture";
			this.SlotPicture.Size = new System.Drawing.Size(1192, 760);
			this.SlotPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.SlotPicture.TabIndex = 0;
			this.SlotPicture.TabStop = false;
			this.SlotPicture.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainWindow_MouseDown);
			this.SlotPicture.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainWindow_MouseMove);
			// 
			// SlotDescription
			// 
			this.SlotDescription.Dock = System.Windows.Forms.DockStyle.Top;
			this.SlotDescription.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.SlotDescription.ForeColor = System.Drawing.Color.White;
			this.SlotDescription.Location = new System.Drawing.Point(0, 0);
			this.SlotDescription.Margin = new System.Windows.Forms.Padding(0);
			this.SlotDescription.Name = "SlotDescription";
			this.SlotDescription.Padding = new System.Windows.Forms.Padding(100, 0, 100, 0);
			this.SlotDescription.Size = new System.Drawing.Size(1192, 114);
			this.SlotDescription.TabIndex = 1;
			this.SlotDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.SlotDescription.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainWindow_MouseDown);
			this.SlotDescription.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainWindow_MouseMove);
			// 
			// SlotPrayer
			// 
			this.SlotPrayer.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.SlotPrayer.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.SlotPrayer.ForeColor = System.Drawing.Color.White;
			this.SlotPrayer.Location = new System.Drawing.Point(0, 587);
			this.SlotPrayer.Margin = new System.Windows.Forms.Padding(0);
			this.SlotPrayer.Name = "SlotPrayer";
			this.SlotPrayer.Padding = new System.Windows.Forms.Padding(100, 0, 100, 0);
			this.SlotPrayer.Size = new System.Drawing.Size(1192, 173);
			this.SlotPrayer.TabIndex = 2;
			this.SlotPrayer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.SlotPrayer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainWindow_MouseDown);
			this.SlotPrayer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainWindow_MouseMove);
			// 
			// MainWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(1192, 760);
			this.Controls.Add(this.SlotPrayer);
			this.Controls.Add(this.SlotDescription);
			this.Controls.Add(this.SlotPicture);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "MainWindow";
			this.ShowIcon = false;
			this.Text = "MainWindow";
			this.Deactivate += new System.EventHandler(this.MainWindow_Deactivate);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainWindow_FormClosed);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainWindow_MouseDown);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainWindow_MouseMove);
			((System.ComponentModel.ISupportInitialize)(this.SlotPicture)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox SlotPicture;
		private System.Windows.Forms.Label SlotDescription;
		private System.Windows.Forms.Label SlotPrayer;
	}
}