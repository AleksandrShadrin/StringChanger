using System.Text.RegularExpressions;

namespace StringChanger.Application.StringTokenizer
{
    public class Tokenizer : ITokenizer
    {
        private Dictionary<int, string> tokens = new();
        public Dictionary<int, string> GetTokens()
        {
            return tokens;
        }
        public void CheckCharWithPosition(char ch, int chPosition)
        {
            AddIfToken(ch, chPosition);
        }

        public void Clear()
        {
            tokens.Clear();
        }

        private void AddIfToken(char ch, int chPosition)
        {
            if(Regex.IsMatch(ch.ToString(), @"[\W_]"))
            {
                if(".!?".Contains(ch))
                {
                    tokens.Add(chPosition,"End");
                }
                else
                {
                    tokens.Add(chPosition, "Split");
                }
            }
        }
    }
}
