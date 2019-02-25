using SmileDirect.SpaceXProxyService.DTOs;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace SmileDirect.SpaceXProxyService.Services
{
    internal class SpaceXOriginalLaunchPad
    {
        [JsonProperty("padid")]
        public string Id { get; set; }

        [JsonProperty("full_name")]
        public string Name { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }

    public class SpaceXOriginalService : ISpaceXService
    {
        private string urlParameters = String.Empty;

        private readonly ILogger<SpaceXOriginalService> _logger;

        private readonly SpaceXSettings _settings;

        public SpaceXOriginalService(ILogger<SpaceXOriginalService> logger, SpaceXSettings settings)
        {
            _logger = logger;
            _settings = settings;
        }

        public IEnumerable<LaunchPad> GetLaunchPads()
        {
            return getLaunchPads();
        }

        public LaunchPad GetLaunchPad(int id)
        {
            IEnumerable<LaunchPad> launchapads = getLaunchPads();

            return launchapads.FirstOrDefault(lp => lp.Id == id.ToString());
        }

        private IEnumerable<LaunchPad> getLaunchPads ()
        {
            IEnumerable<SpaceXOriginalLaunchPad> launchapads = null;

            using (HttpClient client = new HttpClient())
            {      
                try
                {
                    client.BaseAddress = new Uri(_settings.URL);
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "{0} is an invalid URL for the SpaceXService!", _settings.URL);
                    return null;
                }

                client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync(urlParameters).Result;
                if (response.IsSuccessStatusCode)
                {
                    launchapads = response.Content.ReadAsAsync<IEnumerable<SpaceXOriginalLaunchPad>>().Result;
                }
                else
                {
                    _logger.LogError("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                }
            }
            return launchapads.Select( orig => new LaunchPad() {Id = orig.Id, Name = orig.Name, Status = orig.Status } );
        }
    }
}
