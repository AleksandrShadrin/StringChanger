using Shouldly;
using StringChanger.Application.StringTokenizer;

namespace StringChanger.Tests
{
    public class TokenizerTests
    {
        [Theory]
        [InlineData('.')]
        [InlineData('$')]
        [InlineData('_')]
        [InlineData('-')]
        [InlineData('\\')]
        public void Character_Should_Be_A_Token(char data)
        {
            // Act
            tokenizer.AddChar(data);

            // Assert
            tokenizer.IsToken().ShouldBeTrue();
        }
        [Theory]
        [InlineData("w5")]
        [InlineData("в5")]
        [InlineData("y8")]
        public void Digits_Should_Be_Separated_From_Letters(string data)
        {
            // Act
            tokenizer.AddChar(data[0]);
            tokenizer.AddChar(data[1]);

            // Assert
            tokenizer.IsToken().ShouldBeTrue();
        }
        [Theory]
        [InlineData("werwerwer")]
        [InlineData("qweqweq")]
        [InlineData("wqeqweqw")]
        public void String_Has_Not_Tokens(string data)
        {
            //Arrange
            bool result = false;
            tokenizer.Clear();

            // Act
            foreach (var sym in data)
            {
                tokenizer.AddChar(sym);
                result |= tokenizer.IsToken();
            }

            // Assert
            result.ShouldBeFalse();
        }
        #region ARRANGE
        private readonly ITokenizer tokenizer;
        public TokenizerTests()
        {
            tokenizer = new Tokenizer();
        }
        #endregion
    }
}
