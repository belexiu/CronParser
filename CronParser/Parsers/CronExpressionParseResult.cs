using System.Collections.Generic;

namespace CronParser.Parsers
{
    public class CronExpressionParseResult
    {
        public IList<int> Minute { get; set; } = new List<int>();

        public IList<int> Hour { get; set; } = new List<int>();

        public IList<int> DayOfMonth { get; set; } = new List<int>();

        public IList<int> Month { get; set; } = new List<int>();

        public IList<int> DayOfWeek { get; set; } = new List<int>();

        public string Command { get; set; }

        public IList<string> Errors { get; set; } = new List<string>();
    }
}
