using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestManager.DataLayer
{
    class DataHelper
    {
        public static StationList GetCompletedStations(int companyNumber, string ConnectionString)
        {
            const string GetCompletedStationsByCompany = "select StationId from Completed Stations" +
                "where CompletedStations.CompanyId = @companyNumber";
            StationList completedStations = new StationList();
                        try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                { conn.Open();
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = GetCompletedStationsByCompany;
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    var station = new Station();
                                    station.StationNumber = reader.GetInt32(0);
                                    
                                }
                            }        
                        }
                    }
                }
            }
            catch (Exception eSql)
            {
                Debug.WriteLine("Exeception: " + eSql.Message);
            }
            return completedStations;        
        }
    }
}
