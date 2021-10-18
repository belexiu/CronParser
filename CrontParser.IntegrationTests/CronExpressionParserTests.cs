using CronParser;
using CronParser.Parsers;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using FluentAssertions;

namespace CrontParser.IntegrationTests
{
    public class CronExpressionParserTests
    {
        private readonly IServiceProvider _sp = DependencyInjection.GetServiceProvider();

        [Fact]
        public void Parse_ValidInput_ReturnsCorrectResult()
        {
            // Arrange
            var expr = "*/15 0 1,15 * 1-5 /usr/bin/find";
            var expected = new CronExpressionParseResult
            {
                Minute = new List<int> { 0, 15, 30, 45 },
                Hour = new List<int> { 0 },
                DayOfMonth = new List<int> { 1, 15 },
                Month = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 },
                DayOfWeek = new List<int> { 1, 2, 3, 4, 5 },
                Command = "/usr/bin/find",
            };

            // Act
            var result = _sp.GetService<ICronExpressionParser>().Parse(expr);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }
    }
}
