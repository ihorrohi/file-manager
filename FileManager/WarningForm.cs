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
    public partial class WarningForm : Form
    {
        public bool action = false;
        public WarningForm(bool key)
        {
            InitializeComponent();
            if(key)
            {
                button1.Text = "Save";
                button3.Text = "Exit";
                label1.Text = "You didn`t save the file\nAre you sure to close?";
            }
            else
            {
                button1.Text = "Yes";
                button3.Text = "No";
                label1.Text = "Are you sure to delete?";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            action = true;
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            action = false;
            Close();
        }
    }
}
