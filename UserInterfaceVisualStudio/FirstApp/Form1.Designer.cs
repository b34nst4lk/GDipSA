﻿namespace FirstApp
{
    partial class Form1
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
            this.shockButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // shockButton
            // 
            this.shockButton.Location = new System.Drawing.Point(360, 16);
            this.shockButton.Name = "shockButton";
            this.shockButton.Size = new System.Drawing.Size(136, 24);
            this.shockButton.TabIndex = 0;
            this.shockButton.Text = "Apply Electric Shock";
            this.shockButton.UseVisualStyleBackColor = true;
            this.shockButton.Click += new System.EventHandler(this.button1_Click);
            this.shockButton.MouseEnter += new System.EventHandler(this.Form1_Load);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(343, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nothing is so painful to the human mind as a great and sudden change.";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(504, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(173, 26);
            this.button1.TabIndex = 0;
            this.button1.Text = "Turn back before it is too late";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button2_Click);
            this.button1.MouseEnter += new System.EventHandler(this.Form1_Load);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(686, 16);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(106, 26);
            this.button3.TabIndex = 0;
            this.button3.Text = "I ran out of ideas.";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            this.button3.MouseEnter += new System.EventHandler(this.Form1_Load);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(800, 16);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(106, 26);
            this.button4.TabIndex = 0;
            this.button4.Text = "We\'ve gone too far";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            this.button4.MouseEnter += new System.EventHandler(this.Form1_Load);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(915, 54);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.shockButton);
            this.Name = "Form1";
            this.Text = ":w";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button shockButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}

