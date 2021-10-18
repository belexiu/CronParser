using System.Collections.Generic;

namespace CronParser.UnitsOfMeasurement
{
    public class HourInfo : IHourInfo
    {
        public int Min => 0;

        public int Max => 23;

        public IDictionary<string, int> AlternativeNamings => new Dictionary<string, int>();
    }
}
