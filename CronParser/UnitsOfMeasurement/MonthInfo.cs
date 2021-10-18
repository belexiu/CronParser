using System.Collections.Generic;

namespace CronParser.UnitsOfMeasurement
{
    public class MonthInfo : IMonthInfo
    {
        public int Min => 1;

        public int Max => 12;

        public IDictionary<string, int> AlternativeNamings => new Dictionary<string, int>()
        {
            ["JAN"] = 1,
            ["FEB"] = 2,
            ["MAR"] = 3,
            ["APR"] = 4,
            ["MAY"] = 5,
            ["JUN"] = 6,
            ["JUL"] = 7,
            ["AUG"] = 8,
            ["SEP"] = 9,
            ["OCT"] = 10,
            ["NOV"] = 11,
            ["DEC"] = 12
        };
    }
}
