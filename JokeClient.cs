using System.Net.Http;
using System.Threading.Tasks;
using Flurl;

namespace Jokes.Api {
    public static class JokeClient {
        static HttpClient client = new HttpClient ();

        public static async Task<JokeResponse> GetRandomJoke (string[] limitTo, string[] exclude) {

            var url = "http://api.icndb.com"
                .AppendPathSegments ("jokes", "random")
                .SetQueryParam ("exclude", $"[{string.Join(",",exclude)}]")
                .SetQueryParam ("limitTo", $"[{string.Join (",", limitTo)}]");

            var response = await client.GetAsync (url);

            return Newtonsoft.Json.JsonConvert.DeserializeObject<JokeResponse> (await response.Content.ReadAsStringAsync ());
        }
    }
}