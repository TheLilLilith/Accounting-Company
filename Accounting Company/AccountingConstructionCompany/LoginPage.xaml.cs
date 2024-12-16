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
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        //Переменная для передачи ID пользователя
        int userID;
        public LoginPage()
        {
            InitializeComponent();
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            //Заглушка на случай отсутствия подключения к базе данных
            try
            {
                string loginUser = NameTextBox.Text;
                string passUser = PassTextBox.Password;
                //Подключение к базе данных
                BaseContext con = new BaseContext();
                DataTable dt = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                //Запрос на поиск логина и пароля, введенные пользователем
                MySqlCommand comm = new MySqlCommand("SELECT * FROM users WHERE UserLogin = @uL AND UserPassword = @uP", con.getConnection());
                comm.Parameters.Add("@uL", MySqlDbType.VarChar).Value = loginUser;
                comm.Parameters.Add("@uP", MySqlDbType.VarChar).Value = passUser;
                adapter.SelectCommand = comm;
                adapter.Fill(dt);
                //Если такой логин и пароль существует
                if (dt.Rows.Count > 0)
                {
                    con.openConnection();
                    //Сохраняем ID пользователя
                    userID = (int)comm.ExecuteScalar();
                    StaticData.userID = userID;
                    con.closeConnection();
                    //Переходим в новое окно, это окно закрываем
                    WorkWindow ww = new WorkWindow();
                    ww.Show();
                    MainWindow main = Application.Current.MainWindow as MainWindow;
                    if (main != null)
                    {
                        main.Close();
                    }
                }
                //Иначе выдаем ошибку
                else
                {
                    MessageBox.Show("Неправильный логин или пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch
            {
                MessageBox.Show("Отсутствует подключение к базе данных.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            //Переход на страницу с регистрацией
            this.NavigationService.Navigate(new Uri("RegisterPage.xaml", UriKind.Relative));
        }
    }
}
