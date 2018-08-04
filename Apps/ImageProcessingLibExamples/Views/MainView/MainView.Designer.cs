namespace ImageProcessingLibExamples.Views
{
    partial class MainView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            this.cbImages = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbResults = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbExamples = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.spbImage = new ImageProcessingLibExamples.Controls.ScrollablePictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.miCurrentImage = new System.Windows.Forms.ToolStripMenuItem();
            this.miAllImages = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.miClose = new System.Windows.Forms.ToolStripMenuItem();
            this.miMetrics = new System.Windows.Forms.ToolStripMenuItem();
            this.miHistogram = new System.Windows.Forms.ToolStripMenuItem();
            this.miColorCalculator = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.slSummary = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbImages
            // 
            this.cbImages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbImages.FormattingEnabled = true;
            this.cbImages.Location = new System.Drawing.Point(51, 19);
            this.cbImages.Name = "cbImages";
            this.cbImages.Size = new System.Drawing.Size(150, 21);
            this.cbImages.TabIndex = 1;
            this.cbImages.SelectionChangeCommitted += new System.EventHandler(this.cbImages_SelectionChangeCommitted);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cbResults);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbExamples);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnPrevious);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnNext);
            this.groupBox1.Controls.Add(this.cbImages);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1240, 50);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Example selection";
            // 
            // cbResults
            // 
            this.cbResults.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbResults.Enabled = false;
            this.cbResults.FormattingEnabled = true;
            this.cbResults.Location = new System.Drawing.Point(470, 19);
            this.cbResults.Name = "cbResults";
            this.cbResults.Size = new System.Drawing.Size(200, 21);
            this.cbResults.TabIndex = 8;
            this.cbResults.SelectionChangeCommitted += new System.EventHandler(this.cbResults_SelectionChangeCommitted);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(419, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Results:";
            // 
            // cbExamples
            // 
            this.cbExamples.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbExamples.FormattingEnabled = true;
            this.cbExamples.Location = new System.Drawing.Point(263, 19);
            this.cbExamples.Name = "cbExamples";
            this.cbExamples.Size = new System.Drawing.Size(150, 21);
            this.cbExamples.TabIndex = 6;
            this.cbExamples.SelectionChangeCommitted += new System.EventHandler(this.cbExamples_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(207, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Example:";
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(676, 19);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(75, 21);
            this.btnPrevious.TabIndex = 4;
            this.btnPrevious.Text = "<< Previous";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Image:";
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(757, 19);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 21);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = "Next >>";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.spbImage);
            this.groupBox2.Location = new System.Drawing.Point(12, 83);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1240, 653);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Image";
            // 
            // spbImage
            // 
            this.spbImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.spbImage.Image = null;
            this.spbImage.Location = new System.Drawing.Point(6, 19);
            this.spbImage.Name = "spbImage";
            this.spbImage.Size = new System.Drawing.Size(1228, 628);
            this.spbImage.TabIndex = 0;
            this.spbImage.OnMouseClick += new System.Action<int, int>(this.spbImage_OnMouseClickOrMove);
            this.spbImage.OnMouseDoubleClick += new System.Action<int, int>(this.spbImage_OnMouseDoubleClick);
            this.spbImage.OnMouseMove += new System.Action<int, int>(this.spbImage_OnMouseClickOrMove);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.miMetrics,
            this.miHistogram,
            this.miColorCalculator});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1264, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miOpen,
            this.saveToolStripMenuItem1,
            this.toolStripSeparator1,
            this.miClose});
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.saveToolStripMenuItem.Text = "File";
            // 
            // miOpen
            // 
            this.miOpen.Name = "miOpen";
            this.miOpen.Size = new System.Drawing.Size(180, 22);
            this.miOpen.Text = "Open";
            this.miOpen.Click += new System.EventHandler(this.miOpen_Click);
            // 
            // saveToolStripMenuItem1
            // 
            this.saveToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miCurrentImage,
            this.miAllImages});
            this.saveToolStripMenuItem1.Name = "saveToolStripMenuItem1";
            this.saveToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem1.Text = "Save";
            // 
            // miCurrentImage
            // 
            this.miCurrentImage.Name = "miCurrentImage";
            this.miCurrentImage.Size = new System.Drawing.Size(150, 22);
            this.miCurrentImage.Text = "Current image";
            this.miCurrentImage.Click += new System.EventHandler(this.miCurrentImage_Click);
            // 
            // miAllImages
            // 
            this.miAllImages.Name = "miAllImages";
            this.miAllImages.Size = new System.Drawing.Size(150, 22);
            this.miAllImages.Text = "All images";
            this.miAllImages.Click += new System.EventHandler(this.miAllImages_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // miClose
            // 
            this.miClose.Name = "miClose";
            this.miClose.Size = new System.Drawing.Size(180, 22);
            this.miClose.Text = "Close";
            this.miClose.Click += new System.EventHandler(this.miClose_Click);
            // 
            // miMetrics
            // 
            this.miMetrics.Name = "miMetrics";
            this.miMetrics.Size = new System.Drawing.Size(58, 20);
            this.miMetrics.Text = "Metrics";
            this.miMetrics.Click += new System.EventHandler(this.miMetrics_Click);
            // 
            // miHistogram
            // 
            this.miHistogram.Name = "miHistogram";
            this.miHistogram.Size = new System.Drawing.Size(75, 20);
            this.miHistogram.Text = "Histogram";
            this.miHistogram.Click += new System.EventHandler(this.miHistogram_Click);
            // 
            // miColorCalculator
            // 
            this.miColorCalculator.Name = "miColorCalculator";
            this.miColorCalculator.Size = new System.Drawing.Size(103, 20);
            this.miColorCalculator.Text = "Color calculator";
            this.miColorCalculator.Click += new System.EventHandler(this.miColorCalculator_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.slSummary});
            this.statusStrip1.Location = new System.Drawing.Point(0, 739);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1264, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // slSummary
            // 
            this.slSummary.Name = "slSummary";
            this.slSummary.Size = new System.Drawing.Size(0, 17);
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 761);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainView";
            this.Text = "Examples";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cbImages;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.ComboBox cbResults;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbExamples;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem miMetrics;
        private System.Windows.Forms.ToolStripMenuItem miHistogram;
        private Controls.ScrollablePictureBox spbImage;
        private System.Windows.Forms.ToolStripStatusLabel slSummary;
        private System.Windows.Forms.ToolStripMenuItem miColorCalculator;
        private System.Windows.Forms.ToolStripMenuItem miOpen;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem miCurrentImage;
        private System.Windows.Forms.ToolStripMenuItem miAllImages;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem miClose;
    }
}