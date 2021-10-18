using CronParser.UnitsOfMeasurement;
using Xunit;

namespace CrontParser.UnitTests.UnitsOfMeasurement
{
    public class HourInfoTests
    {
        private readonly IHourInfo _hourInfo = new HourInfo();

        [Fact]
        public void Min_Should_ReturnZero()
        {
            Assert.Equal(0, _hourInfo.Min);
        }

        [Fact]
        public void Max_Should_ReturnZero()
        {
            Assert.Equal(23, _hourInfo.Max);
        }

        [Fact]
        public void AlternativeNamings_Should_BeEmpty()
        {
            Assert.Equal(0, _hourInfo.AlternativeNamings.Count);
        }
    }
}
