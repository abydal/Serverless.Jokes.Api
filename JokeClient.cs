using System.Net.Http;
using System.Threading.Tasks;

namespace Jokes.Api {
    public static class JokeClient {
        static HttpClient client = new HttpClient ();

        public static async Task<JokeResponse> GetRandomJoke (string[] limitTo, string[] exclude) {

            var excludes = exclude.Length > 0 ? $"exlude=[{string.Join(",",exclude)}]" : string.Empty;
            var limitedTo = limitTo.Length > 0 ? $"limitTo=[{string.Join (",", limitTo)}]" : string.Empty;
            var queryString = string.Join ("&", limitedTo, excludes);
            queryString = !string.IsNullOrEmpty (queryString) ? $"?{queryString}" : string.Empty;

            var response = await client.GetAsync ($"http://api.icndb.com/jokes/random{queryString}");

            return Newtonsoft.Json.JsonConvert.DeserializeObject<JokeResponse> (await response.Content.ReadAsStringAsync ());
        }
    }
}