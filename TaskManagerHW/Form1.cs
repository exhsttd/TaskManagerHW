using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading.Tasks;
using TaskManagerHW.Classes;
using TaskManagerHW.DataBaseResources;
using Autofac;

namespace TaskManagerHW
{
    public partial class TaskManager : Form
    {
        private readonly TaskDbContext _taskDbContext;
        private List<TaskItem> _tasks = new List<TaskItem>();
        private List<Assignee> _assignees = new List<Assignee>();

        public TaskManager(TaskDbContext taskDbContext)
        {
            InitializeComponent();
            _taskDbContext = taskDbContext;

            InitializeDatabase();

            dtpDeadline.Format = DateTimePickerFormat.Custom;
            dtpDeadline.CustomFormat = "dd.MM.yyyy HH:mm";
            dtpDeadline.ShowUpDown = true;
            dtpDeadline.Value = DateTime.Now.AddDays(1);
            cmbAssignee.DropDownStyle = ComboBoxStyle.DropDownList;

            this.Shown += async (sender, e) =>
            {
                await LoadAssigneesAsync();
                await LoadTasksAsync();
            };
        }

        private void InitializeDatabase()
        {
            _taskDbContext.InitializeDatabase();
        }

        private async Task LoadAssigneesAsync()
        {
                _assignees = await _taskDbContext.GetAssigneesAsync();

 
                this.Invoke((MethodInvoker)delegate
                {
                    cmbAssignee.DataSource = _assignees;
                    cmbAssignee.DisplayMember = "Name";
                    cmbAssignee.ValueMember = "Id";
                });

        }


        private async Task LoadTasksAsync()
        {

                _tasks = await _taskDbContext.GetTasksAsync();

                this.Invoke((MethodInvoker)delegate
                {
                    listBoxAllTasks.Items.Clear();
                    foreach (var task in _tasks)
                    {
                        listBoxAllTasks.Items.Add($"{task.Title} (до {task.Deadline:dd.MM.yyyy HH:mm}) - {task.AssigneeName}");
                    }
                });

        }

        private async void btnAddAssignee_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNewAssignee.Text))
            {
                MessageBox.Show("Введите имя исполнителя", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
                await _taskDbContext.AddAssigneeAsync(txtNewAssignee.Text);
                txtNewAssignee.Clear();
                await LoadAssigneesAsync();


        }

        public async void btnAddTask_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNewTask.Text))
            {
                MessageBox.Show("Введите название задачи", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
                await _taskDbContext.AddTaskAsync(
                    txtNewTask.Text,
                    txtDescription.Text,
                    dtpDeadline.Value,
                    (int)cmbAssignee.SelectedValue);

                txtNewTask.Clear();
                txtDescription.Clear();
                await LoadTasksAsync();
        }

        public async void btnDeleteTask_Click(object sender, EventArgs e)
        {
            if (listBoxAllTasks.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите задачу для удаления", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
                var selectedTask = _tasks[listBoxAllTasks.SelectedIndex];
                await _taskDbContext.DeleteTaskAsync(selectedTask.Id);
                await LoadTasksAsync();

        }

        public async void btnEditTask_Click(object sender, EventArgs e)
        {
            if (listBoxAllTasks.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите задачу для редактирования", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNewTask.Text))
            {
                MessageBox.Show("Введите название задачи", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
                var selectedTask = _tasks[listBoxAllTasks.SelectedIndex];
                await _taskDbContext.UpdateTaskAsync(
                    selectedTask.Id,
                    txtNewTask.Text,
                    txtDescription.Text,
                    dtpDeadline.Value,
                    (int)cmbAssignee.SelectedValue);

                await LoadTasksAsync();
        }

        private void listBoxAllTasks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxAllTasks.SelectedIndex >= 0)
            {
                var selectedTask = _tasks[listBoxAllTasks.SelectedIndex];
                txtNewTask.Text = selectedTask.Title;
                txtDescription.Text = selectedTask.Description;
                dtpDeadline.Value = selectedTask.Deadline;

                if (selectedTask.AssigneeId > 0)
                {
                    cmbAssignee.SelectedValue = selectedTask.AssigneeId;
                }
            }
        }
    }
}