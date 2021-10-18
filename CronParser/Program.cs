using CronParser.Parsers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CronParser
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("error: program should have one string argument that contains the cron expressions and the command to run");
                return;
            }
            
            var sp = DependencyInjection.GetServiceProvider();

            var cronParser = sp.GetService<ICronExpressionParser>();

            var result = cronParser.Parse(args[0]);

            if (result.Errors.Any())
            {
                Console.WriteLine(string.Join('\n', result.Errors));
                return;
            }


            var printLabelsAndValues = new List<(string label, string value)>
            {
                ("minute", CronValuesToString(result.Minute)),
                ("hour",  CronValuesToString(result.Hour)),
                ("day of month",  CronValuesToString(result.DayOfMonth)),
                ("month",  CronValuesToString(result.Month)),
                ("day of week",  CronValuesToString(result.DayOfWeek)),
                ("command", result.Command)
            };

            foreach (var (label, value) in printLabelsAndValues)
            {
                Console.WriteLine($"{label,-14} {value}");
            }
        }

        public static string CronValuesToString(IList<int> values)
        {
            return string.Join(' ', values);
        }
    }
}
