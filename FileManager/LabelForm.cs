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
    public partial class LabelForm : Form
    {
        public string text = "";
        public bool done = false;
        public LabelForm(int type)
        {
            InitializeComponent();
            if (type == 1)
            {
                label1.Text = "Enter the name of folder";
                buttonActions.Text = "Create";
                this.Text = "Create folder";
            }
            else if(type == 0)
            {
                label1.Text = "Enter the name of file";
                buttonActions.Text = "Create";
                this.Text = "Create file";


            }
            else if(type == -1)
            {
                label1.Text = "Enter the new name";
                buttonActions.Text = "Rename";
                this.Text = "Rename";
            }
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
                done = true;
                text = textBox1.Text;
                Close();
            }
            else
            {
                MessageBox.Show("Name is empty!", "Error");
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            done = false;
            Close();
        }

    }
}
