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

        public List<PositionChange> GetChanges(string _name)
        {
            string name = "";
            string dep = "";
            string pos = "";
            string jointime = "";
            string tilltime = "";
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
                            jointime = reader.Value;
                            break;
                        case "TillTime":
                            tilltime = reader.Value;
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
                                JoinTime = jointime,
                                TillTime = tilltime,
                                Faculty = faculty

                            });
                        }
                    }
                }
            }
            return positionChanges;
        }

        public List<string> GetDates(Search search)
        {
            List<string> dates = new List<string>();
            string dep = "";
            string fac = "";
            string this_jointime = "";
            string this_tilltime = "";
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
                        case "Faculty":
                            fac = reader.Value;
                            break;
                        case "JoinTime":
                            this_jointime = reader.Value;
                            break;
                        case "TillTime":
                            this_tilltime = reader.Value;
                            break;
                    }
                }
                // reads the closing elements
                else if ((reader.NodeType == XmlNodeType.EndElement))
                {
                    if (reader.Name == "JoinTime")
                    {
                        if ((dep == search.Department || search.Department == null) && (fac == search.Faculty || search.Faculty == null))
                        {
                            dates.Add(this_jointime);
                        }
                    }
                    if (reader.Name == "TillTime")
                    {
                        if ((dep == search.Department || search.Department == null) && (fac == search.Faculty || search.Faculty == null))
                        {
                            if(this_tilltime != "now") dates.Add(this_tilltime);
                        }
                    }
                }
            }
            var Ordereddates = dates.OrderBy(r => int.Parse(r.Split('.')[0]));
            Ordereddates = Ordereddates.OrderBy(r => int.Parse(r.Split('.')[1]));
            Ordereddates = Ordereddates.OrderBy(r => int.Parse(r.Split('.')[2]));
            var OrderedGroupofDates = Ordereddates.GroupBy(r => r);
            dates = new List<string>();
            foreach(var date in OrderedGroupofDates)
            {
                dates.Add(date.Key);
            }
            return dates;
        }


        public List<ScientistNow> GetScientistsNow(Search search, string date, string finishdate)
        {
            reader = XmlReader.Create(Links.Xml);
            List<ScientistNow> scientists = new List<ScientistNow>();
            string faculty = "";
            string name = "";
            string dep = "";
            string pos = "";
            string this_joinDate = "";
            string this_finishDate = "";
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
                            this_joinDate = reader.Value;
                            break;
                        case "TillTime":
                            this_finishDate = reader.Value;
                            break;
                    }
                }

                // reads the closing elements
                else if ((reader.NodeType == XmlNodeType.EndElement))
                {
                    if (reader.Name == "PositionChange")
                    {
                        if ((dep == search.Department || search.Department == null) && (faculty == search.Faculty || search.Faculty == null)
                            && DateComparator.FirstDateIsBiggerOrEqual(date, this_joinDate) &&
                                    DateComparator.FirstDateIsBiggerOrEqual(this_finishDate, finishdate))
                        {
                            if (dep == search.Department) dep = null;
                            if (faculty == search.Department) faculty = null;
                            scientists.Add(new ScientistNow
                            {
                                Position = pos,
                                Name = name,
                                Faculty = NullGetter.NullIfSecondIsNotNull(faculty, search.Faculty),
                                Department = NullGetter.NullIfSecondIsNotNull(dep, search.Department),
                            });
                        }
                    }
                }
            }
            return scientists;
        }
    }
}
