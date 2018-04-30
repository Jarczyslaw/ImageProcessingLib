namespace TestApps.Apps.MemoryLeaks
{
    partial class MemoryLeaksForm
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
            this.tbMemoryUsage = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.tbImagesCount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbMaxMemoryUsage = new System.Windows.Forms.TextBox();
            this.tbMinMemoryUsage = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbIteration = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnStartStop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbMemoryUsage
            // 
            this.tbMemoryUsage.Location = new System.Drawing.Point(153, 38);
            this.tbMemoryUsage.Name = "tbMemoryUsage";
            this.tbMemoryUsage.ReadOnly = true;
            this.tbMemoryUsage.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tbMemoryUsage.Size = new System.Drawing.Size(100, 20);
            this.tbMemoryUsage.TabIndex = 1;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Memory usage [MB]:";
            // 
            // tbImagesCount
            // 
            this.tbImagesCount.Location = new System.Drawing.Point(153, 12);
            this.tbImagesCount.Name = "tbImagesCount";
            this.tbImagesCount.ReadOnly = true;
            this.tbImagesCount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tbImagesCount.Size = new System.Drawing.Size(100, 20);
            this.tbImagesCount.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Max memory usage [MB]:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Min memory usage [MB]:";
            // 
            // tbMaxMemoryUsage
            // 
            this.tbMaxMemoryUsage.Location = new System.Drawing.Point(153, 64);
            this.tbMaxMemoryUsage.Name = "tbMaxMemoryUsage";
            this.tbMaxMemoryUsage.ReadOnly = true;
            this.tbMaxMemoryUsage.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tbMaxMemoryUsage.Size = new System.Drawing.Size(100, 20);
            this.tbMaxMemoryUsage.TabIndex = 6;
            // 
            // tbMinMemoryUsage
            // 
            this.tbMinMemoryUsage.Location = new System.Drawing.Point(153, 90);
            this.tbMinMemoryUsage.Name = "tbMinMemoryUsage";
            this.tbMinMemoryUsage.ReadOnly = true;
            this.tbMinMemoryUsage.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tbMinMemoryUsage.Size = new System.Drawing.Size(100, 20);
            this.tbMinMemoryUsage.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(73, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Images count:";
            // 
            // tbIteration
            // 
            this.tbIteration.Location = new System.Drawing.Point(153, 145);
            this.tbIteration.Name = "tbIteration";
            this.tbIteration.ReadOnly = true;
            this.tbIteration.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tbIteration.Size = new System.Drawing.Size(100, 20);
            this.tbIteration.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(99, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Iteration:";
            // 
            // btnStartStop
            // 
            this.btnStartStop.Location = new System.Drawing.Point(24, 116);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(229, 23);
            this.btnStartStop.TabIndex = 11;
            this.btnStartStop.Text = "button1";
            this.btnStartStop.UseVisualStyleBackColor = true;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // MemoryLeaksForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 187);
            this.Controls.Add(this.btnStartStop);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbIteration);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbMinMemoryUsage);
            this.Controls.Add(this.tbMaxMemoryUsage);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbImagesCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbMemoryUsage);
            this.Name = "MemoryLeaksForm";
            this.Text = "MemoryLeaksForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MemoryLeaksTest_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbMemoryUsage;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbImagesCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbMaxMemoryUsage;
        private System.Windows.Forms.TextBox tbMinMemoryUsage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbIteration;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnStartStop;
    }
}

