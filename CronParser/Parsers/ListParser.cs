using CronParser.UnitsOfMeasurement;
using System.Collections.Generic;
using System.Linq;

namespace CronParser.Parsers
{
    public class ListParser<T> : IListParser<T>
        where T : ICronUnitInfo
    {
        private readonly IComplexValueParser<T> _complexValueParser;

        public ListParser(IComplexValueParser<T> complexValueParser)
        {
            _complexValueParser = complexValueParser;
        }

        public List<int> Parse(string expr)
        {
            if (string.IsNullOrEmpty(expr))
            {
                return null;
            }

            var items = expr.Split(',');
            
            var values = items
                .Select(x => _complexValueParser.Parse(x))
                .ToList();

            if (values.Any(x => x == null))
            {
                return null;
            }

            var result = values
                .SelectMany(x => x)
                .Distinct()
                .OrderBy(x => x)
                .ToList();

            return result;
        }
    }
}
