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

        public List<PositionChange> GetChanges(string name)
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
                    TillTime = change.SelectSingleNode("TillTime").InnerText,
                    Faculty = change.SelectSingleNode("Faculty").InnerText,
                };
                resList.Add(poschange_obj);
            }
            return resList;
        }
        public List<string> GetDates(Search search)
        {
            List<string> result = new List<string>();

            
            string xpath = "//TillTime[../";
            if (search.Department != null) xpath += "Department = \"" + search.Department + "\"";
            else if (search.Faculty != null) xpath += "Faculty = \"" + search.Faculty + "\"";
            xpath += "and ../TillTime != 'now'] ";
            xpath += "| //JoinTime[../";
            if (search.Department != null) xpath += "Department = \"" + search.Department + "\"";
            else if (search.Faculty != null) xpath += "Faculty = \"" + search.Faculty + "\"";
            xpath += "]";

            XmlNodeList select = doc.SelectNodes(xpath);
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

        public List<ScientistNow> GetScientistsNow(Search search, string date, string finishdate)
        {
            List<ScientistNow> scientists = new List<ScientistNow>();
            XmlNodeList positionChange = doc.SelectNodes("//PositionChange");

            foreach (XmlNode change in positionChange)
            {
                string this_joinDate = change.SelectNodes("JoinTime")[0].InnerText;
                string this_finishDate = change.SelectNodes("TillTime")[0].InnerText;

                if (DateComparator.FirstDateIsBiggerOrEqual(date, this_joinDate) &&
                    DateComparator.FirstDateIsBiggerOrEqual(this_finishDate, finishdate) &&
                    (change.SelectNodes("Department")[0].InnerText == search.Department || search.Department == null) &&
                    (change.SelectNodes("Faculty")[0].InnerText == search.Faculty || search.Faculty == null))
                {
                    string name = change.ParentNode.ParentNode.SelectNodes("Name")[0].InnerText;
                    string pos = change.SelectNodes("Position")[0].InnerText;
                    string faculty = change.SelectNodes("Faculty")[0].InnerText;
                    string dep = change.SelectNodes("Department")[0].InnerText;
                    ScientistNow sc = new ScientistNow
                    {
                        Name = name,
                        Position = pos,
                        Faculty = NullGetter.NullIfSecondIsNotNull(faculty, search.Faculty),
                        Department = NullGetter.NullIfSecondIsNotNull(dep, search.Department)
                    };
                    scientists.Add(sc);
                }
            }
            return scientists;
        }
    }
}

