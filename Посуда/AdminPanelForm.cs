using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Посуда
{
    public partial class AdminPanelForm : Form
    {
        private string currentUserFIO;
        private List<Product> allProducts = new List<Product>();
        private List<Product> filteredProducts = new List<Product>();
        private string selectedArticle = "";

        public AdminPanelForm(string fio)
        {
            InitializeComponent();
            currentUserFIO = fio;
            lblWelcome.Text = $"Админ-панель, {currentUserFIO}!";
            LoadAllProducts();
            UpdateProductDisplay();
        }

        public class Product
        {
            public string Article { get; set; }
            public string Name { get; set; }
            public string Category { get; set; }
            public decimal Price { get; set; }
            public string Manufacturer { get; set; }
            public int Stock { get; set; }
            public string ImagePath { get; set; }
            public string Description { get; set; }
        }

        private void LoadAllProducts()
        {
            allProducts.Clear();
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Товары";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Product product = new Product
                    {
                        Article = reader["Артикул"].ToString(),
                        Name = reader["Наименование"].ToString(),
                        Category = reader["Категория_товара"].ToString(),
                        Price = Convert.ToDecimal(reader["Стоимость"]),
                        Manufacturer = reader["Производитель"].ToString(),
                        Stock = Convert.ToInt32(reader["Кол_во_на_складе"]),
                        ImagePath = reader["Изображение"].ToString(),
                        Description = reader["Описание"].ToString()
                    };
                    allProducts.Add(product);
                }
            }
            filteredProducts = allProducts.ToList();
        }

        private void UpdateProductDisplay()
        {
            flowLayoutPanel1.Controls.Clear();

            if (!filteredProducts.Any())
            {
                Label noProductsLabel = new Label();
                noProductsLabel.Text = "Товары не найдены";
                noProductsLabel.Font = new Font("Comic sans MS", 14, FontStyle.Bold);
                flowLayoutPanel1.Controls.Add(noProductsLabel);
                return;
            }

            foreach (var product in filteredProducts)
            {
                Panel productCard = CloneProductCard(product);
                flowLayoutPanel1.Controls.Add(productCard);
            }
        }

        private Panel CloneProductCard(Product product)
        {
            Panel newCard = new Panel();
            newCard.Size = pnlProductCard1.Size;
            newCard.BackColor = pnlProductCard1.BackColor;
            newCard.BorderStyle = BorderStyle.FixedSingle;
            newCard.Tag = product.Article;

            newCard.Click += (s, e) =>
            {
                selectedArticle = product.Article;
                btnEdit.Visible = true;
                btnRemove.Visible = true;
            };

            foreach (Control control in pnlProductCard1.Controls)
            {
                if (control is Label label)
                {
                    Label newLabel = new Label();
                    newLabel.Text = label.Text;
                    newLabel.Font = label.Font;
                    newLabel.ForeColor = label.ForeColor;
                    newLabel.Location = label.Location;
                    newLabel.Size = label.Size;
                    newLabel.Name = label.Name;

                    switch (label.Name)
                    {
                        case "lblName1":
                            newLabel.Text = product.Name;
                            break;
                        case "lblDescription1":
                            newLabel.Text = product.Description ?? "";
                            break;
                        case "lblCategory1":
                            newLabel.Text = "Категория: " + product.Category;
                            break;
                        case "lblPrice1":
                            newLabel.Text = "Цена: " + product.Price.ToString("N0") + " ₽";
                            break;
                        case "lblManufacturer1":
                            newLabel.Text = "Производитель: " + product.Manufacturer;
                            break;
                        case "lblStock1":
                            newLabel.Text = "В наличии: " + product.Stock + "шт.";
                            break;
                        case "lblAvailability":
                            newLabel.Text = product.Stock > 0 ? "Наличие: Да" : "Наличие: Нет";
                            break;
                    }

                    newCard.Controls.Add(newLabel);
                }
                else if (control is PictureBox pictureBox && pictureBox.Name == "picProduct1")
                {
                    PictureBox newPic = new PictureBox();
                    newPic.Size = pictureBox.Size;
                    newPic.Location = pictureBox.Location;
                    newPic.SizeMode = pictureBox.SizeMode;
                    newPic.BorderStyle = pictureBox.BorderStyle;

                    string imagePath = Path.Combine("Images", product.ImagePath);
                    string placeholderPath = Path.Combine("Images", "picture.png");

                    if (File.Exists(imagePath))
                        newPic.Image = Image.FromFile(imagePath);
                    else if (File.Exists(placeholderPath))
                        newPic.Image = Image.FromFile(placeholderPath);
                    newCard.Controls.Add(newPic);
                }
            }

            return newCard;
        }

        //кнопка изменить
        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditProductsForm editForm = new EditProductsForm(selectedArticle, currentUserFIO, this);
            editForm.Show();
            this.Hide();
        }

        //кнопка удалить
        private void btnRemove_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                $"Удалить товар?",
                "Подтверждение",
                MessageBoxButtons.YesNo
            );

            if (result == DialogResult.Yes)
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = "DELETE FROM Товары WHERE Артикул = @Article";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Article", selectedArticle);
                    cmd.ExecuteNonQuery();
                }

                LoadAllProducts();
                UpdateProductDisplay();
                selectedArticle = "";
                btnEdit.Visible = false;
                btnRemove.Visible = false;
            }
        }

        //новый товар
        private void btnNew_Click(object sender, EventArgs e)
        {
            EditProductsForm editForm = new EditProductsForm(null, currentUserFIO, this);
            editForm.Show();
            this.Hide();
        }

        //поиск
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.ToLower();

            filteredProducts = allProducts.Where(p =>
                p.Name.ToLower().Contains(searchText) ||
                p.Category.ToLower().Contains(searchText) ||
                p.Manufacturer.ToLower().Contains(searchText)
            ).ToList();

            UpdateProductDisplay();
            selectedArticle = "";
            btnEdit.Visible = false;
            btnRemove.Visible = false;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }
        private void AdminPanelForm_Load(object sender, EventArgs e)
        {

        }
        public void ReloadProducts()
        {
            LoadAllProducts();
            UpdateProductDisplay();
            selectedArticle = "";
            btnEdit.Visible = false;
            btnRemove.Visible = false;
        }
    }
}