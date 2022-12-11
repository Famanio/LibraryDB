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
                    dt = view.searchRows(view.choosenTableID, query);
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
            ulong selectedRowCount = (ulong)mainDGV.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                int currentrow = mainDGV.SelectedRows[0].Index;
                string[] dataDGV = new string[mainDGV.ColumnCount];
                objectDGV.Columns.Clear();

                for (int i = 0; i < mainDGV.ColumnCount; i++)
                {
                    objectDGV.Columns.Add("", ""); //добавить пустой столбец (названия убрать сотв. свойством)
                }

                objectDGV.Rows.Add(dataDGV); //добавление

                MessageBox.Show("Строка добавлена на редактирование", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}