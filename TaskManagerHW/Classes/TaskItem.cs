using System;

namespace TaskManagerHW.Classes
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public int AssigneeId { get; set; }
        public string AssigneeName { get; set; } 
    }

    public class Assignee
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
