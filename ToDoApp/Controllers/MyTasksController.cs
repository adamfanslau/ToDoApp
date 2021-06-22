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
        public ActionResult SaveNew(MyTask myTask)
        {
            if(!ModelState.IsValid)
            {
                return View("New", myTask);
            }

            myTask.TaskStatusId = 1;
            myTask.Created = DateTime.Now;

            _context.MyTasks.Add(myTask);
            
            _context.SaveChanges();

            return RedirectToAction("Index", "MyTasks");
        }

        public ActionResult Edit(int id)
        {
            var myTask = _context.MyTasks.SingleOrDefault(t => t.Id == id);

            if (myTask == null)
            {
                return HttpNotFound();
            }

            var viewModel = new MyTaskViewModel()
            {
                MyTask = myTask,
                TaskStatuses = _context.TaskStatuses.ToList()
            };

            return View("Edit", viewModel);
        }

        public ActionResult SaveEdited(MyTask myTask)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", myTask);
            }

            var myTaskInDb = _context.MyTasks.Single(t => t.Id == myTask.Id);

            myTaskInDb.Name = myTask.Name;
            myTaskInDb.Description = myTask.Description;
            myTaskInDb.Deadline = myTask.Deadline;
            myTaskInDb.TaskStatusId = myTask.TaskStatusId;

            _context.SaveChanges();

            return RedirectToAction("Index", "MyTasks");
        }

        public ActionResult Delete(int id)
        {

            var taskToRemove = _context.MyTasks.SingleOrDefault(t => t.Id == id);

            if (taskToRemove == null)
            {
                return HttpNotFound();
            }

            _context.MyTasks.Remove(taskToRemove);
            _context.SaveChanges();

            return RedirectToAction("Index", "MyTasks");
        }
        
        public ViewResult Abandoned()
        {
            var myTasks = _context.MyTasks.Include(t => t.TaskStatus).ToList();

            return View(myTasks);
        }
    }
}