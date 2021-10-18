using System.Collections.Generic;

namespace CronParser.UnitsOfMeasurement
{
    public class DayOfWeekInfo : IDayOfWeekInfo
    {
        public int Min => 0;

        public int Max => 6;

        public IDictionary<string, int> AlternativeNamings => new Dictionary<string, int>
        {
            ["SUN"] = 0,
            ["MON"] = 1,
            ["TUE"] = 2,
            ["WED"] = 3,
            ["THU"] = 4,
            ["FRI"] = 5,
            ["SAT"] = 6
        };
    }
}
