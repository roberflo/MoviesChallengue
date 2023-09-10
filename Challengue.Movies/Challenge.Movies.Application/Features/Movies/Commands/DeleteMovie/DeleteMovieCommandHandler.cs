using AutoMapper;
using Challenge.Movies.Application.Contracts.Persistence;
using Challenge.Movies.Application.Features.Movies.Commands.UpdateMovie;
using Challenge.Movies.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Movies.Application.Features.Movies.Commands.DeleteMovie
{
    public class DeleteMovieCommandHandler :IRequestHandler<DeleteMovieCommand, DeleteMovieCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMovieRepository _movieRepository;
       
        public DeleteMovieCommandHandler(IMapper mapper, IMovieRepository movieRepository)
        {
            _mapper = mapper;
            _movieRepository = movieRepository;
            
        }
    
        public async Task<DeleteMovieCommandResponse> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
        {

            var deleteMovieCommandResponse = new DeleteMovieCommandResponse();

            var validator = new DeleteMovieCommandValidator(_movieRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {
                deleteMovieCommandResponse.Success = false;
                deleteMovieCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    deleteMovieCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }

            }
            if (deleteMovieCommandResponse.Success)
            {
                var movieToDelete = await _movieRepository.GetByIdAsync(request.MovieId);
                await _movieRepository.DeleteAsync(movieToDelete);
            }

            return deleteMovieCommandResponse;
        }
    }
}
