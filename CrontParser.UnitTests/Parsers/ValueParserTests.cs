using CronParser.Parsers;
using CronParser.UnitsOfMeasurement;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace CrontParser.UnitTests.Parsers
{
    public class ValueParserTests
    {

        private readonly Mock<ICronUnitInfo> _mockCronValueInfo;
        
        private readonly IValueParser<ICronUnitInfo> _valueParser;

        public ValueParserTests()
        {
            _mockCronValueInfo = new Mock<ICronUnitInfo>();

            _valueParser = new ValueParser<ICronUnitInfo>(_mockCronValueInfo.Object);

            _mockCronValueInfo.Setup(x => x.Min).Returns(1);
            _mockCronValueInfo.Setup(x => x.Max).Returns(4);
            _mockCronValueInfo.Setup(x => x.AlternativeNamings)
                .Returns(new Dictionary<string, int>
                {
                    ["ONE"] = 1,
                    ["TwO"] = 2
                });
        }

        [Fact]
        public void Parse_ExprNullString_ReturnsNull()
        {
            string input = null;

            var result = _valueParser.Parse(input);

            Assert.Null(result);
        }

        [Fact]
        public void Parse_ExprLessThanMin_ReturnsNull()
        {
            // Arrange
            string input = "0";

            // Act
            var result = _valueParser.Parse(input);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void Parse_ExprGreaterThanMax_ReturnsNull()
        {
            // Arrange
            string input = "5";

            // Act
            var result = _valueParser.Parse(input);

            // Assert
            Assert.Null(result);
        }


        [Fact]
        public void Parse_ExprInvalidString_ReturnsNull()
        {
            // Arrange
            string input = "asdf";

            // Act
            var result = _valueParser.Parse(input);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void Parse_ExprInsideRange_ReturnsCorrectValue()
        {
            // Arrange
            var input = "2";
            var expected = 2;

            // Act
            var result = _valueParser.Parse(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Parse_ExprMinimumValue_ReturnsCorrectValue()
        {
            // Arrange
            var input = "1";
            var expected = 1;

            // Act
            var result = _valueParser.Parse(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Parse_ExprMaximumValue_ReturnsCorrectValue()
        {
            // Arrange
            var input = "4";
            var expected = 4;

            // Act
            var result = _valueParser.Parse(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Parse_ExprInAlternativeNamings_ReturnsCorrectValue()
        {
            // Arrange
            var input = "onE";
            var expected = 1;

            // Act
            var result = _valueParser.Parse(input);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
