using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDo.API.DTO;
using ToDo.Business.Interface;
using ToDo.Data.Models;

namespace ToDo.API.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {

        private IToDoElementRepository _repo;

        public ToDoController(IToDoElementRepository repo)
        {
            _repo = repo;
        }


        // GET: api/ToDo
        [HttpGet]
        public  async  Task<IActionResult> Get()
        {
            var items = (await _repo.GetAllToDo()).Select(x => new ToDoElementDTO
            {
                Id = x.Id,
                Tittle = x.Tittle,
                CreateDate = x.CreateDate,
                Done = x.Done
              
            });


            return Ok(items);
        }

        // GET: api/ToDo/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult>  Get(int id)
        {
            var item = (await _repo.GetElementById(id));

            if(item != null)
            {
                var temp = new ToDoElementDTO();
                temp.CreateDate = item.CreateDate;
                temp.Id = item.Id;
                temp.Tittle = item.Tittle;
                temp.Done = item.Done;
                return Ok(temp);
            }
            else
                return BadRequest("NOT_EXIST");
        }

        // POST: api/ToDo
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ToDoElementAdd state)
        {
            if (string.IsNullOrEmpty(state.Tittle))
                return BadRequest("TITTLE_IS_REQUIRED");
            else
            {
                var newToDoElem =  await _repo.CreateElementAsync(state.Tittle);

                var temp = new ToDoElementDTO();
                temp.CreateDate = newToDoElem.CreateDate;
                temp.Id = newToDoElem.Id;
                temp.Tittle = newToDoElem.Tittle;
                temp.Done = newToDoElem.Done;
                return Ok(temp);
            }
        }

        // PUT: api/ToDo/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ToDoElementEditDTO state)
        {

            if (string.IsNullOrEmpty(state.Tittle))
                return BadRequest("TITTLE_IS_REQUIRED");

            var item = (await _repo.GetElementById(id));

            if (item != null)
            {
                item.Done = state.Done;
                item.Tittle = state.Tittle;
                await _repo.UpdateToDoAsync(item);
                return Ok();
            }
            else
                return BadRequest("NOT_EXIST");
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = (await _repo.GetElementById(id));

            if (item != null)
            {
               await _repo.DeleteToDoAsync(item);
                return Ok();
            }
            else
                return BadRequest("NOT_EXIST");
        }


      
    }
}
