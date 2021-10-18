using CronParser.UnitsOfMeasurement;
using System.Collections.Generic;

namespace CronParser.Parsers
{
    public class ComplexValueParser<T> : IComplexValueParser<T>
        where T : ICronUnitInfo
    {
        private readonly IValueParser<T> _valueParser;
        private readonly IAnyParser<T> _anyParser;
        private readonly IRangeParser<T> _rangeParser;
        private readonly IStepParser<T> _stepParser;

        public ComplexValueParser(
            IValueParser<T> valueParser,
            IAnyParser<T> anyParser,
            IRangeParser<T> rangeParser,
            IStepParser<T> stepParser)
        {
            _valueParser = valueParser;
            _anyParser = anyParser;
            _rangeParser = rangeParser;
            _stepParser = stepParser;
        }

        public List<int> Parse(string expr)
        {
            if (string.IsNullOrEmpty(expr))
            {
                return null;
            }

            var simpleValue = _valueParser.Parse(expr);
            if (simpleValue != null)
            {
                return new List<int> { simpleValue.Value };
            }

            return _anyParser.Parse(expr)
                    ?? _rangeParser.Parse(expr)
                    ?? _stepParser.Parse(expr);
        }
    }
}
