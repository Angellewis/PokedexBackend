using AppBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace AppBackend
{
    public class ApiHelper
    {
        //Creating the ApiHelper
        public static HttpClient ApiClient { get; set; } = new HttpClient();

        public static void InitializeClient()
        {
            //Adding header to get Json data.
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<Pokemon> GetPokemons()
        {
            //Get Request from API
            using (HttpResponseMessage response = await ApiClient.GetAsync("https://pokeapi.co/api/v2/pokemon/?limit=1118"))
            {
                if (response.IsSuccessStatusCode)
                {
                    Pokemon pokemon = await JsonSerializer.DeserializeAsync<Pokemon>(await response.Content.ReadAsStreamAsync());

                    return pokemon;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
        public async Task<Details> GetPokemonByName(string name)
        {
            //Get Request from API, especifying the pokemon name
            using (HttpResponseMessage response = await ApiClient.GetAsync($"https://pokeapi.co/api/v2/pokemon/{ name }"))
            {
                if (response.IsSuccessStatusCode)
                {
                    Details details = await JsonSerializer.DeserializeAsync<Details>(await response.Content.ReadAsStreamAsync());

                    return details;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
