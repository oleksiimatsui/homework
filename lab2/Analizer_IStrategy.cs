
using System.Collections.Generic;


namespace StaffGetter { 
    public interface Analizer_IStrategy
    {
        protected static string path;
        public List<PositionChange> GetChanges(string name);
        public List<StaffChange> GetStaffChanges(Search search)
        {
            List<StaffChange> result = new List<StaffChange>();
            var dates = GetDates(search);

            for (int i = 0; i < dates.Count - 1; i++)
            {
                result.Add(GetStaffChanges(search, dates[i], dates[i + 1]));
            }
            result.Add(GetStaffChanges(search, dates[dates.Count - 1], "now"));
            return result;
        }
        public StaffChange GetStaffChanges(Search search, string date, string finishdate)
        {
            StaffChange staffChange = new StaffChange();
            staffChange.StartTime = date;
            staffChange.FinishTime = finishdate;
            staffChange.Scientists = GetScientistsNow(search, date, finishdate);
            return staffChange;
        }
        public List<ScientistNow> GetScientistsNow(Search search, string date, string finishdate);
        public List<string> GetDates(Search search);

    }
}
