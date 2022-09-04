using StringChanger.Application.StringSplitter;
using System.Text;

namespace StringChanger.Application.StringPreprocessor
{
    public class StringPreprocessor : IStringPreprocessor
    {
        private readonly StringBuilder _stringBuilder = new StringBuilder();
        private readonly IStringSplitter _stringSplitter;

        public StringPreprocessor(IStringSplitter stringSplitter)
        {
            _stringSplitter = stringSplitter;
        }

        public void ClearProcessedString()
        {
            _stringBuilder.Clear();
        }

        public string GetProcessedString()
        {
            return _stringBuilder.ToString();
        }
        public void Process(string input)
        {
            var words = _stringSplitter.Split(input);
            var isFirst = true;
            foreach (var word in words)
            {
                var trimedWord = word.Trim().ToLower();

                if(trimedWord == string.Empty)
                {
                    continue;
                }

                if (isFirst)
                {
                    isFirst = false;
                }
                else
                {
                    _stringBuilder.Append(" ");
                }

                if (trimedWord.StartsWith("при"))
                {
                    _stringBuilder.Append("пре");
                    if (trimedWord.EndsWith("ие"))
                    {
                        _stringBuilder.Append(trimedWord[3..^2]);
                        _stringBuilder.Append("ии");
                    }
                    else
                    {
                        _stringBuilder.Append(trimedWord[3..^0]);
                    }
                }
                else
                {
                    if (trimedWord.EndsWith("ие"))
                    {
                        _stringBuilder.Append(trimedWord[0..^2]);
                        _stringBuilder.Append("ии");
                    }
                    else
                    {
                        _stringBuilder.Append(trimedWord);
                    }
                }
                    
            }
        }
    }
}
