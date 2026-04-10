namespace EFCoreProject
{
    partial class InstructorForm
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
            dataGridViewInstructors = new DataGridView();
            panelDetails = new Panel();
            txtFirstName = new TextBox();
            label4 = new Label();
            label1 = new Label();
            txtPhone = new TextBox();
            label3 = new Label();
            txtLastName = new TextBox();
            label2 = new Label();
            txtId = new TextBox();
            btnSave = new Button();
            btnEdit = new Button();
            btnAdd = new Button();
            btnDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewInstructors).BeginInit();
            panelDetails.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridViewInstructors
            // 
            dataGridViewInstructors.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewInstructors.Location = new Point(426, 140);
            dataGridViewInstructors.Name = "dataGridViewInstructors";
            dataGridViewInstructors.RowHeadersWidth = 51;
            dataGridViewInstructors.Size = new Size(228, 99);
            dataGridViewInstructors.TabIndex = 0;
            // 
            // panelDetails
            // 
            panelDetails.Controls.Add(txtFirstName);
            panelDetails.Controls.Add(label4);
            panelDetails.Controls.Add(label1);
            panelDetails.Controls.Add(txtPhone);
            panelDetails.Controls.Add(label3);
            panelDetails.Controls.Add(txtLastName);
            panelDetails.Controls.Add(label2);
            panelDetails.Controls.Add(txtId);
            panelDetails.Location = new Point(8, 8);
            panelDetails.Name = "panelDetails";
            panelDetails.Size = new Size(352, 360);
            panelDetails.TabIndex = 1;
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(165, 91);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(125, 27);
            txtFirstName.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(92, 211);
            label4.Name = "label4";
            label4.Size = new Size(50, 20);
            label4.TabIndex = 3;
            label4.Text = "Phone";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(102, 44);
            label1.Name = "label1";
            label1.Size = new Size(24, 20);
            label1.TabIndex = 0;
            label1.Text = "ID";
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(176, 193);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(125, 27);
            txtPhone.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(92, 143);
            label3.Name = "label3";
            label3.Size = new Size(79, 20);
            label3.TabIndex = 2;
            label3.Text = "Last Name";
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(165, 143);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(125, 27);
            txtLastName.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(92, 79);
            label2.Name = "label2";
            label2.Size = new Size(80, 20);
            label2.TabIndex = 1;
            label2.Text = "First Name";
            // 
            // txtId
            // 
            txtId.Location = new Point(165, 44);
            txtId.Name = "txtId";
            txtId.Size = new Size(125, 27);
            txtId.TabIndex = 4;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(477, 409);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 8;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(628, 409);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(94, 29);
            btnEdit.TabIndex = 9;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(261, 409);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 10;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(377, 409);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 11;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // InstructorForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(btnEdit);
            Controls.Add(btnSave);
            Controls.Add(panelDetails);
            Controls.Add(dataGridViewInstructors);
            Name = "InstructorForm";
            Text = "InstructorForm";
            ((System.ComponentModel.ISupportInitialize)dataGridViewInstructors).EndInit();
            panelDetails.ResumeLayout(false);
            panelDetails.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewInstructors;
        private Panel panelDetails;
        private Label label2;
        private Label label1;
        private Label label3;
        private Label label4;
        private TextBox txtFirstName;
        private TextBox txtPhone;
        private TextBox txtLastName;
        private TextBox txtId;
        private Button btnSave;
        private Button btnEdit;
        private Button btnAdd;
        private Button btnDelete;
    }
}