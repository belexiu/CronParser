using CronParser.UnitsOfMeasurement;
using Xunit;

namespace CrontParser.UnitTests.UnitsOfMeasurement
{
    public class MinuteInfoTests
    {
        private readonly IMinuteInfo _minuteInfo = new MinuteInfo();

        [Fact]
        public void Min_Should_ReturnZero()
        {
            Assert.Equal(0, _minuteInfo.Min);
        }

        [Fact]
        public void Max_Should_ReturnZero()
        {
            Assert.Equal(59, _minuteInfo.Max);
        }

        [Fact]
        public void AlternativeNamings_Should_BeEmpty()
        {
            Assert.Equal(0, _minuteInfo.AlternativeNamings.Count);
        }
    }
}
