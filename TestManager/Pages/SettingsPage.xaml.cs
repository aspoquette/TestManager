using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Diagnostics;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TestManager.Pages
{
    /// <summary>
    /// SettingsPage contains Connection String controls and other database reset tools
    /// </summary>
    public sealed partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            this.InitializeComponent();
            
        }

        /// <summary>
        /// Test Button Logic, if something was entered into Connection String field test that. If not, test the current saved/default value.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TestButton_Click(object sender, RoutedEventArgs e)
        {
            string connectionstring = "";
            if (SqlTextbox.Text.Length > 0)
            {
                connectionstring = SqlTextbox.Text;
            }
            else
            {
                connectionstring = (App.Current as App).ConnectionString;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionstring))
                {
                    conn.Open();
                    if (conn.State == ConnectionState.Open)
                        TestSaveError.Text = "Connection Successful";
                }
            }
            catch (Exception error)
            {
                TestSaveError.Text = "Connection Failed: " + error.Message;
            }

        }
        /// <summary>
        /// Update the connection string
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            (App.Current as App).ConnectionString = SqlTextbox.Text;
            
        }

        private void ClearDatabase_Click(object sender, RoutedEventArgs e)
        {
            DataLayer.Settings.ClearDatabaseAsync((App.Current as App).ConnectionString);
        }
        private void RebuildDatabase_Click(object sender, RoutedEventArgs e)
        {
            DataLayer.Settings.RebuildDatabaseAsync((App.Current as App).ConnectionString);
        }
        private void PopulateDatabase_Click(object sender, RoutedEventArgs e)
        {
            DataLayer.Settings.PopulateDatabaseAsync((App.Current as App).ConnectionString);
        }



    }
        
}
