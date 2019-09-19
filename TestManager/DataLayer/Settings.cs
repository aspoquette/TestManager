using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestManager.DataLayer
{
    /// <summary>
    /// Database creation and population scripts are stored in the "Database Scripts" folder. 
    /// Code here allows the application to read the various .sql files and run the scripts against the database
    /// </summary>
    class Settings
    {

        //SettingsPage option for clearing the database of all data. 
        public static async void ClearDatabaseAsync(String ConnectionString)
        {
            Windows.Storage.StorageFolder storageFolder = Windows.ApplicationModel.Package.Current.InstalledLocation;
            Windows.Storage.StorageFile clearFile = await storageFolder.GetFileAsync(@"Database Scripts\ClearTables.sql");
            string script = await Windows.Storage.FileIO.ReadTextAsync(clearFile);
            Debug.WriteLine("Read from file ClearTables.sql: " + script);
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            if (conn.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = script;
                        int rowsDeleted = cmd.ExecuteNonQuery();
                        Debug.WriteLine("All data deleted, " + rowsDeleted + " rows deleted.");
                    }
                }
                catch (Exception) { Debug.WriteLine("Unable to delete all data, tables may not exist"); }
            }
        }

        //SettingsPage option to Delete and Recreate Tables. Necessary to reset autoincrement PKs
        public static async void RebuildDatabaseAsync(String ConnectionString)
        {
            Windows.Storage.StorageFolder storageFolder = Windows.ApplicationModel.Package.Current.InstalledLocation;
            Windows.Storage.StorageFile deleteFile = await storageFolder.GetFileAsync(@"Database Scripts\DeleteTables.sql");
            string scriptDelete = await Windows.Storage.FileIO.ReadTextAsync(deleteFile);
            Windows.Storage.StorageFile createFile = await storageFolder.GetFileAsync(@"Database Scripts\CreateTables.sql");            
            string scriptCreate = await Windows.Storage.FileIO.ReadTextAsync(createFile);
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            if (conn.State == System.Data.ConnectionState.Open)
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = scriptDelete;
                    try
                    {
                        cmd.ExecuteNonQuery();
                        Debug.WriteLine("Tables Deleted");
                    }
                    catch (Exception)
                    {
                        Debug.WriteLine("Could not delete all tables, " +
                        "1 or more may not have existed");
                    }
                    cmd.CommandText = scriptCreate;
                    cmd.ExecuteNonQuery();
                    Debug.WriteLine("Tables Created");
                }
            }
        }
        //SettingsPage option to Input Demo Data
        public static async void PopulateDatabaseAsync(String ConnectionString)
        {

            Windows.Storage.StorageFolder storageFolder = Windows.ApplicationModel.Package.Current.InstalledLocation;
            Windows.Storage.StorageFile demoFile = await storageFolder.GetFileAsync(@"Database Scripts\DemoData.sql");
            string script = await Windows.Storage.FileIO.ReadTextAsync(demoFile);
            Debug.WriteLine("Read from file DemoData.sql: " + script);
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            if (conn.State == System.Data.ConnectionState.Open)
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = script;
                    int rowsAdded = cmd.ExecuteNonQuery();
                    Debug.WriteLine("All demo data added, " + rowsAdded + " rows added.");
                }
            }
        }

    }
}
