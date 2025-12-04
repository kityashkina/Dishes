using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Посуда
{
    public partial class CheckoutForm : Form
    {
        private MainForm mainForm;
        private CartForm cartForm;
        private string userFIO;

        public CheckoutForm(MainForm main, CartForm cart, string fio)
        {
            InitializeComponent();
            mainForm = main;
            cartForm = cart;
            userFIO = fio;
            LoadData();
        }

        private void LoadData()
        {
            //пункты выдачи загрузка
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT Адрес FROM ПунктыВыдачи";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    cmbPickupPoints.Items.Add(reader["Адрес"].ToString());
                }
            }

            //формирование деталей заказа
            decimal total = 0;
            string details = "";

            foreach (var item in MainForm.GetCart())
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT Наименование, Стоимость FROM Товары WHERE Артикул = @Article";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Article", item.Key);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        string name = reader["Наименование"].ToString();
                        decimal price = Convert.ToDecimal(reader["Стоимость"]);
                        decimal itemTotal = price * item.Value;
                        total += itemTotal;

                        details += $"• {name} x{item.Value} = {itemTotal:N2} руб.\r\n";
                    }
                }
            }

            txtOrderDetails.Text = details;
            lblTotalAmount.Text = total.ToString("N2") + " руб.";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            cartForm.Show();
            this.Hide();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (cmbPickupPoints.SelectedItem == null)
            {
                MessageBox.Show("Выберите пункт выдачи!");
                return;
            }

            try
            {
                int newNum = 0;

                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    string maxQuery = "SELECT ISNULL(MAX(Номер_заказа), 0) FROM Заказы";
                    SqlCommand maxCmd = new SqlCommand(maxQuery, conn);
                    newNum = Convert.ToInt32(maxCmd.ExecuteScalar()) + 1;

                    string insertQuery = @" 
                INSERT INTO Заказы 
                (Номер_заказа, Состав_заказа, Дата_заказа, Дата_доставки, 
                 Пункт_выдачи, ФИО_клиента, Код_для_получения, Статус_заказа)
                VALUES 
                (@Num, @Items, @Date, @Delivery, @Point, @Client, @Code, 'Новый')";

                    string items = "";
                    foreach (var item in MainForm.GetCart())
                    {
                        items += $"{item.Key}:{item.Value};";
                    }

                    SqlCommand cmd = new SqlCommand(insertQuery, conn);
                    cmd.Parameters.AddWithValue("@Num", newNum);
                    cmd.Parameters.AddWithValue("@Items", items.TrimEnd(';'));
                    cmd.Parameters.AddWithValue("@Date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Delivery", DateTime.Now.AddDays(3));
                    cmd.Parameters.AddWithValue("@Point", cmbPickupPoints.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Client", userFIO ?? "Неизвестный");
                    cmd.Parameters.AddWithValue("@Code", new Random().Next(100, 1000).ToString());
                    cmd.ExecuteNonQuery();
                }

                MainForm.ClearCart();
                MessageBox.Show($"Заказ оформлен! Номер: {newNum}");

                mainForm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void CheckoutForm_Load(object sender, EventArgs e)
        {

        }
    }
}