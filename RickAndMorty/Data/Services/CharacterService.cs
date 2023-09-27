using Newtonsoft.Json;
using RickAndMorty.Data.Models;

namespace RickAndMorty.Data.Services
{
    public class CharacterService
    {
        private readonly HttpClient _httpClient;

        public CharacterService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://rickandmortyapi.com/api/");
        }

     

             public async Task<Characters> GetCharacterByName(int id=0,string name="",string status = "")
        {
            try
            {
                HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync($"character/?page={id}&name={name}&status={status}&gender=&species=");
                httpResponseMessage.EnsureSuccessStatusCode();
                string responseBody = await httpResponseMessage.Content.ReadAsStringAsync();

                Characters characters = JsonConvert.DeserializeObject<Characters>(responseBody);
                return characters;
            }
            catch (Exception ex)
            {
                // Maneja aquí la excepción de manera adecuada si lo deseas.
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }
        public async Task<Characters> GetAllCharacters(int id)
        {
            try
            {
                HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync($"character/?page={id}");
                httpResponseMessage.EnsureSuccessStatusCode();
                string responseBody = await httpResponseMessage.Content.ReadAsStringAsync();

                Characters characters = JsonConvert.DeserializeObject<Characters>(responseBody);
                return characters;
            }
            catch (Exception ex)
            {
                // Maneja aquí la excepción de manera adecuada si lo deseas.
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }
    }
}
