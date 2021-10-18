using System.Collections.Generic;

namespace CronParser.UnitsOfMeasurement
{
    public class MinuteInfo : IMinuteInfo
    {
        public int Min => 0;

        public int Max => 59;

        public IDictionary<string, int> AlternativeNamings => new Dictionary<string, int>();
    }
}