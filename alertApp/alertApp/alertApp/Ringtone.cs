using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace alertApp
{
    public class Ringtone
    {
        public Ringtone(string imagep, string name)
        {
            this.ImageP = imagep;
            this.Name = name;

        }

        public string Name { get; set; }
        public string ImageP { get; set; }

    }
}
