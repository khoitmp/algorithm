namespace Algorithm.Lib;

public interface IStringSearchAlgorithm
{
    IEnumerable<ISearchMatch> Search(string toFind, string toSearch);
}

public interface ISearchMatch
{
    int Start { get; }
    int Length { get; }
}