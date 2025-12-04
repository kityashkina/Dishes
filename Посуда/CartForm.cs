using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Посуда
{
    public partial class CartForm : Form
    {
        private MainForm mainForm;
        public string CurrentUserFIO { get; set; }
        public CartForm(MainForm parent, string userFIO)
        {
            InitializeComponent();
            mainForm = parent;
            CurrentUserFIO = userFIO;
            LoadCart();
        }

        private void LoadCart()
        {
            if (dgvCart.Columns.Count == 0)
            {
                dgvCart.Columns.Add("Article", "Артикул");
                dgvCart.Columns.Add("Name", "Наименование");
                dgvCart.Columns.Add("Quantity", "Количество");
                dgvCart.Columns.Add("Price", "Цена");
                dgvCart.Columns.Add("Total", "Сумма");

                dgvCart.Columns["Article"].Visible = false;

                dgvCart.Columns["Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvCart.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                dgvCart.Columns["Price"].DefaultCellStyle.Format = "N0";
                dgvCart.Columns["Total"].DefaultCellStyle.Format = "N0";
            }

            dgvCart.Rows.Clear();
            decimal total = 0;

            foreach (var item in MainForm.GetCart())
            {
                string article = item.Key;
                int quantity = item.Value;

                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT Наименование, Стоимость FROM Товары WHERE Артикул = @Article";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Article", article);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        string name = reader["Наименование"].ToString();
                        decimal price = (decimal)reader["Стоимость"];
                        decimal sum = price * quantity;
                        total += sum;

                        dgvCart.Rows.Add(article, name, quantity, price, sum);
                    }
                }
            }

            lblTotal.Text = total.ToString("N0");
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            mainForm.Show();
            this.Hide();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvCart.SelectedCells.Count > 0)
            {
                int rowIndex = dgvCart.SelectedCells[0].RowIndex;
                string article = dgvCart.Rows[rowIndex].Cells[0].Value?.ToString();

                if (!string.IsNullOrEmpty(article))
                {
                    MainForm.RemoveFromCart(article);
                    LoadCart();
                }
            }
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (MainForm.GetCart().Count == 0)
            {
                MessageBox.Show("Корзина пуста!");
                return;
            }
            else
            {
                CheckoutForm checkout = new CheckoutForm(mainForm, this, CurrentUserFIO);
                checkout.Show();
                this.Hide();
            }
        }

        private void CartForm_Load(object sender, EventArgs e)
        {

        }
    }
}
