namespace Посуда
{
    partial class EditProductsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditProductsForm));
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblEditTitle = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.picProduct = new System.Windows.Forms.PictureBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txbName = new System.Windows.Forms.TextBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cmbFilterCategory = new System.Windows.Forms.ComboBox();
            this.lblManufacturer = new System.Windows.Forms.Label();
            this.cmbFilterManufacturer = new System.Windows.Forms.ComboBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.txbPrice = new System.Windows.Forms.TextBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.txbQuantity = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txbDescription = new System.Windows.Forms.TextBox();
            this.lblPiece = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnEditImage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // picLogo
            // 
            this.picLogo.Image = global::Посуда.Properties.Resources.logo;
            this.picLogo.Location = new System.Drawing.Point(12, 12);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(60, 61);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 2;
            this.picLogo.TabStop = false;
            // 
            // lblEditTitle
            // 
            this.lblEditTitle.AutoSize = true;
            this.lblEditTitle.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblEditTitle.Location = new System.Drawing.Point(78, 12);
            this.lblEditTitle.Name = "lblEditTitle";
            this.lblEditTitle.Size = new System.Drawing.Size(229, 29);
            this.lblEditTitle.TabIndex = 9;
            this.lblEditTitle.Text = "Окно редактирования";
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(140)))), ((int)(((byte)(81)))));
            this.btnBack.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnBack.Location = new System.Drawing.Point(708, 12);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(80, 30);
            this.btnBack.TabIndex = 11;
            this.btnBack.Text = "Назад";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // picProduct
            // 
            this.picProduct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picProduct.Location = new System.Drawing.Point(12, 98);
            this.picProduct.Name = "picProduct";
            this.picProduct.Size = new System.Drawing.Size(300, 200);
            this.picProduct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picProduct.TabIndex = 12;
            this.picProduct.TabStop = false;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblName.Location = new System.Drawing.Point(333, 98);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(134, 20);
            this.lblName.TabIndex = 13;
            this.lblName.Text = "Название товара:";
            this.lblName.Click += new System.EventHandler(this.lblName1_Click);
            // 
            // txbName
            // 
            this.txbName.Location = new System.Drawing.Point(473, 100);
            this.txbName.Multiline = true;
            this.txbName.Name = "txbName";
            this.txbName.Size = new System.Drawing.Size(315, 33);
            this.txbName.TabIndex = 14;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCategory.Location = new System.Drawing.Point(333, 164);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(88, 20);
            this.lblCategory.TabIndex = 15;
            this.lblCategory.Text = "Категория:";
            // 
            // cmbFilterCategory
            // 
            this.cmbFilterCategory.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbFilterCategory.FormattingEnabled = true;
            this.cmbFilterCategory.Items.AddRange(new object[] {
            "Webber",
            "Luminarc",
            "Нева",
            "Tefal",
            "Solaris",
            "Galaxy",
            "Эмаль"});
            this.cmbFilterCategory.Location = new System.Drawing.Point(337, 187);
            this.cmbFilterCategory.Name = "cmbFilterCategory";
            this.cmbFilterCategory.Size = new System.Drawing.Size(140, 23);
            this.cmbFilterCategory.TabIndex = 16;
            this.cmbFilterCategory.Text = "Выбрать категорию";
            // 
            // lblManufacturer
            // 
            this.lblManufacturer.AutoSize = true;
            this.lblManufacturer.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblManufacturer.Location = new System.Drawing.Point(520, 164);
            this.lblManufacturer.Name = "lblManufacturer";
            this.lblManufacturer.Size = new System.Drawing.Size(125, 20);
            this.lblManufacturer.TabIndex = 17;
            this.lblManufacturer.Text = "Производитель";
            // 
            // cmbFilterManufacturer
            // 
            this.cmbFilterManufacturer.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbFilterManufacturer.FormattingEnabled = true;
            this.cmbFilterManufacturer.Items.AddRange(new object[] {
            "Webber",
            "Luminarc",
            "Нева",
            "Tefal",
            "Solaris",
            "Galaxy",
            "Эмаль"});
            this.cmbFilterManufacturer.Location = new System.Drawing.Point(524, 187);
            this.cmbFilterManufacturer.Name = "cmbFilterManufacturer";
            this.cmbFilterManufacturer.Size = new System.Drawing.Size(157, 23);
            this.cmbFilterManufacturer.TabIndex = 18;
            this.cmbFilterManufacturer.Text = "Выбрать производителя";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPrice.Location = new System.Drawing.Point(333, 238);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(49, 20);
            this.lblPrice.TabIndex = 19;
            this.lblPrice.Text = "Цена:";
            // 
            // txbPrice
            // 
            this.txbPrice.Location = new System.Drawing.Point(388, 240);
            this.txbPrice.Name = "txbPrice";
            this.txbPrice.Size = new System.Drawing.Size(89, 20);
            this.txbPrice.TabIndex = 20;
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblQuantity.Location = new System.Drawing.Point(520, 240);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(100, 20);
            this.lblQuantity.TabIndex = 21;
            this.lblQuantity.Text = "Количество:";
            // 
            // txbQuantity
            // 
            this.txbQuantity.Location = new System.Drawing.Point(626, 242);
            this.txbQuantity.Name = "txbQuantity";
            this.txbQuantity.Size = new System.Drawing.Size(43, 20);
            this.txbQuantity.TabIndex = 22;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDescription.Location = new System.Drawing.Point(333, 278);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(139, 20);
            this.lblDescription.TabIndex = 23;
            this.lblDescription.Text = "Описание товара:";
            // 
            // txbDescription
            // 
            this.txbDescription.Location = new System.Drawing.Point(337, 301);
            this.txbDescription.Multiline = true;
            this.txbDescription.Name = "txbDescription";
            this.txbDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txbDescription.Size = new System.Drawing.Size(315, 79);
            this.txbDescription.TabIndex = 24;
            // 
            // lblPiece
            // 
            this.lblPiece.AutoSize = true;
            this.lblPiece.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPiece.Location = new System.Drawing.Point(675, 242);
            this.lblPiece.Name = "lblPiece";
            this.lblPiece.Size = new System.Drawing.Size(31, 20);
            this.lblPiece.TabIndex = 25;
            this.lblPiece.Text = "шт.";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(140)))), ((int)(((byte)(81)))));
            this.btnSave.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSave.Location = new System.Drawing.Point(473, 11);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(229, 30);
            this.btnSave.TabIndex = 26;
            this.btnSave.Text = "Сохранить изменения";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnEditImage
            // 
            this.btnEditImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(140)))), ((int)(((byte)(81)))));
            this.btnEditImage.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnEditImage.Location = new System.Drawing.Point(44, 304);
            this.btnEditImage.Name = "btnEditImage";
            this.btnEditImage.Size = new System.Drawing.Size(229, 30);
            this.btnEditImage.TabIndex = 27;
            this.btnEditImage.Text = "Добавить/изменить фото";
            this.btnEditImage.UseVisualStyleBackColor = false;
            this.btnEditImage.Click += new System.EventHandler(this.btnEditImage_Click);
            // 
            // EditProductsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnEditImage);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblPiece);
            this.Controls.Add(this.txbDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txbQuantity);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.txbPrice);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.cmbFilterManufacturer);
            this.Controls.Add(this.lblManufacturer);
            this.Controls.Add(this.cmbFilterCategory);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.txbName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.picProduct);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lblEditTitle);
            this.Controls.Add(this.picLogo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EditProductsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавление/изменение товара";
            this.Load += new System.EventHandler(this.EditProductForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picProduct)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblEditTitle;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.PictureBox picProduct;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txbName;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbFilterCategory;
        private System.Windows.Forms.Label lblManufacturer;
        private System.Windows.Forms.ComboBox cmbFilterManufacturer;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txbPrice;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.TextBox txbQuantity;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txbDescription;
        private System.Windows.Forms.Label lblPiece;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnEditImage;
    }
}