using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AoC2020
{
    public class BusScheduler
    {
        public static int FindEarliestBusProduct(int startTime, string[] busSchedule)
        {
            List<int> busIds = new List<int>();

            foreach(string busId in busSchedule)
            {
                if (busId == "x")
                {
                    continue;
                }

                busIds.Add(Convert.ToInt32(busId));
            }

            int shortestWait = int.MaxValue;
            int waitingBusId = 0;

            foreach(int busId in busIds)
            {
                int waitTime = busId - (startTime % busId);

                if (waitTime < shortestWait)
                {
                    shortestWait = waitTime;
                    waitingBusId = busId;
                }
            }

            return waitingBusId * shortestWait;
        }

        public static long FindEarliestSequence(string[] busSchedule)
        {
            List<KeyValuePair<ulong, ulong>> schedule = new List<KeyValuePair<ulong, ulong>>();

            for (int i = 0; i < busSchedule.Length; i++)
            {
                if (busSchedule[i] != "x")
                {
                    long busId = Convert.ToInt64(busSchedule[i]);
                    schedule.Add(new KeyValuePair<ulong, ulong>(Convert.ToUInt64(i), Convert.ToUInt64(busId)));
                }
            }

            ulong currentStart = Convert.ToUInt64(schedule[0].Value * (100371000000000 / schedule[0].Value)); // (103559999999999 / schedule[0].Value));

            bool found = false;
            while (!found)
            {
                for (int i = 1; i < schedule.Count; i++)
                {
                    var value = (currentStart + schedule[i].Key) % schedule[i].Value;
                    if (value == 0)
                    {
                        found = true;
                    }
                    else
                    {
                        found = false;
                        currentStart += schedule[0].Value;
                        break;
                    }
                }
            }

            return (long)currentStart;
        }

        // I stole this one because math is too hard
        public static ulong FindSequentialTimestamp(string[] timetable)
        {
            List<ServiceOffsetPair> services = new List<ServiceOffsetPair>();

            uint i = 0;
            foreach (string s in timetable)
            {
                if (s != "x")
                {
                    ServiceOffsetPair pair = new ServiceOffsetPair
                    {
                        id = uint.Parse(s),
                        offset = i
                    };
                    services.Add(pair);

                    Console.WriteLine("Service {0}, offset {1}", pair.id, pair.offset);
                }
                i++;
            }

            ulong step = services[0].id;
            ulong timestamp = services[0].id;

            foreach (ServiceOffsetPair pair in services.Skip(1))
            {
                while ((timestamp + pair.offset) % pair.id != 0)
                {
                    timestamp = checked(timestamp + step);
                }
                Console.WriteLine("Timestamp {0} is valid for service {1}", timestamp, pair.id);
                step = step * pair.id;
            }

            return timestamp;
        }

        private struct ServiceOffsetPair
        {
            public uint id;
            public uint offset;
        }
    }
}
