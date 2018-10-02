using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileManager1
{
    public partial class SearchForm : Form
    {
        public string Content;
        public bool done = false;
        public SearchForm()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string key = textBox1.Text;
            if (key.Trim() == "")
            {
                MessageBox.Show("Enter workey", "Oops..");
            }
            else
            {
                Content = key;
                done = true;
                Close();
            }
        }
    }
}
