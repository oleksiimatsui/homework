using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;

namespace StaffGetter
{
    public class LINQ : Analizer_IStrategy
    {
        XDocument doc = new XDocument();

        public LINQ()
        {
            doc = XDocument.Load(Links.Xml);
        }

        public List<PositionChange> GetChanges(string name)
        {
            var result = (from change in doc.Descendants("PositionChange")
                          where (string)change.Parent.Parent.Element("Name") == name
                          let dep = (string)change.Element("Department")
                          let joinTime = (string)change.Element("JoinTime")
                          let tillTime = (string)change.Element("TillTime")
                          let pos = (string)change.Element("Position")
                          let faculty = (string)change.Element("Faculty")
                          select new PositionChange
                          {
                              Department = dep,
                              JoinTime = joinTime,
                              TillTime = tillTime,
                              Position = pos,
                              Faculty = faculty
                          }
                      ).ToList();

            return result;
        }

        new public List<string> GetScientistsNames()
        {
            List<string> result = (from value in doc.Descendants("scientist")
                                   select (string)value.Element("Name")).ToList();
            return result;
        }
        new public List<string> GetDepartmentsNames()
        {
            List<string> result = (from Department in doc.Descendants("Department")
                                   group Department by (string)Department into deps
                                   select (string)deps.Key
                                   ).ToList();
            return result;
        }
        new public List<string> GetFacultiesNames()
        {
            List<string> result = (from Department in doc.Descendants("Faculty")
                                   group Department by (string)Department into deps
                                   select (string)deps.Key
                                   ).ToList();
            return result;
        }

        public List<string> GetDates(Search search)
        {
            List<string> result = new List<string>();
            var joindates = (from PositionChange in doc.Descendants("PositionChange")
                             where ((string)PositionChange.Element("Department") == search.Department || search.Department == null) &&
                                   ((string)PositionChange.Element("Faculty") == search.Faculty || search.Faculty == null)
                             select (string)PositionChange.Element("JoinTime")).ToList();

            var endtimes = (from PositionChange in doc.Descendants("PositionChange")
                            where (string)PositionChange.Element("TillTime") != "now" &&
                                    ((string)PositionChange.Element("Department") == search.Department || search.Department == null) &&
                                   ((string)PositionChange.Element("Faculty") == search.Faculty || search.Faculty == null)
                            select (string)PositionChange.Element("TillTime")).ToList();

            var dates = joindates.Union(endtimes).ToList();

            var ordereddates = dates.OrderBy(r => int.Parse(r.Split('.')[0]));
            ordereddates = ordereddates.OrderBy(r => int.Parse(r.Split('.')[1]));
            ordereddates = ordereddates.OrderBy(r => int.Parse(r.Split('.')[2]));
            var orderedGroupofDates = ordereddates.GroupBy(r => r);

            foreach (var date in orderedGroupofDates)
            {
                result.Add(date.Key);
            }
            return result;
        }  

        public List<ScientistNow> GetScientistsNow(Search search, string date, string finishdate)
        {
            var scientists = (from PositionChange in doc.Descendants("PositionChange")
                              let this_joinDate = (string)PositionChange.Element("JoinTime")
                              let this_finishDate = (string)PositionChange.Element("TillTime")
                              where DateComparator.FirstDateIsBiggerOrEqual(date, this_joinDate) &&
                                    DateComparator.FirstDateIsBiggerOrEqual(this_finishDate, finishdate) &&
                              ((string)PositionChange.Element("Department") == search.Department || search.Department == null) &&
                              ((string)PositionChange.Element("Faculty") == search.Faculty || search.Faculty == null)
                              select new ScientistNow
                              {
                                  Name = (string)PositionChange.Parent.Parent.Element("Name"),
                                  Position = (string)PositionChange.Element("Position"),
                                  Faculty = NullGetter.NullIfSecondIsNotNull((string)PositionChange.Element("Faculty"), search.Faculty),
                                  Department = NullGetter.NullIfSecondIsNotNull((string)PositionChange.Element("Department"), search.Department)
                              }).ToList();
            return scientists;
        }
    }
}

