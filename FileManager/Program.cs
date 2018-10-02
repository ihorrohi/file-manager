﻿using System;
using System.Windows.Forms;

namespace FileManager1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FileManager());
            Application.Run(new ReportForm());
        }
    }
}
