using Lab5Buzowicz.Models;
using System.Collections.Generic;
using System.Diagnostics;

namespace Lab5Buzowicz.Services
{
    public interface IMetricsCollector
    {
        void Record(string httpMethod, string requestUrl, int responseCode, Stopwatch czas);
        IEnumerable<EndpointStats> GetEndpointStats();
    }
}
