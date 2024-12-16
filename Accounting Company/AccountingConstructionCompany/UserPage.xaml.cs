using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Логика взаимодействия для UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        BaseContext con = new BaseContext(); // Класс подключения, к которому будем потом обращаться
        MySqlCommand com = null; //
        public UserPage()
        {
            InitializeComponent();
            LoadData(); //Первым подгружается метод выгрузки данных при загрузки страницы
        }
        public void LoadData() //Выгружаем данные пользователя из БД
        {
            try //Заглушка от вылета программы
            {
                com = new MySqlCommand("SELECT * FROM Users WHERE ID = @ID", con.getConnection()); //SQL Запрос
                com.Parameters.Add("@ID", MySqlDbType.VarChar).Value = StaticData.userID; 
                con.openConnection(); //Обязательно открываем соединение
                MySqlDataReader reader = com.ExecuteReader(); //Считывание запроса и выгрузка в textbox'ы
                while (reader.Read())
                {
                    UserNameBox.Text = reader["UserName"].ToString();
                    UserSurnameBox.Text = reader["UserSurname"].ToString();
                    UserPatronymicBox.Text = reader["UserPatronymic"].ToString();
                    UserPhoneBox.Text = reader["Phone"].ToString();
                    UserMailBox.Text = reader["Email"].ToString();
                    UserCompany.Text = reader["CompanyName"].ToString();
                    UserLogin.Text = reader["UserLogin"].ToString();
                    UserPassword.Password = reader["UserPassword"].ToString();
                }
                reader.Close();
                con.closeConnection(); //Обязательно закрываем соеднинение
            }
            catch
            {
                MessageBox.Show("Не удалось подключиться к базе данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void SaveDataButton_Click(object sender, RoutedEventArgs e)
        {
            try //Заглушка от вылета программы
            {
                com = new MySqlCommand("UPDATE users SET UserPassword = @upass, UserSurname = @usname, UserName = @uname, UserPatronymic = @upatron," +
                    " Email = @umail, Phone = @uphone, CompanyName = @cname WHERE ID = @userID", con.getConnection()); //SQL Запрос на сохранение данных
                con.openConnection(); //Обязательно открываем соединение
                com.Parameters.Add("@upass", MySqlDbType.VarChar).Value = UserPassword.Password; //Данные для запроса берём из textbox'ов
                com.Parameters.Add("@usname", MySqlDbType.VarChar).Value = UserSurnameBox.Text;
                com.Parameters.Add("@uname", MySqlDbType.VarChar).Value = UserNameBox.Text;
                com.Parameters.Add("@upatron", MySqlDbType.VarChar).Value = UserPatronymicBox.Text;
                com.Parameters.Add("@uphone", MySqlDbType.VarChar).Value = UserPhoneBox.Text;
                com.Parameters.Add("@umail", MySqlDbType.VarChar).Value = UserMailBox.Text;
                com.Parameters.Add("@cname", MySqlDbType.VarChar).Value = UserCompany.Text;
                com.Parameters.Add("@userID", MySqlDbType.VarChar).Value = StaticData.userID;
                com.ExecuteNonQuery(); //Выполнение запроса
                MessageBox.Show("Данные успешно обновлены.", "Редактирование данных", MessageBoxButton.OK, MessageBoxImage.Information);
                con.closeConnection(); //Обязательно закрываем соеднинение
                LoadData();
            }
            catch
            {
                MessageBox.Show("Не удалось подключиться к базе данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
