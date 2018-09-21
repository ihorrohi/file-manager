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
using System.Diagnostics;
namespace FileManager1
{
    public class Presenter
    {
        List<Folder> foldersToCopy = new List<Folder>();
        List<CommonFile> filesToCopy = new List<CommonFile>();
        string currentPath1 = @"C:\";
        string currentPath2 = @"C:\";
        public string CurrentPath1
        {
            get
            {
                return currentPath1;
            }
            set
            {
                currentPath1 = @value;
            }
        }
        public string CurrentPath2
        {
            get
            {
                return currentPath2;
            }
            set
            {
                currentPath2 = @value;
            }
        }
        FileManager fileManager;
        public Presenter(FileManager FM)
        {
            fileManager = FM;
        }
        static bool IsEqual(string str1, string str2, int len)
        {
            string s1 = "", s2 = "";
            for (int i = 0; i < len; i++)
            {
                if (str1[i] != '\\') s1 += str1[i];
            }
            for (int i = 0; i < len; i++)
            {
                if (str2[i] != '\\') s2 += str2[i];
            }
            return (s1 == s2);
        }
        public void refresh(ListView list, string path)
        {



            Folder folder = new Folder(path);
            Folder[] folders = folder.GetFolders();
            list.Items.Clear();
            ListViewItem.ListViewSubItem[] subItems;
            string dirName = "";
            for (int i = 0; i < folders.Length; i++)
            {
                dirName = folders[i].Name;
                ListViewItem item = new ListViewItem(dirName, 0);
                subItems = new ListViewItem.ListViewSubItem[]{
                       new ListViewItem.ListViewSubItem(item, "FOLDER"),
                     new ListViewItem.ListViewSubItem(item,
                        String.Format("{0}",Directory.GetCreationTime(path+"\\"+dirName)))};
                item.SubItems.AddRange(subItems);
                list.Items.Add(item);
            }
            CommonFile file = new CommonFile(path);
            CommonFile[] files = file.GetFiles();
            string fileName = "";
            for (int i = 0; i < files.Length; i++)
            {
                fileName = files[i].Name;
                ListViewItem item = new ListViewItem(fileName, 1);
                subItems = new ListViewItem.ListViewSubItem[]{
                       new ListViewItem.ListViewSubItem(item, "FILE"),
                     new ListViewItem.ListViewSubItem(item,
                        String.Format("{0}",File.GetCreationTime(path+"\\"+fileName)))};
                item.SubItems.AddRange(subItems);
                list.Items.Add(item);
            }
            list.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
        public void refreshWithExtension(ListView list, string path, string ext)
        {
            Folder folder = new Folder(path);
            Folder[] folders = folder.GetFolders();
            list.Items.Clear();
            ListViewItem.ListViewSubItem[] subItems;
            string dirName = "";
            for (int i = 0; i < folders.Length; i++)
            {
                dirName = folders[i].Name;
                ListViewItem item = new ListViewItem(dirName, 0);
                subItems = new ListViewItem.ListViewSubItem[]{
                       new ListViewItem.ListViewSubItem(item, "FOLDER"),
                     new ListViewItem.ListViewSubItem(item,
                        String.Format("{0}",Directory.GetCreationTime(path+"\\"+dirName)))};
                item.SubItems.AddRange(subItems);
                list.Items.Add(item);
            }
            CommonFile file = new CommonFile(path);
            CommonFile[] files = file.GetFiles();
            string fileName = "";
            for (int i = 0; i < files.Length; i++)
            {
                if (files[i].Name.Substring(files[i].Name.LastIndexOf(".") + 1) == ext)
                {
                    fileName = files[i].Name;
                    ListViewItem item = new ListViewItem(fileName, 1);
                    subItems = new ListViewItem.ListViewSubItem[]{
                       new ListViewItem.ListViewSubItem(item, "FILE"),
                     new ListViewItem.ListViewSubItem(item,
                        String.Format("{0}",File.GetCreationTime(path+"\\"+fileName)))};
                    item.SubItems.AddRange(subItems);
                    list.Items.Add(item);
                }

            }
            list.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        public void openItem(ListView list, bool left)
        {
            string path = list.SelectedItems[0].Text;
            string currentPath;

            if (left)
                currentPath = String.Format(@"{0}\\{1}", currentPath1, path);
            else
                currentPath = String.Format(@"{0}\\{1}", currentPath2, path);

            try
            {
                refresh(list, currentPath);
                if (left)
                    currentPath1 = currentPath;
                else
                    currentPath2 = currentPath;
            }
            catch (IOException ex)
            {
                refresh(list, currentPath1);
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show("You haven`t access","Error");
            }
        }

        public void Move(ListView list, bool left)
        {
            string CurrentPath;
            if (left)
                CurrentPath = currentPath1;
            else
                CurrentPath = currentPath2;
            if (list.SelectedItems.Count > 0)
            {
                foreach (int i in list.SelectedIndices)
                {
                    if (list.Items[i].ImageIndex == 0)
                    {
                        Folder folder = new Folder(CurrentPath + "\\" + list.Items[i].Text);
                        if (left)
                            folder.Move(currentPath2);
                        else
                            folder.Move(currentPath1);
                    }
                    else
                    {
                        CommonFile file = new CommonFile(CurrentPath + "\\" + list.Items[i].Text);
                        if (left)
                            file.Move(currentPath2);
                        else
                            file.Move(currentPath1);
                    }
                }
            }


        }
        public void Delete(ListView list, bool left)
        {
            string CurrentPath;
            if (left)
                CurrentPath = currentPath1;
            else
                CurrentPath = currentPath2;
            if (list.SelectedItems.Count > 0)
            {
                foreach (int i in list.SelectedIndices)
                {
                    if (list.Items[i].ImageIndex == 0)
                    {
                        Folder folder = new Folder(CurrentPath + "\\" + list.Items[i].Text);
                        folder.Delete();
                    }
                    else
                    {
                        CommonFile file = new CommonFile(CurrentPath + "\\" + list.Items[i].Text);
                        file.Delete();
                    }
                }
            }
        }


        static public bool IsSubDirectory(string str1, string str2)
        {
            int len = str1.Length > str2.Length ? str2.Length : str1.Length;
            if (str1[0] != str2[0]) return false;
            if (Presenter.IsEqual(str1, str2, len)) return false;
            if (str1.Length <= str2.Length) return true;
            return false;
        }
        public void Back(ListView list, bool left)
        {
            string currPath;
            if (left)
                currPath = currentPath1;
            else
                currPath = currentPath2;
            int last_index = currPath.LastIndexOf("\\");
            if (last_index > 2)
            {
                currPath = @currPath.Substring(0, last_index - 1);
                refresh(list, currPath);
            }
            else
            {
                refresh(list, currPath);
            }
            if (left)
                currentPath1 = currPath;
            else
                currentPath2 = currPath;
        }


        public void addToBuffer(ListView list, bool left)
        {
            string CurrentPath;
            if (left)
                CurrentPath = currentPath1;
            else
                CurrentPath = currentPath2;
            foldersToCopy.Clear();
            filesToCopy.Clear();
            if (list.SelectedItems.Count > 0)
            {
                foreach (int i in list.SelectedIndices)
                {
                    if (list.Items[i].ImageIndex == 0)
                    {
                        Folder folder = new Folder(CurrentPath + "\\" + list.Items[i].Text);
                        foldersToCopy.Add(folder);
                    }
                    else
                    {
                        CommonFile file = new CommonFile(CurrentPath + "\\" + list.Items[i].Text);
                        filesToCopy.Add(file);
                    }
                }
            }

        }
        public void Paste(ListView list, bool left)
        {
            string CurrentPath;
            if (left)
                CurrentPath = currentPath1;
            else
                CurrentPath = currentPath2;
            if (foldersToCopy.Count > 0)
            {
                for (int i = 0; i < foldersToCopy.Count; i++)
                {

                    if (Presenter.IsSubDirectory(foldersToCopy[i].Path, CurrentPath)) throw new IOException();
                    if (!Directory.Exists(CurrentPath + "\\" + foldersToCopy[i].Name))
                        foldersToCopy[i].Copy(CurrentPath);
                }
            }
            if (filesToCopy.Count > 0)
            {

                for (int i = 0; i < filesToCopy.Count; i++)
                {

                    if (!File.Exists(CurrentPath + "\\" + filesToCopy[i].Name))
                    {

                        filesToCopy[i].Copy(CurrentPath);
                    }
                }
            }
        }

        public void CreateNewFolder(bool left)
        {
            string currentPath;
            if (left) currentPath = CurrentPath1;
            else currentPath = CurrentPath2;

            CreateFolder Cr_fold = new CreateFolder();
            Cr_fold.ShowDialog();
            if (Cr_fold.create)
            {
                if (!Directory.Exists(currentPath + "\\" + Cr_fold.path))
                    Directory.CreateDirectory(currentPath + "\\" + Cr_fold.path);
                else
                    MessageBox.Show("Such a folder already exists", "Error");
            }
            Cr_fold.Dispose();
        }
        public void CreateNewFile(bool left)
        {
            string currentPath;
            if (left) currentPath = CurrentPath1;
            else currentPath = CurrentPath2;

            CreateFolder Cr_fold = new CreateFolder(true);
            Cr_fold.ShowDialog();
            if (Cr_fold.create)
            {
                if (!File.Exists(currentPath + "\\" + Cr_fold.path))
                    File.Create(currentPath + "\\" + Cr_fold.path);
                else
                    MessageBox.Show("Such a file already exists","Error");

            }
            Cr_fold.Dispose();
        }
        public void MoveToDirectory(ListView list, bool left)
        {
            string currentPath;
            if (left) currentPath = CurrentPath1;
            else currentPath = CurrentPath2;
            for (int i = 0; i < list.Items.Count; i++)
            {
                if (list.Items[i].ImageIndex == 1)
                {
                    string name;
                    if (list.Items[i].Text.LastIndexOf(".") == -1)
                        name = "withoutExtension";
                    else
                        name = list.Items[i].Text.Substring(list.Items[i].Text.LastIndexOf(".") + 1);
                    Folder folder = new Folder(currentPath + "\\" + name);
                    if (!folder.isExist())
                    {
                        Directory.CreateDirectory(currentPath + "\\" + name);

                    }
                    CommonFile comFile = new CommonFile(currentPath + "\\" + list.Items[i].Text);
                    comFile.Move(currentPath + "\\" + name);
                }
            }
        }
    }
}
