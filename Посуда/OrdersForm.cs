using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Посуда
{
    public partial class OrdersForm : Form
    {
        private MainForm mainForm;

        public OrdersForm(MainForm main)
        {
            InitializeComponent();
            mainForm = main;
            LoadOrders();
        }

        private void LoadOrders()
        {
            if (dgvOrders.Columns.Count == 0)
            {
                dgvOrders.Columns.Add("OrderNum", "№ Заказа");
                dgvOrders.Columns.Add("Client", "Клиент");
                dgvOrders.Columns.Add("Pickup", "Пункт выдачи");
                dgvOrders.Columns.Add("Status", "Статус");
            }
            dgvOrders.Rows.Clear();

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Заказы";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    dgvOrders.Rows.Add(
                        reader["Номер_заказа"],
                        reader["ФИО_клиента"],
                        reader["Пункт_выдачи"],
                        reader["Статус_заказа"]
                    );
                }
            }
        }

        //при выборе заказа
        private void dgvOrders_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count > 0)
            {
                var row = dgvOrders.SelectedRows[0];
                cmbStatus.Text = row.Cells[3].Value?.ToString() ?? "";
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            mainForm.Show();
            this.Hide();
        }

        //обновить статус
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count == 0) return;

            var row = dgvOrders.SelectedRows[0];
            string orderNum = row.Cells[0].Value.ToString();
            string newStatus = cmbStatus.Text;

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "UPDATE Заказы SET Статус_заказа = @Status WHERE Номер_заказа = @Num";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Status", newStatus);
                cmd.Parameters.AddWithValue("@Num", orderNum);
                cmd.ExecuteNonQuery();
            }

            LoadOrders();
            MessageBox.Show("Статус обновлён!");
        }
        private void OrdersForm_Load(object sender, EventArgs e)
        {

        }
        }
    }