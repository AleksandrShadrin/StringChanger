using System.Text.RegularExpressions;

namespace StringChanger.Application.StringTokenizer
{
    public class Tokenizer : ITokenizer
    {
        private Queue<char> token = new();
        public void AddChar(char ch)
        {
            if (token.Count < 2)
            {
                token.Enqueue(ch);
            }
            else
            {
                token.Enqueue(ch);
                token.Dequeue();
            }
        }

        public void Clear()
        {
            token.Clear();
        }

        public bool IsToken()
        {
            var last = token.Last().ToString();
            var first = token.First().ToString();
            var result = Regex.IsMatch(last, @"[\W_]");
            result = result || Regex.IsMatch(first, @"[\W_]") && Regex.IsMatch(last, @"[а-яА-Яa-zA-Z0-9]");
            result = result || Regex.IsMatch(first, @"[а-яА-Яa-zA-Z]") && Regex.IsMatch(last, @"\d");

            return result;
        }
    }
}
