using System.Collections;

namespace DataLayer
{
    public class ConnectionStatistics
    {
        public long ExecutionTime { get; set; }
        public long BytesReceived { get; set; }
        public IDictionary OriginalStats { get; set; }


        public ConnectionStatistics(IDictionary stats )
        {
            OriginalStats = stats;
            if (stats.Contains("ExecutionTime"))
                ExecutionTime = long.Parse(stats["ExecutionTime"].ToString());

            if (stats.Contains("BytesReceived"))
                BytesReceived = long.Parse(stats["BytesReceived"].ToString());

        }
    }
}
