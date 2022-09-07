using StringChanger.Application.ValueObjects;

namespace StringChanger.Application.StringSplitter
{
    public interface IStringSplitter
    {
        IEnumerable<Sentence> Split(string line);
    }
}
