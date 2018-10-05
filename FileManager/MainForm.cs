using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace FileManager1
{
    public partial class FileManager : Form
    {

        string[] drives;
        int activeListView;
        Presenter presenter;
        public FileManager()
        {

            InitializeComponent();
            presenter = new Presenter(this);
            listView1.MouseDoubleClick += ListView1_MouseDoubleClick;
            listView2.MouseDoubleClick += ListView2_MouseDoubleClick;
            listView1.Enter += ListView1_Enter;
            listView2.Enter += ListView2_Enter;
            drives = Environment.GetLogicalDrives();
            for (int i = 0; i < drives.Length; i++)
            {
                comboBox1.Items.Add(drives[i]);
                comboBox2.Items.Add(drives[i]);
            }
            comboBox1.Text = drives[0];
            comboBox2.Text = drives[0];
            presenter.Refresh(listView1, @drives[0]);
            presenter.Refresh(listView2, @drives[0]);
            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            comboBox2.SelectedIndexChanged += ComboBox2_SelectedIndexChanged;
        }

        void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            string path = drives[comboBox2.SelectedIndex];

            try
            {
                presenter.Refresh(listView2, path);
                presenter.CurrentPath2 = path;
            }
            catch (IOException ex)
            {
                MessageBox.Show("Not found", "Error");
                comboBox1.Text = drives[0];
                path = @"C:\";
                presenter.Refresh(listView2, path);
                presenter.CurrentPath2 = path;
            }
        }

        void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            string path = drives[comboBox1.SelectedIndex];

            try
            {
                presenter.Refresh(listView1, path);
                presenter.CurrentPath1 = path;
            }
            catch (IOException ex)
            {
                MessageBox.Show("Not found", "Error");
                comboBox1.Text = drives[0];
                path = @"C:\";
                presenter.Refresh(listView1, path);
                presenter.CurrentPath1 = path;
            }
        }

        void ListView2_Enter(object sender, EventArgs e)
        {
            activeListView = 2;
        }

        void ListView1_Enter(object sender, EventArgs e)
        {
            activeListView = 1;
        }


        void ListView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            presenter.OpenItem(listView1, true);
        }
        void ListView2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            presenter.OpenItem(listView2, false);
        }

        private void CopyMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (activeListView == 1)
                {
                    if (listView1.SelectedItems.Count > 0)
                    {
                        presenter.AddToBuffer(listView1, true);
                    }
                }
                else
                    if (listView2.SelectedItems.Count > 0)
                {
                    presenter.AddToBuffer(listView2, false);
                }


            }
            catch
            {
                MessageBox.Show("Copy failed", "Error");
            }
        }

        private void MoveMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (activeListView == 1)
                {
                    if (listView1.SelectedItems.Count > 0)
                    {
                        presenter.Move(listView1, true);
                    }
                }
                else
                    if (listView2.SelectedItems.Count > 0)
                    presenter.Move(listView2, false);
            }
            catch (IOException ex)
            {
                MessageBox.Show("Impossible", "Error");
            }
            catch
            {
                MessageBox.Show("Copy error", "Error");
            }
            finally
            {
                presenter.Refresh(listView1, presenter.CurrentPath1);
                presenter.Refresh(listView2, presenter.CurrentPath2);
            }
        }

        private void DeleteMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (activeListView == 1)
                {
                    if (listView1.SelectedItems.Count > 0)
                    {
                        presenter.Delete(listView1, true);
                    }
                }
                else
                    if (listView2.SelectedItems.Count > 0)
                    presenter.Delete(listView2, false);

            }
            catch
            {
                MessageBox.Show("Delete error", "Error");
            }
            finally
            {
                presenter.Refresh(listView1, presenter.CurrentPath1);
                presenter.Refresh(listView2, presenter.CurrentPath2);
            }
        }

        private void ButtonBack1_Click(object sender, EventArgs e)
        {
            presenter.Back(listView1, true);
        }

        private void ButtonBack2_Click(object sender, EventArgs e)
        {
            presenter.Back(listView2, false);
        }

        private void ButtonRefresh1_Click(object sender, EventArgs e)
        {
            presenter.Refresh(listView1, presenter.CurrentPath1);
        }

        private void ButtonRefresh2_Click(object sender, EventArgs e)
        {
            presenter.Refresh(listView2, presenter.CurrentPath2);
        }
        private void InsertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (activeListView == 1)
                    presenter.Paste(listView1, true);
                else
                    presenter.Paste(listView2, false);

            }
            catch (IOException ex)
            {
                MessageBox.Show("Impossible", "Error");
            }
            catch
            {
                MessageBox.Show("Copy error", "Error");
            }
            finally
            {
                presenter.Refresh(listView1, presenter.CurrentPath1);
                presenter.Refresh(listView2, presenter.CurrentPath2);
            }
        }

        private void ButtonAddFolder1_Click(object sender, EventArgs e)
        {
            presenter.CreateNewFolder(true);
            presenter.Refresh(listView1, presenter.CurrentPath1);
            presenter.Refresh(listView2, presenter.CurrentPath2);
        }

        private void ButtonAddFile1_Click(object sender, EventArgs e)
        {
            presenter.CreateNewFile(true);
            presenter.Refresh(listView1, presenter.CurrentPath1);
            presenter.Refresh(listView2, presenter.CurrentPath2);
        }

        private void ButtonAddFolder2_Click(object sender, EventArgs e)
        {
            presenter.CreateNewFolder(false);
            presenter.Refresh(listView1, presenter.CurrentPath1);
            presenter.Refresh(listView2, presenter.CurrentPath2);
        }

        private void ButtonAddFile2_Click(object sender, EventArgs e)
        {
            presenter.CreateNewFile(false);
            presenter.Refresh(listView1, presenter.CurrentPath1);
            presenter.Refresh(listView2, presenter.CurrentPath2);
        }

        private void AboutProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Made by Ihor Piontkovskyi 2018", "About program");
        }


        private void MoveDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (activeListView == 1)
            {
                presenter.MoveToDirectory(listView1, true);
            }
            else
                presenter.MoveToDirectory(listView2, false);

            presenter.Refresh(listView1, presenter.CurrentPath1);
            presenter.Refresh(listView2, presenter.CurrentPath2);
        }

        private void SearchForUnrepeatableWordsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (activeListView == 1)
            {
                presenter.WordsIncludesInFile(listView1, true);
            }
            else
            {
                presenter.WordsIncludesInFile(listView1, false); 
            }
        }

        private void SearchHTMLFileByTitleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (activeListView == 1)
            {
                presenter.SearchHtmlByTitle(listView1, true);
            }
            else
            {
                presenter.SearchHtmlByTitle(listView2, false);
            }
        }


        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(Environment.CurrentDirectory.ToString() + "Resource\\Help.txt");
        }

        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (activeListView == 1)
            {
                presenter.Rename(listView1, true);
            }
            else
            {
                presenter.Rename(listView2, false);
            }
            presenter.Refresh(listView1, presenter.CurrentPath1);
            presenter.Refresh(listView2, presenter.CurrentPath2);
        }

        private void selectForMergeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (activeListView == 1)
            {
                presenter.Select(listView1, true);
            }
            else
            {
                presenter.Select(listView2, false);
            }
        }

        private void mergeHTMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (activeListView == 1)
            {
                presenter.Merging(listView1, true);
            }
            else
            {
                presenter.Merging(listView2, false);
            }
            presenter.Refresh(listView1, presenter.CurrentPath1);
            presenter.Refresh(listView2, presenter.CurrentPath2);
        }
    }
}
