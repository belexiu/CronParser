using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CronParser.Parsers
{
    public interface ICronExpressionParser
    {
        CronExpressionParseResult Parse(string expr);
    }
}
