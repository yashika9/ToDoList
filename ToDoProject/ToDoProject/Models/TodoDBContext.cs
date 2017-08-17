using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ToDoProject.Models
{
    public class TodoDBContext: DbContext
    {

        public TodoDBContext() : base("TodoDB")  
       {
            Database.SetInitializer<TodoDBContext>(new CreateDatabaseIfNotExists<TodoDBContext>());

        }
        public DbSet<Todo> TodoList { get; set; }
    }
}