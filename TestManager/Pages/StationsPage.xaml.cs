using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using TestManager.DataLayer;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TestManager.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class StationsPage : Page
    {
        public List<Station> Stations { get; set; }

        public StationsPage()
        {
            this.InitializeComponent();
            this.LoadStations();
        }

        public void LoadStations()
        {
            Stations = DataHelper.GetStations((App.Current as App).ConnectionString);
            //(App.Current as App).Stations = Stations;
            StationList.ItemsSource = Stations;
        }


    }
}
