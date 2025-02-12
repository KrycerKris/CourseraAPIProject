using CourseraAPIProject.Services.Interfaces;

namespace CourseraAPIProject.Services {

    public class TrafficTrackerLocalTest : ITrafficTracker
    {
        private Dictionary<string, int> _trafficStats = new();

        public KeyValuePair<string, int>[] GetStatistics()
        {
            return _trafficStats.ToArray();
        }

        public void IncrementConnection(string ip)
        {
            if(_trafficStats.ContainsKey(ip))
                _trafficStats[ip]++;
            else
                _trafficStats[ip] = 1;
        }
    }


}