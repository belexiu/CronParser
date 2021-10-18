using CronParser.Parsers;
using CronParser.UnitsOfMeasurement;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CronParser
{
    public static class DependencyInjection
    {
        public static IServiceProvider GetServiceProvider()
        {
            return new ServiceCollection()
                .AddSingleton<IMinuteInfo, MinuteInfo>()
                .AddSingleton<IHourInfo, HourInfo>()
                .AddSingleton<IDayOfMonthInfo, DayOfMonthInfo>()
                .AddSingleton<IMonthInfo, MonthInfo>()
                .AddSingleton<IDayOfWeekInfo, DayOfWeekInfo>()
                .AddSingleton(typeof(IValueParser<>), typeof(ValueParser<>))
                .AddSingleton(typeof(IAnyParser<>), typeof(AnyParser<>))
                .AddSingleton(typeof(IRangeParser<>), typeof(RangeParser<>))
                .AddSingleton(typeof(IStepParser<>), typeof(StepParser<>))
                .AddSingleton(typeof(IComplexValueParser<>), typeof(ComplexValueParser<>))
                .AddSingleton(typeof(IListParser<>), typeof(ListParser<>))
                .AddSingleton<ICronExpressionParser, CronExpressionParser>()
                .BuildServiceProvider();
        }
    }
}
