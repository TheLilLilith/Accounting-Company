using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AccountingConstructionCompany
{
    class BaseContext
    {
        MySqlConnection con = new MySqlConnection("server=localhost;port=3306;username=root;password=;database=accountingbd; Convert Zero Datetime=True");

        public void openConnection()
        {
            try
            {
                if (con.State == System.Data.ConnectionState.Closed)
                    con.Open();
            }
            catch
            {
                MessageBox.Show("Не удалось подключиться к базе данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public void closeConnection()
        {
            if (con.State == System.Data.ConnectionState.Open)
                con.Close();
        }
        public MySqlConnection getConnection()
        {
            return con;
        }
    }
}
