using AutoMapper;
using NoviApp.Application.Commands;
using NoviApp.Application.Dtos.Users;
using NoviApp.Application.Queries.Users;
using NoviApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoviApp.Application.Mappings.UserMappings
{
    public class UserMapping: Profile
    {
        public UserMapping() 
        {
            CreateMap<User, UserDto>();
            CreateMap<GetAllByIdUserQuery, UserDto>();

            CreateMap<CreateUserCommand, User>();
            CreateMap<CreateUserCommand, UserDto>();
            CreateMap<EditUserCommand, UserDto>();
            CreateMap<EditUserCommand, User>();
        }
    }
}
