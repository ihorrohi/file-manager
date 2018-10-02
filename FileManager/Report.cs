using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace FileManager1
{
    class Report : Conteiner
    {
        private string name;
         public string Name
         {
           get {return name;}
           set {name=value;}
         }
        public Report (string path) : base(path)
        {
            Name = path.Substring(path.LastIndexOf("\\") + 1);
        }

        public override void Copy(string copyPath)
        {

            File.AppendAllText(Environment.CurrentDirectory.ToString() + "Report\\Report.txt", DateTime.Now.ToString() + " Copy. " + Path + "\n" + Environment.NewLine);
        }

        public override void Delete()
        {
            File.AppendAllText(Environment.CurrentDirectory.ToString() + "Report\\Report.txt", DateTime.Now.ToString() + "Delete item " + Path + "\n" + Environment.NewLine);
        }

        public override void Move(string movePath)
        {
            File.AppendAllText(Environment.CurrentDirectory.ToString() + "Report\\Report.txt", DateTime.Now.ToString() + " Move. " + Path + "\n" + Environment.NewLine);
        }
        public void Create()
        {
            File.AppendAllText(Environment.CurrentDirectory.ToString() + "Report\\Report.txt", DateTime.Now.ToString() + " Create. " + Path + "\n" + Environment.NewLine);
        }
        public void Open()
        {
            File.AppendAllText(Environment.CurrentDirectory.ToString() + "Report\\Report.txt", DateTime.Now.ToString() + " Open. "  + Path + "\n" + Environment.NewLine);
        }

    }
}
