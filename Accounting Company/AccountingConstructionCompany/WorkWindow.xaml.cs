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
using System.Windows.Shapes;

namespace AccountingConstructionCompany
{
    /// <summary>
    /// Логика взаимодействия для WorkWindow.xaml
    /// </summary>
    public partial class WorkWindow : Window
    {
        BaseContext con = new BaseContext();
        public WorkWindow()
        {
            InitializeComponent();
            WorkFrame.Navigate(new DashboardPage());
            checkRole();

        }
        public void checkRole()
        {
            con.openConnection();
            MySqlCommand com = new MySqlCommand("SELECT Role FROM Users WHERE ID = "+StaticData.userID, con.getConnection());
            if (com.ExecuteScalar().ToString() != "Админ")
            {
                AdminPageButton.Visibility = Visibility.Collapsed;
            }
            else
            {
                AdminPageButton.Visibility = Visibility.Visible;
            }

        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void DashBoardButton_Click(object sender, RoutedEventArgs e)
        {
            WorkFrame.Navigate(new DashboardPage());
            Button clickedButton = (Button)sender;
            foreach (Button button in btnMenu.Children)
            {
                button.FontWeight = FontWeights.Normal;
                button.Foreground = Brushes.DimGray;
            }
            clickedButton.FontWeight = FontWeights.Bold;
            clickedButton.Foreground = Brushes.Black;
        }

        private void UserPageButton_Click(object sender, RoutedEventArgs e)
        {
            WorkFrame.Navigate(new UserPage());
            Button clickedButton = (Button)sender;
            foreach (Button button in btnMenu.Children)
            {
                button.FontWeight = FontWeights.Normal;
                button.Foreground = Brushes.DimGray;
            }
            clickedButton.FontWeight = FontWeights.Bold;
            clickedButton.Foreground = Brushes.Black;
        }

        private void CustomersPageButton_Click(object sender, RoutedEventArgs e)
        {
            WorkFrame.Navigate(new ClientPage());
            Button clickedButton = (Button)sender;
            foreach (Button button in btnMenu.Children)
            {
                button.FontWeight = FontWeights.Normal;
                button.Foreground = Brushes.DimGray;
            }
            clickedButton.FontWeight = FontWeights.Bold;
            clickedButton.Foreground = Brushes.Black;
        }


        private void ReportsPageButton_Click(object sender, RoutedEventArgs e)
        {
            WorkFrame.Navigate(new ReportsPage());
            Button clickedButton = (Button)sender;
            foreach (Button button in btnMenu.Children)
            {
                button.FontWeight = FontWeights.Normal;
                button.Foreground = Brushes.DimGray;
            }
            clickedButton.FontWeight = FontWeights.Bold;
            clickedButton.Foreground = Brushes.Black;
        }

        private void CashPageButton_Click(object sender, RoutedEventArgs e)
        {
            WorkFrame.Navigate(new CashPage());
            Button clickedButton = (Button)sender;
            foreach (Button button in btnMenu.Children)
            {
                button.FontWeight = FontWeights.Normal;
                button.Foreground = Brushes.DimGray;
            }
            clickedButton.FontWeight = FontWeights.Bold;
            clickedButton.Foreground = Brushes.Black;
        }

        private void WarehousePageButton_Click(object sender, RoutedEventArgs e)
        {
            WorkFrame.Navigate(new WarehousePage());
            Button clickedButton = (Button)sender;
            foreach (Button button in btnMenu.Children)
            {
                button.FontWeight = FontWeights.Normal;
                button.Foreground = Brushes.DimGray;
            }
            clickedButton.FontWeight = FontWeights.Bold;
            clickedButton.Foreground = Brushes.Black;
        }

        private void GoodsPageButton_Click(object sender, RoutedEventArgs e)
        {
            WorkFrame.Navigate(new GoodsPage());
            Button clickedButton = (Button)sender;
            foreach (Button button in btnMenu.Children)
            {
                button.FontWeight = FontWeights.Normal;
                button.Foreground = Brushes.DimGray;
            }
            clickedButton.FontWeight = FontWeights.Bold;
            clickedButton.Foreground = Brushes.Black;
        }

        private void HideButton_Click(object sender, RoutedEventArgs e)
        {
            //Свернуть окно
            this.WindowState = WindowState.Minimized;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            //Обработка выхода из приложения
            MessageBoxResult result = MessageBox.Show("Вы действительно хотите выйти?", "Выход", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Environment.Exit(1);
            }
        }
        private void AdminPageButton_Click(object sender, RoutedEventArgs e)
        {
            WorkFrame.Navigate(new AdminPage());
            Button clickedButton = (Button)sender;
            foreach (Button button in btnMenu.Children)
            {
                button.FontWeight = FontWeights.Normal;
                button.Foreground = Brushes.DimGray;
            }
            clickedButton.FontWeight = FontWeights.Bold;
            clickedButton.Foreground = Brushes.Black;
        }
    }
}
