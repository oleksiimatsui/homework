using System.Collections.Generic;


namespace StaffGetter
{
    public struct PositionChange
    {
        public string Department;
        public string Position;
        public string JoinTime;
        public string Faculty;
    }

    public struct StaffChange
    {
        public List<ScientistOnDep> Scientists;
        public string StartTime;
        public string FinishTime;
    }

    public class ScientistOnDep
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public string Faculty { get; set; }
    }

    public class Scientist
    {
        public string Name { get; set; }
        public List<PositionChange> PositionChanges { get; set; } = new List<PositionChange>();
    }
}
