using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoProject.Models
{
   public interface ITodoRepository
    {
          List<Todo> GetAllTodos();

          Todo GetTodo(int TaskID);

          void RemoveTodo(int TaskID);

          void AddTodo(Todo todo);

          void UpdateTodo(Todo todo);
     
    }
}
