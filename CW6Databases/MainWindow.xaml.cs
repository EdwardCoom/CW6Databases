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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OleDbConnection cn;
        public MainWindow()
        {
            InitializeComponent();

            cn = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source =|DataDirectory|\\ZC CW6 DatabasesFH.accdb");
        }

        private void Assets_Click(object sender, RoutedEventArgs e)
        {
            string query = "select EmployeeID, AssetID, Description from Assets";
            OleDbCommand cmd = new OleDbCommand(query, cn);
            cn.Open();
            OleDbDataReader read = cmd.ExecuteReader();

            //string data = "Employee ID\tAsset ID\tDescription\n";
            //while (read.Read())
            //{
            //    data += read[0].ToString() + "\t" + read[1].ToString() + "\t" + read[2].ToString() + "\n"; // concatenating all of the data to a string to be displayed
            //}

            //AssetDisplayBox.Text = data; // where the data is being displayed.
            //cn.Close();

            
            //cn.Open();
            List<Asset> assets = new List<Asset>();
            while (read.Read())
            {
                Asset asset = new Asset();
                asset.EmployeeID = read["EmployeeID"].ToString();
                asset.AssetID = read["AssetID"].ToString();
                asset.Description = read["Description"].ToString();
                /assets.Add(asset);
            }

            AssetGrid.ItemsSource = assets;
            cn.Close();
        }
    }

    public class Asset
    {
        public string EmployeeID { get; set; }
        public string AssetID { get; set; }
        public string Description { get; set; }
    }
}
