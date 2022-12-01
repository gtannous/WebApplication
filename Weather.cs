using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class Weather
    {
        public DateTime date { get; set; }
        public string summary { get; set; }           
        public int temperatureC { get; set; }
        public int temperatureF { get; set; }
    }
}