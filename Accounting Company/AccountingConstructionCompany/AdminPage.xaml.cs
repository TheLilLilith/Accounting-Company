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
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        BaseContext con = new BaseContext();
        public AdminPage()
        {
            InitializeComponent();
            LoadTUsers(); //Метод выгрузки временных пользователей
        }
        public void LoadTUsers()
        {
            con.openConnection();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand com = new MySqlCommand("SELECT * FROM TempUsers", con.getConnection()); //SQL запрос на выгрузку пользователей
            adapter.SelectCommand = com;
            DataSet ds = new DataSet();  
            adapter.Fill(ds); 
            if (TempUserListView != null)
            {
                TempUserListView.DataContext = ds.Tables[0].DefaultView; // Заполняем ListView
            }
            con.closeConnection();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                con.openConnection();
                DataRowView selectedRow = TempUserListView.SelectedItem as DataRowView; //Берём данные от выбранного элемента
                MySqlCommand comm = new MySqlCommand("DELETE FROM TempUsers WHERE ID = @oid", con.getConnection());
                comm.Parameters.Add(new MySqlParameter("@oid", selectedRow["ID"])); // Выбранный элемент ID
                comm.ExecuteNonQuery();
                con.closeConnection();
                MessageBox.Show("Заявка на регистрацию отменена.");
                LoadTUsers();
            }
            catch
            {

            }
        }

        private void ApproveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                con.openConnection();
                DataRowView selectedRow = TempUserListView.SelectedItem as DataRowView; //Берём данные от выбранного элемента
                MySqlCommand comm = new MySqlCommand("DELETE FROM TempUsers WHERE ID = @oid", con.getConnection()); 
                comm.Parameters.Add(new MySqlParameter("@oid", selectedRow["ID"])); // Выбранный элемент ID
                comm.ExecuteNonQuery();
                MySqlCommand comm2 = new MySqlCommand("INSERT INTO Users (UserLogin, UserPassword, UserName, UserSurname, UserPatronymic, Phone, Email, CompanyName, Role)" +
                    "VALUES (@ulog, @upass, @uname, @usur, @upat, @phone, @mail, @comp, @role)", con.getConnection());
                comm2.Parameters.Add(new MySqlParameter("@ulog", selectedRow["UserLogin"]));
                comm2.Parameters.Add(new MySqlParameter("@upass", selectedRow["UserPassword"]));
                comm2.Parameters.Add(new MySqlParameter("@uname", selectedRow["UserName"]));
                comm2.Parameters.Add(new MySqlParameter("@usur", selectedRow["UserSurname"]));
                comm2.Parameters.Add(new MySqlParameter("@upat", selectedRow["UserPatronymic"]));
                comm2.Parameters.Add(new MySqlParameter("@phone", selectedRow["Phone"]));
                comm2.Parameters.Add(new MySqlParameter("@mail", selectedRow["Email"]));
                comm2.Parameters.Add(new MySqlParameter("@comp", selectedRow["CompanyName"]));
                comm2.Parameters.Add(new MySqlParameter("@role", "Клиент"));
                comm2.ExecuteNonQuery();
                con.closeConnection();
                MessageBox.Show("Заявка на регистрацию Подтверждена.");
                LoadTUsers();
            }
            catch
            {

            }
        }
    }
}
