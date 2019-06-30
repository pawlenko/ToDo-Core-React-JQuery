using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Threading.Tasks;
using ToDo.API.API;
using ToDo.API.Automapper;
using ToDo.API.DTO;
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
        public async Task Controller_Add_ToDo_Test()
        {
            var mockRepo = new Mock<IToDoElementRepository>();

            var myProfile = new AutomapperProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));


            var temp = new ToDoElementAdd() { Priority = 1, Tittle = "test" };


            mockRepo.Setup(x =>  x.CreateElementAsync(It.IsAny<ToDoElement>())).ReturnsAsync(new ToDoElement { Tittle = temp.Tittle, Priority = temp.Priority });

            var controller = new ToDoController(mockRepo.Object, configuration.CreateMapper());

            IActionResult result = (await controller.Post(temp));

            Assert.IsType<OkObjectResult>(result);
            var objectResponse = result as OkObjectResult;
            Assert.Equal(200, objectResponse.StatusCode);
            Assert.Equal(typeof(ToDoElementDTO), objectResponse.Value.GetType());

            ToDoElementDTO resultCast = objectResponse.Value as ToDoElementDTO;

            Assert.Equal(temp.Tittle, resultCast.Tittle);
            Assert.Equal(temp.Priority, resultCast.Priority);
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
