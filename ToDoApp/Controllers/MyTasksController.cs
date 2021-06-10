using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDoApp.Models;
using System.Data.Entity;
using ToDoApp.ViewModels;

namespace ToDoApp.Controllers
{
    public class MyTasksController : Controller
    {
        private ApplicationDbContext _context;

        public MyTasksController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: MyTasks
        public ViewResult Index()
        {
            var myTasks = _context.MyTasks.Include(t => t.TaskStatus).ToList();
            
            return View(myTasks);
        }

        public ActionResult New()
        {
            var newTask = new MyTask();
            
            return View(newTask);
        }

        [HttpPost]
        public ActionResult Save(MyTask myTask)
        {
            if(!ModelState.IsValid)
            {
                return View("New", myTask);
            }

            return View("New", myTask);
        }

        public ViewResult Abandoned()
        {
            var myTasks = _context.MyTasks.Include(t => t.TaskStatus).ToList();

            return View(myTasks);
        }
    }
}