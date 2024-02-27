using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class AutomapperConfig : IAutomapperConfig
    {
        public Mapper InitializeAutomapper()
        {
            //Provide all the Mapping Configuration
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserModel>();
                cfg.CreateMap<UserModel, User>();
                cfg.CreateMap<Role, RoleModel>();
                cfg.CreateMap<RoleModel, Role>();
                cfg.CreateMap<Garden, GardenModel>();
                cfg.CreateMap<GardenModel, Garden>();
                cfg.CreateMap<RPlant, RPlantModel>();
                cfg.CreateMap<RPlantModel, RPlant>();
                cfg.CreateMap<UserGarden, UserGardenModel>();
                cfg.CreateMap<UserGardenModel, UserGarden>();
                cfg.CreateMap<PlantInGarden, PlantInGardenModel>();
                cfg.CreateMap<PlantInGardenModel, PlantInGarden>();
                cfg.CreateMap<RReestrObject, RReestrObjectModel>();
                cfg.CreateMap<RReestrObjectModel, RReestrObject>();
            });

            var mapper = new Mapper(config);
            return mapper;
        }
    }
}
