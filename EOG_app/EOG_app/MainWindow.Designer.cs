namespace EOG_app
{
    partial class MainWindow
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.panel3 = new System.Windows.Forms.Panel();
            this.MetroTabControl = new MetroFramework.Controls.MetroTabControl();
            this.TabPage_Config = new MetroFramework.Controls.MetroTabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ConfigButton_Connect = new MetroFramework.Controls.MetroButton();
            this.ConfigComboBox = new MetroFramework.Controls.MetroComboBox();
            this.ConfigButton_Led = new MetroFramework.Controls.MetroButton();
            this.ConfigButton_Initiate = new MetroFramework.Controls.MetroButton();
            this.TabPage_Pointer = new MetroFramework.Controls.MetroTabPage();
            this.button_comer = new MetroFramework.Controls.MetroButton();
            this.MousePointer = new System.Windows.Forms.PictureBox();
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.mainImageList = new System.Windows.Forms.ImageList(this.components);
            this.PlotterConfig = new Toolbox.Plotter();
            this.button_beber = new MetroFramework.Controls.MetroButton();
            this.panel3.SuspendLayout();
            this.MetroTabControl.SuspendLayout();
            this.TabPage_Config.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.TabPage_Pointer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MousePointer)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.MetroTabControl);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(20, 60);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(765, 466);
            this.panel3.TabIndex = 2;
            // 
            // MetroTabControl
            // 
            this.MetroTabControl.Controls.Add(this.TabPage_Config);
            this.MetroTabControl.Controls.Add(this.TabPage_Pointer);
            this.MetroTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MetroTabControl.Location = new System.Drawing.Point(0, 0);
            this.MetroTabControl.Name = "MetroTabControl";
            this.MetroTabControl.SelectedIndex = 1;
            this.MetroTabControl.Size = new System.Drawing.Size(765, 466);
            this.MetroTabControl.TabIndex = 0;
            this.MetroTabControl.UseSelectable = true;
            // 
            // TabPage_Config
            // 
            this.TabPage_Config.Controls.Add(this.panel2);
            this.TabPage_Config.Controls.Add(this.panel1);
            this.TabPage_Config.HorizontalScrollbarBarColor = true;
            this.TabPage_Config.HorizontalScrollbarHighlightOnWheel = false;
            this.TabPage_Config.HorizontalScrollbarSize = 10;
            this.TabPage_Config.Location = new System.Drawing.Point(4, 38);
            this.TabPage_Config.Name = "TabPage_Config";
            this.TabPage_Config.Size = new System.Drawing.Size(757, 424);
            this.TabPage_Config.TabIndex = 0;
            this.TabPage_Config.Text = "Configurações";
            this.TabPage_Config.VerticalScrollbarBarColor = true;
            this.TabPage_Config.VerticalScrollbarHighlightOnWheel = false;
            this.TabPage_Config.VerticalScrollbarSize = 10;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.PlotterConfig);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.ForeColor = System.Drawing.Color.Transparent;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(757, 387);
            this.panel2.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 387);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(757, 37);
            this.panel1.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.42857F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.57143F));
            this.tableLayoutPanel1.Controls.Add(this.ConfigButton_Connect, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.ConfigComboBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ConfigButton_Led, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.ConfigButton_Initiate, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(757, 37);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // ConfigButton_Connect
            // 
            this.ConfigButton_Connect.BackgroundImage = global::EOG_app.Properties.Resources.Disconnected_96px;
            this.ConfigButton_Connect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ConfigButton_Connect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConfigButton_Connect.Location = new System.Drawing.Point(438, 3);
            this.ConfigButton_Connect.Name = "ConfigButton_Connect";
            this.ConfigButton_Connect.Size = new System.Drawing.Size(31, 31);
            this.ConfigButton_Connect.TabIndex = 1;
            this.ConfigButton_Connect.UseSelectable = true;
            this.ConfigButton_Connect.Click += new System.EventHandler(this.ConfigButton_Connect_Click);
            // 
            // ConfigComboBox
            // 
            this.ConfigComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConfigComboBox.FormattingEnabled = true;
            this.ConfigComboBox.ItemHeight = 23;
            this.ConfigComboBox.Location = new System.Drawing.Point(3, 3);
            this.ConfigComboBox.Name = "ConfigComboBox";
            this.ConfigComboBox.Size = new System.Drawing.Size(429, 29);
            this.ConfigComboBox.TabIndex = 0;
            this.ConfigComboBox.UseSelectable = true;
            // 
            // ConfigButton_Led
            // 
            this.ConfigButton_Led.BackgroundImage = global::EOG_app.Properties.Resources.Light_Off_96px;
            this.ConfigButton_Led.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ConfigButton_Led.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConfigButton_Led.Location = new System.Drawing.Point(475, 3);
            this.ConfigButton_Led.Name = "ConfigButton_Led";
            this.ConfigButton_Led.Size = new System.Drawing.Size(31, 31);
            this.ConfigButton_Led.TabIndex = 2;
            this.ConfigButton_Led.UseSelectable = true;
            this.ConfigButton_Led.Click += new System.EventHandler(this.ConfigButton_Led_Click);
            // 
            // ConfigButton_Initiate
            // 
            this.ConfigButton_Initiate.BackgroundImage = global::EOG_app.Properties.Resources.Circled_Play_96px;
            this.ConfigButton_Initiate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ConfigButton_Initiate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConfigButton_Initiate.Location = new System.Drawing.Point(512, 3);
            this.ConfigButton_Initiate.Name = "ConfigButton_Initiate";
            this.ConfigButton_Initiate.Size = new System.Drawing.Size(31, 31);
            this.ConfigButton_Initiate.TabIndex = 3;
            this.ConfigButton_Initiate.UseSelectable = true;
            this.ConfigButton_Initiate.Click += new System.EventHandler(this.ConfigButton_Initiate_Click);
            // 
            // TabPage_Pointer
            // 
            this.TabPage_Pointer.Controls.Add(this.button_beber);
            this.TabPage_Pointer.Controls.Add(this.button_comer);
            this.TabPage_Pointer.Controls.Add(this.MousePointer);
            this.TabPage_Pointer.HorizontalScrollbarBarColor = true;
            this.TabPage_Pointer.HorizontalScrollbarHighlightOnWheel = false;
            this.TabPage_Pointer.HorizontalScrollbarSize = 10;
            this.TabPage_Pointer.Location = new System.Drawing.Point(4, 38);
            this.TabPage_Pointer.Name = "TabPage_Pointer";
            this.TabPage_Pointer.Size = new System.Drawing.Size(757, 424);
            this.TabPage_Pointer.TabIndex = 1;
            this.TabPage_Pointer.Text = "Mouse";
            this.TabPage_Pointer.VerticalScrollbarBarColor = true;
            this.TabPage_Pointer.VerticalScrollbarHighlightOnWheel = false;
            this.TabPage_Pointer.VerticalScrollbarSize = 10;
            // 
            // button_comer
            // 
            this.button_comer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_comer.BackgroundImage")));
            this.button_comer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_comer.Location = new System.Drawing.Point(323, 3);
            this.button_comer.Name = "button_comer";
            this.button_comer.Size = new System.Drawing.Size(88, 76);
            this.button_comer.TabIndex = 5;
            this.button_comer.UseSelectable = true;
            this.button_comer.Click += new System.EventHandler(this.button_comer_Click);
            // 
            // MousePointer
            // 
            this.MousePointer.BackColor = System.Drawing.Color.Transparent;
            this.MousePointer.Image = ((System.Drawing.Image)(resources.GetObject("MousePointer.Image")));
            this.MousePointer.Location = new System.Drawing.Point(354, 191);
            this.MousePointer.Name = "MousePointer";
            this.MousePointer.Size = new System.Drawing.Size(20, 31);
            this.MousePointer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.MousePointer.TabIndex = 2;
            this.MousePointer.TabStop = false;
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Location = new System.Drawing.Point(0, 0);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.Size = new System.Drawing.Size(200, 100);
            this.metroTabControl1.TabIndex = 0;
            this.metroTabControl1.UseSelectable = true;
            // 
            // mainImageList
            // 
            this.mainImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("mainImageList.ImageStream")));
            this.mainImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.mainImageList.Images.SetKeyName(0, "Play");
            this.mainImageList.Images.SetKeyName(1, "Connected");
            this.mainImageList.Images.SetKeyName(2, "Disconnected");
            this.mainImageList.Images.SetKeyName(3, "Light Off");
            this.mainImageList.Images.SetKeyName(4, "Light On");
            this.mainImageList.Images.SetKeyName(5, "Pause");
            // 
            // PlotterConfig
            // 
            this.PlotterConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlotterConfig.FramesPerSecond = 10D;
            this.PlotterConfig.Location = new System.Drawing.Point(0, 0);
            this.PlotterConfig.MaxHeight = 0D;
            this.PlotterConfig.MaxPoints = 0;
            this.PlotterConfig.MaxWidth = 0D;
            this.PlotterConfig.Name = "PlotterConfig";
            this.PlotterConfig.SignalPeriod = 0D;
            this.PlotterConfig.Size = new System.Drawing.Size(757, 387);
            this.PlotterConfig.TabIndex = 0;
            // 
            // button_beber
            // 
            this.button_beber.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_beber.BackgroundImage")));
            this.button_beber.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_beber.Location = new System.Drawing.Point(323, 349);
            this.button_beber.Name = "button_beber";
            this.button_beber.Size = new System.Drawing.Size(88, 76);
            this.button_beber.TabIndex = 6;
            this.button_beber.UseSelectable = true;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(805, 546);
            this.Controls.Add(this.panel3);
            this.Name = "MainWindow";
            this.Text = "EOG app";
            this.panel3.ResumeLayout(false);
            this.MetroTabControl.ResumeLayout(false);
            this.TabPage_Config.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.TabPage_Pointer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MousePointer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel3;
        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private MetroFramework.Controls.MetroTabControl MetroTabControl;
        private MetroFramework.Controls.MetroTabPage TabPage_Config;
        private MetroFramework.Controls.MetroTabPage TabPage_Pointer;
        private System.Windows.Forms.Panel panel2;
        private Toolbox.Plotter PlotterConfig;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MetroFramework.Controls.MetroButton ConfigButton_Connect;
        private MetroFramework.Controls.MetroComboBox ConfigComboBox;
        private MetroFramework.Controls.MetroButton ConfigButton_Led;
        private MetroFramework.Controls.MetroButton ConfigButton_Initiate;
        private System.Windows.Forms.PictureBox MousePointer;
        private System.Windows.Forms.ImageList mainImageList;
        private MetroFramework.Controls.MetroButton button_comer;
        private MetroFramework.Controls.MetroButton button_beber;
    }
}

