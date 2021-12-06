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

        public List<PositionChange> GetPosChanges(string name)
        {
            var result = (from change in doc.Descendants("PositionChange")
                          where (string)change.Parent.Parent.Element("Name") == name
                          let dep = (string)change.Element("Department")
                          let joinTime = (string)change.Element("JoinTime")
                          let pos = (string)change.Element("Position")
                          let faculty = (string)change.Element("Faculty")
                          select new PositionChange
                          {
                              Department = dep,
                              JoinTime = joinTime,
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

        public List<StaffChange> GetStaffChangesOfDep(string dep)       //цей метод з новою реалізацією, не працює коректно
        {
            List<StaffChange> result = new List<StaffChange>();

            var dates = (from PositionChange in doc.Descendants("PositionChange")
                         let date1 = (string)PositionChange.Element("JoinTime")
                         let date2 = (string)PositionChange.Element("TillTime")
                         where (string)PositionChange.Element("Department")==dep
                         orderby int.Parse(date1.Split('.')[0])
                         orderby int.Parse(date1.Split('.')[1])
                         orderby int.Parse(date1.Split('.')[2])
                         select new
                         {
                             date1 = date1,
                             date2 = date2,
                         });

            foreach(var date in dates)
            {
                result.Add(new StaffChange
                {
                    StartTime = date.date1,
                    FinishTime = date.date2,
                    Scientists = (from PositionChange in doc.Descendants("PositionChange")
                                  let department = (string)PositionChange.Element("Department")
                                  let this_date = (string)PositionChange.Element("JoinTime")
                                  orderby this_date
                                  where department == dep && DateComparator.FirstDateIsBiggerOrEqual(this_date, date.date1) && DateComparator.FirstDateIsBigger(date.date2, this_date)
                                  select new ScientistOnDep
                                  {
                                      Name = (string)PositionChange.Parent.Parent.Element("Name"),
                                      Position = (string)PositionChange.Element("Position"),
                                      Faculty = (string)PositionChange.Element("Faculty"),
                                  }).ToList()
                });
            }
            return result;
        }

    }
}

