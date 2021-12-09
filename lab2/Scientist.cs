using System.Collections.Generic;


namespace StaffGetter
{
    public struct Search
    {
        public string Department { get; set; }

        public string Faculty { get; set; }

    }

    public struct PositionChange
    {
        public string Department { get; set; }
        public string Position { get; set; }
        public string JoinTime { get; set; }
        public string TillTime { get; set; }
        public string Faculty { get; set; }
    }

    public struct StaffChange
    {
        public List<ScientistNow> Scientists;
        public string StartTime;
        public string FinishTime;
    }

    public class ScientistNow
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public string Faculty { get; set; }
        public string Department { get; set; }
    }

    public class Scientist
    {
        public string Name { get; set; }
        public List<PositionChange> PositionChanges { get; set; } = new List<PositionChange>();
    }
}
