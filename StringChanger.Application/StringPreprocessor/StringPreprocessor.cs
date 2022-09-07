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
            var sentences = _stringSplitter.Split(input);
            
            foreach (var sentence in sentences)
            {
                int counter = 1;
                foreach (var word in sentence.Words)
                {
                    var trimedWord = word.Trim().ToLower();

                    if (trimedWord == string.Empty)
                    {
                        continue;
                    }

                    if (counter == 1)
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
                    else
                    {
                        _stringBuilder.Append(" ");
                    }

                    if(counter > 1 && counter < sentence.Words.Count)
                    {
                        _stringBuilder.Append(trimedWord);
                    }

                    if(counter == sentence.Words.Count)
                    {
                        if (trimedWord.StartsWith("при"))
                        {
                            _stringBuilder.Append("пре");
                            _stringBuilder.Append(trimedWord[3..^0]);
                        }
                        else
                        {
                            _stringBuilder.Append(trimedWord);
                        }
                    }

                    counter++;
                }
            }
            
        }
    }
}
