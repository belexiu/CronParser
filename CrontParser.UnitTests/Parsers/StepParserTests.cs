using CronParser.Parsers;
using CronParser.UnitsOfMeasurement;
using FluentAssertions;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace CrontParser.UnitTests.Parsers
{
    public class StepParserTests
    {
        private readonly Mock<IValueParser<ICronUnitInfo>> _mockValueParser;

        private readonly Mock<IAnyParser<ICronUnitInfo>> _mockAnyParser;

        private readonly Mock<IRangeParser<ICronUnitInfo>> _mockRangeParser;

        private readonly IStepParser<ICronUnitInfo> _stepParser;

        public StepParserTests()
        {
            _mockValueParser = new Mock<IValueParser<ICronUnitInfo>>();

            _mockAnyParser = new Mock<IAnyParser<ICronUnitInfo>>();

            _mockRangeParser = new Mock<IRangeParser<ICronUnitInfo>>();

            _stepParser = new StepParser<ICronUnitInfo>(
                _mockValueParser.Object,
                _mockAnyParser.Object,
                _mockRangeParser.Object);
        }

        [Fact]
        public void Parse_ExprNull_ReturnsNull()
        {
            // Arrange
            string expr = null;

            // Act
            var result = _stepParser.Parse(expr);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void Parse_ExprDoesNotContainSlash_ReturnsNull()
        {
            // Arrange
            var expr = "123abc";

            // Act
            var result = _stepParser.Parse(expr);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void Parse_ExprContainsMultipleSlashes_ReturnsNull()
        {
            // Arrange
            var expr = "2/4/5";

            // Act
            var result = _stepParser.Parse(expr);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void Parse_LeftCannotBeParsed_ReturnsNull()
        {
            // Arrange
            var expr = "a/22";
            _mockAnyParser
                .Setup(parser => parser.Parse(It.Is<string>(x => x == "a")))
                .Returns((List<int>)null);
            _mockRangeParser
                .Setup(parser => parser.Parse(It.Is<string>(x => x == "a")))
                .Returns((List<int>)null);

            // Act
            var result = _stepParser.Parse(expr);

            // Assert
            Assert.Null(result);
            _mockValueParser.VerifyAll();
            _mockAnyParser.VerifyAll();
            _mockRangeParser.VerifyAll();
        }

        [Fact]
        public void Parse_RightCannotBeParsed_ReturnsNull()
        {
            // Arrange
            var expr = "22/a";
            _mockValueParser
                .Setup(parser => parser.Parse(It.Is<string>(x => x == "a")))
                .Returns((int?)null);

            // Act
            var result = _stepParser.Parse(expr);

            // Assert
            Assert.Null(result);
            _mockValueParser.VerifyAll();
            _mockAnyParser.VerifyAll();
            _mockRangeParser.VerifyAll();
        }

        [Fact]
        public void Parse_RightParsedToZero_ReturnsNull()
        {
            // Arrange
            var expr = "22/0";
            _mockValueParser
                .Setup(parser => parser.Parse(It.Is<string>(x => x == "0")))
                .Returns(0);

            // Act
            var result = _stepParser.Parse(expr);

            // Assert
            Assert.Null(result);
            _mockValueParser.VerifyAll();
        }

        [Fact]
        public void Parse_BothOperandsParseWithRange_ReturnsCorrectResult()
        {
            // Arrange
            var expr = "1-10/2";
            var expected = new List<int> {1, 3, 5, 7, 9 };
            _mockRangeParser
                .Setup(parser => parser.Parse(It.Is<string>(x => x == "1-10")))
                .Returns(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
            _mockValueParser
                .Setup(parser => parser.Parse(It.Is<string>(x => x == "2")))
                .Returns(2);

            // Act
            var result = _stepParser.Parse(expr);

            // Assert
            result.Should().BeEquivalentTo(expected);
            _mockValueParser.VerifyAll();
            _mockRangeParser.VerifyAll();
        }

        [Fact]
        public void Parse_BothOperandsParseWithAny_ReturnsCorrectResult()
        {
            // Arrange
            var expr = "*/2";
            var expected = new List<int> {1, 3, 5, 7, 9 };
            _mockAnyParser
                .Setup(parser => parser.Parse(It.Is<string>(x => x == "*")))
                .Returns(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
            _mockValueParser
                .Setup(parser => parser.Parse(It.Is<string>(x => x == "2")))
                .Returns(2);

            // Act
            var result = _stepParser.Parse(expr);

            // Assert
            result.Should().BeEquivalentTo(expected);
            _mockValueParser.VerifyAll();
            _mockRangeParser.VerifyAll();
        }
    }
}
