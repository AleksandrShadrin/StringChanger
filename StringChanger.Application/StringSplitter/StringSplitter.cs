using StringChanger.Application.StringTokenizer;
using System.Text;

namespace StringChanger.Application.StringSplitter
{
    public class StringSplitter : IStringSplitter
    {
        private readonly ITokenizer _strTokenizer;

        public StringSplitter(ITokenizer strTokenizer)
        {
            _strTokenizer = strTokenizer;
        }

        public IEnumerable<string> Split(string line)
        {
            StringBuilder sb = new();

            foreach (char c in line)
            {
                _strTokenizer.AddChar(c);
                if (_strTokenizer.IsToken())
                {
                    var word = sb.ToString();
                    sb.Clear();
                    yield return word;
                }
                sb.Append(c);
            }
            yield return sb.ToString();
        }
    }
}
