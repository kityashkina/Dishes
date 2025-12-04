using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Посуда
{
    public partial class EditProductsForm : Form
    {
        private string article;
        private AdminPanelForm adminForm;
        private bool isPlaceholderImage = false;

        public EditProductsForm(string article, string userFIO, AdminPanelForm adminForm)
        {
            InitializeComponent();
            this.article = article;
            this.adminForm = adminForm;

            LoadCategories();
            LoadManufacturers();

            if (string.IsNullOrEmpty(article))
            {
                lblEditTitle.Text = "Новый товар";
                LoadDefaultImage();
            }
            else
            {
                lblEditTitle.Text = "Редактирование";
                LoadProduct();
            }
        }

        private void LoadCategories()
        {
            cmbFilterCategory.Items.Clear();
            cmbFilterCategory.Items.Add("Кастрюли");
            cmbFilterCategory.Items.Add("Сковорода");
            cmbFilterCategory.Items.Add("Сервиз");
            cmbFilterCategory.Items.Add("Посуда");
        }

        private void LoadManufacturers()
        {
            cmbFilterManufacturer.Items.Clear();
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT DISTINCT Производитель FROM Товары";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    cmbFilterManufacturer.Items.Add(reader["Производитель"].ToString());
                }
            }
        }

        private void LoadProduct()
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Товары WHERE Артикул = @Article";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Article", article);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txbName.Text = reader["Наименование"].ToString();

                    object priceObj = reader["Стоимость"];
                    txbPrice.Text = priceObj == DBNull.Value ? "0" : priceObj.ToString();

                    object qtyObj = reader["Кол_во_на_складе"];
                    txbQuantity.Text = qtyObj == DBNull.Value ? "0" : qtyObj.ToString();

                    txbDescription.Text = reader["Описание"].ToString();

                    string category = reader["Категория_товара"].ToString();
                    if (cmbFilterCategory.Items.Contains(category))
                        cmbFilterCategory.SelectedItem = category;
                    else
                        cmbFilterCategory.Text = category;

                    string manufacturer = reader["Производитель"].ToString();
                    if (cmbFilterManufacturer.Items.Contains(manufacturer))
                        cmbFilterManufacturer.SelectedItem = manufacturer;
                    else
                        cmbFilterManufacturer.Text = manufacturer;

                    string imageName = reader["Изображение"].ToString();
                    LoadProductImage(imageName);
                }
            }
        }

        private void LoadProductImage(string imageName)
        {
            string placeholderPath = Path.Combine("Images", "picture.png");

            if (!string.IsNullOrEmpty(imageName))
            {
                string imagePath = Path.Combine("Images", imageName);
                if (File.Exists(imagePath))
                {
                    picProduct.Image = Image.FromFile(imagePath);
                    isPlaceholderImage = false;
                    return;
                }
            }
            if (File.Exists(placeholderPath))
            {
                picProduct.Image = Image.FromFile(placeholderPath);
                isPlaceholderImage = true;
            }
            else
            {
                picProduct.BackColor = Color.LightGray;
                isPlaceholderImage = true;
            }
        }

        private void LoadDefaultImage()
        {
            string placeholderPath = Path.Combine("Images", "picture.png");
            if (File.Exists(placeholderPath))
            {
                picProduct.Image = Image.FromFile(placeholderPath);
                isPlaceholderImage = true;
            }
            else
            {
                picProduct.BackColor = Color.LightGray;
                isPlaceholderImage = true;
            }
        }

        //изменить фото
        private void btnEditImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Картинки|*.jpg;*.jpeg;*.png;*.bmp";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    picProduct.Image = Image.FromFile(dialog.FileName);
                    isPlaceholderImage = false;
                }
                catch
                {
                    MessageBox.Show("Ошибка загрузки картинки", "Ошибка");
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            adminForm.ReloadProducts();
            adminForm.Show();
            this.Hide();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txbName.Text) ||
                string.IsNullOrEmpty(txbPrice.Text) ||
                string.IsNullOrEmpty(txbQuantity.Text) ||
                string.IsNullOrEmpty(cmbFilterCategory.Text) ||
                string.IsNullOrEmpty(cmbFilterManufacturer.Text))
            {
                MessageBox.Show("Заполните все поля!");
                return;
            }

            //проверка чисел
            if (!decimal.TryParse(txbPrice.Text, out decimal price) || price < 0)
            {
                MessageBox.Show("Введите корректную цену (например: 1500)");
                txbPrice.Focus();
                return;
            }

            if (!int.TryParse(txbQuantity.Text, out int quantity) || quantity < 0)
            {
                MessageBox.Show("Введите корректное количество (целое число)");
                txbQuantity.Focus();
                return;
            }

            try
            {
                if (string.IsNullOrEmpty(article))
                    InsertProduct(price, quantity);
                else
                    UpdateProduct(price, quantity);

                MessageBox.Show("Сохранено!");
                adminForm.ReloadProducts();
                adminForm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void InsertProduct(decimal price, int quantity)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                //создание артикула
                string query = "SELECT ISNULL(MAX(Артикул), 'A000') FROM Товары";
                SqlCommand cmd = new SqlCommand(query, conn);
                object result = cmd.ExecuteScalar();
                string lastArticle = result?.ToString() ?? "A000";

                string newArticle;
                if (lastArticle.Length >= 4 &&
                    char.IsLetter(lastArticle[0]) &&
                    int.TryParse(lastArticle.Substring(1), out int num))
                {
                    string prefix = lastArticle.Substring(0, 1);
                    newArticle = $"{prefix}{num + 1:D3}";
                }
                else
                {
                    newArticle = "A001";
                }

                string imageName = SaveImage(newArticle);
                query = @"
                    INSERT INTO Товары 
                    (Артикул, Наименование, Единица_измерения, Стоимость, 
                     Размер_максимально_возможной_скидки, Производитель, Поставщик, 
                     Категория_товара, Действующая_скидка, Кол_во_на_складе, 
                     Описание, Изображение)
                    VALUES 
                    (@Article, @Name, @Unit, @Price, @MaxDiscount, 
                     @Manufacturer, @Supplier, @Category, @CurrentDiscount, 
                     @Quantity, @Description, @Image)";

                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Article", newArticle);
                cmd.Parameters.AddWithValue("@Name", txbName.Text);
                cmd.Parameters.AddWithValue("@Unit", "шт.");
                cmd.Parameters.AddWithValue("@Price", price);
                cmd.Parameters.AddWithValue("@MaxDiscount", 10);
                cmd.Parameters.AddWithValue("@Manufacturer", cmbFilterManufacturer.Text);
                cmd.Parameters.AddWithValue("@Supplier", "Поставщик");
                cmd.Parameters.AddWithValue("@Category", cmbFilterCategory.Text);
                cmd.Parameters.AddWithValue("@CurrentDiscount", 0);
                cmd.Parameters.AddWithValue("@Quantity", quantity);
                cmd.Parameters.AddWithValue("@Description", txbDescription.Text);
                cmd.Parameters.AddWithValue("@Image", imageName ?? (object)DBNull.Value);

                cmd.ExecuteNonQuery();
            }
        }

        private void UpdateProduct(decimal price, int quantity)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string imageName = SaveImage(article);
                string query = @"
                    UPDATE Товары SET
                    Наименование = @Name,
                    Единица_измерения = @Unit,
                    Стоимость = @Price,
                    Размер_максимально_возможной_скидки = @MaxDiscount,
                    Производитель = @Manufacturer,
                    Поставщик = @Supplier,
                    Категория_товара = @Category,
                    Действующая_скидка = @CurrentDiscount,
                    Кол_во_на_складе = @Quantity,
                    Описание = @Description,
                    Изображение = @Image
                    WHERE Артикул = @Article";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Article", article);
                cmd.Parameters.AddWithValue("@Name", txbName.Text);
                cmd.Parameters.AddWithValue("@Unit", "шт.");
                cmd.Parameters.AddWithValue("@Price", price);
                cmd.Parameters.AddWithValue("@MaxDiscount", 10);
                cmd.Parameters.AddWithValue("@Manufacturer", cmbFilterManufacturer.Text);
                cmd.Parameters.AddWithValue("@Supplier", "Поставщик");
                cmd.Parameters.AddWithValue("@Category", cmbFilterCategory.Text);
                cmd.Parameters.AddWithValue("@CurrentDiscount", 0);
                cmd.Parameters.AddWithValue("@Quantity", quantity);
                cmd.Parameters.AddWithValue("@Description", txbDescription.Text);
                cmd.Parameters.AddWithValue("@Image", imageName ?? (object)DBNull.Value);

                cmd.ExecuteNonQuery();
            }
        }

        private string SaveImage(string article)
        {
            if (isPlaceholderImage)
                return "";

            if (picProduct.Image == null)
                return "";

            string fileName = $"{article}.jpg";
            string savePath = Path.Combine("Images", fileName);

            try
            {
                picProduct.Image.Save(savePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                return fileName;
            }
            catch
            {
                return "";
            }
        }
        private void lblName1_Click(object sender, EventArgs e)
        {

        }
        private void EditProductForm_Load(object sender, EventArgs e)
        {

        }
    }
}