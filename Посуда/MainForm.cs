using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Посуда
{
    public partial class MainForm : Form
    {
        public string currentUserFIO;
        private string currentUserRole;
        private List<Product> allProducts = new List<Product>();
        private List<Product> filteredProducts = new List<Product>();
        private static Dictionary<string, int> cartItems = new Dictionary<string, int>();

        public static void AddToCart(string article, int quantity = 1)
        {
            if (cartItems.ContainsKey(article))
                cartItems[article] += quantity;
            else
                cartItems[article] = quantity;
        }

        public static void RemoveFromCart(string article)
        {
            cartItems.Remove(article);
        }

        //получить все товары
        public static Dictionary<string, int> GetCart()
        {
            return cartItems;
        }

        public static Dictionary<string, int> GetCartItems()
        {
            return new Dictionary<string, int>(cartItems);
        }

        public static void ClearCart()
        {
            cartItems.Clear();
        }

        public MainForm(string fio, string role)
        {
            InitializeComponent();
            currentUserFIO = fio;
            currentUserRole = role;
            lblWelcome.Text = $"Добро пожаловать, {currentUserFIO}!";

            if (role == "Гость")
            {
                btnControlOrders.Visible = false;
                btnShoppingCart.Visible = false;
                picCart.Visible = false;
            }
            if (role == "Клиент")
            {
                btnControlOrders.Visible = false;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadAllProducts();
            LoadManufacturersFilter();
            UpdateProductDisplay();
        }

        //для хранения данных товара
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

        //загрузка всех товаров из БД
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

        //заполнение фильтра производителей
        private void LoadManufacturersFilter()
        {
            cmbFilter.Items.Clear();
            cmbFilter.Items.Add("Все производители");

            var manufacturers = allProducts
                .Select(p => p.Manufacturer)
                .Distinct()
                .OrderBy(m => m);

            foreach (var manufacturer in manufacturers)
            {
                cmbFilter.Items.Add(manufacturer);
            }
            cmbFilter.SelectedIndex = 0;
        }

        private void UpdateProductDisplay()
        {
            flowProducts.Controls.Clear();
            if (!filteredProducts.Any())
            {
                Label noProductsLabel = new Label();
                noProductsLabel.Text = "Товары не найдены";
                noProductsLabel.Font = new Font("Comic Sans MS", 14, FontStyle.Bold);
                noProductsLabel.AutoSize = true;
                flowProducts.Controls.Add(noProductsLabel);
                lblCount.Text = "Найдено: 0 из " + allProducts.Count + " товаров";
                return;
            }
            foreach (var product in filteredProducts)
            {
                Panel productCard = CloneProductCard(product);
                flowProducts.Controls.Add(productCard);
            }

            lblCount.Text = $"Найдено: {filteredProducts.Count} из {allProducts.Count} товаров";
        }
        private Panel CloneProductCard(Product product)
        {
            Panel newCard = new Panel();
            newCard.Size = pnlProductCard1.Size;
            newCard.BackColor = pnlProductCard1.BackColor;
            newCard.BorderStyle = BorderStyle.FixedSingle;
            newCard.Tag = product.Article;

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
                            newLabel.Text = product.Description ?? "Описание отсутствует";
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
                            newLabel.Text = product.Stock > 0 ? "В наличии: " + product.Stock + "шт." : "Нет в наличии";
                            break;
                        case "lblAvailability":
                            newLabel.Text = product.Stock > 0 ? "Наличие: Да" : "Нет";
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
                    newPic.Name = pictureBox.Name;

                    LoadProductImage(newPic, product.ImagePath);
                    newCard.Controls.Add(newPic);
                }
            }
            if (currentUserRole != "Гость")
            {
                PictureBox cartIcon = new PictureBox();
                cartIcon.Size = picCart.Size;
                cartIcon.Location = picCart.Location;
                cartIcon.SizeMode = picCart.SizeMode;
                cartIcon.BorderStyle = picCart.BorderStyle;
                cartIcon.Image = picCart.Image;
                cartIcon.Cursor = Cursors.Hand;
                cartIcon.Tag = product.Article;
                cartIcon.Click += PicCart_Click;
                newCard.Controls.Add(cartIcon);
            }

            return newCard;
        }
        private void LoadProductImage(PictureBox pictureBox, string imageName)
        {
            try
            {
                if (!string.IsNullOrEmpty(imageName))
                {
                    string imagePath = Path.Combine("Images", imageName);

                    if (File.Exists(imagePath))
                    {
                        pictureBox.Image = Image.FromFile(imagePath);
                        return;
                    }
                }

                string placeholderPath = Path.Combine("Images", "picture.png");
                if (File.Exists(placeholderPath))
                {
                    pictureBox.Image = Image.FromFile(placeholderPath);
                }
            }
            catch
            {
            }
        }

        //поиск
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        //фильтр по производителю
        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        //применение фильтров и поиска
        private void ApplyFilters()
        {
            string searchText = txtSearch.Text.Trim().ToLower();
            string selectedManufacturer = cmbFilter.SelectedItem?.ToString();

            filteredProducts = allProducts.Where(p =>
                (string.IsNullOrEmpty(searchText) ||
                 p.Name.ToLower().Contains(searchText) ||
                 p.Category.ToLower().Contains(searchText) ||
                 p.Manufacturer.ToLower().Contains(searchText) ||
                 p.Description.ToLower().Contains(searchText)) &&
                (selectedManufacturer == "Все производители" ||
                 p.Manufacturer == selectedManufacturer)
            ).ToList();

            UpdateProductDisplay();
        }

        //сортировка по возрастанию 
        private void btnSortAsc_Click(object sender, EventArgs e)
        {
            filteredProducts = filteredProducts.OrderBy(p => p.Price).ToList();
            UpdateProductDisplay();
        }

        //сортировка по убыванию
        private void btnSortDesc_Click(object sender, EventArgs e)
        {
            filteredProducts = filteredProducts.OrderByDescending(p => p.Price).ToList();
            UpdateProductDisplay();
        }

        //добавление в корзину
        private void PicCart_Click(object sender, EventArgs e)
        {
            PictureBox pic = sender as PictureBox;
            string article = pic?.Tag?.ToString();

            if (!string.IsNullOrEmpty(article))
            {
                MainForm.AddToCart(article);
                MessageBox.Show("Добавлено в корзину!");
            }
        }

        //в корзину
        private void btnShoppingCart_Click(object sender, EventArgs e)
        {
            CartForm cartForm = new CartForm(this, currentUserFIO);
            cartForm.CurrentUserFIO = currentUserFIO;
            cartForm.Show();
            this.Hide();
        }

        //к управлению заказами
        private void btnControlOrders_Click(object sender, EventArgs e)
        {
            OrdersForm orders = new OrdersForm(this);
            orders.Show();
            this.Hide();
        }

        //выход
        private void btnLogout_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }
    }
}