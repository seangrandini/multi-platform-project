using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using SQLite;
#if __ANDROID__
#elif __IOS__
#else
using Windows.Storage;
#endif

namespace alertApp
{
    public class NotificationItemDatabase
    {
		static object locker = new object();
		SQLiteConnection database;
		string DatabasePath
		{
			get
			{
				var sqliteFilename = "alertSQLiteNotification.db3";
#if __IOS__
        string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal); // Documents folder
        string libraryPath = Path.Combine (documentsPath, "..", "Library"); // Library folder
        var path = Path.Combine(libraryPath, sqliteFilename);
#else
#if __ANDROID__
                string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
                var path = Path.Combine(documentsPath, sqliteFilename);
#else
				// WinPhone
				var path = Path.Combine(ApplicationData.Current.LocalFolder.Path, sqliteFilename); ;
#endif
#endif
				return path;
			}
		}
		public NotificationItemDatabase()
		{
			database = new SQLiteConnection(DatabasePath);
			// create the tables
			database.CreateTable<NotificationItem>();
		}

		public IEnumerable<NotificationItem> GetItems()
		{
			lock (locker)
			{
				return (from i in database.Table<NotificationItem>() select i).ToList();
			}
		}
		public IEnumerable<NotificationItem> GetItemsNotDone()
		{
			lock (locker)
			{
				return database.Query<NotificationItem>("Select * from [Item] where [Done] = 0");
			}
		}

		public NotificationItem GetItem(int id)
		{
			lock (locker)
			{
				return database.Table<NotificationItem>().FirstOrDefault(X => X.ID == id);
			}
		}

		public int SaveItem(NotificationItem item)
		{
			lock (locker)
			{
				if (IsEmpty() == false)
				{
					NotificationItem existTest = this.GetItem(item.ID);
					if (existTest != null)
					{
						database.Update(item);
						//database.Insert(item);
						return item.ID;
					}
					else
					{
						return database.Insert(item);
					}
				}
				else
				{
					return database.Insert(item);
				}
			}
		}

		public int DeleteItem(int id)
		{
			lock (locker)
			{
				return database.Delete<NotificationItem>(id);
			}
		}
		public void DeleteAllItems()
		{
			lock (locker)
			{
				int itemNumber = length();
				for (int i = 1; i <= itemNumber; i++)
				{
					database.Delete<NotificationItem>(i);
				}
			}
		}
		public bool IsEmpty()
		{
			if (database.Table<NotificationItem>().Count() == 0)
			{
				return true;
			}
			else
			{
				return false;
			}

		}
		public int length()
		{
			int aaa = database.Table<NotificationItem>().Count();
			return database.Table<NotificationItem>().Count();
		}

		public void MoveAllDown()
		{
			NotificationItem notificationItem = new NotificationItem();
			int itemNumber = length();
			for (int i = 1; i < itemNumber; i++)
			{
				notificationItem = GetItem(i + 1);
				notificationItem.ID = i;
				SaveItem(notificationItem);
			}
        }

		public void DeleteAt(int Index)
		{
			NotificationItem notificationItem = new NotificationItem();
			int itemNumber = length();
			for (int i = Index; i <= itemNumber; i++)
			{
				if (i != itemNumber)
				{
					notificationItem = GetItem(i + 1);
					notificationItem.ID = i;
					SaveItem(notificationItem);
				}
				else
				{
					DeleteItem(i);
				}
			}
			
		}
	}
}
