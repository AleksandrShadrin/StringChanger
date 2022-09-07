using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using StringChanger.Application;
using StringChanger.Application.StringPreprocessor;

namespace StringChanger.Tests
{
    public class IntegrationTests
    {
        

        [Theory]
        [MemberData(nameof(TestData))]
        public void All_Parts_Should_Work(string inputData, string outputData)
        {
            // Act
            stringPreprocessor.Process(inputData);
            var result = stringPreprocessor.GetProcessedString();

            // Assert
            result.ShouldBe(outputData);
        }

        #region ARRANGE
        private readonly IStringPreprocessor stringPreprocessor;
        public IntegrationTests()
        {
            ServiceCollection sc = new ServiceCollection();
            sc.RegisterApplication();
            var provider = sc.BuildServiceProvider();
            stringPreprocessor = provider.GetService<IStringPreprocessor>();
        }

        public static TheoryData<string, string> TestData
            => new TheoryData<string, string>
            {
                {"один два три четыре", "один два три четыре"},
                {"привет_два_привет45", "привет _ два _ превет45"},
            };
        #endregion
    }
}
