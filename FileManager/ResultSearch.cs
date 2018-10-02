using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileManager1
{
    public partial class ResultSearch : Form
    {
        public ResultSearch()
        {
            InitializeComponent();
            Presenter.ShowList(listView1);
        }

        private void ListView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Presenter.OpenResult(listView1);
        }
    }
}
