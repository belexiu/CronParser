using CronParser.UnitsOfMeasurement;

namespace CronParser.Parsers
{
    public class ValueParser<T> : IValueParser<T>
        where T : ICronUnitInfo
    {
        private readonly T _cronValueInfo;

        public ValueParser(T cronValueInfo)
        {
            _cronValueInfo = cronValueInfo;
        }

        public int? Parse(string expr)
        {
            if (string.IsNullOrEmpty(expr))
            {
                return null;
            }

            var parseSuccessful = int.TryParse(expr, out var exprAsInt);
            if (parseSuccessful && _cronValueInfo.Min <= exprAsInt && exprAsInt <= _cronValueInfo.Max)
            {
                return exprAsInt;
            }

            if (_cronValueInfo.AlternativeNamings.ContainsKey(expr.ToUpper()))
            {
                return _cronValueInfo.AlternativeNamings[expr.ToUpper()];
            }

            return null;
        }
    }
}
