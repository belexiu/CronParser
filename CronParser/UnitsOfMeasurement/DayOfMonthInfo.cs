using System.Collections.Generic;

namespace CronParser.UnitsOfMeasurement
{
    public class DayOfMonthInfo : IDayOfMonthInfo
    {
        public int Min => 1;

        public int Max => 31;

        public IDictionary<string, int> AlternativeNamings => new Dictionary<string, int>();
    }
}
