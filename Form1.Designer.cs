namespace LibraryDB
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.selectTableCB = new System.Windows.Forms.ComboBox();
            this.selectButton = new System.Windows.Forms.Button();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.mainDGV = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.deleteButton = new System.Windows.Forms.Button();
            this.changeButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainDGV)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // selectTableCB
            // 
            this.selectTableCB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.selectTableCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectTableCB.FormattingEnabled = true;
            this.selectTableCB.Location = new System.Drawing.Point(143, 2);
            this.selectTableCB.Name = "selectTableCB";
            this.selectTableCB.Size = new System.Drawing.Size(196, 28);
            this.selectTableCB.TabIndex = 0;
            // 
            // selectButton
            // 
            this.selectButton.Location = new System.Drawing.Point(345, 2);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(94, 29);
            this.selectButton.TabIndex = 1;
            this.selectButton.Text = "Загрузить";
            this.selectButton.UseVisualStyleBackColor = true;
            // 
            // searchTextBox
            // 
            this.searchTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchTextBox.Location = new System.Drawing.Point(720, 3);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.PlaceholderText = "Поиск";
            this.searchTextBox.Size = new System.Drawing.Size(180, 27);
            this.searchTextBox.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(3, 36);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(897, 498);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.mainDGV);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(889, 465);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Таблица";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // mainDGV
            // 
            this.mainDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainDGV.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.mainDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mainDGV.Location = new System.Drawing.Point(6, 6);
            this.mainDGV.Name = "mainDGV";
            this.mainDGV.RowHeadersWidth = 51;
            this.mainDGV.RowTemplate.Height = 29;
            this.mainDGV.Size = new System.Drawing.Size(877, 453);
            this.mainDGV.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridView1);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(889, 465);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Редактирование";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(877, 30);
            this.dataGridView1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.deleteButton);
            this.groupBox1.Controls.Add(this.changeButton);
            this.groupBox1.Controls.Add(this.addButton);
            this.groupBox1.Location = new System.Drawing.Point(670, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(213, 417);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Запись";
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteButton.Location = new System.Drawing.Point(16, 179);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(180, 58);
            this.deleteButton.TabIndex = 2;
            this.deleteButton.Text = "Удалить";
            this.deleteButton.UseVisualStyleBackColor = true;
            // 
            // changeButton
            // 
            this.changeButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.changeButton.Location = new System.Drawing.Point(17, 101);
            this.changeButton.Name = "changeButton";
            this.changeButton.Size = new System.Drawing.Size(180, 58);
            this.changeButton.TabIndex = 1;
            this.changeButton.Text = "Изменить";
            this.changeButton.UseVisualStyleBackColor = true;
            // 
            // addButton
            // 
            this.addButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addButton.Location = new System.Drawing.Point(17, 26);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(180, 58);
            this.addButton.TabIndex = 0;
            this.addButton.Text = "Добавить";
            this.addButton.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Location = new System.Drawing.Point(6, 52);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(658, 407);
            this.panel1.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(889, 465);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Запросы";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "Выбор таблицы:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 546);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.selectButton);
            this.Controls.Add(this.selectTableCB);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(921, 593);
            this.Name = "Form1";
            this.Text = "База данных библиотеки";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainDGV)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox selectTableCB;
        private Button selectButton;
        private TextBox searchTextBox;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private DataGridView mainDGV;
        private DataGridView dataGridView1;
        private GroupBox groupBox1;
        private Button deleteButton;
        private Button changeButton;
        private Button addButton;
        private Panel panel1;
        private Label label1;
    }
}