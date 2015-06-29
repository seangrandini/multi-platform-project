using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using SQLite;
namespace alertApp
{
    public class ItemDatabase
    {
        static object locker = new object();
        SQLiteConnection database;
        string DatabasePath
        {
            get
            {
                var sqliteFilename = "alertSQLite.db3";
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
        var path = Path.Combine(ApplicationData.Current.LocalFolder.Path, sqliteFilename);;
#endif
#endif
                return path;
            }
        }
        public ItemDatabase()
        {
            database = new SQLiteConnection(DatabasePath);
            // create the tables
            database.CreateTable<Item>();
        }

        public IEnumerable<Item> GetItems ()
        {
            lock (locker)
            {
                return (from i in database.Table<Item>() select i).ToList();
            }
        }
        public IEnumerable<Item> GetItemsNotDone()
        {
            lock (locker)
            {
                return database.Query<Item>("Select * from [Item] where [Done] = 0");
            }
        }

        public Item GetItem(int id)
        {
            lock (locker)
            {
                return database.Table<Item>().FirstOrDefault(X => X.ID == id);
            }
        }

        public int SaveItem(Item item)
        {
            lock (locker)
            {
                if (item.ID != 0)
                {
                    database.Update(item);
                    return item.ID;

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
                return database.Delete<Item>(id);
            }
        }
    }
}
