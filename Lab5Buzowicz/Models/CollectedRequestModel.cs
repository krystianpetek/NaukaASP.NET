using System.Diagnostics;

namespace Lab5Buzowicz.Models
{
    public class CollectedRequestModel
    {
        public string HttpMethod { get; set; }
        public string RequestUrl { get; set; }
        public int ResponseCode { get; set; }
        public Stopwatch CzasZadania { get; set; }   
    }
}
