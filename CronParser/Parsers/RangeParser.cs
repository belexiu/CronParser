using CronParser.UnitsOfMeasurement;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CronParser.Parsers
{
    public class RangeParser<T> : IRangeParser<T>
        where T : ICronUnitInfo
    {
        private readonly T _cronValueInfo;
        private readonly IValueParser<T> _valueParser;

        public RangeParser(T cronValueInfo, IValueParser<T> valueParser )
        {
            _cronValueInfo = cronValueInfo;
            _valueParser = valueParser;
        }
        public List<int> Parse(string expr)
        {
            if (string.IsNullOrEmpty(expr))
            {
                return null;
            }

            var ops = expr.Split('-');
            if (ops.Length != 2)
            {
                return null;
            }

            var (left, right) = (ops[0], ops[1]);

            var from = _valueParser.Parse(left);
            var to = _valueParser.Parse(right);

            if (from == null || to == null || from > to)
            {
                return null;
            }

            return Enumerable
                .Range(from.Value, to.Value - from.Value + 1)
                .ToList();
        }
    }
}
