using System;
using System.Drawing;

namespace Passion_Clock
{
	/// <summary>
	/// A wrapper class for holding a description, a prayer, an image and a time.
	/// </summary>
	public class Slot
	{
		public Slot(string Description, string Prayer, Bitmap Image, int Hour, int Minute, DayOfWeek Day)
		{
			this.Description = Prepare(Description);
			this.Prayer = Prepare(Prayer);
			this.Image = Image;
			this.Hour = Hour;
			this.Minute = Minute;
			this.Day = Day;
		}

		/// <summary>
		/// Strips all formatting from a string and reformats it for display.
		/// </summary>
		/// <param name="Input">The string to prepare.</param>
		/// <returns>The correctly formatted string.</returns>
		private static string Prepare(string Input)
		{
			return (Input
				.Replace("\r", "")
				.Replace("\n", " ")
				.Replace(".", ".\n")
				.Replace("!", "!\n")
				.Replace("?", "?\n")
				.Replace("\n@", "")
				.Replace("@", "")
				.Replace("  ", " ")
				.Replace("\n”", "”\n")
				.Trim('\n')
			);
		}

		/// <summary>
		/// The day of the week for this slot.
		/// </summary>
		public DayOfWeek Day;
		/// <summary>
		/// The description of this slot.
		/// </summary>
		public string Description;
		/// <summary>
		/// The prayer for this slot.
		/// </summary>
		public string Prayer;
		/// <summary>
		/// The picture for this slot.
		/// </summary>
		public Bitmap Image;

		/// <summary>
		/// The backing field for the hour property.
		/// </summary>
		private int _Hour;
		/// <summary>
		/// The hour for this slot.
		/// </summary>
		public int Hour
		{
			get
			{
				return (_Hour);
			}
			set
			{
				if(value < 0 || value > 24)
				{
					throw (new ArgumentOutOfRangeException("The Hour most be between 0 and 23!"));
				}

				_Hour = value;
			}
		}

		/// <summary>
		/// The backing field for the minute property.
		/// </summary>
		private int _Minute;
		/// <summary>
		/// The minute for this slot.
		/// </summary>
		public int Minute
		{
			get
			{
				return (_Minute);
			}
			set
			{
				if(value < 0 || value > 59)
				{
					throw (new ArgumentOutOfRangeException("The minute must be between 0 and 59!"));
				}

				_Minute = value;
			}
		}
	}
}