namespace Algorithm.Lib;

class StringSearchMatch : ISearchMatch
{
    public int Start
    {
        get;
        private set;
    }

    public int Length
    {
        get;
        private set;
    }

    public StringSearchMatch(int start, int length)
    {
        Start = start;
        Length = length;
    }
}