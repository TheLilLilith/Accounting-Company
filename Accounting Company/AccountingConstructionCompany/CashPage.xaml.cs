using MySqlConnector;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для CashPage.xaml
    /// </summary>
    public partial class CashPage : Page
    {
        BaseContext con = new BaseContext();
        MySqlCommand com = null;
        MySqlDataReader reader;
        string query = "SELECT * FROM orders where OrderStatus = 'Активен'";
        int orderID;
        int totalPrice;
        public CashPage()
        {
            InitializeComponent();
            loadOrders();
        }
        public void loadOrders()
        {
            con.openConnection();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            com = new MySqlCommand(query, con.getConnection());

            adapter.SelectCommand = com;
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            if (OrdersListView != null)
            {
                OrdersListView.DataContext = ds.Tables[0].DefaultView;
            }
            con.closeConnection();
        }
        private void NewOrderButton_Click(object sender, RoutedEventArgs e)
        {
            NewOrder no = new NewOrder();
            no.ShowDialog();
        }

        private void OrdersListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataRowView selectedRow = OrdersListView.SelectedItem as DataRowView;
                if (selectedRow != null)
                {
                    con.openConnection();
                    orderID = Convert.ToInt32(selectedRow["ID"]);
                    totalPrice = Convert.ToInt32(selectedRow["Total"]);
                    int quantity = Convert.ToInt32(selectedRow["Quantity"]);
                    string comment = Convert.ToString(selectedRow["Commentary"]);
                    com = new MySqlCommand("SELECT c.CName, c.CSurname, c.CPatronymic, c.Phone, c.Email, c.Address, i.ProductName, i.Type " +
                        "FROM orders o INNER JOIN customers c ON o.CustomerID = c.ID " +
                        "INNER JOIN inventory i ON o.ProductID = i.ID " +
                        "WHERE o.id = " + orderID, con.getConnection());
                    reader = com.ExecuteReader();
                    if (reader.Read())
                    {
                        string cName = reader.GetString("CName");
                        string cSurname = reader.GetString("CSurname");
                        string cPatronymic = reader.GetString("CPatronymic");
                        string phone = reader.GetString("Phone");
                        string mail = reader.GetString("Email");
                        string address = reader.GetString("Address");
                        string ptype = reader.GetString("Type");
                        string pname = reader.GetString("ProductName");

                        CustomerData.Text = cSurname + " " + cName + " " + cPatronymic;
                        CustomerPhone.Text = phone;
                        CustomerMail.Text = mail;
                        CustomerAddress.Text = address;
                        ProductName.Text = pname;
                        ProductType.Text = ptype;
                        ProductQuantity.Text = quantity.ToString();
                        ProductCommentary.Text = comment;
                        if (ProductType.Text == "Товар")
                        {
                            ProductQuantity.Visibility = Visibility.Visible;
                        }
                        else
                        {
                            ProductQuantity.Visibility = Visibility.Collapsed;
                        }
                        if (selectedRow["OrderStatus"].ToString() != "Активен")
                        {
                            AcceptButton.Visibility = Visibility.Collapsed;
                            CancelButton.Visibility = Visibility.Collapsed;
                        }
                        else
                        {
                            AcceptButton.Visibility = Visibility.Visible;
                            CancelButton.Visibility = Visibility.Visible;
                        }
                    }
                    con.closeConnection();
                }
            }
            catch
            {

            }
           
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            con.openConnection();
            DataRowView selectedRow = OrdersListView.SelectedItem as DataRowView;
            MySqlCommand comm = new MySqlCommand("UPDATE Orders SET OrderStatus = 'Отменен' WHERE ID = @oid", con.getConnection());
            comm.Parameters.Add(new MySqlParameter("@oid", selectedRow["ID"]));
            comm.ExecuteNonQuery();
            con.closeConnection();
            MessageBox.Show("Заказ отменен.");
            loadOrders();
        }
        public void IncomeLog()
        {
            try
            {
                DateTime dt = DateTime.Now;
                var date = Convert.ToDateTime(dt).ToString("yyyy/MM/dd");
                con.openConnection();
                MySqlCommand com = new MySqlCommand("INSERT INTO income (IncomeDate, OrderID, TotalIncome) " +
                    "VALUES (@incdate, @oid, @total)", con.getConnection());
                com.Parameters.Add("@incdate", MySqlDbType.VarChar).Value = date;
                com.Parameters.Add("@oid", MySqlDbType.VarChar).Value = orderID;
                com.Parameters.Add("@total", MySqlDbType.VarChar).Value = totalPrice;
                if (com.ExecuteNonQuery() == 1)
                {
                    con.closeConnection();
                }
                else
                {

                }
            }
            catch
            {
                MessageBox.Show("Отсутствует подключение к базе данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                con.openConnection();
                DataRowView selectedRow = OrdersListView.SelectedItem as DataRowView;
                MySqlCommand comm = new MySqlCommand("UPDATE Orders SET OrderStatus = 'Завершен' WHERE ID = @oid", con.getConnection());
                comm.Parameters.Add(new MySqlParameter("@oid", selectedRow["ID"]));
                comm.ExecuteNonQuery();
                con.closeConnection();
                IncomeLog();
                MessageBox.Show("Заказ завершен.");
                loadOrders();
            }
            catch
            {
                MessageBox.Show("Не удалось изменить статус заказа", "Ошибка", MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }

        private void OrderStatusComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (OrderStatusComboBox.SelectedIndex == 0)
            {
                query = "SELECT * FROM orders where OrderStatus = 'Активен'";
                loadOrders();
            }
            if (OrderStatusComboBox.SelectedIndex == 2)
            {
                query = "SELECT * FROM orders";
                loadOrders();
            }
            if (OrderStatusComboBox.SelectedIndex == 3)
            {
                query = "SELECT * FROM orders where OrderStatus = 'Завершен'";
                loadOrders();
            }
            if (OrderStatusComboBox.SelectedIndex == 4)
            {
                query = "SELECT * FROM orders where OrderStatus = 'Отменен'";
                loadOrders();
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            loadOrders();
        }
    }
}
