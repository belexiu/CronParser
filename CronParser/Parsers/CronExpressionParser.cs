using CronParser.UnitsOfMeasurement;

namespace CronParser.Parsers
{
    public class CronExpressionParser : ICronExpressionParser
    {
        private readonly IListParser<IMinuteInfo> _minuteListParser;
        private readonly IListParser<IHourInfo> _hourListParser;
        private readonly IListParser<IDayOfMonthInfo> _dayOfMonthListParser;
        private readonly IListParser<IMonthInfo> _monthListParser;
        private readonly IListParser<IDayOfWeekInfo> _dayOfWeekParser;

        public CronExpressionParser(
            IListParser<IMinuteInfo> minuteListParser,
            IListParser<IHourInfo> hourListParser,
            IListParser<IDayOfMonthInfo> dayOfMonthListParser,
            IListParser<IMonthInfo> monthListParser,
            IListParser<IDayOfWeekInfo> dayOfWeekParser)
        {
            _minuteListParser = minuteListParser;
            _hourListParser = hourListParser;
            _dayOfMonthListParser = dayOfMonthListParser;
            _monthListParser = monthListParser;
            _dayOfWeekParser = dayOfWeekParser;
        }

        public CronExpressionParseResult Parse(string expr)
        {
            var result = new CronExpressionParseResult();

            if (string.IsNullOrEmpty(expr))
            {
                result.Errors.Add("Could not parse expression, it is null or empty.");
                return result;
            }

            var items = expr.Split(' ');
            if (items.Length != 6)
            {
                result.Errors.Add("Could not parse expression, it must have 6 elements separated by space");
                return result;
            }

            var (minute, hour, dayOfMonth, month, dayOfWeek, command) = (items[0], items[1], items[2], items[3], items[4], items[5]);

            result.Minute = _minuteListParser.Parse(minute);
            result.Hour = _hourListParser.Parse(hour);
            result.DayOfMonth = _dayOfMonthListParser.Parse(dayOfMonth);
            result.Month = _monthListParser.Parse(month);
            result.DayOfWeek = _dayOfWeekParser.Parse(dayOfWeek);
            result.Command = command;

            if (result.Minute == null)
            {
                result.Errors.Add($"minute could not be parsed, expr = {minute}");
            }
            if (result.Hour == null)
            {
                result.Errors.Add($"hour could not be parsed, expr = {hour}");
            }
            if (result.DayOfMonth == null)
            {
                result.Errors.Add($"day of month could not be parsed, expr = {dayOfMonth}");
            }
            if (result.Month == null)
            {
                result.Errors.Add($"month could not be parsed, expr = {month}");
            }
            if (result.DayOfWeek == null)
            {
                result.Errors.Add($"day of week could not be parsed, expr = {dayOfWeek}");
            }

            return result;
        }
    }
}
