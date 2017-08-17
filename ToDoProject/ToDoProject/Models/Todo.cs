using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ToDoProject.Models
{
    public class Todo
    {
        [Key]
        public int TaskId { get; set; }
        public string Task { get; set; }
        public DateTime DeadlineDate { get; set; }
        public bool IsCompleted { get; set; }
        public string details { get; set; }

        public Todo()
        {

        }

        public Todo(string task, DateTime deadline, bool isCompleted, string details)
        {
            this.Task = task;
            this.DeadlineDate = deadline;
            this.IsCompleted = IsCompleted;
            this.details = details;

        }
    }
}