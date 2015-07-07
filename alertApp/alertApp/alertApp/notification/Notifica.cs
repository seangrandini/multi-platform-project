using System;
using System.Collections.Generic;
using System.Text;

namespace alertApp
{
    class Notifica
    {
		public string Title { get; set; }
		public string Text { get; set; }
		public string Data { get; set; }
		public string TextPreview { get; set; }
		public string TitlePreview { get; set; }
		public int Index { get; set; }

		public Notifica(string Title, string Text, string Data)
		{
			this.Title = Title;
			this.Text = Text;
			this.Data = Data;
			if (this.Text != null)
			{
				if (this.Text.Length > 50)
				{
					this.TextPreview = Text.Substring(0, 47);
					this.TextPreview += "...";
				}
				else
				{
					this.TextPreview = this.Text;
				}
			}
			else
			{
				this.TextPreview = "No description";
			}

			if (this.Title != null)
			{
				if (this.Title.Length > 50)
				{
					this.TitlePreview = Title.Substring(0, 47);
					this.TitlePreview += "...";
				}
				else
				{
					this.TitlePreview = this.Title;
				}
			}
			else
			{
				this.TitlePreview = "No title";
			}
		}
	}
}
