using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToDoApp.Models;

namespace ToDoApp.ViewModels
{
    public class MyTaskViewModel
    {
        public IEnumerable<TaskStatus> TaskStatuses { get; set; }
        public MyTask MyTask { get; set; }
    }
}