namespace TaskManagerHW
{
    partial class TaskManager
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
            this.listBoxAllTasks = new System.Windows.Forms.ListBox();
            this.txtNewTask = new System.Windows.Forms.TextBox();
            this.btnAddTask = new System.Windows.Forms.Button();
            this.btnEditTask = new System.Windows.Forms.Button();
            this.btnDeleteTask = new System.Windows.Forms.Button();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.dtpDeadline = new System.Windows.Forms.DateTimePicker();
            this.cmbAssignee = new System.Windows.Forms.ComboBox();
            this.txtNewAssignee = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddAssignee = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxAllTasks
            // 
            this.listBoxAllTasks.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.listBoxAllTasks.FormattingEnabled = true;
            this.listBoxAllTasks.HorizontalScrollbar = true;
            this.listBoxAllTasks.ItemHeight = 16;
            this.listBoxAllTasks.Location = new System.Drawing.Point(42, 82);
            this.listBoxAllTasks.Name = "listBoxAllTasks";
            this.listBoxAllTasks.Size = new System.Drawing.Size(297, 420);
            this.listBoxAllTasks.TabIndex = 0;
            this.listBoxAllTasks.SelectedIndexChanged += new System.EventHandler(this.listBoxAllTasks_SelectedIndexChanged);
            // 
            // txtNewTask
            // 
            this.txtNewTask.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.txtNewTask.Location = new System.Drawing.Point(363, 82);
            this.txtNewTask.Multiline = true;
            this.txtNewTask.Name = "txtNewTask";
            this.txtNewTask.Size = new System.Drawing.Size(362, 31);
            this.txtNewTask.TabIndex = 1;
            // 
            // btnAddTask
            // 
            this.btnAddTask.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnAddTask.Location = new System.Drawing.Point(673, 446);
            this.btnAddTask.Name = "btnAddTask";
            this.btnAddTask.Size = new System.Drawing.Size(114, 28);
            this.btnAddTask.TabIndex = 2;
            this.btnAddTask.Text = "Добавить";
            this.btnAddTask.UseVisualStyleBackColor = false;
            this.btnAddTask.Click += new System.EventHandler(this.btnAddTask_Click);
            // 
            // btnEditTask
            // 
            this.btnEditTask.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnEditTask.Location = new System.Drawing.Point(520, 446);
            this.btnEditTask.Name = "btnEditTask";
            this.btnEditTask.Size = new System.Drawing.Size(114, 28);
            this.btnEditTask.TabIndex = 3;
            this.btnEditTask.Text = "Изменить";
            this.btnEditTask.UseVisualStyleBackColor = false;
            this.btnEditTask.Click += new System.EventHandler(this.btnEditTask_Click);
            // 
            // btnDeleteTask
            // 
            this.btnDeleteTask.BackColor = System.Drawing.Color.Crimson;
            this.btnDeleteTask.Location = new System.Drawing.Point(374, 446);
            this.btnDeleteTask.Name = "btnDeleteTask";
            this.btnDeleteTask.Size = new System.Drawing.Size(114, 28);
            this.btnDeleteTask.TabIndex = 4;
            this.btnDeleteTask.Text = "Удалить";
            this.btnDeleteTask.UseVisualStyleBackColor = false;
            this.btnDeleteTask.Click += new System.EventHandler(this.btnDeleteTask_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.txtDescription.Location = new System.Drawing.Point(363, 233);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(424, 167);
            this.txtDescription.TabIndex = 5;
            this.txtDescription.Tag = "Введите описание";
            // 
            // dtpDeadline
            // 
            this.dtpDeadline.Location = new System.Drawing.Point(363, 132);
            this.dtpDeadline.Name = "dtpDeadline";
            this.dtpDeadline.Size = new System.Drawing.Size(200, 22);
            this.dtpDeadline.TabIndex = 6;
            // 
            // cmbAssignee
            // 
            this.cmbAssignee.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.cmbAssignee.FormattingEnabled = true;
            this.cmbAssignee.Location = new System.Drawing.Point(599, 134);
            this.cmbAssignee.Name = "cmbAssignee";
            this.cmbAssignee.Size = new System.Drawing.Size(165, 24);
            this.cmbAssignee.TabIndex = 7;
            this.cmbAssignee.Text = "Исполнитель";
            // 
            // txtNewAssignee
            // 
            this.txtNewAssignee.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.txtNewAssignee.Location = new System.Drawing.Point(363, 203);
            this.txtNewAssignee.Name = "txtNewAssignee";
            this.txtNewAssignee.Size = new System.Drawing.Size(206, 22);
            this.txtNewAssignee.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label1.Location = new System.Drawing.Point(360, 184);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Добавить нового исполнителя";
            // 
            // btnAddAssignee
            // 
            this.btnAddAssignee.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnAddAssignee.Location = new System.Drawing.Point(599, 203);
            this.btnAddAssignee.Name = "btnAddAssignee";
            this.btnAddAssignee.Size = new System.Drawing.Size(89, 24);
            this.btnAddAssignee.TabIndex = 10;
            this.btnAddAssignee.Text = "Создать ";
            this.btnAddAssignee.UseVisualStyleBackColor = false;
            this.btnAddAssignee.Click += new System.EventHandler(this.btnAddAssignee_Click_1);
            // 
            // TaskManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSalmon;
            this.ClientSize = new System.Drawing.Size(869, 579);
            this.Controls.Add(this.btnAddAssignee);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNewAssignee);
            this.Controls.Add(this.cmbAssignee);
            this.Controls.Add(this.dtpDeadline);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.btnDeleteTask);
            this.Controls.Add(this.btnEditTask);
            this.Controls.Add(this.btnAddTask);
            this.Controls.Add(this.txtNewTask);
            this.Controls.Add(this.listBoxAllTasks);
            this.Name = "TaskManager";
            this.Text = "Управление задачами";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxAllTasks;
        private System.Windows.Forms.TextBox txtNewTask;
        private System.Windows.Forms.Button btnEditTask;
        private System.Windows.Forms.Button btnDeleteTask;
        private System.Windows.Forms.Button btnAddTask;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.DateTimePicker dtpDeadline;
        private System.Windows.Forms.ComboBox cmbAssignee;
        private System.Windows.Forms.TextBox txtNewAssignee;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddAssignee;
    }
}

