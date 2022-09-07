
using NSubstitute;
using Shouldly;
using StringChanger.Application.StringSplitter;
using StringChanger.Application.StringTokenizer;

namespace StringChanger.Tests
{
    public class StringSplitterTests
    {
        [Fact]
        public void String_Should_Be_Splitted_On_Four_Words()
        {
            // Arrange
            string line = "один два три четыре";
            tokenizer.GetTokens().Returns(new Dictionary<int, string>
            {
                {4, "Split"},
                {8, "Split"},
                {12, "Split"},
            });
            // Act
            var result = stringSplitter.Split(line).ToArray().First().Words;

            // Assert
            result.ShouldContain("один");
            result.ShouldContain("два");
            result.ShouldContain("три");
            result.ShouldContain("четыре");
        }

        #region ARRANGE
        private readonly IStringSplitter stringSplitter;
        private readonly ITokenizer tokenizer;
        public StringSplitterTests()
        {
            tokenizer = Substitute.For<ITokenizer>();
            stringSplitter = new StringSplitter(tokenizer);
        }
        #endregion
    }
}
