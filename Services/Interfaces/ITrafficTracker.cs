namespace CourseraAPIProject.Services.Interfaces {
    public interface ITrafficTracker {

        public void IncrementConnection(string ip);
        public KeyValuePair<string, int>[] GetStatistics();

    }


}