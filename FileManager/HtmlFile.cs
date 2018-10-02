using System.Text;
using System.IO;

namespace FileManager1
{
    class HtmlFile : CommonFile
    {
        public HtmlFile(string path) : base(path)
        {
            Name = path.Substring(path.LastIndexOf("\\") + 1);
        }
        public override string GetContent()
        {
            string text = File.ReadAllText(Path, Encoding.GetEncoding(1251));
            return text;
        }
    }
}
