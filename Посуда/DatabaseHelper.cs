using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Посуда
{
    public class DatabaseHelper
    {
            private static string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=ПосудаDB;Integrated Security=True;";
            // или если с паролем:
            // private static string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=ПосудаDB;User ID=sa;Password=12345;";

            public static SqlConnection GetConnection()
            {
                return new SqlConnection(connectionString);
            }

            // Метод для проверки пользователя
            public static (bool success, string role, string fio) ValidateUser(string login, string password)
            {
                using (SqlConnection connection = GetConnection())
                {
                    try
                    {
                        connection.Open();
                        string query = "SELECT Роль_сотрудника, ФИО FROM Пользователи WHERE Логин = @login AND Пароль = @password";

                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@login", login);
                        command.Parameters.AddWithValue("@password", password);

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            string role = reader["Роль_сотрудника"].ToString();
                            string fio = reader["ФИО"].ToString();
                            return (true, role, fio);
                        }
                        else
                        {
                            return (false, "", "");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка подключения к БД: " + ex.Message);
                        return (false, "", "");
                    }
                }
            }
    }
}
