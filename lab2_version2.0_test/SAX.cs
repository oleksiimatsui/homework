using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace StaffGetter
{
    public class SAX : Analizer_IStrategy
    {
        static XmlReader reader;
        private List<Scientist> scientists = new List<Scientist> ();
        public SAX()
        {
            reader = XmlReader.Create(Links.Xml);
        }

        public List<PositionChange> GetPosChanges(string _name)
        {
            string name = "";
            string dep = "";
            string pos = "";
            string time = "";
            string faculty = "";

            List<PositionChange> positionChanges = new List<PositionChange>();
            string element = "";
            while (reader.Read())
            {
                // reads the element
                if (reader.NodeType == XmlNodeType.Element)
                {
                    element = reader.Name; // the name of the current element
                }
                // reads the element value
                else if (reader.NodeType == XmlNodeType.Text)
                {
                    switch (element)
                    {
                        case "Name":
                            name = reader.Value;
                            break;
                        case "Department":
                            dep = reader.Value;
                            break;
                        case "Position":
                            pos = reader.Value;
                            break;
                        case "JoinTime":
                            time = reader.Value;
                            break;
                        case "Faculty":
                            faculty = reader.Value;
                            break;
                    }
                }

                // reads the closing elements
                else if ((reader.NodeType == XmlNodeType.EndElement))
                {
                    if (reader.Name == "scientist") {
                        if (name == _name) {
                            //scientists.Add(new Scientist { Name = name, PositionChanges = positionChanges });
                            break;
                        }
                    }
                    if (reader.Name == "PositionChange")
                    {
                        if (name == _name)
                        {
                            positionChanges.Add(new PositionChange
                            {
                                Position = pos,
                                Department = dep,
                                JoinTime = time,
                                Faculty = faculty

                            });
                        }
                    }
                }
            }
            return positionChanges;
        }

        public List<string> GetDates(string _dep)
        {
            List<string> dates = new List<string>();
            string dep = "";
            string time = "";
            string element = "";

            while (reader.Read())
            {
                // reads the element
                if (reader.NodeType == XmlNodeType.Element)
                {
                    element = reader.Name; // the name of the current element
                }
                // reads the element value
                else if (reader.NodeType == XmlNodeType.Text)
                {
                    switch (element)
                    {
                        case "Department":
                            dep = reader.Value;
                            break;
                        case "JoinTime":
                            time = reader.Value;
                            break;
                    }
                }
                // reads the closing elements
                else if ((reader.NodeType == XmlNodeType.EndElement))
                {
                    if (reader.Name == "JoinTime")
                    {
                        if (dep == _dep)
                        {
                            dates.Add(time);
                        }
                    }
                }
            }
            var Ordereddates = dates.OrderBy(r => int.Parse(r.Split('.')[1]));
            Ordereddates = dates.OrderBy(r => int.Parse(r.Split('.')[2]));
            var OrderedGroupofDates = Ordereddates.GroupBy(r => r);
            dates = new List<string>();
            foreach(var date in OrderedGroupofDates)
            {
                dates.Add(date.Key);
            }
            return dates;
        }

        public List<StaffChange> GetStaffChangesOfDep(string dep)
        {
            List<StaffChange> result = new List<StaffChange>();

            //get dates list
            var dates = GetDates(dep);
            //get staff on every date changes
            for (int i = 0; i < dates.Count - 1; i++)
            {
                result.Add(GetStaffChanges(dep, dates[i], dates[i + 1]));
            }
            result.Add(GetStaffChanges(dep, dates[dates.Count - 1], "now"));
            return result;
        }


        public StaffChange GetStaffChanges(string _dep, string date, string finishdate)
        {
            reader = XmlReader.Create(Links.Xml);
            StaffChange staffChange = new StaffChange();
            List<ScientistOnDep> scientists = new List<ScientistOnDep>();
            staffChange.StartTime = date;
            staffChange.FinishTime = finishdate;
            string faculty = "";
            string name = "";
            string dep = "";
            string pos = "";
            string thisDate = "";
            string element = "";
            while (reader.Read())
            {
                // reads the element
                if (reader.NodeType == XmlNodeType.Element)
                {
                    element = reader.Name; // the name of the current element
                }
                // reads the element value
                else if (reader.NodeType == XmlNodeType.Text)
                {
                    switch (element)
                    {
                        case "Name":
                            name = reader.Value;
                            break;
                        case "Department":
                            dep = reader.Value;
                            break;
                        case "Faculty":
                            faculty = reader.Value;
                            break;
                        case "Position":
                            pos = reader.Value;
                            break;
                        case "JoinTime":
                            thisDate = reader.Value;
                            break;
                    }
                }

                // reads the closing elements
                else if ((reader.NodeType == XmlNodeType.EndElement))
                {
                    if (reader.Name == "PositionChange")
                    {
                        if (dep == _dep && DateComparator.FirstDateIsBiggerOrEqual(thisDate, date) && DateComparator.FirstDateIsBigger(finishdate, thisDate))
                        {
                            scientists.Add(new ScientistOnDep
                            {
                                Position = pos,
                                Name = name,
                                Faculty = faculty
                            });
                        }
                    }
                }
            }
            staffChange.Scientists = scientists;
            return staffChange;
        }
    }
}
