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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new LoginPage());
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //Реализация перемещения окна
            if (e.ChangedButton == MouseButton.Left)
               this.DragMove();
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

        private void HideButton_Click(object sender, RoutedEventArgs e)
        {
            //Свернуть окно
            this.WindowState = WindowState.Minimized; 
        }
    }
}
