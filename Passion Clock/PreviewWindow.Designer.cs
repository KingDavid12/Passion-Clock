namespace Passion_Clock
{
	partial class PreviewWindow
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
			this.Label1 = new System.Windows.Forms.Label();
			this.OHours = new System.Windows.Forms.NumericUpDown();
			this.OMinutes = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.ButtonCancel = new System.Windows.Forms.Button();
			this.ButtonOK = new System.Windows.Forms.Button();
			this.ODays = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.OPreview = new System.Windows.Forms.ComboBox();
			this.TimeSide = new System.Windows.Forms.ComboBox();
			((System.ComponentModel.ISupportInitialize)(this.OHours)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.OMinutes)).BeginInit();
			this.SuspendLayout();
			// 
			// Label1
			// 
			this.Label1.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label1.Location = new System.Drawing.Point(20, 20);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(300, 60);
			this.Label1.TabIndex = 1;
			this.Label1.Text = "Select a triddum day and time to preview:";
			// 
			// OHours
			// 
			this.OHours.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.OHours.Location = new System.Drawing.Point(160, 180);
			this.OHours.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
			this.OHours.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.OHours.Name = "OHours";
			this.OHours.Size = new System.Drawing.Size(160, 29);
			this.OHours.TabIndex = 1;
			this.OHours.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
			this.OHours.ValueChanged += new System.EventHandler(this.ValueChanged);
			// 
			// OMinutes
			// 
			this.OMinutes.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.OMinutes.Location = new System.Drawing.Point(160, 220);
			this.OMinutes.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
			this.OMinutes.Name = "OMinutes";
			this.OMinutes.Size = new System.Drawing.Size(160, 29);
			this.OMinutes.TabIndex = 2;
			this.OMinutes.ValueChanged += new System.EventHandler(this.ValueChanged);
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(20, 140);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 5;
			this.label2.Text = "Day:";
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(20, 180);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 23);
			this.label3.TabIndex = 6;
			this.label3.Text = "Hour:";
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(20, 220);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 23);
			this.label4.TabIndex = 7;
			this.label4.Text = "Minute:";
			// 
			// ButtonCancel
			// 
			this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.ButtonCancel.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ButtonCancel.Location = new System.Drawing.Point(280, 280);
			this.ButtonCancel.Name = "ButtonCancel";
			this.ButtonCancel.Size = new System.Drawing.Size(100, 40);
			this.ButtonCancel.TabIndex = 4;
			this.ButtonCancel.Text = "Cancel";
			this.ButtonCancel.UseVisualStyleBackColor = true;
			this.ButtonCancel.Click += new System.EventHandler(this.CancelButton_Click);
			// 
			// ButtonOK
			// 
			this.ButtonOK.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ButtonOK.Location = new System.Drawing.Point(140, 280);
			this.ButtonOK.Name = "ButtonOK";
			this.ButtonOK.Size = new System.Drawing.Size(100, 40);
			this.ButtonOK.TabIndex = 3;
			this.ButtonOK.Text = "OK";
			this.ButtonOK.UseVisualStyleBackColor = true;
			this.ButtonOK.Click += new System.EventHandler(this.ButtonOk_Click);
			// 
			// ODays
			// 
			this.ODays.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ODays.FormattingEnabled = true;
			this.ODays.Items.AddRange(new object[] {
            "Holy Thursday",
            "Good Friday",
            "Holy Saturday",
            "Easter Sunday"});
			this.ODays.Location = new System.Drawing.Point(160, 140);
			this.ODays.Name = "ODays";
			this.ODays.Size = new System.Drawing.Size(160, 31);
			this.ODays.TabIndex = 0;
			this.ODays.Text = "Holy Thursday";
			this.ODays.SelectedIndexChanged += new System.EventHandler(this.ValueChanged);
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(20, 100);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(140, 23);
			this.label5.TabIndex = 8;
			this.label5.Text = "Preview Mode:";
			// 
			// OPreview
			// 
			this.OPreview.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.OPreview.FormattingEnabled = true;
			this.OPreview.Items.AddRange(new object[] {
            "Yes",
            "No"});
			this.OPreview.Location = new System.Drawing.Point(160, 100);
			this.OPreview.Name = "OPreview";
			this.OPreview.Size = new System.Drawing.Size(160, 31);
			this.OPreview.TabIndex = 9;
			this.OPreview.Text = "No";
			// 
			// TimeSide
			// 
			this.TimeSide.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TimeSide.FormattingEnabled = true;
			this.TimeSide.Items.AddRange(new object[] {
            "AM",
            "PM"});
			this.TimeSide.Location = new System.Drawing.Point(340, 180);
			this.TimeSide.Name = "TimeSide";
			this.TimeSide.Size = new System.Drawing.Size(60, 31);
			this.TimeSide.TabIndex = 10;
			this.TimeSide.Text = "PM";
			this.TimeSide.SelectedIndexChanged += new System.EventHandler(this.ValueChanged);
			// 
			// PreviewWindow
			// 
			this.AcceptButton = this.ButtonOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.ButtonCancel;
			this.ClientSize = new System.Drawing.Size(422, 338);
			this.Controls.Add(this.TimeSide);
			this.Controls.Add(this.OPreview);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.ODays);
			this.Controls.Add(this.OHours);
			this.Controls.Add(this.ButtonOK);
			this.Controls.Add(this.ButtonCancel);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.OMinutes);
			this.Controls.Add(this.Label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "PreviewWindow";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Passion Clock Settings";
			((System.ComponentModel.ISupportInitialize)(this.OHours)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.OMinutes)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Label Label1;
		private System.Windows.Forms.NumericUpDown OHours;
		private System.Windows.Forms.NumericUpDown OMinutes;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button ButtonCancel;
		private System.Windows.Forms.Button ButtonOK;
		private System.Windows.Forms.ComboBox ODays;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox OPreview;
		private System.Windows.Forms.ComboBox TimeSide;
	}
}