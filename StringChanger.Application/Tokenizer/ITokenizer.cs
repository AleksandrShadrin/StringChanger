namespace StringChanger.Application.StringTokenizer
{
    public interface ITokenizer
    {
        Dictionary<int, string> GetTokens();
        void CheckCharWithPosition(char ch, int chPosition);
        void Clear();
    }
}
