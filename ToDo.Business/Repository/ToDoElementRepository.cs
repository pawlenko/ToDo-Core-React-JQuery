using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDo.Business.Interface;
using ToDo.Data;
using ToDo.Data.Models;

namespace ToDo.Business.Repository
{
    public class ToDoElementRepository : Repository<ToDoElement>,IToDoElementRepository
    {
        public ToDoElementRepository(ApplicationDbContext repositoryContext) : base(repositoryContext)
        {

        }


        public async Task<ToDoElement> GetElementById(int id)
        {
            return await FindAsync(x => x.Id == id);
        }

        public async Task<ToDoElement> CreateElementAsync(string Tittle)
        {
            var newPlanet = new ToDoElement();
            newPlanet.Tittle = Tittle;

            return await CreateAsync(newPlanet);
        }

        public async Task<ToDoElement> UpdateToDoAsync(ToDoElement state)
        {
            return await UpdateAsync(state);
        }

        public async Task DeleteToDoAsync(ToDoElement element)
        {
            await DeleteAsync(element);
        }

        public async Task<IEnumerable<ToDoElement>> GetAllToDo()
        {
            return await GetAsync();
        }
    }
}
