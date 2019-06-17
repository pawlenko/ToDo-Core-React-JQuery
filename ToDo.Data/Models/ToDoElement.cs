using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Data.Models
{
    public class ToDoElement
    {
        public ToDoElement()
        {
            CreateDate = DateTime.UtcNow;
        }

        [Key]
        public int Id { get; set; }
        public string Tittle { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Done { get; set; }

    }
}
