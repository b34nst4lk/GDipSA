namespace FirstApp
{
    partial class RabbitCatching
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RabbitCatching));
            this.Rabbit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Rabbit
            // 
            this.Rabbit.Image = ((System.Drawing.Image)(resources.GetObject("Rabbit.Image")));
            this.Rabbit.Location = new System.Drawing.Point(592, 136);
            this.Rabbit.Name = "Rabbit";
            this.Rabbit.Size = new System.Drawing.Size(128, 184);
            this.Rabbit.TabIndex = 0;
            this.Rabbit.UseVisualStyleBackColor = true;
            this.Rabbit.Click += new System.EventHandler(this.Rabbit_Click);
            // 
            // RabbitCatching
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1059, 720);
            this.Controls.Add(this.Rabbit);
            this.Name = "RabbitCatching";
            this.Text = "RabbitCatching";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReturnToCaller);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Rabbit;
    }
}