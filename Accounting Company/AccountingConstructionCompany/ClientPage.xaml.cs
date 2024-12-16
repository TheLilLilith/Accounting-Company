using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AccountingConstructionCompany
{
    /// <summary>
    /// Логика взаимодействия для ClientPage.xaml
    /// </summary>
    public partial class ClientPage : Page
    {
        BaseContext con = new BaseContext();
        MySqlCommand com = null;
        string query = "select * from customers";
        int customerId;
        
        public ClientPage()
        {
            InitializeComponent();
            LoadCustomer();
            

        }
        public void LoadCustomer()
        {
            con.openConnection();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            com = new MySqlCommand(query, con.getConnection());

            adapter.SelectCommand = com;
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            if (CustomerListView != null)
            {
                CustomerListView.DataContext = ds.Tables[0].DefaultView;
                
            }
            con.closeConnection();
        }
       
        private void LoadOrders(int customerId)
        {
            BaseContext con = new BaseContext();
           

            using (con.getConnection())
            {
                 MySqlCommand com = new MySqlCommand("SELECT i.ProductName, i.Type, o.Quantity, o.Total, o.OrderDate, o.OrderStatus, o.Commentary " +
                               "FROM Orders o " +
                               "LEFT JOIN Inventory i ON o.ProductID = i.ID " +
                               "WHERE o.CustomerID = " + customerId, con.getConnection());
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = com;
                Order = new List<Orders>();
                Order.Clear();
                con.openConnection();
                MySqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    Orders order = new Orders();
                    order.ProductName = reader.GetString(0);
                    order.Type = reader.GetString(1);
                    order.Quantity = reader.GetInt32(2);
                    order.Total = reader.GetDecimal(3);
                    order.OrderDate = reader.GetDateTime(4);
                    order.OrderStatus = reader.GetString(5);
                    order.Commentary = reader.GetString(6);
                    Order.Add(order);
                }
                reader.Close();
                con.closeConnection();

              
            }
            
        }
        public List<Orders> Order { get; set; }
        public class Orders
        {
            public string ProductName { get; set; }
            public string Type { get; set; }
            public int Quantity { get; set; }
            public decimal Total { get; set; }
            public DateTime OrderDate { get; set; }
            public string OrderStatus { get; set; }
            public string Commentary { get; set; }
        }

        private void NewClientButton_Click(object sender, RoutedEventArgs e)
        {
            NewCustomer nc = new NewCustomer();
            nc.ShowDialog();
        }

        private void CustomerListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                
                DataRowView selectedRow = CustomerListView.SelectedItem as DataRowView;
                customerId = Convert.ToInt32(selectedRow["ID"]);
                
                LoadOrders(customerId);
                OrdersComboBox.ItemsSource = Order;
            }
            catch
            {

            }
        }

        private void OrdersComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            OrdersComboBox.SelectedIndex = -1;
        }

        private void ActiveOrdersCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            query = "SELECT DISTINCT c.ID, c.CName, c.CSurname, c.CPatronymic, c.Email, c.Phone, c.Address " +
                "FROM Customers c INNER JOIN Orders o ON o.CustomerID = c.ID WHERE o.OrderStatus = 'Активен'; ";
            LoadCustomer();
        }

        private void ActiveOrdersCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            query = "select * from customers";
            LoadCustomer();
        }
    }
}
