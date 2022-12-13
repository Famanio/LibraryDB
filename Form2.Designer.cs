namespace LibraryDB
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.helpDGV = new System.Windows.Forms.DataGridView();
            this.infoLabel = new System.Windows.Forms.Label();
            this.helpSelectButton = new System.Windows.Forms.Button();
            this.helpSelectTableCB = new System.Windows.Forms.ComboBox();
            this.helpSearchTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.helpDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // helpDGV
            // 
            this.helpDGV.AllowUserToAddRows = false;
            this.helpDGV.AllowUserToDeleteRows = false;
            this.helpDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.helpDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.helpDGV.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.helpDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.helpDGV.Location = new System.Drawing.Point(3, 41);
            this.helpDGV.Name = "helpDGV";
            this.helpDGV.ReadOnly = true;
            this.helpDGV.RowHeadersWidth = 51;
            this.helpDGV.RowTemplate.Height = 29;
            this.helpDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.helpDGV.Size = new System.Drawing.Size(794, 456);
            this.helpDGV.TabIndex = 3;
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.infoLabel.Location = new System.Drawing.Point(3, 9);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(138, 23);
            this.infoLabel.TabIndex = 7;
            this.infoLabel.Text = "Выбор таблицы:";
            // 
            // helpSelectButton
            // 
            this.helpSelectButton.Location = new System.Drawing.Point(345, 6);
            this.helpSelectButton.Name = "helpSelectButton";
            this.helpSelectButton.Size = new System.Drawing.Size(94, 29);
            this.helpSelectButton.TabIndex = 6;
            this.helpSelectButton.Text = "Загрузить";
            this.helpSelectButton.UseVisualStyleBackColor = true;
            this.helpSelectButton.Click += new System.EventHandler(this.helpSelectButton_Click);
            // 
            // helpSelectTableCB
            // 
            this.helpSelectTableCB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.helpSelectTableCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.helpSelectTableCB.FormattingEnabled = true;
            this.helpSelectTableCB.Items.AddRange(new object[] {
            "Выдача книг",
            "Книги",
            "Читатели",
            "Библиотекари",
            "Жанры",
            "Издания",
            "Возрастной рейтинг",
            "Размещение"});
            this.helpSelectTableCB.Location = new System.Drawing.Point(143, 6);
            this.helpSelectTableCB.Name = "helpSelectTableCB";
            this.helpSelectTableCB.Size = new System.Drawing.Size(196, 28);
            this.helpSelectTableCB.TabIndex = 5;
            // 
            // helpSearchTextBox
            // 
            this.helpSearchTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.helpSearchTextBox.Location = new System.Drawing.Point(601, 7);
            this.helpSearchTextBox.Name = "helpSearchTextBox";
            this.helpSearchTextBox.PlaceholderText = "Поиск";
            this.helpSearchTextBox.Size = new System.Drawing.Size(196, 27);
            this.helpSearchTextBox.TabIndex = 8;
            this.helpSearchTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.helpSearchTextBox_KeyPress);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 509);
            this.Controls.Add(this.helpSearchTextBox);
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.helpSelectButton);
            this.Controls.Add(this.helpSelectTableCB);
            this.Controls.Add(this.helpDGV);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(818, 556);
            this.Name = "Form2";
            this.Text = "Справка из БД";
            ((System.ComponentModel.ISupportInitialize)(this.helpDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DataGridView helpDGV;
        private Label infoLabel;
        private Button helpSelectButton;
        private ComboBox helpSelectTableCB;
        private TextBox helpSearchTextBox;
    }
}