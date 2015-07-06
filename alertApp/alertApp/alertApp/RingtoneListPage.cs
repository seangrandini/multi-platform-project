using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using System.Threading.Tasks;

namespace alertApp
{
    /// <summary>
    ///   This page will display a list of ringtones.
    /// </summary>
    class RingtoneListPage : ContentPage
    {
        ListView _ringtoneList;
        ObservableCollection<Ringtone> _ringtones = new ObservableCollection<Ringtone>();

        public RingtoneListPage()
        {
            LoadRingtonesForDisplay();

            CreateRingtonesListView();

            Content = _ringtoneList;
        }

        void LoadRingtonesForDisplay()
        {
            if (_ringtones.Count == 0)
            {
                _ringtones = App.Ringtones;
            }
        }

        void CreateRingtonesListView()
        {
            _ringtoneList = new ListView
            {
                RowHeight = 50,
                ItemTemplate = new DataTemplate(typeof(ringtoneCell))
            };
        }
        protected override void OnAppearing()
        {
            // This method is invoked by Xamarin.Forms at some point when the 
            // page is being displayed.
            base.OnAppearing();
            LoadRingtonesForDisplay();
            _ringtoneList.ItemsSource = _ringtones;

        }
    }
}
