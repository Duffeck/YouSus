using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using yousus.Models.DTO;

namespace yousus.Models
{
    public static class MappingProfile
    {
        public static MapperConfiguration InitializeAutoMapper()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Categoria, CategoriaDTO>();
                cfg.CreateMap<CategoriaDTO, Categoria>();
                cfg.CreateMap<Foto, FotoDTO>();
                cfg.CreateMap<FotoDTO, Foto>();
                /*etc...*/
            });

            return config;
        }
    }
}