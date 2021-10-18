using CronParser.UnitsOfMeasurement;
using System.Collections.Generic;

namespace CronParser.Parsers
{
    public interface IStepParser<TValue>
        where TValue : ICronUnitInfo
    {
        List<int> Parse(string expr);
    }
}
