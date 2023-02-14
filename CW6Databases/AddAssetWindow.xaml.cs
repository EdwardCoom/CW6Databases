// Name: Zach Coomer
// Date: 2/14/2023
// Assignment: CW6 Databases
// Class: 352
// Description: C# Code for the AddAssetWindow

using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CW6Databases
{
    /// <summary>
    /// Interaction logic for AddAssetWindow.xaml
    /// </summary>
    public partial class AddAssetWindow : Window
    {

        OleDbConnection cn;

        public AddAssetWindow()
        {
            InitializeComponent();

            cn = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source =|DataDirectory|\\ZC CW6 DatabasesFH.accdb"); // Database Connection String
        }

        private void AddEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            string query = "insert into Assets (EmployeeID, AssetID, Description) values (@EmployeeID, @AssetID, @Description)"; // Query command to add to Database
            OleDbCommand cmd = new OleDbCommand(query, cn);
            cmd.Parameters.AddWithValue("@EmployeeID", EmployeeIDTextBox.Text);
            cmd.Parameters.AddWithValue("@AssetID", AssetIDTextBox.Text);
            cmd.Parameters.AddWithValue("@Description", DescriptionTextBox.Text);

            cn.Open();
            cmd.ExecuteNonQuery(); // Executes query
            cn.Close();
            this.Close();
        }
    }
}
