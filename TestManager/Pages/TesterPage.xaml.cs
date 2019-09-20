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
            
        }
        //TODO: ObservableCollection Implmentation
        //public ObservableCollection<Station> stations { get; } = new ObservableCollection<Station>();

                       

        public void AllowDropHighlight(UIElement sender, DragStartingEventArgs args)
        {
            //list of Stations

            StationList completedStations = new StationList();
            completedStations = DataHelper.GetCompletedStations(1, (App.Current as App).ConnectionString);
            
            for  (int i = 0; i < completedStations.Count; i++) 
            {
                if (completedStations[i].StationNumber == 1)
                {
                    Station1Grid.Opacity = .3;
                    Station1Grid.AllowDrop = false;
                }
                else if (completedStations[i].StationNumber == 2)
                {
                    Station2Grid.Opacity = .3;
                    Station2Grid.AllowDrop = false;
                }
                else if (completedStations[i].StationNumber == 3)
                {
                    Station3Grid.Opacity = .3;
                    Station3Grid.AllowDrop = false;
                }
                else if (completedStations[i].StationNumber == 4)
                {
                    Station4Grid.Opacity = .3;
                    Station4Grid.AllowDrop = false;
                }
                else if (completedStations[i].StationNumber == 5)
                {
                    Station5Grid.Opacity = .3;
                    Station5Grid.AllowDrop = false;
                }
                else if (completedStations[i].StationNumber == 6)
                {
                    Station6Grid.Opacity = .3;
                    Station6Grid.AllowDrop = false;
                }
                else if (completedStations[i].StationNumber == 7)
                {
                    Station7Grid.Opacity = .3;
                    Station7Grid.AllowDrop = false;
                }
                else if (completedStations[i].StationNumber == 8)
                {
                    Station8Grid.Opacity = .3;
                    Station8Grid.AllowDrop = false;
                }
                else if (completedStations[i].StationNumber == 9)
                {
                    Station9Grid.Opacity = .3;
                    Station9Grid.AllowDrop = false;
                }
                else if (completedStations[i].StationNumber == 10)
                {
                    Station10Grid.Opacity = .3;
                    Station10Grid.AllowDrop = false;
                }                
            }
        }



        public void ResetHighlight(UIElement sender, DropCompletedEventArgs args)
        {
            Station1Grid.Opacity = 1;
            Station2Grid.Opacity = 1;
            Station3Grid.Opacity = 1;
            Station4Grid.Opacity = 1;
            Station5Grid.Opacity = 1;
            Station6Grid.Opacity = 1;
            Station7Grid.Opacity = 1;
            Station8Grid.Opacity = 1;
            Station9Grid.Opacity = 1;
            Station10Grid.Opacity = 1;

            Station1Grid.AllowDrop = true;
            Station2Grid.AllowDrop = true;
            Station3Grid.AllowDrop = true;
            Station4Grid.AllowDrop = true;
            Station5Grid.AllowDrop = true;
            Station6Grid.AllowDrop = true;
            Station7Grid.AllowDrop = true;
            Station8Grid.AllowDrop = true;
            Station9Grid.AllowDrop = true;
            Station10Grid.AllowDrop = true;
        }

        public void Company1_Drop(object sender, DragEventArgs e)
        {

        }


    }
}
