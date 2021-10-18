using CronParser.UnitsOfMeasurement;
using System.Collections.Generic;
using System.Linq;

namespace CronParser.Parsers
{
    public class StepParser<T> : IStepParser<T>
        where T: ICronUnitInfo
    {
        private readonly IValueParser<T> _valueParser;
        private readonly IAnyParser<T> _anyParser;
        private readonly IRangeParser<T> _rangeParser;

        public StepParser(
            IValueParser<T> valueParser,
            IAnyParser<T> anyParser,
            IRangeParser<T> rangeParser)
        {
            _valueParser = valueParser;
            _anyParser = anyParser;
            _rangeParser = rangeParser;
        }

        public List<int> Parse(string expr)
        {
            if (string.IsNullOrEmpty(expr))
            {
                return null;
            }

            var ops = expr.Split('/');
            if (ops.Length != 2)
            {
                return null;
            }

            var (left, right) = (ops[0], ops[1]);

            var valuesToStep = _anyParser.Parse(left) ?? _rangeParser.Parse(left);
            var step = _valueParser.Parse(right);

            if (valuesToStep == null || step == null || step == 0)
            {
                return null;
            }

            var result = valuesToStep
                .Where((x, index) => index % step == 0)
                .ToList();


            return result;
        }
    }
}
