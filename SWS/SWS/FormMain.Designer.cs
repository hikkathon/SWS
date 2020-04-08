namespace SWS
{
    partial class FormMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tXTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.csvToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xlsxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scrapSetingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.webUpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.byToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonData = new System.Windows.Forms.Button();
            this.TitulBar = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panelBorderTop = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnslideClose = new System.Windows.Forms.PictureBox();
            this.iconsCloseWindow = new System.Windows.Forms.PictureBox();
            this.iconsMinimizeWindow = new System.Windows.Forms.PictureBox();
            this.btnslide = new System.Windows.Forms.PictureBox();
            this.iconsMaximizeWindow = new System.Windows.Forms.PictureBox();
            this.buttonDonate = new System.Windows.Forms.Button();
            this.iconsRestoreWindow = new System.Windows.Forms.PictureBox();
            this.buttonAbout = new System.Windows.Forms.Button();
            this.buttonHelp = new System.Windows.Forms.Button();
            this.buttonSetting = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.PanelContented = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.TitulBar.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panelBorderTop.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnslideClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconsCloseWindow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconsMinimizeWindow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnslide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconsMaximizeWindow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconsRestoreWindow)).BeginInit();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.settingToolStripMenuItem,
            this.webUpdateToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.byToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1524, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.openToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.aboutToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tXTToolStripMenuItem,
            this.csvToolStripMenuItem,
            this.xlsxToolStripMenuItem});
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.saveToolStripMenuItem.Text = "Save as";
            // 
            // tXTToolStripMenuItem
            // 
            this.tXTToolStripMenuItem.Name = "tXTToolStripMenuItem";
            this.tXTToolStripMenuItem.Size = new System.Drawing.Size(97, 22);
            this.tXTToolStripMenuItem.Text = ".txt";
            this.tXTToolStripMenuItem.Click += new System.EventHandler(this.tXTToolStripMenuItem_Click);
            // 
            // csvToolStripMenuItem
            // 
            this.csvToolStripMenuItem.Name = "csvToolStripMenuItem";
            this.csvToolStripMenuItem.Size = new System.Drawing.Size(97, 22);
            this.csvToolStripMenuItem.Text = ".csv";
            this.csvToolStripMenuItem.Click += new System.EventHandler(this.csvToolStripMenuItem_Click);
            // 
            // xlsxToolStripMenuItem
            // 
            this.xlsxToolStripMenuItem.Name = "xlsxToolStripMenuItem";
            this.xlsxToolStripMenuItem.Size = new System.Drawing.Size(97, 22);
            this.xlsxToolStripMenuItem.Text = ".xlsx";
            this.xlsxToolStripMenuItem.Click += new System.EventHandler(this.xlsxToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // settingToolStripMenuItem
            // 
            this.settingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scrapSetingToolStripMenuItem});
            this.settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            this.settingToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.settingToolStripMenuItem.Text = "Setting";
            // 
            // scrapSetingToolStripMenuItem
            // 
            this.scrapSetingToolStripMenuItem.Name = "scrapSetingToolStripMenuItem";
            this.scrapSetingToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.scrapSetingToolStripMenuItem.Text = "Scrap seting";
            // 
            // webUpdateToolStripMenuItem
            // 
            this.webUpdateToolStripMenuItem.Name = "webUpdateToolStripMenuItem";
            this.webUpdateToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.webUpdateToolStripMenuItem.Text = "Web Update";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // byToolStripMenuItem
            // 
            this.byToolStripMenuItem.Name = "byToolStripMenuItem";
            this.byToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.byToolStripMenuItem.Text = "Donate";
            // 
            // buttonData
            // 
            this.buttonData.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.buttonData.FlatAppearance.BorderSize = 0;
            this.buttonData.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.buttonData.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(103)))), ((int)(((byte)(102)))));
            this.buttonData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonData.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonData.ForeColor = System.Drawing.Color.White;
            this.buttonData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonData.Location = new System.Drawing.Point(0, 0);
            this.buttonData.Name = "buttonData";
            this.buttonData.Size = new System.Drawing.Size(126, 63);
            this.buttonData.TabIndex = 1;
            this.buttonData.Text = "Data";
            this.buttonData.UseVisualStyleBackColor = true;
            this.buttonData.Click += new System.EventHandler(this.button1_Click);
            // 
            // TitulBar
            // 
            this.TitulBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.TitulBar.Controls.Add(this.panel7);
            this.TitulBar.Controls.Add(this.panel6);
            this.TitulBar.Controls.Add(this.panel5);
            this.TitulBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitulBar.Location = new System.Drawing.Point(0, 0);
            this.TitulBar.Name = "TitulBar";
            this.TitulBar.Size = new System.Drawing.Size(1524, 100);
            this.TitulBar.TabIndex = 6;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.panelBorderTop);
            this.panel7.Controls.Add(this.panel1);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(354, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1170, 93);
            this.panel7.TabIndex = 4;
            // 
            // panelBorderTop
            // 
            this.panelBorderTop.Controls.Add(this.panel4);
            this.panelBorderTop.Controls.Add(this.panel3);
            this.panelBorderTop.Controls.Add(this.panel2);
            this.panelBorderTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBorderTop.Location = new System.Drawing.Point(0, 14);
            this.panelBorderTop.Name = "panelBorderTop";
            this.panelBorderTop.Size = new System.Drawing.Size(1170, 69);
            this.panelBorderTop.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.panel4.Controls.Add(this.btnslideClose);
            this.panel4.Controls.Add(this.iconsCloseWindow);
            this.panel4.Controls.Add(this.iconsMinimizeWindow);
            this.panel4.Controls.Add(this.btnslide);
            this.panel4.Controls.Add(this.iconsMaximizeWindow);
            this.panel4.Controls.Add(this.buttonDonate);
            this.panel4.Controls.Add(this.iconsRestoreWindow);
            this.panel4.Controls.Add(this.buttonAbout);
            this.panel4.Controls.Add(this.buttonHelp);
            this.panel4.Controls.Add(this.buttonSetting);
            this.panel4.Controls.Add(this.buttonData);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1170, 63);
            this.panel4.TabIndex = 2;
            // 
            // btnslideClose
            // 
            this.btnslideClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnslideClose.Image = ((System.Drawing.Image)(resources.GetObject("btnslideClose.Image")));
            this.btnslideClose.Location = new System.Drawing.Point(5, 13);
            this.btnslideClose.Name = "btnslideClose";
            this.btnslideClose.Size = new System.Drawing.Size(35, 35);
            this.btnslideClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnslideClose.TabIndex = 2;
            this.btnslideClose.TabStop = false;
            this.btnslideClose.Visible = false;
            this.btnslideClose.Click += new System.EventHandler(this.btnslideClose_Click);
            // 
            // iconsCloseWindow
            // 
            this.iconsCloseWindow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconsCloseWindow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconsCloseWindow.Image = ((System.Drawing.Image)(resources.GetObject("iconsCloseWindow.Image")));
            this.iconsCloseWindow.Location = new System.Drawing.Point(1123, 13);
            this.iconsCloseWindow.Name = "iconsCloseWindow";
            this.iconsCloseWindow.Size = new System.Drawing.Size(35, 35);
            this.iconsCloseWindow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iconsCloseWindow.TabIndex = 1;
            this.iconsCloseWindow.TabStop = false;
            this.iconsCloseWindow.Click += new System.EventHandler(this.iconsCloseWindow_Click);
            // 
            // iconsMinimizeWindow
            // 
            this.iconsMinimizeWindow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconsMinimizeWindow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconsMinimizeWindow.Image = ((System.Drawing.Image)(resources.GetObject("iconsMinimizeWindow.Image")));
            this.iconsMinimizeWindow.Location = new System.Drawing.Point(1041, 13);
            this.iconsMinimizeWindow.Name = "iconsMinimizeWindow";
            this.iconsMinimizeWindow.Size = new System.Drawing.Size(35, 35);
            this.iconsMinimizeWindow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iconsMinimizeWindow.TabIndex = 1;
            this.iconsMinimizeWindow.TabStop = false;
            this.iconsMinimizeWindow.Click += new System.EventHandler(this.iconsMinimizeWindow_Click);
            // 
            // btnslide
            // 
            this.btnslide.BackColor = System.Drawing.Color.Transparent;
            this.btnslide.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnslide.Image = ((System.Drawing.Image)(resources.GetObject("btnslide.Image")));
            this.btnslide.Location = new System.Drawing.Point(4, 13);
            this.btnslide.Name = "btnslide";
            this.btnslide.Size = new System.Drawing.Size(35, 35);
            this.btnslide.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnslide.TabIndex = 0;
            this.btnslide.TabStop = false;
            this.btnslide.Visible = false;
            this.btnslide.Click += new System.EventHandler(this.btnslide_Click);
            // 
            // iconsMaximizeWindow
            // 
            this.iconsMaximizeWindow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconsMaximizeWindow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconsMaximizeWindow.Image = ((System.Drawing.Image)(resources.GetObject("iconsMaximizeWindow.Image")));
            this.iconsMaximizeWindow.Location = new System.Drawing.Point(1082, 13);
            this.iconsMaximizeWindow.Name = "iconsMaximizeWindow";
            this.iconsMaximizeWindow.Size = new System.Drawing.Size(35, 35);
            this.iconsMaximizeWindow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iconsMaximizeWindow.TabIndex = 1;
            this.iconsMaximizeWindow.TabStop = false;
            this.iconsMaximizeWindow.Click += new System.EventHandler(this.iconsMaximizeWindow_Click);
            // 
            // buttonDonate
            // 
            this.buttonDonate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.buttonDonate.FlatAppearance.BorderSize = 0;
            this.buttonDonate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.buttonDonate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(103)))), ((int)(((byte)(102)))));
            this.buttonDonate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDonate.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDonate.ForeColor = System.Drawing.Color.White;
            this.buttonDonate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDonate.Location = new System.Drawing.Point(528, 0);
            this.buttonDonate.Name = "buttonDonate";
            this.buttonDonate.Size = new System.Drawing.Size(126, 63);
            this.buttonDonate.TabIndex = 1;
            this.buttonDonate.Text = "Donate";
            this.buttonDonate.UseVisualStyleBackColor = true;
            this.buttonDonate.Click += new System.EventHandler(this.buttonDonate_Click);
            // 
            // iconsRestoreWindow
            // 
            this.iconsRestoreWindow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconsRestoreWindow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconsRestoreWindow.Image = ((System.Drawing.Image)(resources.GetObject("iconsRestoreWindow.Image")));
            this.iconsRestoreWindow.Location = new System.Drawing.Point(1082, 13);
            this.iconsRestoreWindow.Name = "iconsRestoreWindow";
            this.iconsRestoreWindow.Size = new System.Drawing.Size(35, 35);
            this.iconsRestoreWindow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iconsRestoreWindow.TabIndex = 1;
            this.iconsRestoreWindow.TabStop = false;
            this.iconsRestoreWindow.Visible = false;
            this.iconsRestoreWindow.Click += new System.EventHandler(this.iconsRestoreWindow_Click);
            // 
            // buttonAbout
            // 
            this.buttonAbout.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.buttonAbout.FlatAppearance.BorderSize = 0;
            this.buttonAbout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.buttonAbout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(103)))), ((int)(((byte)(102)))));
            this.buttonAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAbout.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAbout.ForeColor = System.Drawing.Color.White;
            this.buttonAbout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAbout.Location = new System.Drawing.Point(396, 0);
            this.buttonAbout.Name = "buttonAbout";
            this.buttonAbout.Size = new System.Drawing.Size(126, 63);
            this.buttonAbout.TabIndex = 1;
            this.buttonAbout.Text = "About";
            this.buttonAbout.UseVisualStyleBackColor = true;
            this.buttonAbout.Click += new System.EventHandler(this.buttonAbout_Click);
            // 
            // buttonHelp
            // 
            this.buttonHelp.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.buttonHelp.FlatAppearance.BorderSize = 0;
            this.buttonHelp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.buttonHelp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(103)))), ((int)(((byte)(102)))));
            this.buttonHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHelp.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonHelp.ForeColor = System.Drawing.Color.White;
            this.buttonHelp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonHelp.Location = new System.Drawing.Point(264, 0);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Size = new System.Drawing.Size(126, 63);
            this.buttonHelp.TabIndex = 1;
            this.buttonHelp.Text = "Help";
            this.buttonHelp.UseVisualStyleBackColor = true;
            this.buttonHelp.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // buttonSetting
            // 
            this.buttonSetting.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.buttonSetting.FlatAppearance.BorderSize = 0;
            this.buttonSetting.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.buttonSetting.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(103)))), ((int)(((byte)(102)))));
            this.buttonSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSetting.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSetting.ForeColor = System.Drawing.Color.White;
            this.buttonSetting.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSetting.Location = new System.Drawing.Point(132, 0);
            this.buttonSetting.Name = "buttonSetting";
            this.buttonSetting.Size = new System.Drawing.Size(126, 63);
            this.buttonSetting.TabIndex = 1;
            this.buttonSetting.Text = "Setting";
            this.buttonSetting.UseVisualStyleBackColor = true;
            this.buttonSetting.Click += new System.EventHandler(this.buttonSetting_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(103)))), ((int)(((byte)(102)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 66);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1170, 3);
            this.panel3.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(103)))), ((int)(((byte)(102)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1170, 3);
            this.panel2.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1170, 14);
            this.panel1.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.pictureBox1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(354, 93);
            this.panel6.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(354, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 93);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1524, 7);
            this.panel5.TabIndex = 1;
            // 
            // PanelContented
            // 
            this.PanelContented.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.PanelContented.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelContented.Location = new System.Drawing.Point(0, 100);
            this.PanelContented.Name = "PanelContented";
            this.PanelContented.Size = new System.Drawing.Size(1524, 615);
            this.PanelContented.TabIndex = 7;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1524, 715);
            this.Controls.Add(this.PanelContented);
            this.Controls.Add(this.TitulBar);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(1300, 650);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simple Web Scraper";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.TitulBar.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panelBorderTop.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnslideClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconsCloseWindow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconsMinimizeWindow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnslide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconsMaximizeWindow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconsRestoreWindow)).EndInit();
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem webUpdateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem byToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tXTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem csvToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xlsxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scrapSetingToolStripMenuItem;
        private System.Windows.Forms.Panel TitulBar;
        private System.Windows.Forms.PictureBox btnslide;
        private System.Windows.Forms.Panel PanelContented;
        private System.Windows.Forms.Panel panelBorderTop;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.PictureBox iconsMinimizeWindow;
        private System.Windows.Forms.PictureBox iconsRestoreWindow;
        private System.Windows.Forms.PictureBox iconsMaximizeWindow;
        private System.Windows.Forms.PictureBox iconsCloseWindow;
        private System.Windows.Forms.PictureBox btnslideClose;
        private System.Windows.Forms.Button buttonData;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button buttonSetting;
        private System.Windows.Forms.Button buttonAbout;
        private System.Windows.Forms.Button buttonHelp;
        private System.Windows.Forms.Button buttonDonate;
    }
}

