using ExoplanetRoamer.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ExoplanetRoamer.Services
{
    public interface IExoplanetQuery
    {
        Task<IEnumerable<Planet>> GetExoplanets();
    }

    /// <summary>
    /// Data from NASA API
    /// NASA API Documentation: https://exoplanetarchive.ipac.caltech.edu/docs/program_interfaces.html
    /// </summary>
    public class ExoplanetQuery : IExoplanetQuery
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly string _baseAddress;
        private readonly string _table;

        public ExoplanetQuery(IConfiguration configuration, IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            _baseAddress = configuration.GetSection("NASA:BaseAddress").Value;
            _table = configuration.GetSection("NASA:ExoplanetTable").Value;
        }

        /// <summary>
        /// Gets all exoplanets from NASA Api
        /// Column names of exoplanet table: https://exoplanetarchive.ipac.caltech.edu/docs/API_exoplanet_columns.html
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Planet>> GetExoplanets()
        {
            var client = _clientFactory.CreateClient();

            var columns = "pl_hostname,pl_letter,pl_name,pl_discmethod,pl_controvflag,pl_pnum,pl_orbper";
            var format = "json";

            var request = new HttpRequestMessage(HttpMethod.Get,
                $"{_baseAddress}?table={ _table }&select={ columns}&format={format}");

            var response = await client.SendAsync(request);

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IEnumerable<Planet>>(content);

            return result;
        }

    }
}
