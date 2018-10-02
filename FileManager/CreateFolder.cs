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
    public partial class CreateFolder : Form
    {
        public string path = "";
        public bool create = false;
        public CreateFolder()
        { 
            
            InitializeComponent();
            label1.Text="Enter the name";
            textBox1.KeyDown += textBox1_KeyDown;
        }
        public CreateFolder(bool file)
        {
            
            InitializeComponent();
            label1.Text = "Enter the name";
            textBox1.KeyDown += textBox1_KeyDown;
        }
        void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                buttonCreate_Click(sender, e);
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                create = true;
                path = textBox1.Text;
                Close();
            }
            else
                MessageBox.Show("Name is empty!", "Error");
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            create = false;
            Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
