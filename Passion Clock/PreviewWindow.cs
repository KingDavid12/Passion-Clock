using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Passion_Clock
{
	public partial class PreviewWindow : Form
	{
		/// <summary>
		/// The constructor
		/// </summary>
		public PreviewWindow()
		{
			// Basic control setup
			InitializeComponent();
			// Set the normal result
			DialogResult = DialogResult.None;

			// Load the settings manager
			var Settings = new UserSettings();
			// Load the settings into the controls
			ODays.Text = Settings.ODay;
			OHours.Value = Settings.OHour - (Settings.OHour > 12 ? 12 : 0);
			OMinutes.Value = Settings.OMinute;
			OPreview.Text = Settings.Preview ? "Yes" : "No";
			TimeSide.Text = Settings.OHour >= 12 ? "PM" : "AM";

			// Set the active control
			ActiveControl = ButtonOK;
		}

		/// <summary>
		/// The preview screen saver.
		/// </summary>
		private Process Screensaver;

		/// <summary>
		/// The function to be called when one of the offset values is changed.
		/// </summary>
		private void ValueChanged(object Sender, EventArgs E)
		{
		}

		/// <summary>
		/// The function to be called when they click OK.
		/// </summary>
		private void ButtonOk_Click(object sender, EventArgs e)
		{
			// Load the settings manager
			var Settings = new UserSettings();

			// Store all the values
			Settings.ODay = ODays.Text;
			Settings.OHour = (int)OHours.Value + (TimeSide.Text == "PM" ? 12 : 0);
			Settings.OMinute = (int)OMinutes.Value;
			Settings.Preview = OPreview.Text == "Yes";

			// Save the values
			Settings.Save();

			// Close this window
			Close();
		}

		/// <summary>
		/// The function to be called when they click Cancel.
		/// </summary>
		private void CancelButton_Click(object Sender, EventArgs E)
		{
			// Set the result
			DialogResult = DialogResult.Cancel;
			// Close the current window
			Close();
		}
	}
}