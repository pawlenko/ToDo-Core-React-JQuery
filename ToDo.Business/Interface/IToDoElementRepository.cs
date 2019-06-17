using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDo.Data.Models;

namespace ToDo.Business.Interface
{
    public interface IToDoElementRepository
    {
         Task<IEnumerable<ToDoElement>> GetAllToDo();
         Task<ToDoElement> GetElementById(int id);
         Task<ToDoElement> CreateElementAsync(string Tittle);
         Task<ToDoElement> UpdateToDoAsync(ToDoElement state);
         Task DeleteToDoAsync(ToDoElement element);
    }
}
