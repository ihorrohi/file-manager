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
        static List<ReportItem> reports = new List<ReportItem>();
        Director director = new Director();

        string currentPath1 = @"C:\";
        string currentPath2 = @"C:\";
        string contentForMerging = "";
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
        
        static public void CreateReport()
        {
            File.Delete(Environment.CurrentDirectory.ToString() + "Report\\Report.txt");
            File.AppendAllText(Environment.CurrentDirectory.ToString() + "Report\\Report.txt", "Report on working File Manager. " + Environment.NewLine);
            foreach(var item in reports)
            {
                File.AppendAllText(Environment.CurrentDirectory.ToString() + "Report\\Report.txt", item.getReport() + Environment.NewLine);
            }
            File.AppendAllText(Environment.CurrentDirectory.ToString() + "Report\\Report.txt", "Thank you " + DateTime.Now.ToString());
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
                director.OpenReport(currentPath);
                director.BuildReport();
                reports.Add(director.GetReportItem());
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
                        TextEditorForm TEdit = new TextEditorForm(content, currentPath, false);
                        TEdit.ShowDialog();
                    }
                    else if (currentPath.Substring(currentPath.LastIndexOf(".") + 1) == "html")
                    {

                        content = cf.GetText(new HtmlFile(currentPath));
                        TextEditorForm HEdit = new TextEditorForm(content, currentPath, false);
                        HEdit.ShowDialog();
                    }
                    else Process.Start(currentPath);
                    director.OpenReport(path);
                    director.BuildReport();
                    reports.Add(director.GetReportItem());

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
                            if (!Directory.Exists(currentPath2 + "\\" + list.Items[i].Text))
                            {
                                folder.Move(currentPath2);
                                director.MoveReport(currentPath + "\\" + list.Items[i].Text, currentPath2 + "\\" + list.Items[i].Text);
                                director.BuildReport();
                                reports.Add(director.GetReportItem());
                            }
                            else
                            {
                                MessageBox.Show("The folder is already exists", "Error");
                            }
                        }
                        else
                        {
                            if (!Directory.Exists(currentPath1 + "\\" + list.Items[i].Text))
                            {
                                folder.Move(currentPath1);
                                director.MoveReport(currentPath + "\\" + list.Items[i].Text, currentPath1 + "\\" + list.Items[i].Text);
                                director.BuildReport();
                                reports.Add(director.GetReportItem());
                            }
                            else
                            {
                                MessageBox.Show("The folder is already exists", "Error");
                            }
                        }
                    }
                    else
                    {
                        CommonFile file = new CommonFile(currentPath + "\\" + list.Items[i].Text);
                        if (left)
                        {
                            if (!File.Exists(currentPath2 + "\\" + list.Items[i].Text))
                            {
                                file.Move(currentPath2);
                                director.MoveReport(currentPath + "\\" + list.Items[i].Text, currentPath2 + "\\" + list.Items[i].Text);
                                director.BuildReport();
                                reports.Add(director.GetReportItem());
                            }
                            else
                            {
                                MessageBox.Show("The file is already exists", "Error");
                            }
                        }
                        else
                        {
                            if (!File.Exists(currentPath1 + "\\" + list.Items[i].Text))
                            {
                                file.Move(currentPath1);
                                director.MoveReport(currentPath + "\\" + list.Items[i].Text, currentPath1 + "\\" + list.Items[i].Text);
                                director.BuildReport();
                                reports.Add(director.GetReportItem());
                            }
                            else
                            {
                                MessageBox.Show("The file is already exists", "Error");
                            }
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
            WarningForm warningForm = new WarningForm(false);
            warningForm.ShowDialog();
            if (warningForm.action)
            {
                if (list.SelectedItems.Count > 0)
                {
                    foreach (int i in list.SelectedIndices)
                    {
                        if (list.Items[i].ImageIndex == 0)
                        {

                            Folder folder = new Folder(currentPath + "\\" + list.Items[i].Text);
                            folder.Delete();
                            director.DeleteReport(currentPath + "\\" + list.Items[i].Text);
                            director.BuildReport();
                            reports.Add(director.GetReportItem());
                        }
                        else
                        {
                            CommonFile file = new CommonFile(currentPath + "\\" + list.Items[i].Text);
                            file.Delete();
                            director.DeleteReport(currentPath + "\\" + list.Items[i].Text);
                            director.BuildReport();
                            reports.Add(director.GetReportItem());
                        }
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
        public void Rename(ListView list, bool left)
        {
            string path = list.SelectedItems[0].Text;
            string currentPath;

            if (left)
                currentPath = String.Format(@"{0}\\{1}", currentPath1, path);
            else
                currentPath = String.Format(@"{0}\\{1}", currentPath2, path);
            LabelForm labelForm = new LabelForm(-1);
            labelForm.ShowDialog();
            try
            {
                if (list.SelectedItems[0].ImageIndex == 0)
                {
                    if (labelForm.done)
                    {
                        if (!Directory.Exists(currentPath + "\\" + labelForm.text))
                        {
                            Folder folder = new Folder(currentPath);
                            folder.Rename(labelForm.text);
                            director.RenameReport(path, labelForm.text);
                            director.BuildReport();
                            reports.Add(director.GetReportItem());
                        }
                        else
                        {
                            MessageBox.Show("Such a folder is already exists", "Error");
                        }
                    }
                }
                else
                {
                    if (!File.Exists(currentPath + "\\" + labelForm.text))
                    {
                        if (labelForm.done)
                        {
                            CommonFile commonFile = new CommonFile(currentPath);
                            commonFile.Rename(labelForm.text);
                            director.RenameReport(path, labelForm.text);
                            director.BuildReport();
                            reports.Add(director.GetReportItem());
                        }
                        labelForm.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("Such a file is already exists", "Error");
                    }
                }
            }
            catch (Exception error)
            {
                labelForm.Dispose();
                MessageBox.Show(error.Message.ToString(), "Error");
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
                        director.CopyReport(foldersToCopy[i].Path, currentPath + "\\" + foldersToCopy[i].Name);
                        director.BuildReport();
                        reports.Add(director.GetReportItem());
                    }
                    else
                    {
                        MessageBox.Show("The folder is already exists", "Error");
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
                        director.CopyReport(filesToCopy[i].Path, currentPath + "\\" + filesToCopy[i].Name);
                        director.BuildReport();
                        reports.Add(director.GetReportItem());
                    }
                    else
                    {
                        MessageBox.Show("The file is already exists", "Error");
                    }
                }
            }
        }
        public void CreateNewFolder(bool left)
        {
            string currentPath;
            if (left) currentPath = CurrentPath1;
            else currentPath = CurrentPath2;

            LabelForm labelForm = new LabelForm(1);
            labelForm.ShowDialog();
            try
            {
                if (labelForm.done)
                {
                    if (!Directory.Exists(currentPath + "\\" + labelForm.text))
                    {
                        Directory.CreateDirectory(currentPath + "\\" + labelForm.text);
                        director.CreateReport(currentPath + "\\" + labelForm.text);
                        director.BuildReport();
                        reports.Add(director.GetReportItem());

                    }

                    else
                        MessageBox.Show("Such a folder already exists", "Error");
                }
                labelForm.Dispose();
            }
            catch (Exception error)
            {
                labelForm.Dispose();
                MessageBox.Show(error.Message.ToString(), "Error");
            }
        }
        public void CreateNewFile(bool left)
        {
            string currentPath;
            if (left) currentPath = CurrentPath1;
            else currentPath = CurrentPath2;

            LabelForm labelForm = new LabelForm(0);
            labelForm.ShowDialog();
            try
            {
                if (labelForm.done)
                {
                    if (!File.Exists(currentPath + "\\" + labelForm.text))
                    {
                        var file = File.Create(currentPath + "\\" + labelForm.text);
                        director.CreateReport(currentPath + "\\" + labelForm.text);
                        director.BuildReport();
                        reports.Add(director.GetReportItem());
                        file.Close();
                    }
                    else
                        MessageBox.Show("Such a file already exists", "Error");
                }
                labelForm.Dispose();
            }
            catch (Exception error)
            {
                labelForm.Dispose();
                MessageBox.Show(error.Message.ToString(), "Error");
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
            string result = "";
            string[] words = Regex.Split(text, @"\s+");
            Dictionary<string, int> wordIncludes = new Dictionary<string, int>();

            foreach (var word in words)
            {
                if (!wordIncludes.Keys.Contains(word))
                {
                    wordIncludes.Add(word, 1);
                }
                else
                {
                    wordIncludes[word] += 1;
                }
            }
            if (wordIncludes.ContainsValue(1))
            {
                foreach (KeyValuePair<string, int> keyValue in wordIncludes)
                {
                    if (keyValue.Value == 1)
                    {
                        result += keyValue.Key + "; ";
                    }
                }
                File.WriteAllText(Environment.CurrentDirectory.ToString() + "Resource\\Result.txt", result);
                Process.Start(Environment.CurrentDirectory.ToString() + "Resource\\Result.txt");
            }
            else
            {
                MessageBox.Show("There isn`t unrepeatable words!", "Oops...");
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
                while (position > -1)
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
                if (!isFind)
                {
                    MessageBox.Show("No such symbol combination", "Oops...");
                }


            }

        }
        public bool StartSearch(string path, string key)
        {
            CommonFile commonFile = new CommonFile(path);
            string content = commonFile.GetText(new HtmlFile(path));
            content = content.ToLower();
            key = key.ToLower();
            MatchCollection matches = Regex.Matches(content, @"(<\s*title[^>]*>(.*?)<\s*\/\s*title>)");
            foreach (var match in matches)
            {
                if (match.ToString().Contains(key))
                    return true;
            }
            return false;
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
            else
            {
                return;
            }
            pathes.Clear();
            for (int i = 0; i < list.Items.Count; ++i)
            {
                string path = currentPath + list.Items[i].Text;
                if (path.Substring(path.LastIndexOf(".") + 1) == "html")
                {
                    if (StartSearch(path, wordkey))
                    {
                        pathes.Add(path);

                    }
                }
            }

            if (pathes.Count == 0)
            {
                MessageBox.Show("The search didn`t give result", "Unfortunately");
            }
            else
            {
                ResultForm RSerach = new ResultForm();
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
            TextEditorForm HEdit = new TextEditorForm(content, currentpath, true);
            HEdit.ShowDialog();

        }
        static public void TitleBackColor(RichTextBox box)
        {
            string content = box.Text;
            int startPosition = content.IndexOf("<title>");
            int endPosition = content.IndexOf("</title>");
            while (startPosition > -1 && endPosition > -1)
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
            box.SelectionStart = 0;
            box.SelectionLength = 0;
        }
        public void Select(ListView list, bool left)
        {
            string path = list.SelectedItems[0].Text;
            string currentPath;

            if (left)
                currentPath = String.Format(@"{0}\\{1}", currentPath1, path);
            else
                currentPath = String.Format(@"{0}\\{1}", currentPath2, path);
            if (list.SelectedItems[0].ImageIndex == 0)
            {
                MessageBox.Show("You haven`t chosen a html1 file", "Oops...");
            }
            else
            {
                try
                {

                    CommonFile cf = new CommonFile(currentPath);
                    if (currentPath.Substring(currentPath.LastIndexOf(".") + 1) == "html")
                    {
                        contentForMerging = cf.GetText(new HtmlFile(currentPath));
                    }
                    else
                    {
                        MessageBox.Show("You haven`t chosen a html file", "Oops...");
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message.ToString(), "Error");
                }
            }
        }
        public bool GetPathesOfImg(string content)
        {
            string text = content;
            string pattern = "<img.+?src=[\"'](.+?)[\"'].*?>";
            List<string> pathes = new List<string>();
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            Match match = regex.Match(text);
            while (match.Success)
            {
                pathes.Add(match.Groups[1].Value);
                match = match.NextMatch();
            }
            foreach (var imgPath in pathes)
            {
                if (Regex.IsMatch(imgPath.ToString(), @"^(?:[a-zA-Z]\:|\\\\[\w\.]+\\[\w.$]+)\\(?:[\w]+\\)*\w([\w.])+$"))
                {
                    if (File.Exists(imgPath.ToString()))
                    {
                        CommonFile currcommonFile = new CommonFile(imgPath.ToString());
                        filesToCopy.Add(currcommonFile);
                    }
                    else
                    {
                        MessageBox.Show("Html file exists inadmissble pathes!", "Oops");
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Html file exists inadmissble pathes!", "Oops");
                    return false;
                }
            }
            return true;
        }
        public void ProcessMerging(string currentPath)
        {
            string path = currentPath.Substring(0, currentPath.LastIndexOf("."));
            if (filesToCopy.Count > 0)
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                    for (int i = 0; i < filesToCopy.Count; i++)
                    {
                        if (!File.Exists(path + "\\" + filesToCopy[i].Name))
                        {
                            filesToCopy[i].Copy(path);
                        }
                    }
                }
            }
        }
        public void Merging(ListView list, bool left)
        {
            if (contentForMerging == "")
            {
                MessageBox.Show("Please select html file", "Oops..");
                return;
            }
            string path = list.SelectedItems[0].Text;
            string currentPath;

            if (left)
                currentPath = String.Format(@"{0}\\{1}", currentPath1, path);
            else
                currentPath = String.Format(@"{0}\\{1}", currentPath2, path);
            if (list.SelectedItems[0].ImageIndex == 0)
            {
                MessageBox.Show("You haven`t chosen a html1 file", "Oops...");
            }
            else
            {
                try
                {

                    CommonFile commonFile = new CommonFile(currentPath);
                    if (currentPath.Substring(currentPath.LastIndexOf(".") + 1) == "html")
                    {
                        filesToCopy.Clear();
                        string content = commonFile.GetText(new HtmlFile(currentPath));
                        if (GetPathesOfImg(content) && GetPathesOfImg(contentForMerging))
                        {     
                            ProcessMerging(currentPath);
                            File.AppendAllText(currentPath, contentForMerging);
                        }
                        else
                        {
                            contentForMerging = "";
                            return;
                        }

                    }
                    else
                    {
                        MessageBox.Show("You haven`t chosen a html file", "Oops...");
                    }
                }
                catch (Exception error)
                {
                    contentForMerging = "";
                    MessageBox.Show(error.Message.ToString(), "Error");
                }
            }
            MessageBox.Show("Merging complete", "Result");
            contentForMerging = "";
        }
    }
}