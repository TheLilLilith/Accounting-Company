using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для ReportsPage.xaml
    /// </summary>
    public partial class ReportsPage : Page
    {
        BaseContext con = new BaseContext();
        MySqlCommand com;
        public ReportsPage()
        {
            InitializeComponent();
            
        }
        public void loadGridView(MySqlDataAdapter adapter)
        {
            DataSet ds = new DataSet();
            ds.Clear();
            con.openConnection();
            adapter.Fill(ds);
            ReportsDataGrid.DataContext = ds.Tables[0].DefaultView;
            ReportsDataGrid.Items.Refresh();
            con.closeConnection();
            ReportsDataGrid.SelectedIndex = 0;
        }

        private void ProductIncome_Click(object sender, RoutedEventArgs e)
        {
            com = new MySqlCommand("SELECT DATE_FORMAT(e.ExpenseDate, '%d-%m-%Y') as Дата, i.ProductName as Наименование, e.Quantity as Количество " +
       "from expense e inner join inventory i on e.ProductID = i.ID where i.Type = 'Товар'", con.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = com;
            loadGridView(adapter);
        }

        private void ProductExpense_Click(object sender, RoutedEventArgs e)
        {
            com = new MySqlCommand("SELECT DATE_FORMAT(inc.IncomeDate, '%d-%m-%Y') as Дата, i.ProductName as Наименование, o.Quantity as Количество " +
                "from income inc inner join orders o inner join inventory i on o.ProductID = i.ID", con.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = com;
            loadGridView(adapter);
        }

        private void ProductIncomeSort_Click(object sender, RoutedEventArgs e)
        {
            com = new MySqlCommand("SELECT DATE_FORMAT(e.ExpenseDate, '%d-%m-%Y') as Дата, i.ProductName as Наименование, SUM(e.Quantity) as Количество FROM expense e " +
              "INNER JOIN inventory i ON e.ProductID = i.ID WHERE i.Type = 'Товар' " +
              "GROUP BY e.ExpenseDate, i.ProductName ORDER BY e.ExpenseDate", con.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = com;
            loadGridView(adapter);
        }

        private void ProductExpenseSort_Click(object sender, RoutedEventArgs e)
        {
            com = new MySqlCommand("SELECT DATE_FORMAT(inc.IncomeDate, '%d-%m-%Y') as Дата, i.ProductName as Наименование, SUM(o.Quantity) as Количество " +
                "FROM income inc INNER JOIN orders o ON inc.OrderID = o.ID " +
                "INNER JOIN inventory i ON o.ProductID = i.ID " +
                "GROUP BY inc.IncomeDate, i.ProductName ", con.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = com;
            loadGridView(adapter);
        }

        private void ProductsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ProductsComboBox.SelectedIndex = -1;
        }

        private void MoneyIncome_Click(object sender, RoutedEventArgs e)
        {
            com = new MySqlCommand("SELECT DATE_FORMAT(IncomeDate, '%d-%m-%Y') as Дата, TotalIncome as Доход from income", con.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = com;
            loadGridView(adapter);
        }

        private void MoneyIncomeSort_Click(object sender, RoutedEventArgs e)
        {
            com = new MySqlCommand("SELECT DATE_FORMAT(IncomeDate, '%d-%m-%Y') AS Дата, SUM(TotalIncome) AS Всего FROM income GROUP BY IncomeDate ORDER BY IncomeDate", con.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = com;
            loadGridView(adapter);
        }

        private void MoneyExpense_Click(object sender, RoutedEventArgs e)
        {
            com = new MySqlCommand("SELECT DATE_FORMAT(ExpenseDate, '%d-%m-%Y') as Дата, TotalExpense as Расход from expense", con.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = com;
            loadGridView(adapter);
        }

        private void MoneyExpenseSort_Click(object sender, RoutedEventArgs e)
        {
            com = new MySqlCommand("SELECT DATE_FORMAT(ExpenseDate, '%d-%m-%Y') AS Дата, SUM(TotalExpense) AS Всего FROM expense GROUP BY ExpenseDate ORDER BY ExpenseDate", con.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = com;
            loadGridView(adapter);
        }

        private void WarehouseLog_Click(object sender, RoutedEventArgs e)
        {
            com = new MySqlCommand("SELECT ProductName as Наименование, Quantity as Количество FROM inventory where Type = 'Товар'", con.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = com;
            loadGridView(adapter);
        }

        private void WarehouseTotal_Click(object sender, RoutedEventArgs e)
        {
            com = new MySqlCommand("SELECT SUM(Quantity) AS 'Всего' FROM inventory WHERE Type = 'Товар'", con.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = com;
            loadGridView(adapter);
        }

        private void ActiveOrders_Click(object sender, RoutedEventArgs e)
        {
            com = new MySqlCommand("select DATE_FORMAT(o.OrderDate, '%d-%m-%Y') as Дата, o.ID as КодЗаказа, i.ProductName as Наименование from orders o " +
                "inner join inventory i on o.ProductID = i.ID where o.OrderStatus = 'Активен'", con.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = com;
            loadGridView(adapter);
        }

        private void ConfirmedOrders_Click(object sender, RoutedEventArgs e)
        {
            com = new MySqlCommand("select DATE_FORMAT(o.OrderDate, '%d-%m-%Y') as Дата, o.ID as КодЗаказа, i.ProductName as Наименование from orders o " +
                "inner join inventory i on o.ProductID = i.ID where o.OrderStatus = 'Завершен'", con.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = com;
            loadGridView(adapter);
        }

        private void CancelledOrders_Click(object sender, RoutedEventArgs e)
        {
            com = new MySqlCommand("select DATE_FORMAT(o.OrderDate, '%d-%m-%Y') as Дата, o.ID as КодЗаказа, i.ProductName as Наименование from orders o " +
                   "inner join inventory i on o.ProductID = i.ID where o.OrderStatus = 'Отменен'", con.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = com;
            loadGridView(adapter);

        }

        private void TotalOrders_Click(object sender, RoutedEventArgs e)
        {
            com = new MySqlCommand("SELECT COUNT(*) AS Всего FROM Orders", con.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = com;
            loadGridView(adapter);
        }

        private void MoneyComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MoneyComboBox.SelectedIndex = -1;
        }

        private void WarehouseComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            WarehouseComboBox.SelectedIndex = -1;
        }

        private void OrdersComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            OrdersComboBox.SelectedIndex = -1;
        }
    }
}
