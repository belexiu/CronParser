using CronParser.UnitsOfMeasurement;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace CrontParser.UnitTests.UnitsOfMeasurement
{
    public class DayOfWeekInfoTests
    {
        private readonly IDayOfWeekInfo _dayOfWeekInfo = new DayOfWeekInfo();

        [Fact]
        public void Min_Should_ReturnZero()
        {
            Assert.Equal(0, _dayOfWeekInfo.Min);
        }

        [Fact]
        public void Max_Should_ReturnZero()
        {
            Assert.Equal(6, _dayOfWeekInfo.Max);
        }

        [Fact]
        public void AlternativeNamings_Should_HaveRelevantValues()
        {
            var expected = new Dictionary<string, int>()
            {
                ["SUN"] = 0,
                ["MON"] = 1,
                ["TUE"] = 2,
                ["WED"] = 3,
                ["THU"] = 4,
                ["FRI"] = 5,
                ["SAT"] = 6,
            };

            _dayOfWeekInfo.AlternativeNamings.Should().BeEquivalentTo(expected);
        }
    }
}
