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
            lblConfirmPassword = new Label();
            lblPassword = new Label();
            lblEmail = new Label();
            lblUsername = new Label();
            txtEmail = new TextBox();
            txtUsername = new TextBox();
            txtPhone = new TextBox();
            txtLastName = new TextBox();
            txtFirstName = new TextBox();
            lblFirstName = new Label();
            lblLastName = new Label();
            lblPhone = new Label();
            SuspendLayout();
            // 
            // lblError
            // 
            lblError.AutoSize = true;
            lblError.ForeColor = Color.Red;
            lblError.Location = new Point(192, 390);
            lblError.Name = "lblError";
            lblError.Size = new Size(0, 20);
            lblError.TabIndex = 23;
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
            cboRole.Location = new Point(59, 301);
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
            // lblConfirmPassword
            // 
            lblConfirmPassword.AutoSize = true;
            lblConfirmPassword.Location = new Point(192, 212);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new Size(127, 20);
            lblConfirmPassword.TabIndex = 17;
            lblConfirmPassword.Text = "Confirm Password";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(220, 152);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(70, 20);
            lblPassword.TabIndex = 16;
            lblPassword.Text = "Password";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(240, 96);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(46, 20);
            lblEmail.TabIndex = 15;
            lblEmail.Text = "Email";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(240, 39);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(79, 20);
            lblUsername.TabIndex = 14;
            lblUsername.Text = "Username ";
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
            // txtPhone
            // 
            txtPhone.Location = new Point(321, 334);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(125, 27);
            txtPhone.TabIndex = 24;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(321, 301);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(125, 27);
            txtLastName.TabIndex = 25;
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(321, 257);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(125, 27);
            txtFirstName.TabIndex = 26;
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Location = new Point(240, 264);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(80, 20);
            lblFirstName.TabIndex = 27;
            lblFirstName.Text = "First Name";
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Location = new Point(240, 309);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(102, 20);
            lblLastName.TabIndex = 28;
            lblLastName.Text = "Second Name";
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Location = new Point(240, 341);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(50, 20);
            lblPhone.TabIndex = 29;
            lblPhone.Text = "Phone";
            // 
            // Register
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblPhone);
            Controls.Add(lblLastName);
            Controls.Add(lblFirstName);
            Controls.Add(txtFirstName);
            Controls.Add(txtLastName);
            Controls.Add(txtPhone);
            Controls.Add(lblError);
            Controls.Add(btnCancel);
            Controls.Add(btnRegister);
            Controls.Add(cboRole);
            Controls.Add(txtConfirmPassword);
            Controls.Add(txtPassword);
            Controls.Add(lblConfirmPassword);
            Controls.Add(lblPassword);
            Controls.Add(lblEmail);
            Controls.Add(lblUsername);
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
        private Label lblConfirmPassword;
        private Label lblPassword;
        private Label lblEmail;
        private Label lblUsername;
        private TextBox txtEmail;
        private TextBox txtUsername;
        private TextBox txtPhone;
        private TextBox txtLastName;
        private TextBox txtFirstName;
        private Label lblFirstName;
        private Label lblLastName;
        private Label lblPhone;
    }
}