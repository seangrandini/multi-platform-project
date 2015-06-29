﻿using System;
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
        public string Notes { get; set; }

        public bool Done { get; set; }
    }
}
