using NuGet.Protocol.Core.Types;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MVCBasics.Models
{
    public static class GitHubModel
    {
        private static readonly HttpClient client = new();
        public static async Task<List<Repository>> GetLatestUserRepos(string uri, string limit = "3", string sortBy = "created")
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            string requestUri = $"{uri}?per_page={limit}&sort={sortBy}";
            var streamTask = client.GetStreamAsync(requestUri);
            var repositories = await JsonSerializer.DeserializeAsync<List<Repository>>(await streamTask);

            if (repositories != null)
            {
                return repositories;
            }
            else
            {
                return new List<Repository>();
            }
        }
    }

    public class Repository
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;

        [JsonPropertyName("html_url")]
        public string Url { get; set; } = string.Empty;
    }
}
