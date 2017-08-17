using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ToDoProject.Models;

namespace ToDoProject.Controllers
{
    public class TodoController : ApiController
    {

        private readonly ITodoRepository todos;


        public TodoController()
        {
            todos = new TodoRepository(new TodoDBContext());
        }

        // GET: api/Todo
        public IEnumerable<Todo> Get()
        {

            return todos.GetAllTodos();
        }

        // GET: api/Todo/5
        public IHttpActionResult Get(int id)
        {
            var todo = todos.GetTodo(id);

            if (todo == null)
                return NotFound();
            return Ok(todo);
        }

        // PUT: api/Todo/5

        public void Put([FromBody]Todo todo)
        {
            todos.UpdateTodo(todo);
        }

        // POST: api/Todo
        public void Post([FromBody]Todo todo)
        {
            todos.AddTodo(todo);
        }



        // DELETE: api/Todo/5
        public void Delete(int id)
        {
            todos.RemoveTodo(id);
        }
    }
}
