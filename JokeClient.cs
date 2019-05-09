using System.Net.Http;
using System.Threading.Tasks;
using Flurl;

namespace Jokes.Api {
    public static class JokeClient {
        static HttpClient client = new HttpClient ();

        public static async Task<JokeResponse> GetRandomJoke (string[] limitTo, string[] exclude) {

            var excludes = exclude.Length > 0 ? $"[{string.Join (",", exclude)}]" : null;
            var limit = limitTo.Length > 0 ? $"[{string.Join (",", limitTo)}]" : null;

            var url = "http://api.icndb.com"
                .AppendPathSegments ("jokes", "random")
                .SetQueryParam ("exclude", excludes)
                .SetQueryParam ("limitTo", limit);

            var response = await client.GetAsync (url);

            return Newtonsoft.Json.JsonConvert.DeserializeObject<JokeResponse> (await response.Content.ReadAsStringAsync ());
        }
    }
}