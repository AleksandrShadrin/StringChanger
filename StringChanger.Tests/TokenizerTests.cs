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
            tokenizer.CheckCharWithPosition(data, 0);

            // Assert
            tokenizer.GetTokens().Count.ShouldBe(1);
        }
        [Theory]
        [InlineData("w5")]
        [InlineData("в5")]
        [InlineData("y8")]
        public void Digits_Should_Be_Separated_From_Letters(string data)
        {
            // Act


            // Assert

        }
        [Theory]
        [InlineData("werwerwer")]
        [InlineData("qweqweq")]
        [InlineData("wqeqweqw")]
        public void String_Has_Not_Tokens(string data)
        {
            //Arrange
            tokenizer.Clear();

            // Act
            for (int i = 0; i < data.Length; i++)
            {
                tokenizer.CheckCharWithPosition(data[i], i);
            }

            // Assert
            tokenizer.GetTokens().Count.ShouldBe(0);
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
