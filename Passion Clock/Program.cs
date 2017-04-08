using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Passion_Clock
{
	static class Program
	{
		private const int SW_SHOWNOACTIVATE = 4;

		[DllImport("user32.dll")]
		static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

		[STAThread]
		public static void Main(string[] Args)
		{
			// If we were given any arguments

			if (Args.Length > 0)
			{
				// If the argument is /S then show the screen saver

				if (Args[0].ToLower().Trim().Substring(0, 2).ToUpper () == "/S")
				{
					ShowScreenSaver();
				}

				// If the argument is /P then fetch the handle for the preview window

				else if (Args[0].ToLower().Trim().Substring(0, 2).ToUpper () == "/P")
				{
					Application.Run(new MainWindow(new IntPtr(long.Parse(Args[1]))));
				}

				// If the argument is /C show the settings window.

				else if (Args[0].ToLower().Trim().Substring(0, 2).ToUpper () == "/C")
				{
					Application.Run(new PreviewWindow());
				}

				// Otherwise show the screen saver

				else
				{
					ShowScreenSaver();
				}
			}

			// Otherwise show the screen saver

			else
			{
				ShowScreenSaver();
			}
		}

		/// <summary>
		/// Shows the screen saver.
		/// </summary>
		public static void ShowScreenSaver()
		{
			// Enable fancy styles.
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			// Loop through all screens and display the screen saver on each screen.

			foreach (Screen Screen in Screen.AllScreens)
			{
				Form ScreenSaver = new MainWindow(Screen.Bounds);
				ScreenSaver.Show();
			}

			Application.Run();
		}
	}
}