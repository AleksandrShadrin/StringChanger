namespace StringChanger.Application.StringTokenizer
{
    public interface ITokenizer
    {
        void Clear();
        void AddChar(char ch);
        bool IsToken();
    }
}
