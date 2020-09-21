namespace Automated_WorkPlace_Library
{
    partial class FormReg
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LoginCreate = new System.Windows.Forms.TextBox();
            this.PasswordCreate = new System.Windows.Forms.TextBox();
            this.RegButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.PasswordRepeat = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Придумайте логин:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Придумайте пароль:";
            // 
            // LoginCreate
            // 
            this.LoginCreate.Location = new System.Drawing.Point(144, 50);
            this.LoginCreate.Name = "LoginCreate";
            this.LoginCreate.Size = new System.Drawing.Size(100, 20);
            this.LoginCreate.TabIndex = 2;
            // 
            // PasswordCreate
            // 
            this.PasswordCreate.Location = new System.Drawing.Point(144, 90);
            this.PasswordCreate.Name = "PasswordCreate";
            this.PasswordCreate.Size = new System.Drawing.Size(100, 20);
            this.PasswordCreate.TabIndex = 3;
            this.PasswordCreate.UseSystemPasswordChar = true;
            // 
            // RegButton
            // 
            this.RegButton.Location = new System.Drawing.Point(76, 177);
            this.RegButton.Name = "RegButton";
            this.RegButton.Size = new System.Drawing.Size(121, 23);
            this.RegButton.TabIndex = 5;
            this.RegButton.Text = "Зарегистрироваться";
            this.RegButton.UseVisualStyleBackColor = true;
            this.RegButton.Click += new System.EventHandler(this.RegButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Повторите пароль:";
            // 
            // PasswordRepeat
            // 
            this.PasswordRepeat.Location = new System.Drawing.Point(144, 131);
            this.PasswordRepeat.Name = "PasswordRepeat";
            this.PasswordRepeat.Size = new System.Drawing.Size(100, 20);
            this.PasswordRepeat.TabIndex = 7;
            this.PasswordRepeat.UseSystemPasswordChar = true;
            // 
            // FormReg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 228);
            this.Controls.Add(this.PasswordRepeat);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.RegButton);
            this.Controls.Add(this.PasswordCreate);
            this.Controls.Add(this.LoginCreate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormReg";
            this.Text = "Регистрация";
            this.Load += new System.EventHandler(this.FormReg_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox LoginCreate;
        private System.Windows.Forms.TextBox PasswordCreate;
        private System.Windows.Forms.Button RegButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox PasswordRepeat;
    }
}