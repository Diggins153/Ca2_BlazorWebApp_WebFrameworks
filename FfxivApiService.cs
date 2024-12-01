namespace DnD_API.Components.Pages;

using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
public class FfxivApiService
{
    
        private readonly HttpClient _httpClient;

        public FfxivApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GameAchievements> GetGameAchievements()
        {
            var response = await _httpClient.GetAsync("https://ffxivcollect.com/api/achievements/30");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<GameAchievements>(content);
        }
    }

    public class GameAchievements
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Points { get; set; }
        public int Order { get; set; }
        public string Patch { get; set; }
        public string Owned { get; set; }
        public string Icon { get; set; }
        public AchievementCategory Category { get; set; }
        public AchievementType Type { get; set; }
    }

    public class AchievementCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class AchievementType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }



