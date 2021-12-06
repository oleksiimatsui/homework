
using System.Collections.Generic;


namespace StaffGetter { 
    public interface Analizer_IStrategy
    {
        protected static string path;
        public List<PositionChange> GetPosChanges(string name);
        public List<StaffChange> GetStaffChangesOfDep(string name);
    }
}
