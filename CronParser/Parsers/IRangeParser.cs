using CronParser.UnitsOfMeasurement;
using System.Collections.Generic;

namespace CronParser.Parsers
{
    public interface IRangeParser<TValue>
        where TValue : ICronUnitInfo
    {
        List<int> Parse(string expr);
    }
}
