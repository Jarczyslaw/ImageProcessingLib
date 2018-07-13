using ImageProcessingLibExamples.Controls;

namespace ImageProcessingLibExamples.Views
{
    partial class ColorCalculatorView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ColorCalculatorView));
            this.plColorPreview = new System.Windows.Forms.Panel();
            this.nudA = new ImageProcessingLibExamples.Controls.AnemicNumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.nudB = new ImageProcessingLibExamples.Controls.AnemicNumericUpDown();
            this.nudG = new ImageProcessingLibExamples.Controls.AnemicNumericUpDown();
            this.nudR = new ImageProcessingLibExamples.Controls.AnemicNumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.nudV = new ImageProcessingLibExamples.Controls.AnemicNumericUpDown();
            this.nudS = new ImageProcessingLibExamples.Controls.AnemicNumericUpDown();
            this.nudH = new ImageProcessingLibExamples.Controls.AnemicNumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.tbHex = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.nudK = new ImageProcessingLibExamples.Controls.AnemicNumericUpDown();
            this.nudY = new ImageProcessingLibExamples.Controls.AnemicNumericUpDown();
            this.nudM = new ImageProcessingLibExamples.Controls.AnemicNumericUpDown();
            this.nudC = new ImageProcessingLibExamples.Controls.AnemicNumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudA)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudR)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudH)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudC)).BeginInit();
            this.SuspendLayout();
            // 
            // plColorPreview
            // 
            this.plColorPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plColorPreview.Location = new System.Drawing.Point(3, 16);
            this.plColorPreview.Name = "plColorPreview";
            this.plColorPreview.Size = new System.Drawing.Size(133, 72);
            this.plColorPreview.TabIndex = 0;
            // 
            // nudA
            // 
            this.nudA.AnemicValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudA.Location = new System.Drawing.Point(49, 19);
            this.nudA.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudA.Name = "nudA";
            this.nudA.Size = new System.Drawing.Size(50, 20);
            this.nudA.TabIndex = 1;
            this.nudA.AnemicValueChanged += new System.EventHandler(this.argb_AnemicValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.nudB);
            this.groupBox1.Controls.Add(this.nudG);
            this.groupBox1.Controls.Add(this.nudR);
            this.groupBox1.Controls.Add(this.nudA);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(157, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(107, 125);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ARGB";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Blue:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Green:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Red:";
            // 
            // nudB
            // 
            this.nudB.AnemicValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudB.Location = new System.Drawing.Point(49, 97);
            this.nudB.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudB.Name = "nudB";
            this.nudB.Size = new System.Drawing.Size(50, 20);
            this.nudB.TabIndex = 6;
            this.nudB.AnemicValueChanged += new System.EventHandler(this.argb_AnemicValueChanged);
            // 
            // nudG
            // 
            this.nudG.AnemicValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudG.Location = new System.Drawing.Point(49, 71);
            this.nudG.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudG.Name = "nudG";
            this.nudG.Size = new System.Drawing.Size(50, 20);
            this.nudG.TabIndex = 5;
            this.nudG.AnemicValueChanged += new System.EventHandler(this.argb_AnemicValueChanged);
            // 
            // nudR
            // 
            this.nudR.AnemicValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudR.Location = new System.Drawing.Point(49, 45);
            this.nudR.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudR.Name = "nudR";
            this.nudR.Size = new System.Drawing.Size(50, 20);
            this.nudR.TabIndex = 4;
            this.nudR.AnemicValueChanged += new System.EventHandler(this.argb_AnemicValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Alpha:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.plColorPreview);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(139, 91);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Preview";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.nudV);
            this.groupBox3.Controls.Add(this.nudS);
            this.groupBox3.Controls.Add(this.nudH);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(270, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(127, 125);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "HSV";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 73);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "Value:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Saturation:";
            // 
            // nudV
            // 
            this.nudV.AnemicValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudV.DecimalPlaces = 1;
            this.nudV.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudV.Location = new System.Drawing.Point(70, 71);
            this.nudV.Name = "nudV";
            this.nudV.Size = new System.Drawing.Size(50, 20);
            this.nudV.TabIndex = 5;
            this.nudV.AnemicValueChanged += new System.EventHandler(this.hsv_AnemicValueChanged);
            // 
            // nudS
            // 
            this.nudS.AnemicValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudS.DecimalPlaces = 1;
            this.nudS.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudS.Location = new System.Drawing.Point(70, 45);
            this.nudS.Name = "nudS";
            this.nudS.Size = new System.Drawing.Size(50, 20);
            this.nudS.TabIndex = 4;
            this.nudS.AnemicValueChanged += new System.EventHandler(this.hsv_AnemicValueChanged);
            // 
            // nudH
            // 
            this.nudH.AnemicValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudH.DecimalPlaces = 1;
            this.nudH.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudH.Location = new System.Drawing.Point(70, 19);
            this.nudH.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.nudH.Name = "nudH";
            this.nudH.Size = new System.Drawing.Size(50, 20);
            this.nudH.TabIndex = 1;
            this.nudH.AnemicValueChanged += new System.EventHandler(this.hsv_AnemicValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Hue:";
            // 
            // tbHex
            // 
            this.tbHex.Location = new System.Drawing.Point(50, 109);
            this.tbHex.Name = "tbHex";
            this.tbHex.Size = new System.Drawing.Size(101, 20);
            this.tbHex.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "HEX:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.nudK);
            this.groupBox4.Controls.Add(this.nudY);
            this.groupBox4.Controls.Add(this.nudM);
            this.groupBox4.Controls.Add(this.nudC);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Location = new System.Drawing.Point(403, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(121, 125);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "CMYK";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 99);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 13);
            this.label12.TabIndex = 9;
            this.label12.Text = "Black:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 73);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 13);
            this.label11.TabIndex = 8;
            this.label11.Text = "Yellow:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 47);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 13);
            this.label10.TabIndex = 7;
            this.label10.Text = "Magenta:";
            // 
            // nudK
            // 
            this.nudK.AnemicValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudK.DecimalPlaces = 1;
            this.nudK.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudK.Location = new System.Drawing.Point(64, 97);
            this.nudK.Name = "nudK";
            this.nudK.Size = new System.Drawing.Size(50, 20);
            this.nudK.TabIndex = 6;
            this.nudK.AnemicValueChanged += new System.EventHandler(this.cmyk_AnemicValueChanged);
            // 
            // nudY
            // 
            this.nudY.AnemicValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudY.DecimalPlaces = 1;
            this.nudY.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudY.Location = new System.Drawing.Point(64, 71);
            this.nudY.Name = "nudY";
            this.nudY.Size = new System.Drawing.Size(50, 20);
            this.nudY.TabIndex = 5;
            this.nudY.AnemicValueChanged += new System.EventHandler(this.cmyk_AnemicValueChanged);
            // 
            // nudM
            // 
            this.nudM.AnemicValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudM.DecimalPlaces = 1;
            this.nudM.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudM.Location = new System.Drawing.Point(64, 45);
            this.nudM.Name = "nudM";
            this.nudM.Size = new System.Drawing.Size(50, 20);
            this.nudM.TabIndex = 4;
            this.nudM.AnemicValueChanged += new System.EventHandler(this.cmyk_AnemicValueChanged);
            // 
            // nudC
            // 
            this.nudC.AnemicValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudC.DecimalPlaces = 1;
            this.nudC.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudC.Location = new System.Drawing.Point(64, 19);
            this.nudC.Name = "nudC";
            this.nudC.Size = new System.Drawing.Size(50, 20);
            this.nudC.TabIndex = 1;
            this.nudC.AnemicValueChanged += new System.EventHandler(this.cmyk_AnemicValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Cyan:";
            // 
            // ColorCalculatorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 151);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbHex);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ColorCalculatorView";
            this.Text = "Examples - Color Calculator";
            ((System.ComponentModel.ISupportInitialize)(this.nudA)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudR)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudH)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudC)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel plColorPreview;
        private AnemicNumericUpDown nudA;
        private System.Windows.Forms.GroupBox groupBox1;
        private AnemicNumericUpDown nudB;
        private AnemicNumericUpDown nudG;
        private AnemicNumericUpDown nudR;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private AnemicNumericUpDown nudH;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbHex;
        private System.Windows.Forms.Label label3;
        private AnemicNumericUpDown nudV;
        private AnemicNumericUpDown nudS;
        private System.Windows.Forms.GroupBox groupBox4;
        private AnemicNumericUpDown nudC;
        private System.Windows.Forms.Label label4;
        private AnemicNumericUpDown nudK;
        private AnemicNumericUpDown nudY;
        private AnemicNumericUpDown nudM;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
    }
}