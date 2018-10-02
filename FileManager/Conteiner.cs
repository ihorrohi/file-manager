using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace FileManager1
{
   abstract class Conteiner
    {
       private string _currentPath;
       public string Path
       {
           get
           {
               return _currentPath;
           }
           set
           {
               _currentPath = value;
           }
       }
       public Conteiner(string path)
       {
           Path = path;
       }
      
       
       public abstract void Move(string MovePath);
       public abstract void Delete();
       public abstract void Copy(string CopyPath);
       
      
        
    }
  
}
