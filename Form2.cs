using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryDB.Objects;
using LibraryDB.DB;
using LibraryDB.View;
using MySql.Data.MySqlClient;

namespace LibraryDB
{
    public partial class Form2 : Form
    {
        DataTable dt = new DataTable();
        VIewDBObjects view = new VIewDBObjects();

        public Form2()
        {
            InitializeComponent();
        }

        private void helpSelectButton_Click(object sender, EventArgs e)
        {
            try
            {
                dt.Clear();
                dt = view.chooseTable(helpSelectTableCB.Text);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Возникла ошибка загрузки: {ex}", "Ошибка сервера", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            helpDGV.DataSource = dt;
        }

        private void helpSearchTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                try
                {
                    string query = helpSearchTextBox.Text;
                    query = System.Text.RegularExpressions.Regex.Replace(query, @"\s+", " ");
                    dt.Clear();
                    dt = view.searchRows(query);
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Возникла ошибка загрузки: {ex}", "Ошибка сервера", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                helpDGV.DataSource = dt;
            }
        }
    }
}
