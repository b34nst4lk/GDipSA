namespace FirstApp
{
    partial class Fishing
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Fishing));
            this.Fish = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Fish)).BeginInit();
            this.SuspendLayout();
            // 
            // Fish
            // 
            this.Fish.Image = ((System.Drawing.Image)(resources.GetObject("Fish.Image")));
            this.Fish.Location = new System.Drawing.Point(368, 144);
            this.Fish.Name = "Fish";
            this.Fish.Size = new System.Drawing.Size(192, 104);
            this.Fish.TabIndex = 0;
            this.Fish.TabStop = false;
            // 
            // Fishing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(1396, 649);
            this.Controls.Add(this.Fish);
            this.Name = "Fishing";
            this.Text = "Form3";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReturnToCaller);
            this.MouseEnter += new System.EventHandler(this.FishEscape);
            ((System.ComponentModel.ISupportInitialize)(this.Fish)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Fish;
    }
}