using CronParser.Parsers;
using CronParser.UnitsOfMeasurement;
using FluentAssertions;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace CrontParser.UnitTests.Parsers
{
    public class ComplexValueParserTests
    {
        private readonly Mock<IValueParser<ICronUnitInfo>> _mockValueParser;

        private readonly Mock<IAnyParser<ICronUnitInfo>> _mockAnyParser;

        private readonly Mock<IRangeParser<ICronUnitInfo>> _mockRangeParser;

        private readonly Mock<IStepParser<ICronUnitInfo>> _mockStepParser;

        private readonly IComplexValueParser<ICronUnitInfo> _complexValueParser;

        public ComplexValueParserTests()
        {
            _mockValueParser = new Mock<IValueParser<ICronUnitInfo>>();

            _mockAnyParser = new Mock<IAnyParser<ICronUnitInfo>>();

            _mockRangeParser = new Mock<IRangeParser<ICronUnitInfo>>();

            _mockStepParser = new Mock<IStepParser<ICronUnitInfo>>();

            _complexValueParser = new ComplexValueParser<ICronUnitInfo>(
                _mockValueParser.Object,
                _mockAnyParser.Object,
                _mockRangeParser.Object,
                _mockStepParser.Object);
        }

        [Fact]
        public void Parse_ExprNull_ReturnsNull()
        {
            // Arrange
            string expr = null;

            // Act
            var result = _complexValueParser.Parse(expr);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void Parse_NestedParsersReuturnNull_ReturnsNull()
        {
            // Arrange
            string expr = null;

            // Act
            var result = _complexValueParser.Parse(expr);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void Parse_AnyParserSuccess_ReturnsCorrectResult()
        {
            // Arrange
            var expr = "22";
            var expected = new List<int> { 22 };
            _mockAnyParser
                .Setup(parser => parser.Parse(expr))
                .Returns(expected);

            // Act
            var result = _complexValueParser.Parse(expr);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Parse_ValueParserSuccess_ReturnsCorrectResult()
        {
            // Arrange
            var expr = "22";
            var expected = new List<int> { 22 };
            _mockValueParser
                .Setup(parser => parser.Parse(expr))
                .Returns(22);

            // Act
            var result = _complexValueParser.Parse(expr);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Parse_RangeParserSuccess_ReturnsCorrectResult()
        {
            // Arrange
            var expr = "22-24";
            var expected = new List<int> { 22, 23, 24 };
            _mockRangeParser
                .Setup(parser => parser.Parse(expr))
                .Returns(expected);

            // Act
            var result = _complexValueParser.Parse(expr);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Parse_StepParserSuccess_ReturnsCorrectResult()
        {
            // Arrange
            var expr = "10-20/3";
            var expected = new List<int> { 13, 16, 19 };
            _mockRangeParser
                .Setup(parser => parser.Parse(expr))
                .Returns(expected);

            // Act
            var result = _complexValueParser.Parse(expr);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }
    }
}
