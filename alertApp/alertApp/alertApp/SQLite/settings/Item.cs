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

		public int notificationSaveNumber { get; set; }

        public string Authority { get; set; }
        public string EncodedAuthority { get; set; }
        public string EncodedFragment { get; set; }
        public string EncodedPath { get; set; }
        public string EncodedQuery { get; set; }
        public string Fragment { get; set; }
        public string Path { get; set; }
        public string Query { get; set; }
        public string Scheme { get; set; }

        public string Notes { get; set; }

        public bool Done { get; set; }
#if __ANDROID__
        public void setSettingsFromItem(Item item)
        {
            this.ID = item.ID;
            this.Name = item.Name;
			this.notificationSaveNumber = item.notificationSaveNumber;

            this.Authority = item.Authority;
            this.EncodedAuthority = item.EncodedAuthority;
            this.EncodedFragment = item.EncodedFragment;
            this.EncodedPath = item.EncodedPath;
            this.EncodedQuery = item.EncodedQuery;
            this.Fragment = item.Fragment;
            this.Path = item.Path;
            this.Query = item.Query;
            this.Scheme = item.Scheme;
            this.Notes = item.Notes;
            this.Done = item.Done;
            System.Diagnostics.Debug.WriteLine(this.ID);
        }
        public Android.Net.Uri derivateUri()
        {
            Android.Net.Uri.Builder builder = new Android.Net.Uri.Builder();
            builder.Authority(this.Authority);
            builder.EncodedAuthority(this.EncodedAuthority);
            builder.EncodedFragment(this.EncodedFragment);
            builder.EncodedPath(this.EncodedPath);
            builder.EncodedQuery(this.EncodedQuery);
            builder.Fragment(this.Fragment);
            builder.Path(this.Path);
            builder.Query(this.Query);
            builder.Scheme(this.Scheme);
            Android.Net.Uri derivateUri = builder.Build();
            return derivateUri;
        }
        public void setUriAsProperty(Android.Net.Uri uri)
        {
            this.Authority = uri.Authority;
            this.EncodedAuthority = uri.EncodedAuthority;
            this.EncodedFragment = uri.EncodedFragment;
            this.EncodedPath = uri.EncodedPath;
            this.EncodedQuery = uri.EncodedQuery;
            this.Fragment = uri.Fragment;
            this.Path = uri.Path;
            this.Query = uri.Query;
            this.Scheme = uri.Scheme;
        }
#endif
    }
}
