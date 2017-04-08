using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

namespace Passion_Clock
{
	public partial class MainWindow : Form
	{
		/// <summary>
		/// If we were given a handle to a preview window.
		/// </summary>
		/// <param name="PreviewHandle">The handle to the preview window.</param>
		public MainWindow(IntPtr PreviewHandle)
		{
			// Set the preview flag to true
			IsPreviewMode = true;

			// Basic control setup
			InitializeComponent();

			// Set the preview window to be our parent window
			SetParent(Handle, PreviewHandle);
			SetWindowLong(Handle, -16, new IntPtr(GetWindowLong(Handle, -16) | 0x40000000));

			// Get the size of the preview window
			GetClientRect(PreviewHandle, out var ParentRect);

			// Set our size to be the size of the preview window
			Size = ParentRect.Size;

			// Set our location to the top left corner
			Location = new Point(0, 0);
			
			// Run the timer setup function
			Init();
		}
		/// <summary>
		/// If we were given a rectangle matching a screen.
		/// </summary>
		/// <param name="Bounds">The bounds of one of the screens.</param>
		public MainWindow(Rectangle Bounds)
		{
			// Set the preview flag to false
			IsPreviewMode = false;

			InitializeComponent();
			// Set our location to the location of the given rectangle
			Location = Bounds.Location;
			// Set our size to the size of the given rectangle
			Size = Bounds.Size;

			// Run the timer setup function
			Init();
		}

		// DLL Imports.

		[DllImport("user32.dll")]
		static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

		[DllImport("user32.dll")]
		static extern int SetWindowLong(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

		[DllImport("user32.dll", SetLastError = true)]
		static extern int GetWindowLong(IntPtr hWnd, int nIndex);

		[DllImport("user32.dll")]
		static extern bool GetClientRect(IntPtr hWnd, out Rectangle lpRect);

		/// <summary>
		/// Make the preview window not steal focus
		/// </summary>
		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams BaseParams = base.CreateParams;

				if (IsPreviewMode)
				{
					const int WS_EX_NOACTIVATE = 0x08000000;
					const int WS_EX_TOOLWINDOW = 0x00000080;

					BaseParams.ExStyle |= (WS_EX_NOACTIVATE | WS_EX_TOOLWINDOW);
				}

				return (BaseParams);
			}
		}

		/// <summary>
		/// Stores true if the screen saver is being previewed.
		/// </summary>
		public bool IsPreviewMode = false;
		/// <summary>
		/// The position of the cursor when the screen saver starts.
		/// </summary>
		public Point Start = Cursor.Position;

		/// <summary>
		/// Loads the text for the slots.
		/// </summary>
		public static string[] Content = ReadItems().Replace("\r", "").Replace("#", "\n").Split(new string[] { "\n\n" }, StringSplitOptions.RemoveEmptyEntries);

		/// <summary>
		/// Setup the list of slots to be displayed.
		/// </summary>
		public static List<Slot> Slots = new List<Slot>()
		{
			new Slot(Content[0], Content[1], ReadImage("P1"), 18, 0, DayOfWeek.Thursday),
			new Slot(Content[0], Content[1], ReadImage("P2"), 18, 30, DayOfWeek.Thursday),

			new Slot(Content[2], Content[3], ReadImage("P3"), 19, 0, DayOfWeek.Thursday),

			new Slot(Content[4], Content[5], ReadImage("P4"), 20, 0, DayOfWeek.Thursday),
			new Slot(Content[4], Content[5], ReadImage("P5"), 20, 30, DayOfWeek.Thursday),

			new Slot(Content[6], Content[7], ReadImage("P6"), 21, 0, DayOfWeek.Thursday),
			new Slot(Content[6], Content[7], ReadImage("P7"), 21, 30, DayOfWeek.Thursday),

			new Slot(Content[8], Content[9], ReadImage("P8"), 22, 0, DayOfWeek.Thursday),

			new Slot(Content[10], Content[11], ReadImage("P9"), 23, 0, DayOfWeek.Thursday),
			new Slot(Content[10], Content[11], ReadImage("P10"), 23, 30, DayOfWeek.Thursday),

			new Slot(Content[12], Content[13], ReadImage("P11"), 0, 0, DayOfWeek.Friday),

			new Slot(Content[14], Content[15], ReadImage("P12"), 1, 0, DayOfWeek.Friday),
			new Slot(Content[14], Content[15], ReadImage("P13"), 1, 30, DayOfWeek.Friday),

			new Slot(Content[16], Content[17], ReadImage("P14"), 2, 0, DayOfWeek.Friday),

			new Slot(Content[18], Content[19], ReadImage("P15"), 3, 0, DayOfWeek.Friday),

			new Slot(Content[20], Content[21], ReadImage("P16"), 4, 0, DayOfWeek.Friday),

			new Slot(Content[22], Content[23], ReadImage("P17"), 5, 0, DayOfWeek.Friday),

			new Slot(Content[24], Content[25], ReadImage("P18"), 6, 0, DayOfWeek.Friday),

			new Slot(Content[26], Content[27], ReadImage("P19"), 7, 0, DayOfWeek.Friday),

			new Slot(Content[28], Content[29], ReadImage("P20"), 8, 0, DayOfWeek.Friday),

			new Slot(Content[30], Content[31], ReadImage("P21"), 9, 0, DayOfWeek.Friday),

			new Slot(Content[32], Content[33], ReadImage("P22"), 10, 0, DayOfWeek.Friday),

			new Slot(Content[34], Content[35], ReadImage("P23"), 11, 0, DayOfWeek.Friday),

			new Slot(Content[36], Content[37], ReadImage("P24"), 12, 0, DayOfWeek.Friday),

			new Slot(Content[38], Content[39], ReadImage("P25"), 13, 0, DayOfWeek.Friday),

			new Slot(Content[40], Content[41], ReadImage("P26"), 14, 0, DayOfWeek.Friday),

			new Slot(Content[42], Content[43], ReadImage("P27"), 15, 0, DayOfWeek.Friday),

			new Slot(Content[44], Content[45], ReadImage("P28"), 16, 0, DayOfWeek.Friday),

			new Slot(Content[46], Content[47], ReadImage("P29"), 17, 0, DayOfWeek.Friday),

			new Slot(Content[48], Content[49], ReadImage("P30"), 18, 0, DayOfWeek.Friday)
		};


		/// <summary>
		/// Calculates what date easter Sunday falls on for a given year.
		/// </summary>
		/// <param name="Year">The year to find easter in.</param>
		/// <returns>The date easter Sunday falls on for the given year.</returns>
		public static DateTime EasterSunday(int Year)
		{
			// I did not come up with this formula.
			// Credit goes to the accepted answer at: http://stackoverflow.com/questions/2510383/how-can-i-calculate-what-date-good-friday-falls-on-given-a-year

			int Day = 0;
			int Month = 0;
			int LunarCycle = Year % 19;
			int Century = Year / 100;
			int CycleMonth = (Century - Century / 4 - (8 * Century + 13) / 25 + 19 * LunarCycle + 15) % 30;
			int FullMoon = CycleMonth - CycleMonth / 28 * (1 - CycleMonth / 28 * (29 / (CycleMonth + 1)) * ((21 - LunarCycle) / 11));

			Day = FullMoon - ((Year + Year / 4 + FullMoon + 2 - Century + Century / 4) % 7) + 28;
			Month = 3;

			if (Day > 31)
			{
				Month++;
				Day -= 31;
			}

			return (new DateTime(Year, Month, Day));
		}

		/// <summary>
		/// Offsets for preview days.
		/// </summary>
		public static Dictionary<string, int> TridDayOffset = new Dictionary<string, int>()
		{
			["Holy Thursday"] = -3,
			["Good Friday"] = -2,
			["Holy Saturday"] = -1
		};


		/// <summary>
		/// A private cache for storing text sizes for the slots.
		/// </summary>
		private Dictionary<string, float> FontMap = new Dictionary<string, float>();

		/// <summary>
		/// Finds the best possible font size for the text on the given label.
		/// </summary>
		/// <param name="Label">The label to check.</param>
		public void FindScaleFont(Label Label)
		{
			// If it does not contain any text stop.
			if (Label.Text == null || Label.Text == "")
			{
				return;
			}

			// If the cache does not contain the label's text.
			if (!FontMap.ContainsKey(Label.Text))
			{
				// Find the height of the label minus about 0.9%
				float Height = Label.Height - ((10.0F / 1080.0F) * this.Height);
				// Find the width of the label
				float Width = Label.Width;
				// Find the labels current font size
				float Size = Label.Font.Size;

				// Create a graphics object for the window
				var Graphics = CreateGraphics();
				// Measure how much space the text wants with the current font size
				SizeF TempSize = Graphics.MeasureString(Label.Text, Label.Font, (int)Math.Ceiling(Width));

				// While the height is less than the height of the label
				while (TempSize.Height < Height)
				{
					// Make the size bigger by 0.5 points.
					Size += 0.5F;
					TempSize = Graphics.MeasureString(Label.Text, new Font(Label.Font.FontFamily, Size), (int)Math.Ceiling(Width));
				}
				// While the height is greater than or equal to the height of the label
				while (TempSize.Height >= Height)
				{
					// Shrink the font size by 0.5 points.
					Size -= 0.5F;
					TempSize = Graphics.MeasureString(Label.Text, new Font(Label.Font.FontFamily, Size), (int)Math.Ceiling(Width));
				}

				// Store the text and size in the cache.
				FontMap[Label.Text] = Size;
			}

			// Stop the label from redrawing.
			Label.SuspendLayout();
			// Set the font to be the cached font size.
			Label.Font = new Font(Label.Font.FontFamily, FontMap[Label.Text]);

			// Find the padding amount.
			int Amount = (int)Math.Round(100.0 / 1920.0 * this.Width, MidpointRounding.AwayFromZero);

			// Set the padding.
			Label.Padding = new Padding(Amount, 0, Amount, 0);
			// Allow the label to redraw.
			Label.ResumeLayout();
		}

		/// <summary>
		/// The timer setup function.
		/// </summary>
		public void Init()
		{
			// Load the settings manager
			var Settings = new UserSettings();
			// If the settings want a preview
			if (Settings.Preview)
			{
				// Setup the offset from the settings
				Offset = EasterSunday(DateTime.Now.Year) - DateTime.Now;

				Offset += TimeSpan.FromDays(TridDayOffset[Settings.ODay]);
				Offset += TimeSpan.FromHours(Settings.OHour);
				Offset += TimeSpan.FromMinutes(Settings.OMinute + 1);
			}

			// Create a new timer
			var Updater = new Timer();

			// Make it run every second
			Updater.Interval = 1000;
			// Make it call the tick function every second
			Updater.Tick += Tick;
			// Start the timer
			Updater.Start();

			// If we are running normally hide the cursor
			if (!IsPreviewMode)
			{
				Cursor.Hide();
			}

			// Call the tick function
			Tick(null, null);
		}

		/// <summary>
		/// Offset used for debugging the program ahead of time.
		/// </summary>
		public TimeSpan Offset = new TimeSpan(0, 0, 0, 0);
		/// <summary>
		/// The currently displayed slot.
		/// </summary>
		public Slot CurrentSlot = null;

		/// <summary>
		/// The tick function to be called every second.
		/// </summary>
		private void Tick(object Sender, EventArgs E)
		{
			// Finds easter Sunday for the current year
			var Easter = EasterSunday(DateTime.Now.Year);
			// The current date plus the offset
			var Now = DateTime.Now.AddDays(Offset.Days).AddHours(Offset.Hours).AddMinutes(Offset.Minutes);

			// Clears the display items
			void ClearItems()
			{
				SlotDescription.Text = "";
				SlotPrayer.Text = "";
				SlotPicture.Image = null;
			}
			// Sets up the font size for the two labels
			void SetupFont()
			{
				if (SlotPrayer.Text == "")
				{
					SlotPrayer.Height = 0;
				}
				if (SlotPrayer.Text != "")
				{
					SlotDescription.Height = (int)Math.Round(15.0 / 112.0 * Height, MidpointRounding.AwayFromZero); // 15 : 112
					SlotPrayer.Height = (int)Math.Round(25.0 / 152.0 * Height, MidpointRounding.AwayFromZero); // 25 : 152
				}
				else
				{
					SlotDescription.Height = (int)Math.Round(25.0 / 152.0 * Height, MidpointRounding.AwayFromZero); // 25 : 152
				}

				FindScaleFont(SlotDescription);
				FindScaleFont(SlotPrayer);
			}

			// If we are before the triduum 
			if (Now < Easter - TimeSpan.FromDays(3))
			{
				// Clear the display
				ClearItems();
				// Setup the description text
				SlotDescription.Text = Content[50];
				// Load the Jesus preaching image
				SlotPicture.Image = ReadImage("Jesus Preaching");
				// Setup the font
				SetupFont();
			}
			// If we are in easter season
			else if (Now >= Easter && Now <= Easter + TimeSpan.FromDays(50))
			{
				// Clear the display
				ClearItems();
				// Setup the description
				SlotDescription.Text = Content[51];
				// Load the Jesus Risen picture
				SlotPicture.Image = ReadImage("Jesus Risen");
				// Setup the font
				SetupFont();
			}
			// Otherwise if we are in the triduum
			else
			{
				// If today is Saturday
				if (Now.DayOfWeek == DayOfWeek.Saturday)
				{
					// Clear the display
					ClearItems();
					// Setup the description
					SlotDescription.Text = Content[52];
					// Load the Apostles Hiding picture
					SlotPicture.Image = ReadImage("Jesus - Apostles Hiding");
					// Setup the font
					SetupFont();
				}
				// If today is Friday and we at or after seven o'clock PM
				else if (Now.DayOfWeek == DayOfWeek.Friday && Now.Hour >= 19)
				{
					// Load the last slot
					var Item = Slots[Slots.Count - 1];

					// Set the description to the slot's description
					SlotDescription.Text = Item.Description;
					// Set the prayer to the slot's prayer
					SlotPrayer.Text = Item.Prayer;
					// Set the image to the slot's image
					SlotPicture.Image = Item.Image;
					// Setup the font
					SetupFont();
				}
				// Otherwise
				else
				{
					// Load the last slot where the day of week matches today
					// and the hour matches the current hour
					// and the current minute is greater than equal to the slot's minute.
					var Item = Slots.LastOrDefault(Slot => Slot.Day == Now.DayOfWeek && Slot.Hour == Now.Hour && Now.Minute >= Slot.Minute);

					// If there is such a slot and it is not the slot already being displayed
					if (Item != null && Item != CurrentSlot)
					{
						// Set the description to the slot's description
						SlotDescription.Text = Item.Description;
						// Set the prayer to the slot's prayer
						SlotPrayer.Text = Item.Prayer;
						// Set the image to the slot's image
						SlotPicture.Image = Item.Image;
						// Setup the font
						SetupFont();
						// Set the currently displayed slot the one we just loaded
						CurrentSlot = Item;
					}
					// If something goes wrong and there is no such slot
					else if (Item == null)
					{
						// Clear the screen
						ClearItems();
						// Setup the description
						SlotDescription.Text = Content[50];
						// Load the Jesus Preaching image
						SlotPicture.Image = ReadImage("Jesus Preaching");
						// Setup the font
						SetupFont();
					}
				}
			}	
		}

		/// <summary>
		/// When the user presses a key and we are not in preview mode, close the program.
		/// </summary>
		private void MainWindow_KeyDown(object Sender, KeyEventArgs E)
		{
			if (!IsPreviewMode)
			{
				Application.Exit();
			}
		}
		/// <summary>
		/// If the user switches away from the screen saver and we are not in preview mode, close the program.
		/// </summary>
		private void MainWindow_Deactivate(object Sender, EventArgs E)
		{
			if (!IsPreviewMode)
			{
				Application.Exit();
			}
		}
		/// <summary>
		/// When the user clicks the mouse button and we are not in preview mode, close the program.
		/// </summary>
		private void MainWindow_MouseDown(object Sender, MouseEventArgs E)
		{
			if (!IsPreviewMode)
			{
				Application.Exit();
			}
		}
		/// <summary>
		/// When the user moves the mouse and we are not in preview mode, close the program.
		/// </summary>
		private void MainWindow_MouseMove(object Sender, MouseEventArgs E)
		{
			if (!IsPreviewMode && Cursor.Position.X != Start.X && Cursor.Position.Y != Start.Y)
			{
				Application.Exit();
			}
		}
		/// <summary>
		/// When a single window closes, close the program.
		/// </summary>
		private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
		{
			Application.Exit();
		}

		/// <summary>
		/// Reads an image from the embedded pictures with the given name.
		/// </summary>
		/// <param name="Name">The name of the picture to load.</param>
		/// <returns>The picture with the given name.</returns>
		public static Bitmap ReadImage(string Name)
		{
			// Load the running program
			var Assembly = System.Reflection.Assembly.GetExecutingAssembly();

			// Open a stream to the file
			using (Stream Stream = Assembly.GetManifestResourceStream("Passion_Clock.Resources." + Name + ".jpg"))
			{
				// Return a bitmap image created from the stream
				return (new Bitmap(Stream));
			}
		}
		/// <summary>
		/// Reads the list of text parts for the screen saver.
		/// </summary>
		/// <returns>The list of text parts for the screen saver.</returns>
		public static string ReadItems()
		{
			// Load the running program
			var Assembly = System.Reflection.Assembly.GetExecutingAssembly();

			// Open a stream to the text file
			using (Stream Stream = Assembly.GetManifestResourceStream("Passion_Clock.Resources.Text.txt"))
			// Read the text from the stream and return it
			using (StreamReader Sr = new StreamReader(Stream, Encoding.UTF8))
			{
				return (Sr.ReadToEnd());
			}
		}
	}
}