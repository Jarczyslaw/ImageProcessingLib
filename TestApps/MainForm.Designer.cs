namespace TestApps.Apps
{
    partial class MainForm
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
            this.plButtons = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // plButtons
            // 
            this.plButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.plButtons.AutoScroll = true;
            this.plButtons.Location = new System.Drawing.Point(12, 12);
            this.plButtons.Name = "plButtons";
            this.plButtons.Size = new System.Drawing.Size(276, 202);
            this.plButtons.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 226);
            this.Controls.Add(this.plButtons);
            this.Name = "MainForm";
            this.Text = "Test Apps";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel plButtons;
    }
}