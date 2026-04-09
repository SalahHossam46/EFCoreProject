namespace EFCoreProject
{
    partial class MainForm
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
            btnStudent = new Button();
            btnCourse = new Button();
            btnInstructor = new Button();
            btnDepartment = new Button();
            SuspendLayout();
            // 
            // btnStudent
            // 
            btnStudent.Location = new Point(8, 12);
            btnStudent.Name = "btnStudent";
            btnStudent.Size = new Size(94, 29);
            btnStudent.TabIndex = 0;
            btnStudent.Text = "Student Form ";
            btnStudent.UseVisualStyleBackColor = true;
            btnStudent.Click += btnStudent_Click;
            // 
            // btnCourse
            // 
            btnCourse.Location = new Point(134, 12);
            btnCourse.Name = "btnCourse";
            btnCourse.Size = new Size(94, 29);
            btnCourse.TabIndex = 1;
            btnCourse.Text = "Course";
            btnCourse.UseVisualStyleBackColor = true;
            // 
            // btnInstructor
            // 
            btnInstructor.Location = new Point(8, 131);
            btnInstructor.Name = "btnInstructor";
            btnInstructor.Size = new Size(94, 29);
            btnInstructor.TabIndex = 2;
            btnInstructor.Text = "Instructor";
            btnInstructor.UseVisualStyleBackColor = true;
            // 
            // btnDepartment
            // 
            btnDepartment.Location = new Point(134, 122);
            btnDepartment.Name = "btnDepartment";
            btnDepartment.Size = new Size(94, 29);
            btnDepartment.TabIndex = 3;
            btnDepartment.Text = "Department";
            btnDepartment.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnDepartment);
            Controls.Add(btnInstructor);
            Controls.Add(btnCourse);
            Controls.Add(btnStudent);
            Name = "MainForm";
            Text = "MainForm";
            ResumeLayout(false);
        }

        #endregion

        private Button btnStudent;
        private Button btnCourse;
        private Button btnInstructor;
        private Button btnDepartment;
    }
}