using System.Net.Http;
using System.Threading.Tasks;

namespace Jokes.Api {
    public static class JokeClient {
        static HttpClient client = new HttpClient ();

        public static async Task<JokeResponse> GetRandomJoke () {

            var response = await client.GetAsync ("http://api.icndb.com/jokes/random");
            return Newtonsoft.Json.JsonConvert.DeserializeObject<JokeResponse> (await response.Content.ReadAsStringAsync ());
        }
    }
}