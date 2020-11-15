using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace frontend
{
   public class WeatherClient
   {
      private readonly JsonSerializerOptions options = new JsonSerializerOptions()
      {
         PropertyNameCaseInsensitive = true,
         PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
      };

      private readonly HttpClient _client;

      public WeatherClient(HttpClient client)
      {
         this._client = client;
      }

      public async Task<WeatherForecast[]> GetWeatherAsync()
      {

         var responseMessage = await _client.GetAsync("/weatherforecast");

         var stream = await responseMessage.Content.ReadAsStreamAsync();
         return await JsonSerializer.DeserializeAsync<WeatherForecast[]>(stream, options);
      }
   }
}