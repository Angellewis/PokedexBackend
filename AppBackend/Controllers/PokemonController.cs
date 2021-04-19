using AppBackend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace AppBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonController : Controller
    {
        // GET: PokemonController
        [HttpGet]
        public async Task<Pokemon> Index(string name)
        {
            ApiHelper apiClient = new ApiHelper();
            return await apiClient.GetPokemons();
        }

        // GET: Pokemon/pokemonname
        [HttpGet("{name}")]
        public async Task<Details> GetPokemon(string name)
        {
            ApiHelper apiClient = new ApiHelper();
            return await apiClient.GetPokemonByName(name);
        }        
    }
}
