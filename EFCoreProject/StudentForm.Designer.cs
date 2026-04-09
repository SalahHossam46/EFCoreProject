
namespace EFCoreProject
{
    partial class StudentForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtEmail = new TextBox();
            txtPhone = new TextBox();
            txtFirstName = new TextBox();
            dataGridViewStudents = new DataGridView();
            label4 = new Label();
            txtId = new TextBox();
            txtLastName = new TextBox();
            label5 = new Label();
            btnSave = new Button();
            btnDelete = new Button();
            btnAdd = new Button();
            panelDetails = new Panel();
            ((System.ComponentModel.ISupportInitialize)dataGridViewStudents).BeginInit();
            panelDetails.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(130, 106);
            label1.Name = "label1";
            label1.Size = new Size(80, 20);
            label1.TabIndex = 0;
            label1.Text = "First Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(131, 215);
            label2.Name = "label2";
            label2.Size = new Size(50, 20);
            label2.TabIndex = 1;
            label2.Text = "Phone";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(130, 256);
            label3.Name = "label3";
            label3.Size = new Size(46, 20);
            label3.TabIndex = 2;
            label3.Text = "Email";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(222, 265);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(125, 27);
            txtEmail.TabIndex = 3;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(222, 215);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(125, 27);
            txtPhone.TabIndex = 4;
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(221, 103);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(125, 27);
            txtFirstName.TabIndex = 5;
            // 
            // dataGridViewStudents
            // 
            dataGridViewStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewStudents.Location = new Point(812, 65);
            dataGridViewStudents.Name = "dataGridViewStudents";
            dataGridViewStudents.RowHeadersWidth = 51;
            dataGridViewStudents.Size = new Size(300, 188);
            dataGridViewStudents.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(130, 60);
            label4.Name = "label4";
            label4.Size = new Size(24, 20);
            label4.TabIndex = 7;
            label4.Text = "ID";
            // 
            // txtId
            // 
            txtId.Location = new Point(219, 53);
            txtId.Name = "txtId";
            txtId.Size = new Size(125, 27);
            txtId.TabIndex = 8;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(209, 157);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(125, 27);
            txtLastName.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(118, 160);
            label5.Name = "label5";
            label5.Size = new Size(79, 20);
            label5.TabIndex = 9;
            label5.Text = "Last Name";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(631, 268);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 11;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(631, 321);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 12;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(631, 356);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 13;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // panelDetails
            // 
            panelDetails.Controls.Add(label5);
            panelDetails.Controls.Add(label1);
            panelDetails.Controls.Add(label2);
            panelDetails.Controls.Add(label3);
            panelDetails.Controls.Add(txtLastName);
            panelDetails.Controls.Add(txtEmail);
            panelDetails.Controls.Add(txtPhone);
            panelDetails.Controls.Add(txtId);
            panelDetails.Controls.Add(txtFirstName);
            panelDetails.Controls.Add(label4);
            panelDetails.Location = new Point(22, 12);
            panelDetails.Name = "panelDetails";
            panelDetails.Size = new Size(564, 469);
            panelDetails.TabIndex = 14;
            // 
            // StudentForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1108, 550);
            Controls.Add(panelDetails);
            Controls.Add(btnAdd);
            Controls.Add(btnDelete);
            Controls.Add(btnSave);
            Controls.Add(dataGridViewStudents);
            Name = "StudentForm";
            Text = "StudentForm";
            Load += StudentForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewStudents).EndInit();
            panelDetails.ResumeLayout(false);
            panelDetails.PerformLayout();
            ResumeLayout(false);
        }

        private void StudentForm_Load(object sender, EventArgs e)
        {

            throw new NotImplementedException();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtEmail;
        private TextBox txtPhone;
        private TextBox txtFirstName;
        private DataGridView dataGridViewStudents;
        private Label label4;
        private TextBox txtId;
        private TextBox txtLastName;
        private Label label5;
        private Button btnSave;
        private Button btnDelete;
        private Button btnAdd;
        private Panel panelDetails;
    }
}