namespace ImageProcessingLibExamples.Controls
{
    partial class ScrollablePictureBox
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
            this.plContainer = new System.Windows.Forms.Panel();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.plContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // plContainer
            // 
            this.plContainer.AutoScroll = true;
            this.plContainer.Controls.Add(this.pbImage);
            this.plContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plContainer.Location = new System.Drawing.Point(0, 0);
            this.plContainer.Name = "plContainer";
            this.plContainer.Size = new System.Drawing.Size(400, 400);
            this.plContainer.TabIndex = 3;
            // 
            // pbImage
            // 
            this.pbImage.Location = new System.Drawing.Point(3, 3);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(242, 261);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbImage.TabIndex = 0;
            this.pbImage.TabStop = false;
            this.pbImage.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbImage_MouseClick);
            this.pbImage.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pbImage_MouseDoubleClick);
            this.pbImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbImage_MouseMove);
            // 
            // ScrollablePictureBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.plContainer);
            this.Name = "ScrollablePictureBox";
            this.Size = new System.Drawing.Size(400, 400);
            this.plContainer.ResumeLayout(false);
            this.plContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel plContainer;
        private System.Windows.Forms.PictureBox pbImage;
    }
}
