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
    /// Логика взаимодействия для WarehousePage.xaml
    /// </summary>
    public partial class WarehousePage : Page
    {
        BaseContext con = new BaseContext();
        MySqlCommand com = null;
        int idgoods;
        public WarehousePage()
        {
            InitializeComponent();
            loadData();
        }
        public void loadData()
        {

            con.openConnection();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            com = new MySqlCommand("SELECT * FROM inventory where Type = 'Товар'", con.getConnection());
            uploadData();
        }
        public void uploadData()
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = com;
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            InventoryListView.DataContext = ds.Tables[0].DefaultView;
            con.closeConnection();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataRowView selectedRow = InventoryListView.SelectedItem as DataRowView;
                if (MessageBox.Show("Вы действительно хотите удалить '" + selectedRow["ProductName"].ToString() + "' из системы?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    con.openConnection();
                    MySqlCommand comm = new MySqlCommand("DELETE FROM inventory WHERE ID = @oid", con.getConnection());
                    comm.Parameters.Add(new MySqlParameter("@oid", idgoods));
                    comm.ExecuteNonQuery();
                    con.closeConnection();
                    loadData();
                }
                else
                {

                }
            }
            catch
            {
                MessageBox.Show("Не удалось удалить товар.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                con.openConnection();
                MySqlCommand comm = new MySqlCommand("UPDATE inventory SET ProductName = @pid, Quantity = @qua, Price = @price WHERE ID = @oid", con.getConnection());
                comm.Parameters.Add(new MySqlParameter("@oid", idgoods));
                comm.Parameters.Add(new MySqlParameter("@pid", ProductNameTextBox.Text));
                comm.Parameters.Add(new MySqlParameter("@qua", ProductQuantityTextBox.Text));
                comm.Parameters.Add(new MySqlParameter("@price", ProductPriceTextBox.Text));
                comm.ExecuteNonQuery();
                con.closeConnection();
                loadData();
            }
            catch
            {
                MessageBox.Show("Не удалось отредактировать товар.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void InventoryListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView selectedRow = InventoryListView.SelectedItem as DataRowView;
            if (selectedRow != null)
            {
                idgoods = Convert.ToInt32(selectedRow["ID"]);
                string name = selectedRow["ProductName"].ToString();
                string quantity = selectedRow["Quantity"].ToString();
                string price = selectedRow["Price"].ToString();
                ProductNameTextBox.Text = name;
                ProductQuantityTextBox.Text = quantity;
                ProductPriceTextBox.Text = price;
            }
        }
    }
}
