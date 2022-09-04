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

            // Act
            var result = stringSplitter.Split(line).ToArray();

            // Assert
            result.ShouldBeEquivalentTo(new string[] {"один", " два", " три", " четыре" });
        }

        #region ARRANGE
        private readonly IStringSplitter stringSplitter;
        public StringSplitterTests()
        {
            ITokenizer tokenizer = Substitute.For<ITokenizer>();
            tokenizer
                .When(x => x.AddChar(Arg.Is<char>(a => a == ' ')))
                .Do( x => tokenizer.IsToken().Returns(true));

            tokenizer
                .When(x => x.AddChar(Arg.Is<char>(a => a != ' ')))
                .Do(x => tokenizer.IsToken().Returns(false));

            stringSplitter = new StringSplitter(tokenizer);
        }
        #endregion
    }
}
