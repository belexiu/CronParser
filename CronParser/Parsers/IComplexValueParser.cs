using CronParser.UnitsOfMeasurement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CronParser.Parsers
{
    public interface IComplexValueParser<TValue>
        where TValue : ICronUnitInfo
    {
        List<int> Parse(string expr);
    }
}
