namespace FileManager1
{
    partial class FileManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileManager));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listView1 = new System.Windows.Forms.ListView();
            this.ColumnName1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnType1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CopyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MoveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.InsertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchForUnrepeatableWordsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchHTMLFileByTitleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnName2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnType2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.MainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.underDevelopmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutProgramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonBack1 = new System.Windows.Forms.Button();
            this.buttonRefresh1 = new System.Windows.Forms.Button();
            this.buttonAddFile1 = new System.Windows.Forms.Button();
            this.buttonAddFolder1 = new System.Windows.Forms.Button();
            this.buttonBack2 = new System.Windows.Forms.Button();
            this.buttonAddFolder2 = new System.Windows.Forms.Button();
            this.buttonRefresh2 = new System.Windows.Forms.Button();
            this.buttonAddFile2 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Date modified";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 75);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listView2);
            this.splitContainer1.Size = new System.Drawing.Size(809, 420);
            this.splitContainer1.SplitterDistance = 404;
            this.splitContainer1.TabIndex = 0;
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnName1,
            this.columnType1,
            this.columnHeader1});
            this.listView1.ContextMenuStrip = this.contextMenuStrip1;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.LargeImageList = this.imageList1;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(404, 420);
            this.listView1.SmallImageList = this.imageList1;
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // ColumnName1
            // 
            this.ColumnName1.Text = "Name";
            this.ColumnName1.Width = 150;
            // 
            // columnType1
            // 
            this.columnType1.Text = "Type";
            this.columnType1.Width = 120;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Date modified";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CopyMenuItem,
            this.MoveMenuItem,
            this.InsertToolStripMenuItem,
            this.DeleteMenuItem,
            this.searchForUnrepeatableWordsToolStripMenuItem,
            this.searchHTMLFileByTitleToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(235, 136);
            // 
            // CopyMenuItem
            // 
            this.CopyMenuItem.Name = "CopyMenuItem";
            this.CopyMenuItem.Size = new System.Drawing.Size(234, 22);
            this.CopyMenuItem.Text = "Copy";
            this.CopyMenuItem.Click += new System.EventHandler(this.CopyMenuItem_Click);
            // 
            // MoveMenuItem
            // 
            this.MoveMenuItem.Name = "MoveMenuItem";
            this.MoveMenuItem.Size = new System.Drawing.Size(234, 22);
            this.MoveMenuItem.Text = "Move";
            this.MoveMenuItem.Click += new System.EventHandler(this.MoveMenuItem_Click);
            // 
            // InsertToolStripMenuItem
            // 
            this.InsertToolStripMenuItem.Name = "InsertToolStripMenuItem";
            this.InsertToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.InsertToolStripMenuItem.Text = "Paste";
            this.InsertToolStripMenuItem.Click += new System.EventHandler(this.InsertToolStripMenuItem_Click);
            // 
            // DeleteMenuItem
            // 
            this.DeleteMenuItem.Name = "DeleteMenuItem";
            this.DeleteMenuItem.Size = new System.Drawing.Size(234, 22);
            this.DeleteMenuItem.Text = "Delete";
            this.DeleteMenuItem.Click += new System.EventHandler(this.DeleteMenuItem_Click);
            // 
            // searchForUnrepeatableWordsToolStripMenuItem
            // 
            this.searchForUnrepeatableWordsToolStripMenuItem.Name = "searchForUnrepeatableWordsToolStripMenuItem";
            this.searchForUnrepeatableWordsToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.searchForUnrepeatableWordsToolStripMenuItem.Text = "Search for unrepeatable words";
            this.searchForUnrepeatableWordsToolStripMenuItem.Click += new System.EventHandler(this.SearchForUnrepeatableWordsToolStripMenuItem_Click);
            // 
            // searchHTMLFileByTitleToolStripMenuItem
            // 
            this.searchHTMLFileByTitleToolStripMenuItem.Name = "searchHTMLFileByTitleToolStripMenuItem";
            this.searchHTMLFileByTitleToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.searchHTMLFileByTitleToolStripMenuItem.Text = "Search HTML file by title";
            this.searchHTMLFileByTitleToolStripMenuItem.Click += new System.EventHandler(this.SearchHTMLFileByTitleToolStripMenuItem_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Folder.png");
            this.imageList1.Images.SetKeyName(1, "File.png");
            // 
            // listView2
            // 
            this.listView2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnName2,
            this.columnType2,
            this.columnHeader2});
            this.listView2.ContextMenuStrip = this.contextMenuStrip1;
            this.listView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.listView2.LargeImageList = this.imageList1;
            this.listView2.Location = new System.Drawing.Point(0, 0);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(401, 420);
            this.listView2.SmallImageList = this.imageList1;
            this.listView2.TabIndex = 0;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // columnName2
            // 
            this.columnName2.Text = "Name";
            this.columnName2.Width = 150;
            // 
            // columnType2
            // 
            this.columnType2.Text = "Type";
            this.columnType2.Width = 120;
            // 
            // comboBox2
            // 
            this.comboBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(625, 48);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(196, 21);
            this.comboBox2.TabIndex = 11;
            // 
            // MainToolStripMenuItem
            // 
            this.MainToolStripMenuItem.Name = "MainToolStripMenuItem";
            this.MainToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutProgramToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(833, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.underDevelopmentToolStripMenuItem});
            this.fileToolStripMenuItem.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // underDevelopmentToolStripMenuItem
            // 
            this.underDevelopmentToolStripMenuItem.Name = "HelpToolStripMenuItem";
            this.underDevelopmentToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.underDevelopmentToolStripMenuItem.Text = "Help";
            this.underDevelopmentToolStripMenuItem.Click += new System.EventHandler(this.HelpToolStripMenuItem_Click);
            // 
            // aboutProgramToolStripMenuItem
            // 
            this.aboutProgramToolStripMenuItem.ForeColor = System.Drawing.SystemColors.InfoText;
            this.aboutProgramToolStripMenuItem.Name = "aboutProgramToolStripMenuItem";
            this.aboutProgramToolStripMenuItem.Size = new System.Drawing.Size(101, 20);
            this.aboutProgramToolStripMenuItem.Text = "About program";
            this.aboutProgramToolStripMenuItem.Click += new System.EventHandler(this.AboutProgramToolStripMenuItem_Click);
            // 
            // buttonBack1
            // 
            this.buttonBack1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBack1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonBack1.Image = ((System.Drawing.Image)(resources.GetObject("buttonBack1.Image")));
            this.buttonBack1.Location = new System.Drawing.Point(12, 32);
            this.buttonBack1.Name = "buttonBack1";
            this.buttonBack1.Size = new System.Drawing.Size(38, 37);
            this.buttonBack1.TabIndex = 2;
            this.buttonBack1.UseVisualStyleBackColor = true;
            this.buttonBack1.Click += new System.EventHandler(this.ButtonBack1_Click);
            // 
            // buttonRefresh1
            // 
            this.buttonRefresh1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRefresh1.ForeColor = System.Drawing.Color.Black;
            this.buttonRefresh1.Image = ((System.Drawing.Image)(resources.GetObject("buttonRefresh1.Image")));
            this.buttonRefresh1.Location = new System.Drawing.Point(56, 32);
            this.buttonRefresh1.Name = "buttonRefresh1";
            this.buttonRefresh1.Size = new System.Drawing.Size(38, 37);
            this.buttonRefresh1.TabIndex = 3;
            this.buttonRefresh1.UseVisualStyleBackColor = true;
            this.buttonRefresh1.Click += new System.EventHandler(this.ButtonRefresh1_Click);
            // 
            // buttonAddFile1
            // 
            this.buttonAddFile1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddFile1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonAddFile1.Image = ((System.Drawing.Image)(resources.GetObject("buttonAddFile1.Image")));
            this.buttonAddFile1.Location = new System.Drawing.Point(100, 32);
            this.buttonAddFile1.Name = "buttonAddFile1";
            this.buttonAddFile1.Size = new System.Drawing.Size(38, 37);
            this.buttonAddFile1.TabIndex = 4;
            this.buttonAddFile1.UseVisualStyleBackColor = true;
            this.buttonAddFile1.Click += new System.EventHandler(this.ButtonAddFile1_Click);
            // 
            // buttonAddFolder1
            // 
            this.buttonAddFolder1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddFolder1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonAddFolder1.Image = ((System.Drawing.Image)(resources.GetObject("buttonAddFolder1.Image")));
            this.buttonAddFolder1.Location = new System.Drawing.Point(144, 32);
            this.buttonAddFolder1.Name = "buttonAddFolder1";
            this.buttonAddFolder1.Size = new System.Drawing.Size(38, 37);
            this.buttonAddFolder1.TabIndex = 5;
            this.buttonAddFolder1.UseVisualStyleBackColor = true;
            this.buttonAddFolder1.Click += new System.EventHandler(this.ButtonAddFolder1_Click);
            // 
            // buttonBack2
            // 
            this.buttonBack2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBack2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonBack2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBack2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonBack2.Image = ((System.Drawing.Image)(resources.GetObject("buttonBack2.Image")));
            this.buttonBack2.Location = new System.Drawing.Point(420, 32);
            this.buttonBack2.Name = "buttonBack2";
            this.buttonBack2.Size = new System.Drawing.Size(38, 37);
            this.buttonBack2.TabIndex = 6;
            this.buttonBack2.UseVisualStyleBackColor = true;
            this.buttonBack2.Click += new System.EventHandler(this.ButtonBack2_Click);
            // 
            // buttonAddFolder2
            // 
            this.buttonAddFolder2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddFolder2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddFolder2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonAddFolder2.Image = ((System.Drawing.Image)(resources.GetObject("buttonAddFolder2.Image")));
            this.buttonAddFolder2.Location = new System.Drawing.Point(552, 32);
            this.buttonAddFolder2.Name = "buttonAddFolder2";
            this.buttonAddFolder2.Size = new System.Drawing.Size(38, 37);
            this.buttonAddFolder2.TabIndex = 7;
            this.buttonAddFolder2.UseVisualStyleBackColor = true;
            this.buttonAddFolder2.Click += new System.EventHandler(this.ButtonAddFolder2_Click);
            // 
            // buttonRefresh2
            // 
            this.buttonRefresh2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRefresh2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRefresh2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonRefresh2.Image = ((System.Drawing.Image)(resources.GetObject("buttonRefresh2.Image")));
            this.buttonRefresh2.Location = new System.Drawing.Point(464, 32);
            this.buttonRefresh2.Name = "buttonRefresh2";
            this.buttonRefresh2.Size = new System.Drawing.Size(38, 37);
            this.buttonRefresh2.TabIndex = 8;
            this.buttonRefresh2.UseVisualStyleBackColor = true;
            this.buttonRefresh2.Click += new System.EventHandler(this.ButtonRefresh2_Click);
            // 
            // buttonAddFile2
            // 
            this.buttonAddFile2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddFile2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddFile2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonAddFile2.Image = ((System.Drawing.Image)(resources.GetObject("buttonAddFile2.Image")));
            this.buttonAddFile2.Location = new System.Drawing.Point(508, 32);
            this.buttonAddFile2.Name = "buttonAddFile2";
            this.buttonAddFile2.Size = new System.Drawing.Size(38, 37);
            this.buttonAddFile2.TabIndex = 9;
            this.buttonAddFile2.UseVisualStyleBackColor = true;
            this.buttonAddFile2.Click += new System.EventHandler(this.ButtonAddFile2_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(220, 48);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(196, 21);
            this.comboBox1.TabIndex = 10;
            // 
            // FileManager
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(833, 531);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.buttonAddFile2);
            this.Controls.Add(this.buttonRefresh2);
            this.Controls.Add(this.buttonAddFolder2);
            this.Controls.Add(this.buttonBack2);
            this.Controls.Add(this.buttonAddFolder1);
            this.Controls.Add(this.buttonAddFile1);
            this.Controls.Add(this.buttonRefresh1);
            this.Controls.Add(this.buttonBack1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FileManager";
            this.Text = "FileManager";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader ColumnName1;
        private System.Windows.Forms.ColumnHeader columnType1;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader columnName2;
        private System.Windows.Forms.ColumnHeader columnType2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutProgramToolStripMenuItem;
        private System.Windows.Forms.Button buttonBack1;
        private System.Windows.Forms.Button buttonRefresh1;
        private System.Windows.Forms.Button buttonAddFile1;
        private System.Windows.Forms.Button buttonAddFolder1;
        private System.Windows.Forms.Button buttonBack2;
        private System.Windows.Forms.Button buttonAddFolder2;
        private System.Windows.Forms.Button buttonRefresh2;
        private System.Windows.Forms.Button buttonAddFile2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem CopyMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MoveMenuItem;
        private System.Windows.Forms.ToolStripMenuItem InsertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MainToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ToolStripMenuItem underDevelopmentToolStripMenuItem;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripMenuItem searchForUnrepeatableWordsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchHTMLFileByTitleToolStripMenuItem;
    }
}

