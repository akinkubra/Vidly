using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>();

            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MovieDto, Movie>();

            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<MembershipTypeDto, MembershipType>();

            Mapper.CreateMap<Genre, GenreDto>();
            Mapper.CreateMap<GenreDto, Genre>();


        }
    }
}