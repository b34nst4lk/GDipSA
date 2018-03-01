namespace FirstApp
{
    partial class RabbitSnatching
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
        /// </summary>C:\Users\Jack\Projects\GDipSA\UserInterfaceVisualStudio\FirstApp\Properties\logo.png
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RabbitSnatching));
            this.Rabbit = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Rabbit)).BeginInit();
            this.SuspendLayout();
            // 
            // Rabbit
            // 
            this.Rabbit.Image = ((System.Drawing.Image)(resources.GetObject("Rabbit.Image")));
            this.Rabbit.Location = new System.Drawing.Point(344, 144);
            this.Rabbit.Name = "Rabbit";
            this.Rabbit.Size = new System.Drawing.Size(120, 176);
            this.Rabbit.TabIndex = 0;
            this.Rabbit.TabStop = false;
            this.Rabbit.MouseDown += new System.Windows.Forms.MouseEventHandler(this.RabbitFleeing);
            this.Rabbit.MouseUp += new System.Windows.Forms.MouseEventHandler(this.RabbitReturning);
            // 
            // RabbitSnatching
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 491);
            this.Controls.Add(this.Rabbit);
            this.Name = "RabbitSnatching";
            this.Text = "RabbitSnatching";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReturnToCaller);
            ((System.ComponentModel.ISupportInitialize)(this.Rabbit)).EndInit();
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.PictureBox Rabbit;
    }
}