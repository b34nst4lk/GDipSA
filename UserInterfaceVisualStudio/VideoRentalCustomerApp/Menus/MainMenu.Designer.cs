namespace VideoRentalCustomerApp
{
    partial class MainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.MaintainCustomersButton = new System.Windows.Forms.Button();
            this.RentVideoButton = new System.Windows.Forms.Button();
            this.MaintainVideoRecordsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Exit
            // 
            this.Exit.Location = new System.Drawing.Point(216, 144);
            // 
            // MaintainCustomersButton
            // 
            this.MaintainCustomersButton.Location = new System.Drawing.Point(152, 88);
            this.MaintainCustomersButton.Name = "MaintainCustomersButton";
            this.MaintainCustomersButton.Size = new System.Drawing.Size(128, 24);
            this.MaintainCustomersButton.TabIndex = 0;
            this.MaintainCustomersButton.Text = "Maintain Customers Records";
            this.MaintainCustomersButton.UseVisualStyleBackColor = true;
            this.MaintainCustomersButton.Click += new System.EventHandler(this.MainMenuButton_Click);
            // 
            // RentVideoButton
            // 
            this.RentVideoButton.Location = new System.Drawing.Point(152, 24);
            this.RentVideoButton.Name = "RentVideoButton";
            this.RentVideoButton.Size = new System.Drawing.Size(128, 24);
            this.RentVideoButton.TabIndex = 0;
            this.RentVideoButton.Text = "Rent Video";
            this.RentVideoButton.UseVisualStyleBackColor = true;
            this.RentVideoButton.Click += new System.EventHandler(this.MainMenuButton_Click);
            // 
            // MaintainVideoRecordsButton
            // 
            this.MaintainVideoRecordsButton.Location = new System.Drawing.Point(152, 56);
            this.MaintainVideoRecordsButton.Name = "MaintainVideoRecordsButton";
            this.MaintainVideoRecordsButton.Size = new System.Drawing.Size(128, 24);
            this.MaintainVideoRecordsButton.TabIndex = 0;
            this.MaintainVideoRecordsButton.Text = "Maintain Video Records";
            this.MaintainVideoRecordsButton.UseVisualStyleBackColor = true;
            this.MaintainVideoRecordsButton.Click += new System.EventHandler(this.MainMenuButton_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 175);
            this.Controls.Add(this.RentVideoButton);
            this.Controls.Add(this.MaintainVideoRecordsButton);
            this.Controls.Add(this.MaintainCustomersButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainMenu";
            this.Text = "Main Menu";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.Controls.SetChildIndex(this.Exit, 0);
            this.Controls.SetChildIndex(this.Back, 0);
            this.Controls.SetChildIndex(this.MaintainCustomersButton, 0);
            this.Controls.SetChildIndex(this.MaintainVideoRecordsButton, 0);
            this.Controls.SetChildIndex(this.RentVideoButton, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button MaintainCustomersButton;
        private System.Windows.Forms.Button RentVideoButton;
        private System.Windows.Forms.Button MaintainVideoRecordsButton;
    }
}

