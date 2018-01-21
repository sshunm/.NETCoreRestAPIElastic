using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nest;

namespace ElasticSearchRestAPI.Model
{
    [ElasticsearchType(Name = "alarm")]
    public class Alarm
    {
        public string unit { get; set; }
        //[Date(Format = "yyyyMMdd'T'HHmmssZ")]
        [Date(Format = DateFormat.basic_ordinal_date_time_no_millis/*"yyyyMMdd'T'HHmmssZ"*/)]
        public string datetime { get; set; }
        //[Date(Format = "yyyy-MM-dd")]
        public string date { get; set; }
        //[Date(Format = "HH:mm:ss.SSS")]
        public string timeofday { get; set; }
    }
}
