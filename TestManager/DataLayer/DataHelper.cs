using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace TestManager.DataLayer
{
    class DataHelper
    {
        /// <summary>
        /// When starting the drag process on a Company Card we need to prevent making an assignment that has already been completed.
        /// This Method queries the SQL database for Stations already completed by the Company selected.
        /// Returns a StationList of the completed stations. 
        /// </summary>
        /// <param name="companyNumber"></param>
        /// <param name="ConnectionString"></param>
        /// <returns>StationList of Completed Stations</returns>
        public static StationList GetCompletedStations(int companyNumber, string ConnectionString)
        {
            const string GetCompletedStationsByCompany = " select StationId from CompletedStations " +
                " where CompletedStations.CompanyId = @companyNumber ";
            StationList completedStations = new StationList();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = GetCompletedStationsByCompany;
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@companyNumber", companyNumber);
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    Station station = new Station();
                                    station.StationNumber = reader.GetInt32(0);
                                    completedStations.Add(station);
                                    Debug.WriteLine("Added Station " + station.StationNumber + " to inelligible list");
                                }
                                reader.Close();
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
        /// <summary>
        /// When making an assignment we need to populate the CompletedStations table so we do not repeat assignments.
        /// This Method Insert a new row in the CompletedStations Table for the relevant Company and Station.
        /// This returns the Primary Key of the record.
        /// </summary>
        /// <param name="stationNumber"></param>
        /// <param name="companyNumber"></param>
        /// <param name="ConnectionString"></param>
        /// <returns>Primary Key of the inserted row</returns>
        public static string AddNewCompletedStation(int stationNumber, int companyNumber, string ConnectionString)
        {
            const string InsertCompletedStation = " Insert into CompletedStations " +
                " values (@StationId, @CompanyId) ";            
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        Debug.WriteLine("Creating SQL command...");
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = InsertCompletedStation;
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add(new SqlParameter("StationId", stationNumber));
                            cmd.Parameters.Add(new SqlParameter("CompanyId", companyNumber));
                            var completedID = cmd.ExecuteScalar();
                            Debug.WriteLine("Inserted Completed Station " + stationNumber + " for Company " +companyNumber  );
                            return completedID.ToString();
                        }
                    }
                }
            }
            catch (Exception eSql)
            {
                Debug.WriteLine("Exception " + eSql.Message);
            }
            return "";
        }
    }
}
