using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.API.DTO;
using ToDo.Data.Models;

namespace ToDo.API.Automapper
{
    public class AutomapperProfile : Profile
    {
         public AutomapperProfile()
        {
            CreateMap<ToDoElement,ToDoElementDTO>();
            CreateMap<ToDoElementAdd,ToDoElement>();
            CreateMap<ToDoElementEditDTO, ToDoElement>()
                .ForMember(dest => dest.Tittle, opts => opts.MapFrom(src => src.Tittle))
                .ForMember(dest => dest.Done, opts => opts.MapFrom(src => src.Done));
        }

    }
}
