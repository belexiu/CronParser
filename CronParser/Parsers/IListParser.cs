using CronParser.UnitsOfMeasurement;
using System.Collections.Generic;

namespace CronParser.Parsers
{
    public interface IListParser<TValue>
        where TValue : ICronUnitInfo
    {
        List<int> Parse(string expr);
    }
}
