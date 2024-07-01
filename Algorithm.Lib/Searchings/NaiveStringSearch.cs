namespace Algorithm.Lib;

public class NaiveStringSearch : IStringSearchAlgorithm
{
    public IEnumerable<ISearchMatch> Search(string toFind, string toSearch)
    {
        if (toFind == null)
        {
            throw new ArgumentNullException(nameof(toFind));
        }

        if (toSearch == null)
        {
            throw new ArgumentNullException(nameof(toSearch));
        }

        if (toFind.Length > 0 && toSearch.Length > 0)
        {
            for (int startIndex = 0; startIndex <= toSearch.Length - toFind.Length; startIndex++)
            {
                int matchCount = 0;

                while (toFind[matchCount] == toSearch[startIndex + matchCount])
                {
                    matchCount++;

                    if (toFind.Length == matchCount)
                    {
                        yield return new StringSearchMatch(startIndex, matchCount);
                        startIndex += matchCount - 1;
                        break;
                    }
                }
            }
        }
    }
}