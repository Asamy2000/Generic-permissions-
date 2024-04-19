using AutoMapper;
using PAT.AccessModel.Models.Info;
using PAT.Provider.Info.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAT.Provider.Info
{
    public class InfoMappingConfig : Profile
    {
        public InfoMappingConfig()
        {
            CreateMap<UserDto, User>().ReverseMap();


        }
    }
}
