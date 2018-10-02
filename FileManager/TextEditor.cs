using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FileManager1
{
    public partial class TextEditor : Form
    {
        string path;
        public string Content
        {
            get
            {
                return richTextBox1.Text;
            }
            set
            {
                richTextBox1.Text = value;
            }
        }
        public TextEditor(string content, string path)
        {
            InitializeComponent();
            Content = content;
            this.path = path;
            richTextBox1.TextChanged += richtextBox1_TextChanged;
            richTextBox1.SelectionStart = 0;
        }

        void richtextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                File.WriteAllText(path, Content, Encoding.GetEncoding(1251));
            }
            catch
            {
                MessageBox.Show("Couldn`t save text!", "Error");
            }

        }

        private void ClearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Content = "";
        }

        private void ToUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int start = richTextBox1.SelectionStart;
            int lenght = richTextBox1.SelectionLength;
            string firstPart = richTextBox1.SelectedText.ToUpper();
            string secondPart = Content.Substring(start + lenght);
            Content = Content.Substring(0, start) + firstPart + secondPart;
        }

        private void ToDownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int start = richTextBox1.SelectionStart;
            int lenght = richTextBox1.SelectionLength;
            string firstPart = richTextBox1.SelectedText.ToLower();
            string secondPart = Content.Substring(start + lenght);
            Content = Content.Substring(0, start) + firstPart + secondPart;
        }
        private void SelectDefaultBackColor()
        {
            richTextBox1.SelectionStart = 0;
            richTextBox1.SelectionLength = richTextBox1.Text.Length;
            richTextBox1.SelectionBackColor = Color.White;
            richTextBox1.SelectionLength = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string WordKey = textBox2.Text;
            SelectDefaultBackColor();
            Presenter.SearchByCobination(richTextBox1, WordKey);

        }

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                SelectDefaultBackColor();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            string WordKey = textBox2.Text;
            if (e.KeyData == Keys.Enter)
            {
                SelectDefaultBackColor();
                Presenter.SearchByCobination(richTextBox1, WordKey);
            }
        }
    }
}