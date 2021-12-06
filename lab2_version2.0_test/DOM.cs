using System.Collections.Generic;
using System.Linq;
using System.Xml;


namespace StaffGetter
{
    public class DOM : Analizer_IStrategy 
    {
        static XmlDocument doc = new XmlDocument();
        public DOM()
        {
            doc.Load(Links.Xml);
        }

        public List<PositionChange> GetPosChanges(string name)
        {
            var resList = new List<PositionChange>();
            XmlNodeList changesList = doc.SelectNodes("//scientist[Name=\"" + name + "\"]//PositionChange");
            foreach (XmlNode change in changesList)
            {
                PositionChange poschange_obj = new PositionChange
                {
                    Position = change.SelectSingleNode("Position").InnerText,
                    Department = change.SelectSingleNode("Department").InnerText,
                    JoinTime = change.SelectSingleNode("JoinTime").InnerText,
                    Faculty = change.SelectSingleNode("Faculty").InnerText,
                };
                resList.Add(poschange_obj);
            }
            return resList;
        }
        public List<string> GetDates(string dep)
        {
            List<string> result = new List<string>();

            var select = doc.SelectNodes("//JoinTime[../Department='" + dep + "']");
            IEnumerable<XmlNode> datesEnum = select.Cast<XmlNode>().OrderBy(r => int.Parse((r.InnerText).Split('.')[0]));
            datesEnum = datesEnum.OrderBy(r => int.Parse((r.InnerText).Split('.')[1]));
            datesEnum = datesEnum.OrderBy(r => int.Parse((r.InnerText).Split('.')[2]));
            var dates = datesEnum.GroupBy(r => (r.InnerText));
            foreach (var date in dates)
            {
                result.Add(date.Key);
            }
            return result;
        }

        public List<StaffChange> GetStaffChangesOfDep(string dep)
        {
            List<StaffChange> result = new List<StaffChange>();
            var dates = GetDates(dep);

            for (int i = 0; i < dates.Count - 1; i++)
            {
                result.Add(GetStaffChanges(dep, dates[i], dates[i + 1]));
            }
            result.Add(GetStaffChanges(dep, dates[dates.Count - 1], "now"));
            return result;
        }


        public StaffChange GetStaffChanges(string dep, string date, string finishdate)
        {
            StaffChange staffChange = new StaffChange();
            staffChange.StartTime = date;
            staffChange.FinishTime = finishdate;

            List<ScientistOnDep> scientists = new List<ScientistOnDep>();
            XmlNodeList dates = doc.SelectNodes("//JoinTime");
            foreach (XmlNode dateNode in dates)
            {
                string thisDate = dateNode.InnerText;
                if(DateComparator.FirstDateIsBiggerOrEqual(thisDate, date) && DateComparator.FirstDateIsBigger(finishdate, thisDate) &&
                    (dateNode.ParentNode.SelectNodes("Department")[0].InnerText == dep))
                {
                    string name = dateNode.ParentNode.ParentNode.ParentNode.SelectNodes("Name")[0].InnerText;
                    string pos = dateNode.ParentNode.SelectNodes("Position")[0].InnerText;
                    string faculty = dateNode.ParentNode.SelectNodes("Faculty")[0].InnerText;
                    ScientistOnDep sc = new ScientistOnDep
                    {
                        Name = name,
                        Position = pos,
                        Faculty = faculty,
                    };
                    scientists.Add(sc);
                }
            }
            staffChange.Scientists = scientists;
            return staffChange;
        }
    }
}

