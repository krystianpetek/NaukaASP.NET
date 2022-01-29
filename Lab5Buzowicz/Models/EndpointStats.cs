using System.Diagnostics;

namespace Lab5Buzowicz.Models
{
    public class EndpointStats
    {
        public string HttpMethod { get; set; }
        public string RequestUrl { get; set; }
        public int RequestsCount { get; set; }
        public Stopwatch CzasZadania { get; set; }
    }
}
