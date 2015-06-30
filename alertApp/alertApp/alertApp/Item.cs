using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace alertApp
{
    public class Item
    {
        public Item()
        {

        }
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }   
        public string Name { get; set; }
        public string defaultUri { get; set; }
        public string Notes { get; set; }

        public bool Done { get; set; }
        public void setSettingsFromItem(Item item)
        {
            this.ID = item.ID;
            this.Name = item.Name;
            this.defaultUri = item.defaultUri;
            this.Notes = item.Notes;
            this.Done = item.Done;
            System.Diagnostics.Debug.WriteLine(this.ID);
        }
    }
}
