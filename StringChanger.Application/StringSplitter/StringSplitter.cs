using StringChanger.Application.StringTokenizer;
using StringChanger.Application.ValueObjects;
using System.Text;

namespace StringChanger.Application.StringSplitter
{
    public class StringSplitter : IStringSplitter
    {
        private readonly ITokenizer _strTokenizer;
        private List<Sentence> sentences = new();
        public StringSplitter(ITokenizer strTokenizer)
        {
            _strTokenizer = strTokenizer;
        }

        public IEnumerable<Sentence> Split(string line)
        {
            StringBuilder sb = new();
            sentences.Clear();

            for(int i = 0; i < line.Length; i++)
            {
                _strTokenizer.CheckCharWithPosition(line[i], i);
            }

            int prevPos = -1;
            var sentence = new Sentence();
            sentences.Add(sentence);
            foreach (var item in _strTokenizer.GetTokens())
            {
                sentences.Last().Words.Add(line[(prevPos+1)..item.Key]);
                if(item.Value == "Split")
                {
                    sentences.Last().Words.Add(line[item.Key].ToString());
                }
                if (item.Value == "End")
                {
                    sentences.Last().Words.Add(line[item.Key].ToString());
                    sentences.Add(new Sentence());
                }
                prevPos = item.Key;
            }
            sentences.Last().Words.Add(line[(prevPos + 1)..line.Length]);
            _strTokenizer.Clear();
            return sentences;
        }
    }
}
