using System;
using System.Collections.Generic;
using System.Text;

using SQLite;

namespace alertApp
{
    public class NotificationItem
    {
		public NotificationItem() { }
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		public string Name { get; set; }

		public string Title { get; set; }
		public string Text { get; set; }
		public string Data { get; set; }

		public string Notes { get; set; }

		public bool Done { get; set; }
	}
}
