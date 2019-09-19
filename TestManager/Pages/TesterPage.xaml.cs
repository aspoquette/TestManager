using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
using System.Collections.ObjectModel;
using System.Diagnostics;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TestManager.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TesterPage : Page
    {
        public TesterPage()
        {
            this.InitializeComponent();
            AllowDrops();
            DontAllowDrops();

        }
        public Boolean AllowDropTrue = true;
        public Boolean AllowDropFalse = false;

        public ObservableCollection<Station> stations { get; } = new ObservableCollection<Station>();



        /// <summary>
        /// Turn on AllowDrop.
        /// TODO: Currently hardcoded for demo data turn on
        /// </summary>
        public void AllowDrops()
        {
            InitializeComponent();
            this.Station1Grid.AllowDrop = AllowDropTrue;
            this.Station2Grid.AllowDrop = AllowDropTrue;
        }
        /// <summary>
        /// Turn of AllowDrop.
        /// TODO: Currently hardcoded for demo data turn off
        /// </summary>
        public void DontAllowDrops()
        {
            InitializeComponent();
            this.Station3Grid.AllowDrop = AllowDropFalse;
            this.Station4Grid.AllowDrop = AllowDropFalse;
        }

    

        public async void AllowDropHighlight(UIElement sender, DragStartingEventArgs args)
        {
            //list of Stations

            StationList completedStations = new StationList();
            completedStations = DataHelper.GetCompletedStations(1, (App.Current as App).ConnectionString);


            /*
            if (Station1Grid.AllowDrop == false)
            {
                Station1Grid.Opacity = .3;
            }
            if (Station2Grid.AllowDrop == false)
            {
                Station2Grid.Opacity = .3;
            }
            if (Station3Grid.AllowDrop == false)
            {
                Station3Grid.Opacity = .3;
            }
            if (Station4Grid.AllowDrop == false)
            {
                Station4Grid.Opacity = .3;
            }
            */

            /*
             for (int i= 0; i < completedStation.Count; i++)
             {
                 Station station = completedStation[i];
                 if(station.StationNumber == 1){
                     Station1Grid.Opacity = .3;                    
                 }
                 if (station.StationNumber == 2)
                 {
                     Station2Grid.Opacity = .3;
                 }
                 if (station.StationNumber == 3)
                 {
                     Station3Grid.Opacity = .3;
                 }
                 if (station.StationNumber == 4)
                 {
                     Station4Grid.Opacity = .3;
                 }
             }
             */

        }



        public void ResetHighlight(UIElement sender, DropCompletedEventArgs args)
        {
            Station1Grid.Opacity = 1;
            Station2Grid.Opacity = 1;
            Station3Grid.Opacity = 1;
            Station4Grid.Opacity = 1;
        }
        
        


    }
}
