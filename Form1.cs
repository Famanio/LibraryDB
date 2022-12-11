using LibraryDB.Objects;
using LibraryDB.DB;
using LibraryDB.View;
using System.Data;

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
            dt = view.chooseTable(selectTableCB.Text);
            mainDGV.DataSource = dt;
        }
    }
}