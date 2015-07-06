using System;
using System.Collections.Generic;
using System.Text;

namespace alertApp
{
    class Notifica
    {
		public string Title { get; set; }
		public string Text { get; set; }

		public Notifica(string Title, string Text)
		{
			this.Title = Title;
			this.Text = Text;
		}
	}
}
