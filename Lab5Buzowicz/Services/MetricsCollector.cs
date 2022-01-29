using Lab5Buzowicz.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Lab5Buzowicz.Services
{
    public class MetricsCollector : IMetricsCollector
    {
        public readonly List<CollectedRequestModel> _requests = new List<CollectedRequestModel>();
        public IEnumerable<EndpointStats> GetEndpointStats()
        
        {
            var requestsByMethodAndUrl = _requests.GroupBy(x => new
            {
                x.HttpMethod,
                x.RequestUrl,
                x.CzasZadania

            });
            var requestsCounts = requestsByMethodAndUrl.Select(x => new EndpointStats
            {
                HttpMethod = x.Key.HttpMethod,
                RequestUrl = x.Key.RequestUrl,
                CzasZadania = x.Key.CzasZadania,
                RequestsCount = x.Count()

            });

            return requestsCounts;
        }

        public void Record(string httpMethod, string requestUrl, int responseCode, Stopwatch czas)
        {
            var request = new CollectedRequestModel
            {
                HttpMethod = httpMethod,
                RequestUrl = requestUrl,
                ResponseCode = responseCode,
                CzasZadania = czas
            };
            foreach(var item in _requests)
                if(item.HttpMethod == httpMethod && item.RequestUrl == requestUrl && item.ResponseCode == responseCode)
                {
                    item.CzasZadania = request.CzasZadania;
                }
            _requests.Add(request);
        }
    }
}
