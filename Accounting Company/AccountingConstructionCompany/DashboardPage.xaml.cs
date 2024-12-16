using MySqlConnector;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для DashboardPage.xaml
    /// </summary>
    public partial class DashboardPage : Page
    {
        BaseContext con = new BaseContext();
        public DashboardPage()
        {
            InitializeComponent();
            loadData();
        }
        public void loadData()
        {
            try
            {
                //Подгружаем из БД в textbox с помощью SQL запросов
                con.openConnection();
                MySqlCommand com = new MySqlCommand("SELECT COUNT(*) FROM orders where OrderStatus = 'Активен' ", con.getConnection());
                MySqlCommand com2 = new MySqlCommand("SELECT COUNT(*) FROM orders where OrderStatus = 'Завершен' ", con.getConnection());
                MySqlCommand com3 = new MySqlCommand("SELECT COUNT(*) FROM orders where OrderStatus = 'Отменен' ", con.getConnection());
                MySqlCommand com4 = new MySqlCommand("SELECT (SELECT SUM(TotalIncome) FROM Income) - (SELECT SUM(TotalExpense) FROM Expense) as Выручка", con.getConnection());
                MySqlCommand com5 = new MySqlCommand("SELECT SUM(Quantity) as Товаров FROM inventory i where i.Type = 'Товар'", con.getConnection());
                MySqlCommand com6 = new MySqlCommand("SELECT COUNT(*) FROM orders", con.getConnection());
                ActiveOrdersTextBlock.Text = com.ExecuteScalar().ToString();
                ConfirmedOrdersTextBlock.Text = com2.ExecuteScalar().ToString();
                CancelledOrdersTextBlock.Text = com3.ExecuteScalar().ToString();
                IncomeTextBlock.Text = com4.ExecuteScalar().ToString();
                ProductsTextBlock.Text = com5.ExecuteScalar().ToString();
                OrdersTextBlock.Text = com6.ExecuteScalar().ToString();
                con.closeConnection();
            }
            catch
            {

            }
        }
    }
}
