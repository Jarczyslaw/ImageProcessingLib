namespace ImageProcessingLibExamples.Views
{
    partial class HistogramView
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
            System.Windows.Media.SolidColorBrush solidColorBrush1 = new System.Windows.Media.SolidColorBrush();
            System.Windows.Media.SolidColorBrush solidColorBrush2 = new System.Windows.Media.SolidColorBrush();
            System.Windows.Media.SolidColorBrush solidColorBrush3 = new System.Windows.Media.SolidColorBrush();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HistogramView));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.chRed = new ImageProcessingLibExamples.Views.HistogramChart();
            this.chGreen = new ImageProcessingLibExamples.Views.HistogramChart();
            this.chBlue = new ImageProcessingLibExamples.Views.HistogramChart();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.chRed, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.chGreen, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.chBlue, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1084, 761);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // chRed
            // 
            solidColorBrush1.Color = System.Windows.Media.Color.FromArgb(((byte)(255)), ((byte)(255)), ((byte)(0)), ((byte)(0)));
            this.chRed.Color = solidColorBrush1;
            this.chRed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chRed.Location = new System.Drawing.Point(3, 3);
            this.chRed.Name = "chRed";
            this.chRed.Size = new System.Drawing.Size(1078, 245);
            this.chRed.TabIndex = 0;
            this.chRed.Text = "histogramChart1";
            // 
            // chGreen
            // 
            solidColorBrush2.Color = System.Windows.Media.Color.FromArgb(((byte)(255)), ((byte)(0)), ((byte)(255)), ((byte)(0)));
            this.chGreen.Color = solidColorBrush2;
            this.chGreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chGreen.Location = new System.Drawing.Point(3, 254);
            this.chGreen.Name = "chGreen";
            this.chGreen.Size = new System.Drawing.Size(1078, 245);
            this.chGreen.TabIndex = 1;
            this.chGreen.Text = "histogramChart1";
            // 
            // chBlue
            // 
            solidColorBrush3.Color = System.Windows.Media.Color.FromArgb(((byte)(255)), ((byte)(0)), ((byte)(0)), ((byte)(255)));
            this.chBlue.Color = solidColorBrush3;
            this.chBlue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chBlue.Location = new System.Drawing.Point(3, 505);
            this.chBlue.Name = "chBlue";
            this.chBlue.Size = new System.Drawing.Size(1078, 253);
            this.chBlue.TabIndex = 2;
            this.chBlue.Text = "histogramChart1";
            // 
            // HistogramView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 761);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HistogramView";
            this.Text = "Examples - Histogram";
            this.Load += new System.EventHandler(this.HistogramView_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private HistogramChart chRed;
        private HistogramChart chGreen;
        private HistogramChart chBlue;
    }
}