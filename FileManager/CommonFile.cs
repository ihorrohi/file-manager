using System.IO;

namespace FileManager1
{
    class CommonFile:Conteiner
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public CommonFile(string path) : base(path) 
        {
            Name = path.Substring(path.LastIndexOf("\\") + 1); 
        }
        public CommonFile[] GetFiles()
        {
            string[] strFiles = Directory.GetFiles(Path);
            CommonFile[] files = new CommonFile[strFiles.Length];
            for (int i = 0; i < strFiles.Length; i++)
            {
               files[i] = new CommonFile(strFiles[i]);
            }
            return files;
        }
        public override void Move(string movePath)
        {
            File.Move(this.Path, movePath+"\\"+this.Name);
        }
        public override void Delete()
        {
            File.Delete(this.Path);
        }
        public override void Rename(string NewName)
        {
            File.Copy(this.Path, this.Path.Substring(0, this.Path.LastIndexOf("\\") + 1) + NewName,true);
            File.Delete(this.Path);
        }
        public override void Copy(string CopyPath)
        {
            File.Copy(this.Path, CopyPath+ "\\"+ this.Name);
        }
        public virtual string GetContent() { return ""; }
        public string GetText(CommonFile ComFile)
        {
          return ComFile.GetContent();
        }
        public bool IsExist()
        {
            if (File.Exists(Path)) return true;
            else return false;
        }
    }
}
