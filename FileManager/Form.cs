using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.XPath;
using System.Xml;
using System.IO;

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
            
            
            listView1.MouseDoubleClick += listView1_MouseDoubleClick;
            listView2.MouseDoubleClick += listView2_MouseDoubleClick;
            listView1.Enter += listView1_Enter;
            listView2.Enter += listView2_Enter;
            drives = Environment.GetLogicalDrives();
            for(int i=0;i<drives.Length;i++)
            {
                comboBox1.Items.Add(drives[i]);
                comboBox2.Items.Add(drives[i]);
            }
            comboBox1.Text = drives[0];
            comboBox2.Text = drives[0];
            presenter.refresh(listView1, @drives[0]);
            presenter.refresh(listView2, @drives[0]);
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
        }

        void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            string path = drives[comboBox2.SelectedIndex];

            try
            {
                presenter.refresh(listView2, path);
                presenter.CurrentPath2 = path;
            }
            catch (IOException ex)
            {
                MessageBox.Show("Not found","Error");
                comboBox1.Text = drives[0];
                path = @"C:\";
                presenter.refresh(listView2, path);
                presenter.CurrentPath2 = path;
            }
        }

        void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            string path = drives[comboBox1.SelectedIndex];
           
            try
            {
                presenter.refresh(listView1, path); 
                presenter.CurrentPath1 = path;
            }
            catch(IOException ex) 
            {
                MessageBox.Show("Not found", "Error");
                comboBox1.Text = drives[0];
                path = @"C:\";
                presenter.refresh(listView1, path);
                presenter.CurrentPath1 = path;
            }
        }

        void listView2_Enter(object sender, EventArgs e)
        {
            activeListView = 2;
        }

        void listView1_Enter(object sender, EventArgs e)
        {
            activeListView = 1;
        }
     

        void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        { 
            presenter.openItem(listView1,true);
        }
        void listView2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            presenter.openItem(listView2,false);
        }

        private void CopyMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (activeListView == 1)
                {
                    if (listView1.SelectedItems.Count > 0)
                    {
                        presenter.addToBuffer(listView1, true);
                    }
                }
                else
                    if (listView2.SelectedItems.Count > 0)
                    {
                        presenter.addToBuffer(listView2, false);
                    }

            }
            catch
            {
                MessageBox.Show("Copy failed","Error");
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
                        presenter.Move(listView1,true);
                    }
                }
                else
                    if (listView2.SelectedItems.Count > 0)
                        presenter.Move(listView2, false);
            }
            catch(IOException ex)
            {
                MessageBox.Show("Impossible", "Error");
            }
            catch
            {
                MessageBox.Show("Copy error", "Error");
            }
            finally
            {
                presenter.refresh(listView1, presenter.CurrentPath1);
                presenter.refresh(listView2, presenter.CurrentPath2);
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
                        presenter.Delete(listView1,true);
                    }
                }
                else
                    if (listView2.SelectedItems.Count > 0)
                        presenter.Delete(listView2,false);
                
            }
            catch
            {
                MessageBox.Show("Delete error", "Error");
            }
            finally
            {
                presenter.refresh(listView1, presenter.CurrentPath1);
                presenter.refresh(listView2, presenter.CurrentPath2);
            }
        }

        private void buttonBack1_Click(object sender, EventArgs e)
        {
            presenter.Back(listView1, true);
        }

        private void buttonBack2_Click(object sender, EventArgs e)
        {
            presenter.Back(listView2, false);
        }

        private void buttonRefresh1_Click(object sender, EventArgs e)
        {
            presenter.refresh(listView1, presenter.CurrentPath1);
        }

        private void buttonRefresh2_Click(object sender, EventArgs e)
        {
            presenter.refresh(listView2, presenter.CurrentPath2);
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
                catch(IOException ex)
            {
                MessageBox.Show("Impossible", "Error");
            }
            catch
            {
                MessageBox.Show("Copy error", "Error");
            }
            finally
            {
                presenter.refresh(listView1, presenter.CurrentPath1);
                presenter.refresh(listView2, presenter.CurrentPath2);
            }
        }

        private void buttonAddFolder1_Click(object sender, EventArgs e)
        {
            presenter.CreateNewFolder(true);
            presenter.refresh(listView1, presenter.CurrentPath1);
            presenter.refresh(listView2, presenter.CurrentPath2);
        }

        private void buttonAddFile1_Click(object sender, EventArgs e)
        {
            presenter.CreateNewFile(true);
            presenter.refresh(listView1, presenter.CurrentPath1);
            presenter.refresh(listView2, presenter.CurrentPath2);
        }

        private void buttonAddFolder2_Click(object sender, EventArgs e)
        {
            presenter.CreateNewFolder(false);
            presenter.refresh(listView1, presenter.CurrentPath1);
            presenter.refresh(listView2, presenter.CurrentPath2);
        }

        private void buttonAddFile2_Click(object sender, EventArgs e)
        {
            presenter.CreateNewFile(false);
            presenter.refresh(listView1, presenter.CurrentPath1);
            presenter.refresh(listView2, presenter.CurrentPath2);
        }

        private void aboutProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Made by Ihor Piontkovskyi 2018");
        }


        private void MoveDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (activeListView == 1)
            {
                    presenter.MoveToDirectory(listView1, true);
            }
            else
                    presenter.MoveToDirectory(listView2, false);
            
                presenter.refresh(listView1, presenter.CurrentPath1);
                presenter.refresh(listView2, presenter.CurrentPath2);
        }
        
      }
   }
