using CronParser.UnitsOfMeasurement;
using Xunit;

namespace CrontParser.UnitTests.UnitsOfMeasurement
{
    public class DayOfMonthInfoTests
    {
        private readonly IDayOfMonthInfo _dayOfMonthInfo = new DayOfMonthInfo();

        [Fact]
        public void Min_Should_ReturnZero()
        {
            Assert.Equal(1, _dayOfMonthInfo.Min);
        }

        [Fact]
        public void Max_Should_ReturnZero()
        {
            Assert.Equal(31, _dayOfMonthInfo.Max);
        }

        [Fact]
        public void AlternativeNamings_Should_BeEmpty()
        {
            Assert.Equal(0, _dayOfMonthInfo.AlternativeNamings.Count);
        }
    }
}
