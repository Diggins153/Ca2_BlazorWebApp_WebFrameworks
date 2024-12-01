using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DnD_API
{
    public class DnDApiService
    {
        private readonly HttpClient _httpClient;

        public DnDApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<DwarfRace> GetDwarfRaceAsync()
        {
            var response = await _httpClient.GetAsync("https://www.dnd5eapi.co/api/races/dwarf");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<DwarfRace>(content);
        }
    }

    public class DwarfRace
    {
        public string Index { get; set; }
        public string Name { get; set; }
        public string Alignment { get; set; }
        public string Age { get; set; }
        public string Size { get; set; }
        public string SizeDescription { get; set; }
        public string LanguageDesc { get; set; }
    }

}
