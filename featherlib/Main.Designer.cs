namespace featherlib
{
    partial class main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main));
            this.main_layout = new System.Windows.Forms.TableLayoutPanel();
            this.nav_tree = new System.Windows.Forms.TreeView();
            this.menu_layout = new System.Windows.Forms.TableLayoutPanel();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadLibraryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveLibraryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createLibraryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.main_layout.SuspendLayout();
            this.menu_layout.SuspendLayout();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // main_layout
            // 
            this.main_layout.ColumnCount = 2;
            this.main_layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.main_layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.main_layout.Controls.Add(this.nav_tree, 0, 0);
            this.main_layout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.main_layout.Location = new System.Drawing.Point(0, 40);
            this.main_layout.Name = "main_layout";
            this.main_layout.RowCount = 1;
            this.main_layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.main_layout.Size = new System.Drawing.Size(782, 465);
            this.main_layout.TabIndex = 0;
            // 
            // nav_tree
            // 
            this.nav_tree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nav_tree.Location = new System.Drawing.Point(3, 3);
            this.nav_tree.Name = "nav_tree";
            this.nav_tree.Size = new System.Drawing.Size(228, 459);
            this.nav_tree.TabIndex = 0;
            // 
            // menu_layout
            // 
            this.menu_layout.ColumnCount = 1;
            this.menu_layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.menu_layout.Controls.Add(this.menu, 0, 0);
            this.menu_layout.Location = new System.Drawing.Point(3, 2);
            this.menu_layout.Name = "menu_layout";
            this.menu_layout.RowCount = 1;
            this.menu_layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.menu_layout.Size = new System.Drawing.Size(779, 35);
            this.menu_layout.TabIndex = 1;
            // 
            // menu
            // 
            this.menu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(779, 35);
            this.menu.TabIndex = 0;
            this.menu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadLibraryToolStripMenuItem,
            this.saveLibraryToolStripMenuItem,
            this.createLibraryToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 31);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadLibraryToolStripMenuItem
            // 
            this.loadLibraryToolStripMenuItem.Name = "loadLibraryToolStripMenuItem";
            this.loadLibraryToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.loadLibraryToolStripMenuItem.Text = "Load library";
            // 
            // saveLibraryToolStripMenuItem
            // 
            this.saveLibraryToolStripMenuItem.Name = "saveLibraryToolStripMenuItem";
            this.saveLibraryToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.saveLibraryToolStripMenuItem.Text = "Save library";
            // 
            // createLibraryToolStripMenuItem
            // 
            this.createLibraryToolStripMenuItem.Name = "createLibraryToolStripMenuItem";
            this.createLibraryToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.createLibraryToolStripMenuItem.Text = "Create library";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectionToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(74, 31);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // connectionToolStripMenuItem
            // 
            this.connectionToolStripMenuItem.Name = "connectionToolStripMenuItem";
            this.connectionToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.connectionToolStripMenuItem.Text = "Connection";
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(782, 505);
            this.Controls.Add(this.menu_layout);
            this.Controls.Add(this.main_layout);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "main";
            this.Text = "featherlib";
            this.main_layout.ResumeLayout(false);
            this.menu_layout.ResumeLayout(false);
            this.menu_layout.PerformLayout();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel main_layout;
        private System.Windows.Forms.TreeView nav_tree;
        private System.Windows.Forms.TableLayoutPanel menu_layout;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadLibraryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveLibraryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createLibraryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectionToolStripMenuItem;
    }
}

