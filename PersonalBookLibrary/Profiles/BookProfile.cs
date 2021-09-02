using System;
using AutoMapper;
using PersonalBookLibrary.Models;
using PersonalBookLibrary.ViewModels;

namespace PersonalBookLibrary.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookViewModel>();
            CreateMap<Book, BookFormViewModel>().ReverseMap();
        }
    }
}
