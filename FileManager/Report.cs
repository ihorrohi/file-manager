using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace FileManager1
{
    class ReportItem
    {
        public string time;
        public string operation;
        public string getReport()
        {
            return time + operation;
        }
    }
    abstract class ReportBuilder
    {
        protected ReportItem RItem = new ReportItem();
        protected string Path;
        protected string ActionPath;
        public ReportBuilder(string path){}
        public ReportBuilder(string path,string additional){}
        public ReportItem GetReportItem()
        {
            return RItem;
        }
        public abstract void setOperation();
    }
    class CopyReportItemBuilder : ReportBuilder
    {
        public CopyReportItemBuilder(string path, string additional) : base(path, additional)
        {
            Path = path;
            ActionPath = additional;
        }
        public override void setOperation()
        {
            RItem.time = DateTime.Now.ToString();
            RItem.operation = " Copy from " + Path + " to "+ ActionPath;
        }
    }
    class DeleteReportItemBuilder : ReportBuilder
    {
        public DeleteReportItemBuilder(string path) : base(path)
        {
            Path = path;
        }
        public override void setOperation()
        {
            RItem.time = DateTime.Now.ToString();
            RItem.operation = " Delete " + Path;
        }
    }
    class CreateReportItemBuilder : ReportBuilder
    {
        public CreateReportItemBuilder(string path) : base(path)
        {
            Path = path;
        }
        public override void setOperation()
        {
            RItem.time = DateTime.Now.ToString();
            RItem.operation = " Create " + Path;
        }
    }
    class MoveReportItemBuilder : ReportBuilder
    {
        public MoveReportItemBuilder(string path, string additional) : base(path, additional)
        {
            Path = path;
            ActionPath = additional;
        }
        public override void setOperation()
        {
            RItem.time = DateTime.Now.ToString();
            RItem.operation = " Move from " + Path + " to " + ActionPath;
        }
    }
    class OpenReportItemBuilder : ReportBuilder
    {
        public OpenReportItemBuilder(string path) : base(path)
        {
            Path = path;
        }
        public override void setOperation()
        {
            RItem.time = DateTime.Now.ToString();
            RItem.operation = " Open " + Path;
        }
    }
    class RenameReportItemBuilder : ReportBuilder
    {
        public RenameReportItemBuilder(string path, string additional) : base(path, additional)
        {
            Path = path;
            ActionPath = additional;
        }
        public override void setOperation()
        {
            RItem.time = DateTime.Now.ToString();
            RItem.operation = " Rename from " + Path + " to " + ActionPath;
        }
    }
    class Director
    {
        private ReportBuilder builder;
        public void CopyReport(string path, string ActionPath)
        {
            this.builder = new CopyReportItemBuilder(path,ActionPath);
        }
        public void MoveReport(string path, string ActionPath)
        {
            this.builder = new MoveReportItemBuilder(path, ActionPath);
        }
        public void DeleteReport(string path)
        {
            this.builder = new DeleteReportItemBuilder(path);
        }
        public void OpenReport(string path)
        {
            this.builder = new OpenReportItemBuilder(path);
        }
        public void CreateReport(string path)
        {
            this.builder = new CreateReportItemBuilder(path);
        }
        public void RenameReport(string path, string ActionPath)
        {
            this.builder = new RenameReportItemBuilder(path, ActionPath);
        }
        public ReportItem GetReportItem()
        {
            return builder.GetReportItem();
        }
        public void BuildReport()
        {
            builder.setOperation();
        }
    }
}
