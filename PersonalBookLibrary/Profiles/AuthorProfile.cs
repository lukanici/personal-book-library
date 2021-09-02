using System;
using AutoMapper;
using PersonalBookLibrary.Models;
using PersonalBookLibrary.ViewModels;

namespace PersonalBookLibrary.Profiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<Author, AuthorViewModel>();
        }
    }
}
