using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using ToDo.Business.Interface;
using ToDo.Business.Repository;
using ToDo.Data;
using ToDo.Data.Models;
using Xunit;

namespace ToDo.Unit.Test
{
    public class UnitTest1
    {

        ToDoElementRepository _repo;

        public UnitTest1()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase(databaseName: "ToDoTests")
               .Options;
                ApplicationDbContext context = new ApplicationDbContext(options);

             _repo = new ToDoElementRepository(context); 
        }


        [Fact]
        public async Task Add_ToDo()
        {
            var newToDo = new ToDoElement();
            var name = "TEST";
            newToDo.Tittle = name;
            var temp =  await _repo.CreateAsync(newToDo);
            Assert.NotNull(temp);
        }


        [Fact]
        public async Task Update_ToDo()
        {
            var newToDo = new ToDoElement();
            var name = "TEST1";
            newToDo.Tittle = name;
            var temp = await _repo.CreateAsync(newToDo);
            name = "TEST2";
            temp.Tittle = name;
            await _repo.UpdateAsync(temp);
            Assert.True(temp.Tittle == name);
        }


        [Fact]
        public async Task Delete_ToDo()
        {
            var newToDo = new ToDoElement();
            var name = "DELETE";
            newToDo.Tittle = name;
            var temp = await _repo.CreateAsync(newToDo);
            Assert.NotNull(temp);
            await _repo.DeleteAsync(temp);
            var exist = await _repo.FindAsync(x => x.Tittle == name);
            Assert.Null(exist);
        }



    }
}
