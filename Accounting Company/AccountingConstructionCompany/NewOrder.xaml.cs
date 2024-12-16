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
using System.Windows.Shapes;

namespace AccountingConstructionCompany
{
    /// <summary>
    /// Логика взаимодействия для NewOrder.xaml
    /// </summary>
    public partial class NewOrder : Window
    {
        BaseContext con = new BaseContext();
        MySqlCommand com = null;
        string price;
        int idcustomer;
        int idproduct;
        public NewOrder()
        {
            InitializeComponent();
            LoadUsers();
            LoadProducts();
        }
        public void LoadUsers()
        {
            try
            {
                con.openConnection();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                com = new MySqlCommand("SELECT * FROM customers", con.getConnection());

                adapter.SelectCommand = com;
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                UserListView.DataContext = ds.Tables[0].DefaultView;
                con.closeConnection();
            }
            catch
            {
                MessageBox.Show("Отсутствует подключение к базе данных.");
            }
        }
        public void LoadProducts()
        {
            try
            {
                con.openConnection();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                com = new MySqlCommand("SELECT * FROM inventory", con.getConnection());

                adapter.SelectCommand = com;
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                ProductsListView.DataContext = ds.Tables[0].DefaultView;
                con.closeConnection();
            }
            catch
            {
                MessageBox.Show("Отсутствует подключение к базе данных.");
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void HideButton_Click(object sender, RoutedEventArgs e)
        {
            //Свернуть окно
            this.WindowState = WindowState.Minimized;
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //Реализация перемещения окна
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void CustomerSearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


        private void UserListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataRowView selectedRow = UserListView.SelectedItem as DataRowView;
                if (selectedRow != null)
                {
                    idcustomer = Convert.ToInt32(selectedRow["ID"]);
                    string name = selectedRow["CName"].ToString();
                    string surname = selectedRow["CSurname"].ToString();
                    string patronymic = selectedRow["CPatronymic"].ToString();
                    string address = selectedRow["Address"].ToString();
                    CustomerData.Text = name + " " + surname + " " + patronymic;
                    AddressTextBox.Text = address;
                }
            }
            catch
            {

            }
        }

        private void ProductsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataRowView selectedRow = ProductsListView.SelectedItem as DataRowView;
                if (selectedRow != null)
                {
                    idproduct = Convert.ToInt32(selectedRow["ID"]);
                    string pname = selectedRow["ProductName"].ToString();
                    price = selectedRow["Price"].ToString();
                    ProductTextBox.Text = pname;
                    OverallTextBox.Text = price;
                }
            }
            catch
            {

            }
        }

        private void QuantityTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(QuantityTextBox.Text))
                {
                    OverallTextBox.Text = string.Empty;
                    return;
                }
                double itogo = Convert.ToDouble(QuantityTextBox.Text) * Convert.ToDouble(price);
                OverallTextBox.Text = itogo.ToString();
            }
            catch
            {

            }
        }

        private void CreateOrderButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime dt = DateTime.Now;
                var date = Convert.ToDateTime(dt).ToString("yyyy/MM/dd");
                con.openConnection();
                MySqlCommand com = new MySqlCommand("INSERT INTO orders (CustomerID, ProductID, Quantity, Total, Commentary, OrderDate, OrderStatus) " +
                    "VALUES (@cid, @pid, @quan, @total, @comm, @odate, @ostatus)", con.getConnection());
                com.Parameters.Add("@cid", MySqlDbType.VarChar).Value = idcustomer;
                com.Parameters.Add("@pid", MySqlDbType.VarChar).Value = idproduct;
                com.Parameters.Add("@quan", MySqlDbType.VarChar).Value = QuantityTextBox.Text;
                com.Parameters.Add("@total", MySqlDbType.VarChar).Value = OverallTextBox.Text;
                com.Parameters.Add("@comm", MySqlDbType.VarChar).Value = CommentTextBox.Text;
                com.Parameters.Add("@odate", MySqlDbType.VarChar).Value = date;
                com.Parameters.Add("@ostatus", MySqlDbType.VarChar).Value = "Активен";
                if (com.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Заказ успешно сформирован!", "Успех", MessageBoxButton.OK);
                    con.closeConnection();
                }
                else
                {
                    MessageBox.Show("Произошла ошибка при формировании заказа.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch
            {
                MessageBox.Show("Отсутствует подключение к базе данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
