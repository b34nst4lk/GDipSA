namespace VideoRentalCustomerApp
{
    partial class CustomerMainMenu
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
            this.AddCustomerButton = new System.Windows.Forms.Button();
            this.EditCustomerButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Exit
            // 
            this.Exit.Location = new System.Drawing.Point(216, 144);
            // 
            // AddCustomerButton
            // 
            this.AddCustomerButton.Location = new System.Drawing.Point(152, 24);
            this.AddCustomerButton.Name = "AddCustomerButton";
            this.AddCustomerButton.Size = new System.Drawing.Size(128, 24);
            this.AddCustomerButton.TabIndex = 5;
            this.AddCustomerButton.Text = "Add New Customer";
            this.AddCustomerButton.UseVisualStyleBackColor = true;
            // 
            // EditCustomerButton
            // 
            this.EditCustomerButton.Location = new System.Drawing.Point(152, 56);
            this.EditCustomerButton.Name = "EditCustomerButton";
            this.EditCustomerButton.Size = new System.Drawing.Size(128, 24);
            this.EditCustomerButton.TabIndex = 5;
            this.EditCustomerButton.Text = "Edit Customer Record";
            this.EditCustomerButton.UseVisualStyleBackColor = true;
            // 
            // CustomerMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 174);
            this.Controls.Add(this.EditCustomerButton);
            this.Controls.Add(this.AddCustomerButton);
            this.Name = "CustomerMainMenu";
            this.Text = "CustomerMainMenu";
            this.Controls.SetChildIndex(this.Exit, 0);
            this.Controls.SetChildIndex(this.Back, 0);
            this.Controls.SetChildIndex(this.AddCustomerButton, 0);
            this.Controls.SetChildIndex(this.EditCustomerButton, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button AddCustomerButton;
        private System.Windows.Forms.Button EditCustomerButton;
    }
}