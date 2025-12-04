namespace Посуда
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lblWelcome = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblSearch = new System.Windows.Forms.Label();
            this.lblFilter = new System.Windows.Forms.Label();
            this.cmbFilter = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSortAsc = new System.Windows.Forms.Button();
            this.btnSortDesc = new System.Windows.Forms.Button();
            this.pnlProductCard1 = new System.Windows.Forms.Panel();
            this.lblDescription1 = new System.Windows.Forms.Label();
            this.picCart = new System.Windows.Forms.PictureBox();
            this.lblAvailability = new System.Windows.Forms.Label();
            this.lblCategory1 = new System.Windows.Forms.Label();
            this.lblStock1 = new System.Windows.Forms.Label();
            this.lblPrice1 = new System.Windows.Forms.Label();
            this.lblManufacturer1 = new System.Windows.Forms.Label();
            this.lblName1 = new System.Windows.Forms.Label();
            this.picProduct1 = new System.Windows.Forms.PictureBox();
            this.lblCount = new System.Windows.Forms.Label();
            this.flowProducts = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlProducts = new System.Windows.Forms.Panel();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.btnShoppingCart = new System.Windows.Forms.Button();
            this.btnControlOrders = new System.Windows.Forms.Button();
            this.pnlProductCard1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picProduct1)).BeginInit();
            this.flowProducts.SuspendLayout();
            this.pnlProducts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblWelcome.Location = new System.Drawing.Point(81, 13);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(212, 29);
            this.lblWelcome.TabIndex = 8;
            this.lblWelcome.Text = "Добро пожаловать, ";
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(140)))), ((int)(((byte)(81)))));
            this.btnLogout.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnLogout.Location = new System.Drawing.Point(708, 12);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(80, 30);
            this.btnLogout.TabIndex = 9;
            this.btnLogout.Text = "Выйти";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSearch.Location = new System.Drawing.Point(15, 89);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(65, 23);
            this.lblSearch.TabIndex = 10;
            this.lblSearch.Text = "Поиск:";
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblFilter.Location = new System.Drawing.Point(353, 89);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(70, 23);
            this.lblFilter.TabIndex = 11;
            this.lblFilter.Text = "Фильтр:";
            // 
            // cmbFilter
            // 
            this.cmbFilter.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbFilter.FormattingEnabled = true;
            this.cmbFilter.Items.AddRange(new object[] {
            "Webber",
            "Luminarc",
            "Нева",
            "Tefal",
            "Solaris",
            "Galaxy",
            "Эмаль"});
            this.cmbFilter.Location = new System.Drawing.Point(429, 91);
            this.cmbFilter.Name = "cmbFilter";
            this.cmbFilter.Size = new System.Drawing.Size(140, 23);
            this.cmbFilter.TabIndex = 13;
            this.cmbFilter.Text = "Все производители";
            this.cmbFilter.SelectedIndexChanged += new System.EventHandler(this.cmbFilter_SelectedIndexChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(86, 92);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(247, 20);
            this.txtSearch.TabIndex = 14;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnSortAsc
            // 
            this.btnSortAsc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(227)))), ((int)(((byte)(131)))));
            this.btnSortAsc.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSortAsc.Location = new System.Drawing.Point(589, 85);
            this.btnSortAsc.Name = "btnSortAsc";
            this.btnSortAsc.Size = new System.Drawing.Size(86, 31);
            this.btnSortAsc.TabIndex = 15;
            this.btnSortAsc.Text = "▲ По цене";
            this.btnSortAsc.UseVisualStyleBackColor = false;
            this.btnSortAsc.Click += new System.EventHandler(this.btnSortAsc_Click);
            // 
            // btnSortDesc
            // 
            this.btnSortDesc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(227)))), ((int)(((byte)(131)))));
            this.btnSortDesc.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSortDesc.Location = new System.Drawing.Point(681, 85);
            this.btnSortDesc.Name = "btnSortDesc";
            this.btnSortDesc.Size = new System.Drawing.Size(86, 31);
            this.btnSortDesc.TabIndex = 16;
            this.btnSortDesc.Text = "▼ По цене";
            this.btnSortDesc.UseVisualStyleBackColor = false;
            this.btnSortDesc.Click += new System.EventHandler(this.btnSortDesc_Click);
            // 
            // pnlProductCard1
            // 
            this.pnlProductCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(227)))), ((int)(((byte)(131)))));
            this.pnlProductCard1.Controls.Add(this.lblDescription1);
            this.pnlProductCard1.Controls.Add(this.picCart);
            this.pnlProductCard1.Controls.Add(this.lblAvailability);
            this.pnlProductCard1.Controls.Add(this.lblCategory1);
            this.pnlProductCard1.Controls.Add(this.lblStock1);
            this.pnlProductCard1.Controls.Add(this.lblPrice1);
            this.pnlProductCard1.Controls.Add(this.lblManufacturer1);
            this.pnlProductCard1.Controls.Add(this.lblName1);
            this.pnlProductCard1.Controls.Add(this.picProduct1);
            this.pnlProductCard1.Location = new System.Drawing.Point(9, 10);
            this.pnlProductCard1.Name = "pnlProductCard1";
            this.pnlProductCard1.Size = new System.Drawing.Size(369, 175);
            this.pnlProductCard1.TabIndex = 0;
            this.pnlProductCard1.Visible = false;
            // 
            // lblDescription1
            // 
            this.lblDescription1.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDescription1.Location = new System.Drawing.Point(143, 38);
            this.lblDescription1.Name = "lblDescription1";
            this.lblDescription1.Size = new System.Drawing.Size(215, 34);
            this.lblDescription1.TabIndex = 8;
            this.lblDescription1.Text = "Описание товара";
            // 
            // picCart
            // 
            this.picCart.Image = global::Посуда.Properties.Resources.picCart;
            this.picCart.Location = new System.Drawing.Point(330, 135);
            this.picCart.Name = "picCart";
            this.picCart.Size = new System.Drawing.Size(30, 30);
            this.picCart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCart.TabIndex = 7;
            this.picCart.TabStop = false;
            // 
            // lblAvailability
            // 
            this.lblAvailability.AutoSize = true;
            this.lblAvailability.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblAvailability.Location = new System.Drawing.Point(143, 150);
            this.lblAvailability.Name = "lblAvailability";
            this.lblAvailability.Size = new System.Drawing.Size(128, 15);
            this.lblAvailability.TabIndex = 6;
            this.lblAvailability.Text = "Наличие на складе: да";
            // 
            // lblCategory1
            // 
            this.lblCategory1.AutoSize = true;
            this.lblCategory1.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCategory1.Location = new System.Drawing.Point(143, 131);
            this.lblCategory1.Name = "lblCategory1";
            this.lblCategory1.Size = new System.Drawing.Size(122, 15);
            this.lblCategory1.TabIndex = 5;
            this.lblCategory1.Text = "Категория: Кастрюли";
            // 
            // lblStock1
            // 
            this.lblStock1.AutoSize = true;
            this.lblStock1.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblStock1.Location = new System.Drawing.Point(143, 112);
            this.lblStock1.Name = "lblStock1";
            this.lblStock1.Size = new System.Drawing.Size(95, 15);
            this.lblStock1.TabIndex = 4;
            this.lblStock1.Text = "В наличии: 6 шт.";
            // 
            // lblPrice1
            // 
            this.lblPrice1.AutoSize = true;
            this.lblPrice1.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPrice1.Location = new System.Drawing.Point(143, 92);
            this.lblPrice1.Name = "lblPrice1";
            this.lblPrice1.Size = new System.Drawing.Size(81, 15);
            this.lblPrice1.TabIndex = 3;
            this.lblPrice1.Text = "Цена: 2 600 ₽";
            // 
            // lblManufacturer1
            // 
            this.lblManufacturer1.AutoSize = true;
            this.lblManufacturer1.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblManufacturer1.Location = new System.Drawing.Point(143, 72);
            this.lblManufacturer1.Name = "lblManufacturer1";
            this.lblManufacturer1.Size = new System.Drawing.Size(139, 15);
            this.lblManufacturer1.TabIndex = 2;
            this.lblManufacturer1.Text = "Производитель: Webber";
            // 
            // lblName1
            // 
            this.lblName1.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblName1.Location = new System.Drawing.Point(143, 19);
            this.lblName1.Name = "lblName1";
            this.lblName1.Size = new System.Drawing.Size(215, 14);
            this.lblName1.TabIndex = 1;
            this.lblName1.Text = "Название";
            // 
            // picProduct1
            // 
            this.picProduct1.Location = new System.Drawing.Point(12, 18);
            this.picProduct1.Name = "picProduct1";
            this.picProduct1.Size = new System.Drawing.Size(120, 120);
            this.picProduct1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picProduct1.TabIndex = 0;
            this.picProduct1.TabStop = false;
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCount.Location = new System.Drawing.Point(16, 115);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(138, 15);
            this.lblCount.TabIndex = 18;
            this.lblCount.Text = "Найдено: 0 из 0 товаров";
            // 
            // flowProducts
            // 
            this.flowProducts.AutoScroll = true;
            this.flowProducts.Controls.Add(this.pnlProducts);
            this.flowProducts.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowProducts.Location = new System.Drawing.Point(0, 133);
            this.flowProducts.Name = "flowProducts";
            this.flowProducts.Size = new System.Drawing.Size(800, 317);
            this.flowProducts.TabIndex = 19;
            // 
            // pnlProducts
            // 
            this.pnlProducts.Controls.Add(this.pnlProductCard1);
            this.pnlProducts.Location = new System.Drawing.Point(3, 3);
            this.pnlProducts.Name = "pnlProducts";
            this.pnlProducts.Size = new System.Drawing.Size(797, 314);
            this.pnlProducts.TabIndex = 0;
            // 
            // picLogo
            // 
            this.picLogo.Image = global::Посуда.Properties.Resources.logo;
            this.picLogo.Location = new System.Drawing.Point(12, 12);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(60, 61);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 1;
            this.picLogo.TabStop = false;
            // 
            // btnShoppingCart
            // 
            this.btnShoppingCart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(140)))), ((int)(((byte)(81)))));
            this.btnShoppingCart.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnShoppingCart.Location = new System.Drawing.Point(86, 63);
            this.btnShoppingCart.Name = "btnShoppingCart";
            this.btnShoppingCart.Size = new System.Drawing.Size(75, 23);
            this.btnShoppingCart.TabIndex = 20;
            this.btnShoppingCart.Text = "Корзина";
            this.btnShoppingCart.UseVisualStyleBackColor = false;
            this.btnShoppingCart.Click += new System.EventHandler(this.btnShoppingCart_Click);
            // 
            // btnControlOrders
            // 
            this.btnControlOrders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(140)))), ((int)(((byte)(81)))));
            this.btnControlOrders.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnControlOrders.Location = new System.Drawing.Point(182, 62);
            this.btnControlOrders.Name = "btnControlOrders";
            this.btnControlOrders.Size = new System.Drawing.Size(151, 23);
            this.btnControlOrders.TabIndex = 21;
            this.btnControlOrders.Text = "Управление заказами";
            this.btnControlOrders.UseVisualStyleBackColor = false;
            this.btnControlOrders.Click += new System.EventHandler(this.btnControlOrders_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnControlOrders);
            this.Controls.Add(this.btnShoppingCart);
            this.Controls.Add(this.flowProducts);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.btnSortDesc);
            this.Controls.Add(this.btnSortAsc);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.cmbFilter);
            this.Controls.Add(this.lblFilter);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.picLogo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Главная";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.pnlProductCard1.ResumeLayout(false);
            this.pnlProductCard1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picProduct1)).EndInit();
            this.flowProducts.ResumeLayout(false);
            this.pnlProducts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.ComboBox cmbFilter;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSortAsc;
        private System.Windows.Forms.Button btnSortDesc;
        private System.Windows.Forms.Panel pnlProductCard1;
        private System.Windows.Forms.Label lblName1;
        private System.Windows.Forms.PictureBox picProduct1;
        private System.Windows.Forms.Label lblCategory1;
        private System.Windows.Forms.Label lblStock1;
        private System.Windows.Forms.Label lblPrice1;
        private System.Windows.Forms.Label lblManufacturer1;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label lblAvailability;
        private System.Windows.Forms.PictureBox picCart;
        private System.Windows.Forms.FlowLayoutPanel flowProducts;
        private System.Windows.Forms.Panel pnlProducts;
        private System.Windows.Forms.Button btnShoppingCart;
        private System.Windows.Forms.Button btnControlOrders;
        private System.Windows.Forms.Label lblDescription1;
    }
}