
using NSubstitute;
using Shouldly;
using StringChanger.Application.StringSplitter;
using StringChanger.Application.StringTokenizer;

namespace StringChanger.Tests
{
    public class StringSplitterTests
    {
        [Fact]
        public void StringSplitter_Should_Return_Three_Sentences()
        {
            // Arrange
            string data = "привет. пока! привет?";
            tokenizer.GetTokens().Returns(new Dictionary<int, string>
            {
                {6, "End"},
                {7, "Split"},
                {12, "End"},
                {13, "Split"},
                {20, "End"},
            });
            // Act
            var result = stringSplitter.Split(data)
                .Where(s
                    => !String.IsNullOrWhiteSpace(String.Join("", s.Words)))
                .Select(s =>
                {
                    s.Words = s.Words
                        .Where(w => !String.IsNullOrWhiteSpace(w))
                        .ToList();
                    return s;
                })
                .ToList();

            // Assert
            result.Count.ShouldBe(3);
            result[0].Words.ToArray().ShouldBeEquivalentTo(new string[] { "привет", "." });
            result[1].Words.ToArray().ShouldBeEquivalentTo(new string[] { "пока", "!" });
            result[2].Words.ToArray().ShouldBeEquivalentTo(new string[] { "привет", "?" });
        }

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
