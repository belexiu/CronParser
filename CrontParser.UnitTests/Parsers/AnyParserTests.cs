using CronParser.Parsers;
using CronParser.UnitsOfMeasurement;
using FluentAssertions;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace CrontParser.UnitTests.Parsers
{
    public class AnyParserTests
    {
        private readonly Mock<ICronUnitInfo> _mockCronValueInfo;

        private readonly IAnyParser<ICronUnitInfo> _anyParser;

        public AnyParserTests()
        {
            _mockCronValueInfo = new Mock<ICronUnitInfo>();

            _anyParser = new AnyParser<ICronUnitInfo>(_mockCronValueInfo.Object);
        }

        [Fact]
        public void Parse_ExprEmptyString_ReturnsNull()
        {
            // Arrange
            string expr = null;

            // Act
            var result = _anyParser.Parse(expr);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void Parse_ExprInvalidString_ReturnsNull()
        {
            // Arrange
            string expr = "*a";

            // Act
            var result = _anyParser.Parse(expr);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void Parse_ExprValid_ReturnsAllPosibleValues()
        {
            // Arrange
            var expr = "*";
            var expected = new List<int> { 1, 2, 3, 4 };
            _mockCronValueInfo.Setup(x => x.Min).Returns(1);
            _mockCronValueInfo.Setup(x => x.Max).Returns(4);

            // Act
            var result = _anyParser.Parse(expr);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }
    }
}
