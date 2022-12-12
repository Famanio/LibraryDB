using LibraryDB.Objects;
using LibraryDB.DB;
using LibraryDB.View;
using System.Data;
using MySql.Data.MySqlClient;

namespace LibraryDB
{
    public partial class Form1 : Form
    {
        DataTable dt = new DataTable();
        VIewDBObjects view = new VIewDBObjects();

        public Form1()
        {
            InitializeComponent();
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            try
            {
                dt.Clear();
                dt = view.chooseTable(selectTableCB.Text);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Возникла ошибка загрузки: {ex}", "Ошибка сервера", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            mainDGV.DataSource = dt;
        }

        private void searchTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                try
                {
                    string query = searchTextBox.Text;
                    query = System.Text.RegularExpressions.Regex.Replace(query, @"\s+", " ");
                    dt.Clear();
                    dt = view.searchRows(query);
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Возникла ошибка загрузки: {ex}", "Ошибка сервера", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                mainDGV.DataSource = dt;
            }
        }

        private void mainDGV_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                ulong selectedRowCount = (ulong)mainDGV.Rows.GetRowCount(DataGridViewElementStates.Selected);
                if (selectedRowCount > 0)
                {
                    int dgvID = (int)mainDGV.Rows[mainDGV.SelectedRows[0].Index].Cells[0].Value;
                    string[] dataDGV = new string[mainDGV.ColumnCount];
                    objectDGV.Columns.Clear();
                    for (int i = 0; i < mainDGV.ColumnCount; i++)
                    {
                        objectDGV.Columns.Add("", "");
                    }
                    dataDGV = prepareEditing(view.choosenTableID, dgvID, dataDGV.Length);
                    objectDGV.Rows.Add(dataDGV);
                    MessageBox.Show("Строка добавлена на редактирование", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Возникла ошибка загрузки: {ex}", "Ошибка сервера", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {

        }

        private void changeButton_Click(object sender, EventArgs e)
        {

        }

        private void deleteButton_Click(object sender, EventArgs e)
        {

        }

        private string[] prepareEditing(int tableID, int objID, int length)
        {
            try
            {
                string[] obj = view.getStringRow(objID);
                switch (tableID)
                {
                    case 1:
                        for (int i = 1; i <= length; i++)
                        {
                            this.Controls.Find($"label{i}", true)[0].Visible = true;
                            this.Controls.Find($"textBox{i}", true)[0].Visible = true;

                            this.Controls.Find($"label{i}", true)[0].Text = view.bookLendingLabels[i - 1];
                            this.Controls.Find($"textBox{i}", true)[0].Text = obj[i - 1];
                        }
                        for (int i = length + 1; i <= 13; i++)
                        {
                            this.Controls.Find($"label{i}", true)[0].Visible = false;
                            this.Controls.Find($"textBox{i}", true)[0].Visible = false;
                        }
                        break;
                    case 2:
                        for (int i = 1; i <= length; i++)
                        {
                            this.Controls.Find($"label{i}", true)[0].Visible = true;
                            this.Controls.Find($"textBox{i}", true)[0].Visible = true;

                            this.Controls.Find($"label{i}", true)[0].Text = view.bookLabels[i - 1];
                            this.Controls.Find($"textBox{i}", true)[0].Text = obj[i - 1];
                        }
                        for (int i = length + 1; i <= 13; i++)
                        {
                            this.Controls.Find($"label{i}", true)[0].Visible = false;
                            this.Controls.Find($"textBox{i}", true)[0].Visible = false;
                        }
                        break;
                    case 3:
                        for (int i = 1; i <= length; i++)
                        {
                            this.Controls.Find($"label{i}", true)[0].Visible = true;
                            this.Controls.Find($"textBox{i}", true)[0].Visible = true;

                            this.Controls.Find($"label{i}", true)[0].Text = view.readerLabels[i - 1];
                            this.Controls.Find($"textBox{i}", true)[0].Text = obj[i - 1];
                        }
                        for (int i = length + 1; i <= 13; i++)
                        {
                            this.Controls.Find($"label{i}", true)[0].Visible = false;
                            this.Controls.Find($"textBox{i}", true)[0].Visible = false;
                        }
                        break;
                    case 4:
                        for (int i = 1; i <= length; i++)
                        {
                            this.Controls.Find($"label{i}", true)[0].Visible = true;
                            this.Controls.Find($"textBox{i}", true)[0].Visible = true;

                            this.Controls.Find($"label{i}", true)[0].Text = view.librarianLabels[i - 1];
                            this.Controls.Find($"textBox{i}", true)[0].Text = obj[i - 1];
                        }
                        for (int i = length + 1; i <= 13; i++)
                        {
                            this.Controls.Find($"label{i}", true)[0].Visible = false;
                            this.Controls.Find($"textBox{i}", true)[0].Visible = false;
                        }
                        break;
                    case 5:
                        for (int i = 1; i <= length; i++)
                        {
                            this.Controls.Find($"label{i}", true)[0].Visible = true;
                            this.Controls.Find($"textBox{i}", true)[0].Visible = true;

                            this.Controls.Find($"label{i}", true)[0].Text = view.genreLabels[i - 1];
                            this.Controls.Find($"textBox{i}", true)[0].Text = obj[i - 1];
                        }
                        for (int i = length + 1; i <= 13; i++)
                        {
                            this.Controls.Find($"label{i}", true)[0].Visible = false;
                            this.Controls.Find($"textBox{i}", true)[0].Visible = false;
                        }
                        break;
                    case 6:
                        for (int i = 1; i <= length; i++)
                        {
                            this.Controls.Find($"label{i}", true)[0].Visible = true;
                            this.Controls.Find($"textBox{i}", true)[0].Visible = true;

                            this.Controls.Find($"label{i}", true)[0].Text = view.editionLabels[i - 1];
                            this.Controls.Find($"textBox{i}", true)[0].Text = obj[i - 1];
                        }
                        for (int i = length + 1; i <= 13; i++)
                        {
                            this.Controls.Find($"label{i}", true)[0].Visible = false;
                            this.Controls.Find($"textBox{i}", true)[0].Visible = false;
                        }
                        break;
                    case 7:
                        for (int i = 1; i <= length; i++)
                        {
                            this.Controls.Find($"label{i}", true)[0].Visible = true;
                            this.Controls.Find($"textBox{i}", true)[0].Visible = true;

                            this.Controls.Find($"label{i}", true)[0].Text = view.ratingLabels[i - 1];
                            this.Controls.Find($"textBox{i}", true)[0].Text = obj[i - 1];
                        }
                        for (int i = length + 1; i <= 13; i++)
                        {
                            this.Controls.Find($"label{i}", true)[0].Visible = false;
                            this.Controls.Find($"textBox{i}", true)[0].Visible = false;
                        }
                        break;
                    case 8:
                        for (int i = 1; i <= length; i++)
                        {
                            this.Controls.Find($"label{i}", true)[0].Visible = true;
                            this.Controls.Find($"textBox{i}", true)[0].Visible = true;

                            this.Controls.Find($"label{i}", true)[0].Text = view.storageLabels[i - 1];
                            this.Controls.Find($"textBox{i}", true)[0].Text = obj[i - 1];
                        }
                        for (int i = length + 1; i <= 13; i++)
                        {
                            this.Controls.Find($"label{i}", true)[0].Visible = false;
                            this.Controls.Find($"textBox{i}", true)[0].Visible = false;
                        }
                        break;
                    default:
                        MessageBox.Show($"Возникла ошибка загрузки строки:\nНе удалось загрузить данные на редактирование", "Неизвестная ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
                return obj;
            }
            catch (Exception)
            {
                MessageBox.Show($"Возникла ошибка загрузки строки:\nНе удалось загрузить данные на редактирование", "Неизвестная ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                string[] empty = new string[0];
                return empty;
            }
        }
    }
}