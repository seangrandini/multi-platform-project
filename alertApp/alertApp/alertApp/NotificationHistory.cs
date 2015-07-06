using System;
using System.Collections.Generic;
using System.Text;

namespace alertApp
{
    class NotificationHistory
    {
		public List<Notifica> notifactionList;

		public int notificationNumber = 0;

		public NotificationHistory()
		{
			this.notifactionList = new List<Notifica>();
		}
		public void Append(string Title, string Text)
		{
			Notifica notif = new Notifica(Title, Text);
			this.notifactionList.Add(notif);
			this.notificationNumber++;
		}
		public void Append(Notifica notifica)
		{
			this.notifactionList.Add(notifica);
			this.notificationNumber++;
		}
    }
}
