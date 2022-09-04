namespace StringChanger.Application.StringPreprocessor
{
    public interface IStringPreprocessor
    {
        void Process(string input);
        string GetProcessedString();
        void ClearProcessedString();
    }
}
