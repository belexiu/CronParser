using CronParser.UnitsOfMeasurement;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CronParser.Parsers
{
    public class AnyParser<T> : IAnyParser<T>
        where T : ICronUnitInfo
    {
        private readonly T _cronValueInfo;

        public AnyParser(T cronValueInfo)
        {
            _cronValueInfo = cronValueInfo;
        }

        public List<int> Parse(string expr)
        {
            if (_cronValueInfo.Min > _cronValueInfo.Max)
            {
                throw new Exception($"Min value greater than max for {typeof(T).Name}");
            }

            if (expr != "*")
            {
                return null;
            }

            return Enumerable
                .Range(_cronValueInfo.Min, _cronValueInfo.Max - _cronValueInfo.Min + 1)
                .ToList();
        }
    }
}
