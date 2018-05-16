using System;
using Xunit;

namespace BracketMatcher.Tests
{
    public class BracketMatcherTests
    {
        BracketMatcher sub = new BracketMatcher();

        [Fact]
        public void WhenEmptyString_Return0()
        {
            //Given
            var expected = 0;

            //When
            var actual = sub.Match("");

            //Then
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("()")]
        [InlineData("[]")]
        [InlineData("{}")]
        public void WhenStringIsBrackets_Return0(string str)
        {
            //Given
            var excepted = 0;

            //When
            var actual = sub.Match(str);

            //Then
            Assert.Equal(excepted, actual);
        }

        [Theory]
        [InlineData("0(1", 1)]
        [InlineData("(", 0)]
        public void WhenMissMatchOpenRoundBracket_ReturnIndexOfOpenBracket(string str, int exceptedIndex)
        {
            //Given
            var expected = exceptedIndex;

            //When
            var actual = sub.Match(str);

            //Then
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("0[1", 1)]
        [InlineData("[", 0)]
        public void WhenMissMatchOpenSquarBracket_ReturnIndexOfOpenBracket(string str, int exceptedIndex)
        {
            //Given
            var expected = exceptedIndex;

            //When
            var actual = sub.Match(str);

            //Then
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("0{1", 1)]
        [InlineData("{", 0)]
        public void WhenMissMatchOpenCurlyBracket_ReturnIndexOfOpenBracket(string str, int exceptedIndex)
        {
            //Given
            var expected = exceptedIndex;

            //When
            var actual = sub.Match(str);

            //Then
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("09)", 2)]
        [InlineData("09))", 2)]
        [InlineData(")", 0)]
        public void WhenMissClosedRoundBracket_ReturnIndexOfClosedBrackets(string str, int expected)
        {
            //Given
            //When
            var actual = sub.Match(str);
            //Then
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WhenMissClosedRoundThenSquareBracket_ReturnIndexOfRoundBracket()
        {
            //Given
            var expected = 2;
            var actual = sub.Match("01)34]");
            //When

            //Then
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("01()23[]34{}")]
        [InlineData("01(23[45])67{}")]
        [InlineData("{01[23(45)6]}")]
        public void WhenMatchedBrackets_Return0(string str)
        {
            //Given
            var expected = 0;
            var actual = sub.Match(str);
            //When

            //Then
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WhenMixedBrackets_ReturnIndexOfFirstMissed()
        {
        //Given
        var expected = 4;
        var actual = sub.Match("012([)]");
        //When
        
        //Then
        Assert.Equal(expected,actual);
        }
    }
}
