namespace EFCoreProject
{
    partial class CourseForm
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
            dataGridViewCourses = new DataGridView();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCourses).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewCourses
            // 
            dataGridViewCourses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCourses.Location = new Point(105, 55);
            dataGridViewCourses.Name = "dataGridViewCourses";
            dataGridViewCourses.RowHeadersWidth = 51;
            dataGridViewCourses.Size = new Size(439, 188);
            dataGridViewCourses.TabIndex = 0;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(164, 279);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(315, 279);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(94, 29);
            btnEdit.TabIndex = 2;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(441, 279);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // CourseForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(dataGridViewCourses);
            Name = "CourseForm";
            Text = "CourseForm";
            ((System.ComponentModel.ISupportInitialize)dataGridViewCourses).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewCourses;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
    }
}