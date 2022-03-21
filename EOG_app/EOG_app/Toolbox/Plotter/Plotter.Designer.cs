namespace Toolbox
{
    partial class Plotter
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ZedGraphic = new ZedGraph.ZedGraphControl();
            this.SuspendLayout();
            // 
            // ZedGraphic
            // 
            this.ZedGraphic.AutoSize = true;
            this.ZedGraphic.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ZedGraphic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ZedGraphic.Font = new System.Drawing.Font("Microsoft Sans Serif", 1F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Pixel, ((byte)(1)), true);
            this.ZedGraphic.Location = new System.Drawing.Point(0, 0);
            this.ZedGraphic.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.ZedGraphic.Name = "ZedGraphic";
            this.ZedGraphic.ScrollGrace = 0D;
            this.ZedGraphic.ScrollMaxX = 0D;
            this.ZedGraphic.ScrollMaxY = 0D;
            this.ZedGraphic.ScrollMaxY2 = 0D;
            this.ZedGraphic.ScrollMinX = 0D;
            this.ZedGraphic.ScrollMinY = 100D;
            this.ZedGraphic.ScrollMinY2 = 0D;
            this.ZedGraphic.Size = new System.Drawing.Size(600, 500);
            this.ZedGraphic.TabIndex = 0;
            this.ZedGraphic.UseExtendedPrintDialog = true;
            // 
            // Plotter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ZedGraphic);
            this.Name = "Plotter";
            this.Size = new System.Drawing.Size(600, 500);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ZedGraph.ZedGraphControl ZedGraphic;
    }
}
