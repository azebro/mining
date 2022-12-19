using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace DataAccess
{
    public class SampleUpload
    {
        public void UploadWorkerStats(MeasureSample sample)
        {
            try
            {
                if (sample == null) return;
                using (var model = new MiningEntities())
                {
                    
                    if (sample.Payments != null)
                    {
                        var transactionsInDb = model.Payments.Select(pm => pm.TxId).ToList();

                        foreach (
                            var payment in
                                sample.Payments.Where(p => !model.Payments.Select(pm => pm.TxId).Contains(p.TxId)))
                        {
                            //if (model.Payments.SingleOrDefault(p => p.TxId == payment.TxId) != null) continue;
                            var tempPayment = new Payment
                            {
                                Amount = payment.Amount,
                                TransactionDate = payment.When,
                                TxId = payment.TxId
                            };
                            model.Payments.Add(tempPayment);
                        }

                    }

                    var readingId = Guid.NewGuid();
                    var poolReading = new PoolReading
                    {
                        ReadingId = readingId,
                        Time = sample.TakenOn,
                        Pool = 1,
                        Reading = sample.HashRate

                    };
                    model.PoolReadings.Add(poolReading);
                    if (sample.Balances != null)
                    {
                        var tempBalance = new Balance
                        {
                            Confirmed = sample.Balances.Confirmed,
                            Unconverted = sample.Balances.Unconverted,
                            Sent = sample.Balances.Sent,
                            ReadingId = readingId
                        };
                        model.Balances.Add(tempBalance);
                    }
                    if (sample.Readings != null)
                    {
                        foreach (var workerReading in sample.Readings)
                        {
                            var reading = new PoolWorkerReading
                            {
                                Hashrate = workerReading.Hashrate,
                                StaleRate = workerReading.StaleRate,
                                LastSeen = workerReading.LastSeen,
                                Worker = String.IsNullOrEmpty(workerReading.RigName) ? "Empty" : workerReading.RigName,
                                ReadingId = readingId
                            };
                            model.PoolWorkerReadings.Add(reading);

                        }

                    }
                    model.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e);

            }



            //foreach (var poolReadingTaken in sample.Readings)
            //{
            //    var poolReading = new PoolReading
            //    {
            //        Rig1 =
            //            model.Rigs.SingleOrDefault(
            //                r =>
            //                   r.Name.ToLower() == poolReadingTaken.RigName.ToLower()),
            //        Reading = poolReadingTaken.Hashrate,
            //        Time = sample.TakenOn,
            //        Pool1 = model.Pools.SingleOrDefault(p => p.Name == "Waffle")
            //    };
            //    model.PoolReadings.Add(poolReading);
            //    model.SaveChanges();
            //}
        }

        public void UploadPoolStats(PoolStatsMeasure measure)
        {
            try
            {
                if(measure == null) return;
                using (var model = new MiningEntities())
                {
                    var poolStat = new PoolStat
                    {
                        Earned = measure.Earned,
                        PerMH = measure.Permhs,
                        Hashrate = measure.Hashrate,
                        TakenOn = measure.CollectedOn
                    };
                    model.PoolStats.Add(poolStat);
                    model.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.ToString());
            }
           
        }
    }
}
