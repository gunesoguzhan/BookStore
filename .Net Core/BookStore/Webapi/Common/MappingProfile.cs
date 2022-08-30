using AutoMapper;
using Webapi.Entities;
using Webapi.ViewModels.Author;
using Webapi.ViewModels.Book;
using Webapi.ViewModels.Genre;

namespace Webapi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CommandBookViewModel, Book>();

            CreateMap<Book, QueryBookViewModel>()
                .ForMember(dest => dest.Genre,
                    opt => opt.MapFrom(src => src.Genre.Name))
                .ForMember(dest => dest.PublishDate,
                    opt => opt.MapFrom(src => src.PublishDate.Date.ToString("dd/MM/yyy")));

            CreateMap<Genre, QueryGenreViewModel>();

            CreateMap<CommandGenreViewModel, Genre>()
                .ForMember(dest => dest.IsActive,
                    opt => opt.MapFrom(src => Convert.ToBoolean(src.IsActive)));

            CreateMap<CommandAuthorViewModel, Author>();

            CreateMap<Author, QueryAuthorViewModel>()
                .ForMember(dest => dest.BirthDate,
                    opt => opt.MapFrom(src => src.BirthDate.Date.ToString("dd/MM/yyy")));
        }
    }
}