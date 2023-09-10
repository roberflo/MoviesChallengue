using AutoMapper;
using Challenge.Movies.Application.Features.Movies.Commands.CreateMovie;
using Challenge.Movies.Application.Features.Movies.Commands.DeleteMovie;
using Challenge.Movies.Application.Features.Movies.Commands.UpdateMovie;
using Challenge.Movies.Application.Features.Movies.Queries.GetMoviesList.DTO;
using Challenge.Movies.Application.Features.Ratings.Commands.CreateRating;
using Challenge.Movies.Application.Features.Ratings.Commands.DeleteRating;
using Challenge.Movies.Application.Features.Ratings.Queries.DTO;
using Challenge.Movies.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Movies.Application.Features.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Movie, MovieViewModel>()
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.Name));
            CreateMap<Movie, CreateMovieDto>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.Name));
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Movie, CreateMovieCommand>().ReverseMap();
            CreateMap<Movie, UpdateMovieCommand>().ReverseMap();
            CreateMap<Movie, DeleteMovieCommand>().ReverseMap();

            CreateMap<Rating, RatingViewModel>().ReverseMap();
            CreateMap<Movie, MovieDto>().ReverseMap();
            CreateMap<Rating, CreateRatingCommand>().ReverseMap();
            CreateMap<Rating, DeleteRatingCommand>().ReverseMap();
            CreateMap<Rating, CreateRatingDto>()
                .ForMember(dest => dest.Movie, opt => opt.MapFrom(src => src.Movie.Name));
        }
    }
}
