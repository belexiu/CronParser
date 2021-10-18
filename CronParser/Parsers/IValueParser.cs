using CronParser.UnitsOfMeasurement;

namespace CronParser.Parsers
{
    public interface IValueParser<TValue> 
        where TValue : ICronUnitInfo
    {
        int? Parse(string expr);
    }
}
