using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProAgil.WebApi.Data;
using ProAgil.WebApi.Model;

namespace ProAgil.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly DataContex _context;


        public WeatherForecastController(DataContex context)
        {     
            _context = context;   
        }

        [HttpGet]
        //Para uma requisição assíncrona, colocamos a palavra "async" e para que 
        //e para que a Controller saiba que tem de abrir uma no Thread a cada requisição,
        //se usa a plavra "Task".
        public async Task <IActionResult>  Get()
        {
            try
            {
                //Quando se abre uma thread tem que esperar a requisição no banco. 
                //Com isso se coloca a plavra "aeait".
                var results = await _context.Eventos.OrderByDescending(e => e.DataEvento).ToListAsync();
                return Ok (results);
            }
            catch (System.Exception)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }
            
        }

        [HttpGet("{id}")]
        //Para uma requisição assíncrona, colocamos a palavra "async" e para que 
        //e para que a Controller saiba que tem de abrir uma no Thread a cada requisição,
        //se usa a plavra "Task".
        public async Task <IActionResult>  Get(int id)
        {
            try
            {
                //Quando se abre uma thread tem que esperar a requisição no banco. 
                //Com isso se coloca a plavra "aeait".
                var results = await _context.Eventos.FirstOrDefaultAsync(x => x.EventoId == id);
                return Ok (results);
            }
            catch (System.Exception)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }
            
        }

        //[HttpGet]
       // public IEnumerable<WeatherForecast> Get()
        //{
         //   var rng = new Random();
           // return Enumerable.Range(1, 5).Select(index => new WeatherForecast
         //   {
         //       Date = DateTime.Now.AddDays(index),
       //         TemperatureC = rng.Next(-20, 55),
       //         Summary = Summaries[rng.Next(Summaries.Length)]
       //     })
       //     .ToArray();
        //}
    }
}
