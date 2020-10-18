using AutoMapper;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MoviesAPI.Contexts;
using MoviesAPI.Entities;
using MoviesAPI.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly RepositoryDbContext _repository;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public MoviesController(RepositoryDbContext repository, ILogger<MoviesController> logger, IMapper mapper)
        {
            this._repository = repository;
            this._logger = logger;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieOutputDTO>>> GetAllAsync()
        {
            var movies = await _repository.Movies.ToListAsync();
            var moviesOutputDTO = _mapper.Map<List<MovieOutputDTO>>(movies);
            return moviesOutputDTO;
        }

        [HttpGet("{id}", Name="GetMovieById")]
        public async Task<ActionResult<MovieOutputDTO>> GetByIdAsync(int id)
        {
            var movie = await _repository.Movies.FirstOrDefaultAsync(x=>x.Id == id);

            if (movie == null)
            {
                _logger.LogError("The movie wasn't found...");
                return NotFound();
            }

            var movieOutputDTO = _mapper.Map<MovieOutputDTO>(movie);
            return movieOutputDTO;
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] MovieInputDTO movieInputDTO)
        {
            var movie = _mapper.Map<Movie>(movieInputDTO);
            await _repository.Movies.AddAsync(movie);
            await _repository.SaveChangesAsync();
            return new CreatedAtRouteResult("GetMovieById", new { id = movie.Id }, movie);
        }
    }
}
