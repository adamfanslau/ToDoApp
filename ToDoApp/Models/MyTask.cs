using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Models
{
    public class MyTask
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
        public DateTime Created { get; set; }
        
        [Display(Name = "Deadline (dd/MM/yyyy HH:mm)")]
        public DateTime Deadline { get; set; }
        public TaskStatus TaskStatus { get; set; }
        public int TaskStatusId { get; set; }

    }
}