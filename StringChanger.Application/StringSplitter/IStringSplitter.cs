namespace StringChanger.Application.StringSplitter
{
    public interface IStringSplitter
    {
        IEnumerable<string> Split(string line);
    }
}
