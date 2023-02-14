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
    /// Interaction logic for AddEmployeeWindow.xaml
    /// </summary>
    public partial class AddEmployeeWindow : Window
    {
        OleDbConnection cn;
        public AddEmployeeWindow()
        {
            InitializeComponent();

            cn = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source =|DataDirectory|\\ZC CW6 DatabasesFH.accdb"); // Database Connection String
        }

        private void AddEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            string query = "insert into Employees (EmployeeID, FirstName, LastName) values (@EmployeeID, @FirstName, @LastName)"; // Query command to add to Database
            OleDbCommand cmd = new OleDbCommand(query, cn);
            cmd.Parameters.AddWithValue("@EmployeeID", EmployeeIDTextBox.Text);
            cmd.Parameters.AddWithValue("@FirstName", FirstNameTextBox.Text);
            cmd.Parameters.AddWithValue("@LastName", LastNameTextBox.Text);
            
            cn.Open();
            cmd.ExecuteNonQuery(); // Executes query
            cn.Close();
            this.Close();
        }
    }
}
