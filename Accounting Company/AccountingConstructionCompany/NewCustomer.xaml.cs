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
    /// Логика взаимодействия для NewCustomer.xaml
    /// </summary>
   
    public partial class NewCustomer : Window
    {
        BaseContext con = new BaseContext();
        public NewCustomer()
        {
            InitializeComponent();
            this.Topmost = true;
            
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
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddClientButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                con.openConnection();
                MySqlCommand com = new MySqlCommand("INSERT INTO customers (Cname, CSurname, CPatronymic, Email, Phone, Address) " +
                    "VALUES (@cname, @csur, @cpatron, @mail, @phn, @adr)", con.getConnection());
                com.Parameters.Add("@cname", MySqlDbType.VarChar).Value = cNameBox.Text;
                com.Parameters.Add("@csur", MySqlDbType.VarChar).Value = cSurnameBox.Text;
                com.Parameters.Add("@cpatron", MySqlDbType.VarChar).Value = cPatronymicBox.Text;
                com.Parameters.Add("@mail", MySqlDbType.VarChar).Value = cMailBox.Text;
                com.Parameters.Add("@phn", MySqlDbType.VarChar).Value = cPhoneBox.Text;
                com.Parameters.Add("@adr", MySqlDbType.VarChar).Value = cAdressBox.Text;
                if (com.ExecuteNonQuery() == 1)
                {
                    con.closeConnection();
                    MessageBox.Show("Покупатель успешно добавлен в систему.");
                }
                else
                {
                    MessageBox.Show("Ошибка добавления в систему.");
                }
            }
            catch
            {
                MessageBox.Show("Ошибка подключения к базе данных.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
