using LibraryDB.Objects;
using LibraryDB.DB;
using LibraryDB.View;
using System.Data;
using MySql.Data.MySqlClient;

namespace LibraryDB
{
    public partial class Form1 : Form
    {
        int dgvID;
        DataTable dt = new DataTable();
        VIewDBObjects view = new VIewDBObjects();
        DBExtraReqRequests req = new DBExtraReqRequests();

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
            objectDGV.Columns.Clear();
            loadEditing(view.choosenTableID, mainDGV.ColumnCount);
        }

        private void searchTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                try
                {
                    string query = searchTextBox.Text;
                    query = System.Text.RegularExpressions.Regex.Replace(query, @"\s+", " ");
                    query = query.Trim();
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
            clearEditing();
            try
            {
                ulong selectedRowCount = (ulong)mainDGV.Rows.GetRowCount(DataGridViewElementStates.Selected);
                if (selectedRowCount > 0)
                {
                    dgvID = Convert.ToInt32(mainDGV.Rows[mainDGV.SelectedRows[0].Index].Cells[0].Value);
                    string[] dataDGV = new string[mainDGV.ColumnCount];
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
            try
            {
                string[] obj = new string[mainDGV.ColumnCount];
                int dgvID = 0;
                for (int i = 1; i <= obj.Length; i++)
                {
                    string elem = this.Controls.Find($"textBox{i}", true)[0].Text;
                    elem = System.Text.RegularExpressions.Regex.Replace(elem, @"\s+", " ");
                    obj[i - 1] = elem.Trim();
                }
                view.viewModeRowDB(obj, dgvID, VIewDBObjects.mode.add);
                dt.Clear();
                dt = view.chooseTable(selectTableCB.Text);
                mainDGV.DataSource = dt;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Возникла ошибка добавления: {ex}", "Ошибка сервера", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            clearEditing();
            
            
        }

        private void changeButton_Click(object sender, EventArgs e)
        {
            try
            {
                string[] obj = new string[mainDGV.ColumnCount];
                for (int i = 1; i <= obj.Length; i++)
                {
                    string elem = this.Controls.Find($"textBox{i}", true)[0].Text;
                    elem = System.Text.RegularExpressions.Regex.Replace(elem, @"\s+", " ");
                    obj[i - 1] = elem.Trim();
                }
                view.viewModeRowDB(obj, dgvID, VIewDBObjects.mode.upd);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Возникла ошибка при изменении: {ex}", "Ошибка сервера", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dt.Clear();
            clearEditing();
            dt = view.chooseTable(selectTableCB.Text);
            mainDGV.DataSource = dt;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                string[] obj = new string[mainDGV.ColumnCount];
                for (int i = 1; i <= obj.Length; i++)
                {
                    string elem = this.Controls.Find($"textBox{i}", true)[0].Text;
                    elem = System.Text.RegularExpressions.Regex.Replace(elem, @"\s+", " ");
                    obj[i - 1] = elem.Trim();
                }
                view.viewModeRowDB(obj, dgvID, VIewDBObjects.mode.del);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Возникла ошибка при удалении: {ex}", "Ошибка сервера", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dt.Clear();
            clearEditing();
            dt = view.chooseTable(selectTableCB.Text);
            mainDGV.DataSource = dt;
        }

        private void helpButton_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2();
            newForm.Show();
        }

        private void req1Button_Click(object sender, EventArgs e)
        {
            try
            {
                reqDGV.DataSource = null;
                reqDGV.DataSource = req.getDebtors();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Возникла ошибка при загрузке: {ex}", "Ошибка сервера", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void req2Button_Click(object sender, EventArgs e)
        {
            try
            {
                reqDGV.DataSource = null;
                reqDGV.DataSource = req.getUnderageReaders();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Возникла ошибка при загрузке: {ex}", "Ошибка сервера", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void req3Button_Click(object sender, EventArgs e)
        {
            try
            {
                reqDGV.DataSource = null;
                reqDGV.DataSource = req.getEndedBooks();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Возникла ошибка при загрузке: {ex}", "Ошибка сервера", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loadEditing(int tableID, int rows)
        {
            clearEditing();

            for (int i = 1; i <= rows; i++)
            {
                this.Controls.Find($"label{i}", true)[0].Visible = true;
                this.Controls.Find($"textBox{i}", true)[0].Visible = true;

            }
            for (int i = rows + 1; i <= 13; i++)
            {
                this.Controls.Find($"label{i}", true)[0].Visible = false;
                this.Controls.Find($"textBox{i}", true)[0].Visible = false;
            }

            switch (tableID)
            {
                case 1:
                    for (int i = 1; i <= rows; i++)
                    {
                        this.Controls.Find($"label{i}", true)[0].Text = view.bookLendingLabels[i - 1];
                    }
                    break;
                case 2:
                    for (int i = 1; i <= rows; i++)
                    {
                        this.Controls.Find($"label{i}", true)[0].Text = view.bookLabels[i - 1];
                    }
                    break;
                case 3:
                    for (int i = 1; i <= rows; i++)
                    {
                        this.Controls.Find($"label{i}", true)[0].Text = view.readerLabels[i - 1];
                    }
                    break;
                case 4:
                    for (int i = 1; i <= rows; i++)
                    {
                        this.Controls.Find($"label{i}", true)[0].Text = view.librarianLabels[i - 1];
                    }
                    break;
                case 5:
                    for (int i = 1; i <= rows; i++)
                    {
                        this.Controls.Find($"label{i}", true)[0].Text = view.genreLabels[i - 1];
                    }
                    break;
                case 6:
                    for (int i = 1; i <= rows; i++)
                    {
                        this.Controls.Find($"label{i}", true)[0].Text = view.editionLabels[i - 1];
                    }
                    break;
                case 7:
                    for (int i = 1; i <= rows; i++)
                    {
                        this.Controls.Find($"label{i}", true)[0].Text = view.ratingLabels[i - 1];
                    }
                   break;
                case 8:
                    for (int i = 1; i <= rows; i++)
                    {
                        this.Controls.Find($"label{i}", true)[0].Text = view.storageLabels[i - 1];
                    }
                    break;
                default:
                    MessageBox.Show($"Возникла ошибка загрузки формы:\nНе удалось изменить данные на форме \"Редактирование\"", "Неизвестная ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private string[] prepareEditing(int tableID, int objID, int length)
        {
            try
            {
                string[] obj = view.getStringRow(objID);
                for (int i = 1; i <= length; i++)
                {
                    this.Controls.Find($"textBox{i}", true)[0].Text = obj[i - 1];
                }
                return obj;
            }
            catch (Exception)
            {
                MessageBox.Show($"Возникла ошибка загрузки строки:\nНе удалось загрузить надписи для полей ввода в редактировании", "Неизвестная ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                string[] empty = new string[0];
                return empty;
            }
        }

        private void clearEditing()
        {
            objectDGV.Columns.Clear();

            for (int i = 1; i <= 13; i++)
            {
                this.Controls.Find($"textBox{i}", true)[0].Text = null;
            }
        }
    }
}