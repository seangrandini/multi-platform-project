using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace alertApp
{
    class NotificationHistory
    {

		public ObservableCollection<Notifica> notifactionList { get; set; }
		public ObservableCollection<Notifica> reverseNotificationList { get; set; }
        public int notificationNumber = 0;
		public int maxNotification;

		private NotificationItemDatabase notificationDatabase;
		public NotificationHistory()
		{
			this.notifactionList = new ObservableCollection<Notifica>();
			this.reverseNotificationList = new ObservableCollection<Notifica>();
			this.notificationDatabase = new NotificationItemDatabase();
			this.maxNotification = sharedLogic.notificationSaveNumber;
			this.notifactionList.CollectionChanged += NotifactionList_CollectionChanged;
		}

		private void NotifactionList_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			InvertNotificationList();
        }

		public void Append(string Title, string Text)
		{
			Notifica notifica = new Notifica(Title, Text, DateTime.Now.ToString("dd MMM HH:mm:ss"));
			if (IsFull())
			{
				this.notifactionList.RemoveAt(0);
				this.notifactionList.Add(notifica);
				SaveOnDatabase(notifica);
				ReIndexDatabase();
            }
			else
			{
				notifica.Index = this.notificationNumber;
				this.notifactionList.Add(notifica);
				this.notificationNumber++;
				SaveOnDatabase(notifica);
			}
		}
		public void Append(Notifica notifica)
		{
			if (IsFull())
			{
				this.notifactionList.RemoveAt(0);
				this.notifactionList.Add(notifica);
				SaveOnDatabase(notifica);
				ReIndexDatabase();
            }
			else
			{
				notifica.Index = this.notificationNumber;
				this.notifactionList.Add(notifica);
				this.notificationNumber++;
				SaveOnDatabase(notifica);
			}
		}
		public void Clear()
		{
			this.notificationDatabase.DeleteAllItems();
			this.notifactionList.Clear();
			this.notificationNumber = 0;
		}
		public void LoadFromDatabase()
		{
			NotificationItem singleNotification = new NotificationItem();

			if (!this.notificationDatabase.IsEmpty())
			{
				int size = this.notificationDatabase.length();
                for (int i = 1; i <= size; i++)
				{
					if (this.notificationNumber >= this.maxNotification)
					{
						this.notifactionList.RemoveAt(0);
						singleNotification = this.notificationDatabase.GetItem(i);
						Notifica notifica = new Notifica(singleNotification.Title, singleNotification.Text, singleNotification.Data);
						this.notifactionList.Add(notifica);
					}
					else
					{
						singleNotification = this.notificationDatabase.GetItem(i);
						if (singleNotification != null)
						{
							Notifica notifica = new Notifica(singleNotification.Title, singleNotification.Text, singleNotification.Data);
							this.notifactionList.Add(notifica);
							this.notificationNumber++;
						}
					}
				}
				ReIndexDatabase();
            }
		}
		public void SaveOnDatabase(Notifica notifica)
		{
			if (IsFull())
			{
				this.notificationDatabase.MoveAllDown();
			}
			NotificationItem notificationItem = new NotificationItem();
			notificationItem.ID = this.notificationNumber;
			notificationItem.Name = "notifica" + this.notificationNumber;
			notificationItem.Title = notifica.Title;
			notificationItem.Text = notifica.Text;
			notificationItem.Data = notifica.Data;
			this.notificationDatabase.SaveItem(notificationItem);
        }
		public bool IsFull()
		{
			if (this.notificationNumber >= this.maxNotification)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public void ReIndexDatabase()
		{
			for (int i = 0; i < this.notificationNumber; i++)
			{
				if (this.notifactionList[i] != null)
				{
					this.notifactionList[i].Index = i;
				}
			}
		}

		public void DeleteAt(int Index)
		{
			Notifica notifica;
			int size = this.notificationNumber-1;
			for (int i = 0; i <= size; i++)
			{
				if (i != size)
				{
					notifica = this.notifactionList[i + 1];
					this.notifactionList[i] = notifica;
				}
				else
				{
					this.notifactionList.RemoveAt(i);
					this.notificationNumber--;
				}
            }
			ReIndexDatabase();
			this.notificationDatabase.DeleteAt(Index + 1);
		}

		public void InvertNotificationList()
		{
			this.reverseNotificationList.Clear();

			for (int i = 0; i < this.notificationNumber; i++)
			{
				this.reverseNotificationList.Add(this.notifactionList[this.notificationNumber-i]);
			}

		}

		/*public void MyCollectionChanged()
		{
			if (sharedLogic.notifications.notificationNumber > 0)
			{
				mainPage.notificationList.ScrollTo(sharedLogic.notifications.notifactionList[sharedLogic.notifications.notificationNumber - 1], ScrollToPosition.End, false);
			}
		}*/
	}
}
