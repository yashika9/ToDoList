using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using ToDoProject.Models;

namespace ToDoClient.Models
{
    public class ToDoController : Controller
    {
        // GET: ToDo
        public ActionResult Index()
        {
            TodoClient todo = new TodoClient();
            ViewBag.result = todo.displayAll();
            return View();
        }
        //post
        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }
        [HttpPost]
        public ActionResult Create(Todo td)
        {
            td.DeadlineDate = DateTime.Now;
            TodoClient todo = new TodoClient();
            todo.Create(td);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            TodoClient todo = new TodoClient();
            todo.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            TodoClient todo = new TodoClient();
            Todo td = new Todo();
            td = todo.display(id);
            return View("Edit", td);
        }
        [HttpPost]
        public ActionResult Edit(Todo td)
        {
            TodoClient todo = new TodoClient();
            todo.Edit(td);
            return RedirectToAction("Index");
        }

    }
}