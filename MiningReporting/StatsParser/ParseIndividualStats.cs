using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Common;
using System.Net;

namespace StatsParser
{
    public class ParseIndividualStats
    {
        private readonly DateTime _baseUnixDate = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        public MeasureSample ParseWorkers()
        {

            return LoadFromApi("1Y9My747MgN9jVovucztEKSgLengPrsm6");

        }

        private MeasureSample LoadFromApi(string btcAddress)
        {
            var serializer =
                new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof (IndividualStatsApi.Rootobject));
            var hashrates = new List<Rig>();
            var payments = new List<Payment>();
            var measureSample = new MeasureSample();
            using (var client = new WebClient())
            {
                using (
                    var response =
                        client.OpenRead(new Uri(String.Format("http://wafflepool.com/tmp_api?address={0}", btcAddress)))
                    )
                {
                    if (response == null) return null;
                    var responseObject = (IndividualStatsApi.Rootobject) serializer.ReadObject(response);

                    if (responseObject == null) return null;
                    hashrates.AddRange(from workerHashrate in responseObject.worker_hashrates
                        let rigNameList =
                            workerHashrate.username.Split(new[] {"_"}, StringSplitOptions.RemoveEmptyEntries)
                        select new Rig
                        {
                            Hashrate = workerHashrate.hashrate,
                            LastSeen = _baseUnixDate.AddSeconds(workerHashrate.last_seen).ToUniversalTime(),
                            RigName = rigNameList.Length == 2 ? rigNameList[1] : null,
                            StaleRate = workerHashrate.stalerate/100
                        });
                    payments.AddRange(responseObject.recent_payments.Select(paymentReading => new Payment
                    {
                        Amount = float.Parse(paymentReading.amount),
                        TxId = paymentReading.txn,
                        When = Convert.ToDateTime(paymentReading.time)
                    }));
                    measureSample.TakenOn = DateTime.Now;
                    measureSample.HashRate = responseObject.hash_rate;
                    measureSample.Payments = payments;
                    measureSample.Readings = hashrates;
                    if (responseObject.balances != null)
                    {
                        measureSample.Balances = new Balance
                        {
                            Confirmed = responseObject.balances.confirmed,
                            Sent = responseObject.balances.sent,
                            Unconverted = responseObject.balances.unconverted
                        };
                    }
                }
            }
            return measureSample;
        }

// ReSharper disable once UnusedMember.Local
        private MeasureSample LoadFromFile()
        {
           
            using (var file = File.OpenRead(@"C:\MinerStats\Waffle.htm"))
            {
                return ParsePayload(file);
            }
            
        }

// ReSharper disable once UnusedMember.Local
        private MeasureSample LoadFromWeb()
        {
            using (var client = new WebClient())
            {
                var response = client.OpenRead(new Uri("http://wafflepool.com/miner/1Y9My747MgN9jVovucztEKSgLengPrsm6"));
                return ParsePayload(response);

            }

        }

        private static MeasureSample ParsePayload(Stream inputStream)
        {
            var workerHashrates = new List<Rig>();

            float hashrate = 0;
            using (var reader = new StreamReader(inputStream))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (!String.IsNullOrEmpty(line))
                    {

                        if (
                            line.Contains("<b>Hash Rate:</b>"))
                        {
                            var hashrateString =
                                line.Replace("<b>Hash Rate:</b> ", "")
                                    .Replace(@" (15min approximated)<br>", "")
                                    .Replace(" MH/s", "")
                                    .Replace(" KH/s", "")
                                    .Trim();

                            float.TryParse(hashrateString, out hashrate);
                        }
                        else if (line.Contains("<td>1Y9My747MgN9jVovucztEKSgLengPrsm6_"))
                        {
                            float workerHashRate = 0;
                            float workerStaleRate = 0;
                            var worker1 = line.Replace("<td>1Y9My747MgN9jVovucztEKSgLengPrsm6_", "")
                                .Replace("</td>", "");
                            if (!reader.EndOfStream)
                            {
                                var workerHashRateLine = reader.ReadLine();
                                if (!String.IsNullOrEmpty(workerHashRateLine))
                                {
                                    var workerHashrateString =
                                        workerHashRateLine.Replace("<td align=\"right\">", "").Replace("</td>", "").Replace("kH/s", "").Replace("MH/s", "").Trim();
                                    var isMh = workerHashRateLine.Contains("MH/s");
                                    float.TryParse(workerHashrateString, out workerHashRate);
                                    workerHashRate = isMh ? workerHashRate * 1000 :
                                    workerHashRate;

                                }
                            }
                            if (!reader.EndOfStream)
                            {
                                var workerStaleRateLine = reader.ReadLine();
                                if (!String.IsNullOrEmpty(workerStaleRateLine))
                                {
                                    var workerStaleString =
                                        workerStaleRateLine.Replace("<td align=\"right\">", "")
                                            .Replace("</td>", "")
                                            .Replace("kH/s", "")
                                            .Replace("MH/s", "")
                                            .Trim();
                                    float.TryParse(workerStaleString, out workerStaleRate);
                                    workerStaleRate = workerStaleRate/100;
                                }
                            }
                            workerHashrates.Add(new Rig
                            {
                                RigName = worker1,
                                Hashrate = workerHashRate,
                                StaleRate = workerStaleRate
                            });
                        }
                    }

                }

            }
            var sample = new MeasureSample
            {
                TakenOn = DateTime.UtcNow,
                Readings = workerHashrates,
                HashRate = hashrate

            };
            return sample;
        }
    }
}
