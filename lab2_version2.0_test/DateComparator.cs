namespace StaffGetter
{
    public class DateComparator
    {
        public static bool FirstDateIsBiggerOrEqual(string date1, string date2)
        {
            if (date1 == "now") return true;
            if (date2 == "now") return false;
            if (int.Parse(date1.Split('.')[2]) < int.Parse(date2.Split('.')[2])) return false;      //if the year is smaller, then tha date is smaller
            else if (int.Parse(date1.Split('.')[2]) == int.Parse(date2.Split('.')[2]))
            {
                if (int.Parse(date1.Split('.')[1]) < int.Parse(date2.Split('.')[1])) return false;
                else if (int.Parse(date1.Split('.')[1]) == int.Parse(date2.Split('.')[1]))
                {
                    if (int.Parse(date1.Split('.')[0]) < int.Parse(date2.Split('.')[0])) return false;
                }
            }
            return true;
        }
        public static bool FirstDateIsBigger(string date1, string date2)
        {
            if (FirstDateIsBiggerOrEqual(date1, date2) == true && FirstDateIsBiggerOrEqual(date2, date1) == false) return true;
            return false;
        }


    }
}
