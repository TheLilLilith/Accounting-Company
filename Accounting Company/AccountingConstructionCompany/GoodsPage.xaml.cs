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
    /// Логика взаимодействия для GoodsPage.xaml
    /// </summary>
    public partial class GoodsPage : Page
    {
        BaseContext con = new BaseContext();
        MySqlCommand com = null;
        int idproduct;
        int price;
        public GoodsPage()
        {
            InitializeComponent();
            loadSuppliers();
            loadBox();
        }
        public void loadBox()
        {
            ProductSupplierBox.Items.Clear();
            con.openConnection();
            com = new MySqlCommand("SELECT SupplierName FROM suppliers", con.getConnection());
            MySqlDataReader sqlReader = com.ExecuteReader();
            while (sqlReader.Read())
            {
                ProductSupplierBox.Items.Add(sqlReader["SupplierName"].ToString());
            }
            con.closeConnection();
            sqlReader.Close();
        }
        public void loadSuppliers()
        {
            con.openConnection();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            com = new MySqlCommand("SELECT * FROM Suppliers", con.getConnection());

            adapter.SelectCommand = com;
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            if (SuppliersListView != null)
            {
                SuppliersListView.DataContext = ds.Tables[0].DefaultView;
            }
        }

        private void SuppliersListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView selectedRow = SuppliersListView.SelectedItem as DataRowView;
            if (selectedRow != null)
            {
                con.openConnection();
                int supId = Convert.ToInt32(selectedRow["ID"]);
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                com = new MySqlCommand("SELECT i.ID, i.ProductName, i.SupplierPrice FROM inventory i " +
                    "INNER JOIN suppliers s on i.SupplierID = s.ID where i.SupplierID = " + supId, con.getConnection());
                adapter.SelectCommand = com;
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                if (ProductsListView != null)
                {
                    ProductsListView.DataContext = ds.Tables[0].DefaultView;
                }
            }
            
        }

        private void ProductsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataRowView selectedRow = ProductsListView.SelectedItem as DataRowView;
                idproduct = Convert.ToInt32(selectedRow["ID"]);
                price = Convert.ToInt32(selectedRow["SupplierPrice"]);
                ProductNameBox.Text = selectedRow["ProductName"].ToString();
                OverallBox.Text = price.ToString();
            }
            catch
            {

            }   
        }
        private void OrderProductButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime dt = DateTime.Now;
                var date = Convert.ToDateTime(dt).ToString("yyyy/MM/dd");
                con.openConnection();
                MySqlCommand com = new MySqlCommand("INSERT INTO expense (ExpenseDate, ProductID, Quantity, TotalExpense) " +
                    "VALUES (@edate, @pid, @quan, @total)", con.getConnection());
                com.Parameters.Add("@edate", MySqlDbType.VarChar).Value = date;
                com.Parameters.Add("@pid", MySqlDbType.VarChar).Value = idproduct;
                com.Parameters.Add("@quan", MySqlDbType.VarChar).Value = ProductQuantityBox.Text;
                com.Parameters.Add("@total", MySqlDbType.VarChar).Value = OverallBox.Text;
                if (com.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Товар заказан, обновите его количество на складе.", "Заказ товара", MessageBoxButton.OK);
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

        private void ProductQuantityBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(ProductQuantityBox.Text))
                {
                    ProductQuantityBox.Text = string.Empty;
                    return;
                }
                double itogo = Convert.ToDouble(ProductQuantityBox.Text) * Convert.ToDouble(price);
                OverallBox.Text = itogo.ToString();
            }
            catch
            {

            }
        }

        private void NewSupplierButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                con.openConnection();
                MySqlCommand com = new MySqlCommand("INSERT INTO suppliers (SupplierName, ContactName, ContactEmail, ContactPhone) " +
                       "VALUES (@sname, @cname, @mail, @phone)", con.getConnection());
                com.Parameters.Add("@sname", MySqlDbType.VarChar).Value = SupplierNamingBox.Text;
                com.Parameters.Add("@cname", MySqlDbType.VarChar).Value = SupplierNameBox.Text;
                com.Parameters.Add("@mail", MySqlDbType.VarChar).Value = SupplierMailBox.Text;
                com.Parameters.Add("@phone", MySqlDbType.VarChar).Value = SupplierPhoneBox.Text;
                if (com.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Поставщик успешно добавлен в систему", "Успех", MessageBoxButton.OK);
                    con.closeConnection();
                    loadBox();
                }
                else
                {
                    MessageBox.Show("Произошла ошибка при добавлении.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch
            {
                MessageBox.Show("Отсутствует подключение к базе данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void NewProductButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                con.openConnection();
                MySqlCommand com = new MySqlCommand("INSERT INTO inventory (ProductName, SupplierID, SupplierPrice, Type) " +
                       "VALUES (@pname, @sid, @sprice, @type)", con.getConnection());
                com.Parameters.Add("@pname", MySqlDbType.VarChar).Value = ProductName.Text;
                com.Parameters.Add("@sid", MySqlDbType.VarChar).Value = ProductSupplierBox.SelectedIndex + 1;
                com.Parameters.Add("@sprice", MySqlDbType.VarChar).Value = ProductSupplierPrice.Text;
                com.Parameters.Add("@type", MySqlDbType.VarChar).Value = "Товар";
                if (com.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Товар успешно добавлен в систему", "Успех", MessageBoxButton.OK);
                    con.closeConnection();
                }
                else
                {
                    MessageBox.Show("Произошла ошибка при добавлении.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch
            {
                MessageBox.Show("Отсутствует подключение к базе данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void NewServiceButton_Click(object sender, RoutedEventArgs e)
        {
           try
            {
                con.openConnection();
                MySqlCommand com = new MySqlCommand("INSERT INTO inventory (ProductName, Type, SupplierID) " +
                       "VALUES (@pname, @type, @sid)", con.getConnection());
                com.Parameters.Add("@pname", MySqlDbType.VarChar).Value = ServiceNameBox.Text;
                com.Parameters.Add("@type", MySqlDbType.VarChar).Value = "Услуга";
                com.Parameters.Add("@sid", MySqlDbType.VarChar).Value = null;
                if (com.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Товар успешно добавлен в систему", "Успех", MessageBoxButton.OK);
                    con.closeConnection();
                }
                else
                {
                    MessageBox.Show("Произошла ошибка при добавлении.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch
            {
                MessageBox.Show("Отсутствует подключение к базе данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
