namespace EFCoreProject
{
    partial class Register
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
            lblError = new Label();
            btnCancel = new Button();
            btnRegister = new Button();
            cboRole = new ComboBox();
            txtConfirmPassword = new TextBox();
            txtPassword = new TextBox();
            lable = new Label();
            lable2 = new Label();
            label2 = new Label();
            label1 = new Label();
            txtEmail = new TextBox();
            txtUsername = new TextBox();
            SuspendLayout();
            // 
            // lblError
            // 
            lblError.AutoSize = true;
            lblError.Location = new Point(192, 390);
            lblError.Name = "lblError";
            lblError.Size = new Size(41, 20);
            lblError.TabIndex = 23;
            lblError.Text = "Error";
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(515, 390);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 22;
            btnCancel.Text = "Cancle ";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(321, 390);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(94, 29);
            btnRegister.TabIndex = 21;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // cboRole
            // 
            cboRole.FormattingEnabled = true;
            cboRole.Location = new Point(335, 285);
            cboRole.Name = "cboRole";
            cboRole.Size = new Size(151, 28);
            cboRole.TabIndex = 20;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Location = new Point(335, 212);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(125, 27);
            txtConfirmPassword.TabIndex = 19;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(335, 149);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(125, 27);
            txtPassword.TabIndex = 18;
            // 
            // lable
            // 
            lable.AutoSize = true;
            lable.Location = new Point(192, 212);
            lable.Name = "lable";
            lable.Size = new Size(127, 20);
            lable.TabIndex = 17;
            lable.Text = "Confirm Password";
            // 
            // lable2
            // 
            lable2.AutoSize = true;
            lable2.Location = new Point(220, 152);
            lable2.Name = "lable2";
            lable2.Size = new Size(70, 20);
            lable2.TabIndex = 16;
            lable2.Text = "Password";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(240, 96);
            label2.Name = "label2";
            label2.Size = new Size(46, 20);
            label2.TabIndex = 15;
            label2.Text = "Email";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(240, 39);
            label1.Name = "label1";
            label1.Size = new Size(79, 20);
            label1.TabIndex = 14;
            label1.Text = "Username ";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(335, 96);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(125, 27);
            txtEmail.TabIndex = 13;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(335, 32);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(125, 27);
            txtUsername.TabIndex = 12;
            // 
            // Register
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblError);
            Controls.Add(btnCancel);
            Controls.Add(btnRegister);
            Controls.Add(cboRole);
            Controls.Add(txtConfirmPassword);
            Controls.Add(txtPassword);
            Controls.Add(lable);
            Controls.Add(lable2);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtEmail);
            Controls.Add(txtUsername);
            Name = "Register";
            Text = "Register";
            Load += Register_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblError;
        private Button btnCancel;
        private Button btnRegister;
        private ComboBox cboRole;
        private TextBox txtConfirmPassword;
        private TextBox txtPassword;
        private Label lable;
        private Label lable2;
        private Label label2;
        private Label label1;
        private TextBox txtEmail;
        private TextBox txtUsername;
    }
}