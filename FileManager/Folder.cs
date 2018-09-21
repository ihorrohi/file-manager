using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileManager1
{
     class Folder:Conteiner
     {
         private string name;
         public string Name
         {
           get {return name;}
           set {name=value;}
         }
         public Folder(string path):base(path)
         {
             Name = path.Substring(path.LastIndexOf("\\") + 1);
         }
          public Folder[] GetFolders()
         {
             string[] strFolders = Directory.GetDirectories(Path); 
             Folder[] folders = new Folder[strFolders.Length];
             for (int i = 0; i < strFolders.Length; i++)
             {
                 folders[i] = new Folder(strFolders[i]);
             }
             return folders;
         }
          public override void Move( string MovePath)
          {       
                  Directory.Move(this.Path, MovePath+"\\"+this.Name);
          }
          public override void Delete()
          {
              Directory.Delete(this.Path, true);
          }
          public override void Copy(string CopyPath)
          {

              Folder[] folders = GetFolders();
              string[] files = Directory.GetFiles(Path);
              for (int i = 0; i < folders.Length; i++)
              {
                  folders[i].Copy(CopyPath + "\\" + Name);
              }
              Directory.CreateDirectory(CopyPath+"\\"+Name);
              for (int i = 0; i < files.Length; i++)
              {
                  File.Copy(files[i], CopyPath + "\\" +Name+"\\"+ files[i].Substring(files[i].LastIndexOf("\\")));
              }
          }
         public bool isExist()
          {
              if (Directory.Exists(Path)) return true;
              else return false;
          }
     }
}
