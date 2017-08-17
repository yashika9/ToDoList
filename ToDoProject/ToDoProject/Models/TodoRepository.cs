using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDoProject.Models
{
    public class TodoRepository : ITodoRepository,IDisposable
    {
        TodoDBContext context;

        public TodoRepository(TodoDBContext context)
        {
            this.context = context;
        }

        public List<Todo> GetAllTodos()
        {            
            return context.TodoList.ToList();
        }

        public Todo GetTodo(int TaskID)
        {
            var todoModel = context.TodoList.Where(t => t.TaskId == TaskID).FirstOrDefault();
            return todoModel;
        }

        public void RemoveTodo(int TaskID)
        {
            Todo t = context.TodoList.Find(TaskID);
            context.TodoList.Remove(t);
            context.SaveChanges();
        }

        public void AddTodo(Todo todo)
        {
            context.TodoList.Add(todo);
            context.SaveChanges();
        }

        void ITodoRepository.UpdateTodo(Todo todo)
        {
            context.Entry(todo).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}