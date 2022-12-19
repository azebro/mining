using DataAccess;
using System;
using System.Collections.Generic;

namespace Collector
{
    public class DataCollector
    {

        public void CollectMultipleRigData(IList<RigToCollect> collectionList)
        {
            if (collectionList == null || collectionList.Count == 0) throw new ArgumentNullException("collectionList");
            foreach (var rigToCollect in collectionList)
            {
                CollectHashData(rigToCollect.RigAddress, rigToCollect.RigPort, rigToCollect.RigName, rigToCollect.RigId);
            }
        }

        public void CollectHashData(string minerAddress, int minerPort, string rigName, int rigId)
        {
            if (rigName == null) throw new ArgumentNullException("rigName");
            var miner = new CGMinerAcceess();
            var rigData = miner.QueryCGMiner(minerAddress, minerPort, rigId);
            if (rigData == null || rigData.SUMMARY == null || rigData.STATUS == null || rigData.SUMMARY.Length == 0 ||
                rigData.STATUS.Length == 0) return;
            var data = rigData.SUMMARY[0];

            var reading = new RigReading
            {
                Accepted = data.Accepted,
                BestShare = data.BestShare,
                CollectedOn = DateTime.UtcNow,
                AverageMH = data.MHSav,
                DeviceHardware = data.DeviceHardware,
                DeviceRejected = data.DeviceRejected,
                DifficultyAccepted = data.DifficultyAccepted,
                DifficultyRejected = data.DifficultyRejected,
                DifficultyStale = data.DifficultyStale,
                Discarded = data.Discarded,
                Elapsed = data.Elapsed,
                GetFailures = data.GetFailures,
                GetWorks = data.Getworks,
                HardwareErrors = data.HardwareErrors,
                LoaclWork = data.LocalWork,
                MinerDescription = rigData.STATUS[0].Description,
                NetworkBlocks = data.NetworkBlocks,
                PoolRejected = data.PoolRejected,
                PoolStale = data.PoolStale,
                Rejected = data.Rejected,
                RemoteFailures = data.RemoteFailures,
                Rig = rigId,
                Stale = data.Stale,
                TotalMH = data.TotalMH,
                Utility = data.Utility,
                WorkUtility = data.WorkUtility,
                CurrentMH = data.MHS5s
            };
            using (var context = new MiningEntities())
            {
                context.RigReadings.Add(reading);
                context.SaveChanges();
            }

           

        }
    }
}
