using NSubstitute;
using Shouldly;
using StringChanger.Application.StringPreprocessor;
using StringChanger.Application.StringSplitter;

namespace StringChanger.Tests
{
    public class StringPreprocessorTests
    {
        [Fact]
        public void StringPreprocessor_Should_Not_Change_String()
        {
            // Arrange
            string data = "один два три четыре !";
            _stringSplitter.Split(Arg.Any<string>()).Returns(new List<string> { "один", " два", " три", " четыре", " !" });

            // Act
            _stringPreprocessor.Process(data);
            var result = _stringPreprocessor.GetProcessedString();

            // Assert
            result.ShouldBe("один два три четыре !");
        }

        [Fact]
        public void StringPreprocessor_Should_Change_String()
        {
            // Arrange
            string data = "приветствие_слово_432423";
            _stringSplitter.Split(Arg.Any<string>()).Returns(new List<string> { "приветствие", "_", "слово", "_", "432423"});

            // Act
            _stringPreprocessor.Process(data);
            var result = _stringPreprocessor.GetProcessedString();

            // Assert
            result.ShouldBe("преветствии _ слово _ 432423");
        }

        #region ARRANGE
        private readonly IStringPreprocessor _stringPreprocessor;
        private readonly IStringSplitter _stringSplitter;
        public StringPreprocessorTests()
        {
            _stringSplitter = Substitute.For<IStringSplitter>();
            _stringPreprocessor = new StringPreprocessor(_stringSplitter);
        }
        #endregion
    }
}
