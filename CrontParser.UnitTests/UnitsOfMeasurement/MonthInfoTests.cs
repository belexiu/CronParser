using CronParser.UnitsOfMeasurement;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace CrontParser.UnitTests.UnitsOfMeasurement
{
    public class MonthInfoTests
    {
        private readonly IMonthInfo _monthInfo = new MonthInfo();

        [Fact]
        public void Min_Should_ReturnZero()
        {
            Assert.Equal(1, _monthInfo.Min);
        }

        [Fact]
        public void Max_Should_ReturnZero()
        {
            Assert.Equal(12, _monthInfo.Max);
        }

        [Fact]
        public void AlternativeNamings_Should_HaveRelevantValues()
        {
            var expected = new Dictionary<string, int>()
            {
                ["JAN"] = 1,
                ["FEB"] = 2,
                ["MAR"] = 3,
                ["APR"] = 4,
                ["MAY"] = 5,
                ["JUN"] = 6,
                ["JUL"] = 7,
                ["AUG"] = 8,
                ["SEP"] = 9,
                ["OCT"] = 10,
                ["NOV"] = 11,
                ["DEC"] = 12
            };

            _monthInfo.AlternativeNamings.Should().BeEquivalentTo(expected);
        }
    }
}
