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
    /// Логика взаимодействия для RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("LoginPage.xaml", UriKind.Relative));
        }

        private void AcceptRegButton_Click(object sender, RoutedEventArgs e)
        {
            //Проверка, если поля пустые
            if (!string.IsNullOrEmpty(LogTextBox.Text) ||
                !string.IsNullOrEmpty(PassTextBox.Password) ||
                !string.IsNullOrEmpty(SurTextBox.Text) ||
                !string.IsNullOrEmpty(NameTextBox.Text) ||
                !string.IsNullOrEmpty(PhoneTextBox.Text) ||
                !string.IsNullOrEmpty(MailTextBox.Text))
            {
                try //Проверка подключения к БД
                {

                    if (isUserExists())//Проверка есть такой пользователь в БД
                        return;
                    BaseContext con = new BaseContext();
                    MySqlCommand comm = new MySqlCommand("INSERT INTO tempusers (UserLogin, UserPassword, UserSurname, UserName, UserPatronymic, Phone, Email) " +
                        "VALUES (@log, @pass, @surname, @name, @patronymic, @phone, @email)", con.getConnection());
                    comm.Parameters.Add("@log", MySqlDbType.VarChar).Value = LogTextBox.Text;
                    comm.Parameters.Add("@pass", MySqlDbType.VarChar).Value = PassTextBox.Password;
                    comm.Parameters.Add("@surname", MySqlDbType.VarChar).Value = SurTextBox.Text;
                    comm.Parameters.Add("@name", MySqlDbType.VarChar).Value = NameTextBox.Text;
                    comm.Parameters.Add("@patronymic", MySqlDbType.VarChar).Value = PatronymicTextBox.Text;
                    comm.Parameters.Add("@phone", MySqlDbType.VarChar).Value = PhoneTextBox.Text;
                    comm.Parameters.Add("@email", MySqlDbType.VarChar).Value = MailTextBox.Text;
                    comm.Parameters.Add("@role", MySqlDbType.VarChar).Value = "Клиент";
                    con.openConnection();
                    if (comm.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Ваша заявка на регистрацию принята.", "Успех", MessageBoxButton.OK);
                        this.NavigationService.Navigate(new Uri("LoginPage.xaml", UriKind.Relative));
                    }
                    else
                        MessageBox.Show("Ошибка при создании заявки.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    con.closeConnection();
                }
                catch
                {
                    MessageBox.Show("Ошибка подключения к базе данных.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Введите данные в поля.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            
        }
        //Проверка пользователя в БД
        public Boolean isUserExists()
        {
            BaseContext con = new BaseContext();
            DataTable dt = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand comm = new MySqlCommand("SELECT * FROM users WHERE UserLogin = @uL", con.getConnection());
            comm.Parameters.Add("@uL", MySqlDbType.VarChar).Value = LogTextBox.Text;

            adapter.SelectCommand = comm;
            adapter.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Такой логин уже используется, введите другой.", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
                return true;
            }

            else
                return false;
        }
        private void HideCheckBox_Click(object sender, RoutedEventArgs e)
        {
            //Отключаем доступ к полю Отчество при нажатии чекбокса
            if (HideCheckBox.IsChecked == true)
                PatronymicTextBox.IsEnabled = false;
            else
                PatronymicTextBox.IsEnabled = true;
        }
    }
}
