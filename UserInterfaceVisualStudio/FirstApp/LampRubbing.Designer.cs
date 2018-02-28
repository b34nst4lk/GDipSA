namespace FirstApp
{
    partial class LampRubbing
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LampRubbing));
            this.Lamp = new System.Windows.Forms.PictureBox();
            this.Genie = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Lamp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Genie)).BeginInit();
            this.SuspendLayout();
            // 
            // Lamp
            // 
            this.Lamp.Image = ((System.Drawing.Image)(resources.GetObject("Lamp.Image")));
            this.Lamp.Location = new System.Drawing.Point(232, 408);
            this.Lamp.Name = "Lamp";
            this.Lamp.Size = new System.Drawing.Size(96, 82);
            this.Lamp.TabIndex = 0;
            this.Lamp.TabStop = false;
            this.Lamp.Click += new System.EventHandler(this.SummonGenie);
            this.Lamp.DoubleClick += new System.EventHandler(this.RubGenie);
            // 
            // Genie
            // 
            this.Genie.Image = ((System.Drawing.Image)(resources.GetObject("Genie.Image")));
            this.Genie.Location = new System.Drawing.Point(384, 272);
            this.Genie.Name = "Genie";
            this.Genie.Size = new System.Drawing.Size(136, 136);
            this.Genie.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Genie.TabIndex = 0;
            this.Genie.TabStop = false;
            this.Genie.Visible = false;
            this.Genie.MouseEnter += new System.EventHandler(this.Vanish);
            // 
            // LampRubbing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 721);
            this.Controls.Add(this.Genie);
            this.Controls.Add(this.Lamp);
            this.Name = "LampRubbing";
            this.Text = "Lamp Rubbing";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReturnToCaller);
            ((System.ComponentModel.ISupportInitialize)(this.Lamp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Genie)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Lamp;
        private System.Windows.Forms.PictureBox Genie;
    }
}