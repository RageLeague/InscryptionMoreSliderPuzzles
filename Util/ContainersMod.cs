using System;
using System.Collections.Generic;
using System.Text;

namespace MoreSliderPuzzles.Util
{
    public static class ContainersMod
    {
        public static Dictionary<Tuple<string, int>, int> max_open_times = new()
        {
            // { new Tuple<string, int>("GBC_Temple_Nature", 34565083), 2 }
        };

        public static int MaxOpenTimes(string scene, int id)
        {
            // Try look up the result in max_open_times
            if (max_open_times.TryGetValue(new Tuple<string, int>(scene, id), out int result))
            {
                return result;
            }
            else
            {
                // By default, a container can be opened once
                return 1;
            }
        }

        public static void AddOpenTimes(string scene, int id, int max_time)
        {
            max_open_times.Add(new Tuple<string, int>(scene, id), max_time);
        }

        public static void AddInfiniteOpenTimes(string scene, int id)
        {
            AddOpenTimes(scene, id, -1);
        }
    }
}
