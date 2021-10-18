using CronParser.Parsers;
using CronParser.UnitsOfMeasurement;
using FluentAssertions;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace CrontParser.UnitTests.Parsers
{
    public class RangeParserTests
    {
        private readonly Mock<ICronUnitInfo> _mockCronValueInfo;

        private readonly Mock<IValueParser<ICronUnitInfo>> _valueParser;

        private readonly IRangeParser<ICronUnitInfo> _anyParser;

        public RangeParserTests()
        {
            _mockCronValueInfo = new Mock<ICronUnitInfo>();

            _valueParser = new Mock<IValueParser<ICronUnitInfo>>();

            _anyParser = new RangeParser<ICronUnitInfo>(
                _mockCronValueInfo.Object, 
                _valueParser.Object);
        }

        [Fact]
        public void Parse_ExprNull_ReturnsNull()
        {
            // Arrange
            string expr = null;

            // Act
            var result = _anyParser.Parse(expr);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void Parse_ExprDoesNotContainDash_ReturnsNull()
        {
            // Arrange
            var expr = "123abc";

            // Act
            var result = _anyParser.Parse(expr);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void Parse_ExprContainsMultipleDashes_ReturnsNull()
        {
            // Arrange
            var expr = "2-4-5";

            // Act
            var result = _anyParser.Parse(expr);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void Parse_FromCannotBeParsed_ReturnsNull()
        {
            // Arrange
            var expr = "a-22";
            _valueParser
                .Setup(parser => parser.Parse(It.Is<string>(x => x == "a")))
                .Returns((int?)null);

            // Act
            var result = _anyParser.Parse(expr);

            // Assert
            Assert.Null(result);
            _valueParser.VerifyAll();
        }

        [Fact]
        public void Parse_ToCannotBeParsed_ReturnsNull()
        {
            // Arrange
            var expr = "22-b";
            _valueParser
                .Setup(parser => parser.Parse(It.Is<string>(x => x == "b")))
                .Returns((int?)null);
            // Act
            var result = _anyParser.Parse(expr);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void Parse_FromGreaterThanTo_ReturnsNull()
        {
            // Arrange
            var expr = "44-22";
            _valueParser
                .Setup(parser => parser.Parse(It.Is<string>(x => x == "22")))
                .Returns(22);
            _valueParser
                .Setup(parser => parser.Parse(It.Is<string>(x => x == "44")))
                .Returns(44);

            // Act
            var result = _anyParser.Parse(expr);

            // Assert
            Assert.Null(result);
            _valueParser.VerifyAll();
        }

        [Fact]
        public void Parse_ToEqualFrom_ReturnsCorrectResult()
        {
            // Arrange
            var expr = "22-22";
            var expected = new List<int> { 22 };
            _valueParser
                .Setup(parser => parser.Parse(It.Is<string>(x => x == "22")))
                .Returns(22);

            // Act
            var result = _anyParser.Parse(expr);

            // Assert
            result.Should().BeEquivalentTo(expected);
            _valueParser.VerifyAll();
        }

        [Fact]
        public void Parse_ToAndFromValid_ReturnsCorrectResult()
        {
            // Arrange
            var expr = "22-25";
            var expected = new List<int> { 22, 23, 24, 25 };
            _valueParser
                .Setup(parser => parser.Parse(It.Is<string>(x => x == "22")))
                .Returns(22);
            _valueParser
                .Setup(parser => parser.Parse(It.Is<string>(x => x == "25")))
                .Returns(25);

            // Act
            var result = _anyParser.Parse(expr);

            // Assert
            result.Should().BeEquivalentTo(expected);            
            _valueParser.VerifyAll();
        }
    }
}
