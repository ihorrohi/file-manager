using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
namespace FileManager1
{
    public class Presenter
    {
        static List<string> pathes = new List<string>();
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
        readonly FileManager fileManager;
        public Presenter(FileManager FManager)
        {
            fileManager = FManager;
        }
        public void ClearReport()
        {
            File.Delete(Environment.CurrentDirectory.ToString() + "Report\\Report.txt");
        }
        public void ReportHeader()
        {
            File.AppendAllText(Environment.CurrentDirectory.ToString() + "Report\\Report.txt", "Report on working File Manager. " + DateTime.Now.ToString() + Environment.NewLine);
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
        public void Refresh(ListView list, string path)
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
            Report openObject = new Report(path);
            openObject.Open();
            list.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
        public void OpenItem(ListView list, bool left)
        {
            string path = list.SelectedItems[0].Text;
            string currentPath;

            if (left)
                currentPath = String.Format(@"{0}\\{1}", currentPath1, path);
            else
                currentPath = String.Format(@"{0}\\{1}", currentPath2, path);
            if (list.SelectedItems[0].ImageIndex == 0)
            {
                try
                {
                    Refresh(list, currentPath);
                    if (left)
                        currentPath1 = currentPath;
                    else
                        currentPath2 = currentPath;
                }
                catch (IOException ex)
                {
                    Refresh(list, currentPath1);
                }
                catch (UnauthorizedAccessException ex)
                {
                    MessageBox.Show("You haven`t access", "Error");
                }
            }
            else
            {
                try
                {

                    CommonFile cf = new CommonFile(currentPath);
                    string content;
                    if (currentPath.Substring(currentPath.LastIndexOf(".") + 1) == "txt")
                    {

                        content = cf.GetText(new TxtFile(currentPath));
                        TextEditor TEdit = new TextEditor(content, currentPath);
                        TEdit.ShowDialog();
                    }
                    else if (currentPath.Substring(currentPath.LastIndexOf(".") + 1) == "html")
                    {

                        content = cf.GetText(new HtmlFile(currentPath));
                        HtmlEditor HEdit = new HtmlEditor(content, currentPath);
                        HEdit.ShowDialog();
                    }
                    else Process.Start(currentPath);

                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show("You haven`t access", "Error");
                }
            }
        }
        public void Move(ListView list, bool left)
        {
            string currentPath;
            if (left)
                currentPath = currentPath1;
            else
                currentPath = currentPath2;
            if (list.SelectedItems.Count > 0)
            {
                foreach (int i in list.SelectedIndices)
                {
                    if (list.Items[i].ImageIndex == 0)
                    {
                        Folder folder = new Folder(currentPath + "\\" + list.Items[i].Text);
                        if (left)
                        {
                            folder.Move(currentPath2);
                            Report moveObject = new Report(currentPath);
                            moveObject.Move(currentPath2);
                        }
                        else
                        {
                            folder.Move(currentPath1);
                            Report moveObject = new Report(currentPath);
                            moveObject.Move(currentPath1);
                        }
                    }
                    else
                    {
                        CommonFile file = new CommonFile(currentPath + "\\" + list.Items[i].Text);
                        if (left)
                        {
                            file.Move(currentPath2);
                            Report moveObject = new Report(currentPath);
                            moveObject.Move(currentPath2);
                        }
                        else
                        {
                            file.Move(currentPath1);
                            Report moveObject = new Report(currentPath);
                            moveObject.Move(currentPath1);
                        }
                    }
                }
            }


        }
        public void Delete(ListView list, bool left)
        {
            string currentPath;
            if (left)
                currentPath = currentPath1;
            else
                currentPath = currentPath2;
            if (list.SelectedItems.Count > 0)
            {
                foreach (int i in list.SelectedIndices)
                {
                    if (list.Items[i].ImageIndex == 0)
                    {

                        Folder folder = new Folder(currentPath + "\\" + list.Items[i].Text);
                        folder.Delete();
                        Report deleteObject = new Report(currentPath + "\\" + list.Items[i].Text);
                        deleteObject.Delete();
                    }
                    else
                    {
                        CommonFile file = new CommonFile(currentPath + "\\" + list.Items[i].Text);
                        file.Delete();
                        Report deleteObject = new Report(currentPath + "\\" + list.Items[i].Text);
                        deleteObject.Delete();
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
            string currentPath;
            if (left)
                currentPath = currentPath1;
            else
                currentPath = currentPath2;
            int last_index = currentPath.LastIndexOf("\\");
            if (last_index > 2)
            {
                currentPath = @currentPath.Substring(0, last_index - 1);
                Refresh(list, currentPath);
            }
            else
            {
                Refresh(list, currentPath);
            }
            if (left)
                currentPath1 = currentPath;
            else
                currentPath2 = currentPath;
        }
        public void AddToBuffer(ListView list, bool left)
        {
            string currentPath;
            if (left)
                currentPath = currentPath1;
            else
                currentPath = currentPath2;
            foldersToCopy.Clear();
            filesToCopy.Clear();
            if (list.SelectedItems.Count > 0)
            {
                foreach (int i in list.SelectedIndices)
                {
                    if (list.Items[i].ImageIndex == 0)
                    {
                        Folder folder = new Folder(currentPath + "\\" + list.Items[i].Text);
                        foldersToCopy.Add(folder);
                    }
                    else
                    {
                        CommonFile file = new CommonFile(currentPath + "\\" + list.Items[i].Text);
                        filesToCopy.Add(file);
                    }
                }
            }

        }
        public void Paste(ListView list, bool left)
        {
            string currentPath;
            if (left)
                currentPath = currentPath1;
            else
                currentPath = currentPath2;
            if (foldersToCopy.Count > 0)
            {
                for (int i = 0; i < foldersToCopy.Count; i++)
                {

                    if (Presenter.IsSubDirectory(foldersToCopy[i].Path, currentPath)) throw new IOException();
                    if (!Directory.Exists(currentPath + "\\" + foldersToCopy[i].Name))
                    {
                        foldersToCopy[i].Copy(currentPath);
                        Report copyObject = new Report(currentPath + "\\" + list.Items[i].Text);
                        copyObject.Copy(currentPath);
                    }
                }
            }
            if (filesToCopy.Count > 0)
            {

                for (int i = 0; i < filesToCopy.Count; i++)
                {

                    if (!File.Exists(currentPath + "\\" + filesToCopy[i].Name))
                    {

                        filesToCopy[i].Copy(currentPath);
                        Report copyObject = new Report(currentPath + "\\" + list.Items[i].Text);
                        copyObject.Copy(currentPath);
                    }
                }
            }
        }
        public void CreateNewFolder(bool left)
        {
            string currentPath;
            if (left) currentPath = CurrentPath1;
            else currentPath = CurrentPath2;

            CreateFolder createFolder = new CreateFolder();
            createFolder.ShowDialog();
            try
            {
                if (createFolder.create)
                {
                    if (!Directory.Exists(currentPath + "\\" + createFolder.path))
                    {
                        Directory.CreateDirectory(currentPath + "\\" + createFolder.path);
                        Report createObject = new Report(currentPath + "\\" + createFolder.path);
                        createObject.Create();
                    }

                    else
                        MessageBox.Show("Such a folder already exists", "Error");
                }
                createFolder.Dispose();
            }
            catch(Exception error)
            {
                createFolder.Dispose();
                MessageBox.Show("You haven`t access", "Error");
            }
        }
        public void CreateNewFile(bool left)
        {
            string currentPath;
            if (left) currentPath = CurrentPath1;
            else currentPath = CurrentPath2;

            CreateFolder createFile = new CreateFolder(true);
            createFile.ShowDialog();
            try
            {
                if (createFile.create)
                {
                    if (!File.Exists(currentPath + "\\" + createFile.path))
                    {
                        File.Create(currentPath + "\\" + createFile.path);
                        Report createObject = new Report(currentPath + "\\" + createFile.path);
                        createObject.Create();
                    }
                    else
                        MessageBox.Show("Such a file already exists", "Error");
                }
                createFile.Dispose();
            }
            catch (Exception error)
            {
                createFile.Dispose();
                MessageBox.Show("You haven`t access!", "Error");
            }

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
                    if (!folder.IsExist())
                    {
                        Directory.CreateDirectory(currentPath + "\\" + name);
                    }
                    CommonFile comFile = new CommonFile(currentPath + "\\" + list.Items[i].Text);
                    comFile.Move(currentPath + "\\" + name);

                }
            }
        }
        static public void SearchWordIncludes(string content)
        {
            if (content.Trim() == "")
            {
                MessageBox.Show("File is empty!", "Result");
                return;
            }
            string text = content.ToLower();
            text = Regex.Replace(text, "[^0-9a-zA-Z]+", " ");
            List<string> UnrepeatableWords = new List<string>();
            string[] words = Regex.Split(text, @"\s+");

            foreach (var word in words)
            {
                int includes = 0;
                foreach (var word1 in words)
                {
                    if (word == word1)
                    {
                        includes++;
                    }
                }
                if (includes == 1)
                {
                    UnrepeatableWords.Add(word);
                }
            }
            if (UnrepeatableWords.Count != 0)
            {
                string result = "";
                foreach (var item in UnrepeatableWords)
                {
                    result += item + "\n";
                }
                MessageBox.Show(result, "Unrepeatable words is:");
            }
            else
            {
                MessageBox.Show("There isn`t unrepeatable words =(", "Result");
            }
        }
        public void WordsIncludesInFile(ListView list, bool left)
        {
            string currentPath;
            if (left) currentPath = CurrentPath1;
            else currentPath = CurrentPath2;
            if (list.SelectedItems.Count > 0)
            {
                foreach (int i in list.SelectedIndices)
                {
                    if (list.Items[i].ImageIndex == 0) continue;
                    else
                    {
                        string currentPosition = list.Items[i].Text;
                        CommonFile commonFile = new CommonFile(currentPath + "\\" + list.Items[i].Text);
                        if (currentPosition.Substring(currentPosition.LastIndexOf(".") + 1) == "txt")
                        {
                            string sent = commonFile.GetText(new TxtFile(currentPath + "\\" + list.Items[i].Text));
                            Presenter.SearchWordIncludes(sent);

                        }
                        else continue;
                    }
                }
            }

        }
        static public void SearchByCobination(RichTextBox box, string wordKey)
        {


            if (wordKey == "")
            {
                MessageBox.Show("Enter the symbol combination", "Oops...");
            }
            else
            {
                string checkWordKey = Regex.Replace(wordKey, "[^0-9a-zA-Z]+", " ");
                if (wordKey.Length != checkWordKey.Trim().Length)
                {
                    MessageBox.Show("Symbol combination contain no literal constants", "Oops...");
                    return;
                }
                string text = box.Text.ToLower();
                wordKey.ToLower();
                bool isFind = false;
                int position = text.IndexOf(wordKey);
                while (true)
                {
                    if (position > -1)
                    {
                        isFind = true;
                        box.SelectionStart = position;
                        box.SelectionLength = wordKey.Length;
                        box.SelectionBackColor = Color.Yellow;
                        if (position + wordKey.Length < text.Length)
                        {
                            position = text.IndexOf(wordKey, position + wordKey.Length);
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        if (!isFind)
                        {
                            MessageBox.Show("No such symbol combination", "Oops...");
                        }
                        break;
                    }

                }

            }

        }
        public bool StartSearch(string path, string key)
        {
            CommonFile commonFile = new CommonFile(path);
            string content = commonFile.GetText(new HtmlFile(path));
            int startPosition = content.IndexOf("<title>");
            int endPosition = content.IndexOf("</title>");
            while (true)
            {
                if (startPosition == -1)
                {
                    return false;
                }
                else
                {
                    if (endPosition == -1)
                    {
                        return false;
                    }
                    string title = content.Substring(startPosition + 7, endPosition - startPosition);
                    if (title.Contains(key))
                    {
                        return true;
                    }
                    else
                    {
                        startPosition = content.IndexOf("<title>", startPosition + 7);
                        endPosition = content.IndexOf("</title>", endPosition + 8);
                    }
                }
            }

        }
        public void SearchHtmlByTitle(ListView list, bool left)
        {
            string currentPath;
            if (left) currentPath = CurrentPath1;
            else currentPath = CurrentPath2;
            string wordkey = "";
            SearchForm searchForm = new SearchForm();
            searchForm.ShowDialog();
            if (searchForm.done)
            {
                wordkey = searchForm.Content;
            }
            pathes.Clear();

            bool isFindFile = false;
            for (int i = 0; i < list.Items.Count; ++i)
            {
                string path = currentPath + list.Items[i].Text;
                if (path.Substring(path.LastIndexOf(".") + 1) == "html")
                {
                    isFindFile = true;
                    if (StartSearch(path, wordkey))
                    {
                        pathes.Add(path);

                    }
                }
            }

            if (!isFindFile)
            {
                MessageBox.Show("There isn`t html files", "Oops...");
            }
            else if (pathes.Count == 0)
            {
                MessageBox.Show("The search didn`t give result", "Unfortunately");
            }
            else
            {
                ResultSearch RSerach = new ResultSearch();
                RSerach.ShowDialog();
            }
        }
        static public void ShowList(ListView list)
        {
            list.Items.Clear();
            ListViewItem.ListViewSubItem[] subItems;
            foreach (var path in pathes)
            {
                string fileName = path.Substring(path.LastIndexOf("\\") + 1);
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
        static public void OpenResult(ListView list)
        {
            string currentpath = pathes[0].Substring(0, pathes[0].LastIndexOf('\\') + 1);
            string path = list.SelectedItems[0].Text;
            currentpath = currentpath + path;
            CommonFile commonFile = new CommonFile(currentpath);
            string content;
            content = commonFile.GetText(new HtmlFile(currentpath));
            HtmlEditor HEdit = new HtmlEditor(content, currentpath, 1);
            HEdit.ShowDialog();

        }
        static public void TitleBackColor(RichTextBox box)
        {
            string content = box.Text;
            int startPosition = content.IndexOf("<title>");
            int endPosition = content.IndexOf("</title>");
            while (true)
            {
                if (startPosition > -1 && endPosition > -1)
                {
                    box.SelectionStart = startPosition + 7;
                    box.SelectionLength = endPosition - startPosition - 7;
                    box.SelectionBackColor = Color.Yellow;
                    if (startPosition + 7 < content.Length && endPosition + 8 < content.Length)
                    {
                        startPosition = content.IndexOf("<title>", startPosition + 7);
                        endPosition = content.IndexOf("</title>", endPosition + 8);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            box.SelectionStart = 0;
            box.SelectionLength = 0;
        }
    }
}