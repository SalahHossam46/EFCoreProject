namespace EFCoreProject
{
    partial class DepartmentForm
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
            dataGridViewDepartments = new DataGridView();
            panelDetails = new Panel();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtDepartmentId = new TextBox();
            txtDepartmentName = new TextBox();
            txtLocation = new TextBox();
            btnSave = new Button();
            btnEdit = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDepartments).BeginInit();
            panelDetails.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridViewDepartments
            // 
            dataGridViewDepartments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewDepartments.Location = new Point(355, 12);
            dataGridViewDepartments.Name = "dataGridViewDepartments";
            dataGridViewDepartments.RowHeadersWidth = 51;
            dataGridViewDepartments.Size = new Size(300, 188);
            dataGridViewDepartments.TabIndex = 0;
            // 
            // panelDetails
            // 
            panelDetails.Controls.Add(label1);
            panelDetails.Controls.Add(label2);
            panelDetails.Controls.Add(label3);
            panelDetails.Controls.Add(txtDepartmentId);
            panelDetails.Controls.Add(txtDepartmentName);
            panelDetails.Controls.Add(txtLocation);
            panelDetails.Location = new Point(0, 0);
            panelDetails.Name = "panelDetails";
            panelDetails.Size = new Size(341, 413);
            panelDetails.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(35, 23);
            label1.Name = "label1";
            label1.Size = new Size(24, 20);
            label1.TabIndex = 2;
            label1.Text = "ID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(35, 103);
            label2.Name = "label2";
            label2.Size = new Size(49, 20);
            label2.TabIndex = 3;
            label2.Text = "Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(35, 180);
            label3.Name = "label3";
            label3.Size = new Size(66, 20);
            label3.TabIndex = 4;
            label3.Text = "Location";
            // 
            // txtDepartmentId
            // 
            txtDepartmentId.Location = new Point(149, 16);
            txtDepartmentId.Name = "txtDepartmentId";
            txtDepartmentId.Size = new Size(125, 27);
            txtDepartmentId.TabIndex = 5;
            // 
            // txtDepartmentName
            // 
            txtDepartmentName.Location = new Point(149, 96);
            txtDepartmentName.Name = "txtDepartmentName";
            txtDepartmentName.Size = new Size(125, 27);
            txtDepartmentName.TabIndex = 6;
            // 
            // txtLocation
            // 
            txtLocation.Location = new Point(149, 173);
            txtLocation.Name = "txtLocation";
            txtLocation.Size = new Size(125, 27);
            txtLocation.TabIndex = 7;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(376, 317);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 8;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(476, 317);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(94, 29);
            btnEdit.TabIndex = 9;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // DepartmentForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSave);
            Controls.Add(btnEdit);
            Controls.Add(panelDetails);
            Controls.Add(dataGridViewDepartments);
            Name = "DepartmentForm";
            Text = "DepartmentForm";
            ((System.ComponentModel.ISupportInitialize)dataGridViewDepartments).EndInit();
            panelDetails.ResumeLayout(false);
            panelDetails.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewDepartments;
        private Panel panelDetails;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtDepartmentId;
        private TextBox txtDepartmentName;
        private TextBox txtLocation;
        private Button btnSave;
        private Button btnEdit;
    }
}