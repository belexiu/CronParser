using CronParser.Parsers;
using CronParser.UnitsOfMeasurement;
using FluentAssertions;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace CrontParser.UnitTests.Parsers
{
    public class ListParserTests
    {
        private readonly Mock<IComplexValueParser<ICronUnitInfo>> _mockComplexValueParser;

        private readonly IListParser<ICronUnitInfo> _listParser;

        public ListParserTests()
        {
            _mockComplexValueParser = new Mock<IComplexValueParser<ICronUnitInfo>>();

            _listParser = new ListParser<ICronUnitInfo>(_mockComplexValueParser.Object);
        }

        [Fact]
        public void Parse_ExprEmptyString_ReturnsNull()
        {
            // Arrange
            string expr = null;

            // Act
            var result = _listParser.Parse(expr);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void Parse_NestedParserReturnsNullForSingleValue_ReturnsNull()
        {
            // Arrange
            string expr = "asdf";
            
            // Act
            var result = _listParser.Parse(expr);

            // Assert
            Assert.Null(result);
        }


        [Fact]
        public void Parse_ExprHasOneValue_ReturnsCorrectResult()
        {
            // Arrange
            string expr = "23";
            var expected = new List<int> { 23 };
            _mockComplexValueParser
                .Setup(parser => parser.Parse(It.Is<string>(x => x == expr)))
                .Returns(expected);

            // Act
            var result = _listParser.Parse(expr);

            // Assert
            result.Should().BeEquivalentTo(expected);
            _mockComplexValueParser.VerifyAll();
        }

        [Fact]
        public void Parse_ExprHasMultipleValue_ReturnsCorrectResult()
        {
            // Arrange
            string expr = "23,25-27";
            var expected = new List<int> { 23, 25, 26, 27 };
            _mockComplexValueParser
                .Setup(parser => parser.Parse(It.Is<string>(x => x == "23")))
                .Returns(new List<int> { 23 });
            _mockComplexValueParser
                .Setup(parser => parser.Parse(It.Is<string>(x => x == "25-27")))
                .Returns(new List<int> { 25, 26, 27 });

            // Act
            var result = _listParser.Parse(expr);

            // Assert
            result.Should().BeEquivalentTo(expected);
            _mockComplexValueParser.VerifyAll();
        }

        [Fact]
        public void Parse_ExprHasMultipleValueOneFails_ReturnsNull()
        {
            // Arrange
            string expr = "26,ab";
            _mockComplexValueParser
                .Setup(parser => parser.Parse(It.Is<string>(x => x == "26")))
                .Returns(new List<int> { 26 });
            _mockComplexValueParser
               .Setup(parser => parser.Parse(It.Is<string>(x => x == "ab")))
               .Returns((List<int>)null);

            // Act
            var result = _listParser.Parse(expr);

            // Assert
            Assert.Null(result);
        }
    }
}
