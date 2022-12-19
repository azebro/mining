using System;
using System.IO;
using System.Net;
using Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace StatsParser
{
    public class ParsePoolStats
    {

        public PoolStatsMeasure LoadFromApi()
        {
            var serializer =
                new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof (WafflePoolStats.Rootobject));

            using (var client = new WebClient())
            {
                using (
                    var response =
                        client.OpenRead(new Uri("http://wafflepool.com/stats_api"))
                    )
                {
                    if (response == null) return null;
                   // var responseObject =  serializer.ReadObject(response) as WafflePoolStats.Rootobject;
                    var json = Newtonsoft.Json.JsonSerializer.Create(new JsonSerializerSettings());
                    var output = json.Deserialize(new JsonTextReader(new StreamReader(response))) as JArray;
                    if (output == null || output.Count == 0) return null;

                    var record = output[0];
                    
                    var measure = new PoolStatsMeasure
                    {
                        Earned = record["earned"].Value<float>(),
                        Hashrate = record["hashrate"].Value<float>(),
                        Permhs = record["permhs"].Value<float>(),
                        CollectedOn = DateTime.Now
                    };
                    return measure;
                    
                }
            }
            
        }
    }
}
