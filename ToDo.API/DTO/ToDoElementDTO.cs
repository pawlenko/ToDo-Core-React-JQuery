using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDo.API.DTO
{
    public class ToDoElementDTO
    {
        public int Id { get; set; }
        public string Tittle { get; set; }
        public DateTime CreateDate { get; set; }

        public bool Done { get; set; }
    }
}
