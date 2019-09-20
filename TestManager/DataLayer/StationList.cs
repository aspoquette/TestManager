using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace TestManager.DataLayer
{
    public class StationList : ObservableCollection<Station>
    {
        public StationList()
        {

        }

        /*
        public static StationList GetStationsCompleted(int id)
        {
            StationList completedStations = new StationList();


            
            //Hardcoded station return for now
            //TODO: Call logic on the station list
            Station station1 = new Station();
            station1.StationNumber = 1;
            Station station2 = new Station();
            station2.StationNumber = 2; 
            completedStations.Add(station1);
            completedStations.Add(station2);

    
            return completedStations;
            
            
        } */
                
    }
}
