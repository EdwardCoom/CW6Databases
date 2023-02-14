// Name: Zach Coomer
// Date: 2/14/2023
// Assignment: CW6 Databases
// Class: 352
// Description: C# Code for the Main Window

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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CW6Databases
{
    /// <summary>
    /// Class used to populate DataGrid for Asset Table fields
    /// </summary>
    public class Asset
    {
        public string EmployeeID { get; set; }
        public string AssetID { get; set; }
        public string Description { get; set; }
    }
    
    /// <summary>
    /// Class used to populate DataGrid for Employee Table fields
    /// </summary>
    public class Employee
    {
        public string EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OleDbConnection cn;
        public MainWindow()
        {
            InitializeComponent();

            cn = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source =|DataDirectory|\\ZC CW6 DatabasesFH.accdb"); // Database Connection String
        }

        private void Assets_Click(object sender, RoutedEventArgs e)
        {
            string query = "select EmployeeID, AssetID, Description from Assets";
            OleDbCommand cmd = new OleDbCommand(query, cn);
            cn.Open();
            OleDbDataReader read = cmd.ExecuteReader();

            List<Asset> assets = new List<Asset>(); // list used to hold asset information
            while (read.Read())
            {
                Asset asset = new Asset();
                asset.EmployeeID = read["EmployeeID"].ToString();
                asset.AssetID = read["AssetID"].ToString();
                asset.Description = read["Description"].ToString();
                assets.Add(asset);
            }

            AssetGrid.ItemsSource = assets; // Information being display in DataGrid
            cn.Close();
        }

        private void Employees_Click(object sender, RoutedEventArgs e)
        {
            string query = "select EmployeeID, FirstName, LastName from Employees";
            OleDbCommand cmd = new OleDbCommand(query, cn);
            cn.Open();
            OleDbDataReader read = cmd.ExecuteReader();

            List<Employee> employees = new List<Employee>(); // list used to hold employee information
            while (read.Read())
            {
                Employee employee = new Employee();
                employee.EmployeeID = read["EmployeeID"].ToString();
                employee.FirstName = read["FirstName"].ToString();
                employee.LastName = read["LastName"].ToString();
                employees.Add(employee);
            }

            EmployeeGrid.ItemsSource = employees; // Information being display in DataGrid
            cn.Close();
        }

        private void AddEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            var addEmployeeWindow = new AddEmployeeWindow();
            addEmployeeWindow.ShowDialog(); // opens the add employee window
        }

        private void AddAssetButton_Click(object sender, RoutedEventArgs e)
        {
            var addAssetWindow = new AddAssetWindow();
            addAssetWindow.ShowDialog(); // opens the add asset window
        }
    }

}
