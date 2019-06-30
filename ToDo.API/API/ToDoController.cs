using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
        private IMapper _mapper;


        public ToDoController(IToDoElementRepository repo,IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }


        // GET: api/ToDo
        [HttpGet]
        public  async  Task<IActionResult> Get()
        {
            var items = (await _repo.GetAllToDo());
            var mappedItems = _mapper.Map<List<ToDoElementDTO>>(items);

            return Ok(mappedItems);
        }

        // GET: api/ToDo/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult>  Get(int id)
        {
            var item = (await _repo.GetElementById(id));

            if(item != null)
            {
                var mappedItem = _mapper.Map<ToDoElementDTO>(item);
                return Ok(mappedItem);
            }
            else
                return BadRequest("NOT_EXIST");
        }

        // POST: api/ToDo
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ToDoElementAdd state)
        {

            if(state.Priority>=1 && state.Priority <= 10)
            {
                if (string.IsNullOrEmpty(state.Tittle))
                    return BadRequest("TITTLE_IS_REQUIRED");
                else
                {
                    var itemToADD = _mapper.Map<ToDoElement>(state);
                    var newToDoElem =  await _repo.CreateElementAsync(itemToADD);
                    var mappedItem = _mapper.Map<ToDoElementDTO>(newToDoElem);
                    return Ok(mappedItem);
                }
            }
            else
            {
                return BadRequest("PRIORITY_INCORECT_RANGE");
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
                var mappedItem = _mapper.Map(state, item);


                await _repo.UpdateToDoAsync(mappedItem);
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
