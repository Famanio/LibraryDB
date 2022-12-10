using LibraryDB.Objects;
using LibraryDB.DB;
using LibraryDB.View;
using System.Data;

namespace LibraryDB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            string qw = "search";
            Reader reader = new Reader();
            DataTable dt = new DataTable();
            dt = new Reader.search(qw);
        }
    }
}