namespace Algorithm.Test;

[TestClass]
public class StringSearchingTest
{
    [Xunit.Theory]
    [Xunit.ClassData(typeof(SearchAlgorithms))]
    public void SearchForMissingMatchTest(IStringSearchAlgorithm algorithm)
    {
        string toFind = "missing data";
        string toSearch = "this string does not contain the missing string data";

        ISearchMatch[] matches = algorithm.Search(toFind, toSearch).ToArray();

        Xunit.Assert.NotNull(matches);
        Xunit.Assert.Empty(matches);
    }

    [Xunit.Theory]
    [Xunit.ClassData(typeof(SearchAlgorithms))]
    public void EmptySourceStringTest(IStringSearchAlgorithm algorithm)
    {
        string toFind = string.Empty;
        string toSearch = "this string does not contain the missing string data";

        ISearchMatch[] matches = algorithm.Search(toFind, toSearch).ToArray();

        Xunit.Assert.NotNull(matches);
        Xunit.Assert.Empty(matches);
    }

    [Xunit.Theory]
    [Xunit.ClassData(typeof(SearchAlgorithms))]
    public void NullSourceStringTest(IStringSearchAlgorithm algorithm)
    {
        string toFind = null;
        string toSearch = "this string does not contain the missing string data";

        Xunit.Assert.Throws<ArgumentNullException>(() => algorithm.Search(toFind, toSearch).ToArray());
    }

    [Xunit.Theory]
    [Xunit.ClassData(typeof(SearchAlgorithms))]
    public void EmptyTargetStringTest(IStringSearchAlgorithm algorithm)
    {
        string toFind = "missing data";
        string toSearch = string.Empty;

        ISearchMatch[] matches = algorithm.Search(toFind, toSearch).ToArray();

        Xunit.Assert.NotNull(matches);
        Xunit.Assert.Empty(matches);
    }

    [Xunit.Theory]
    [Xunit.ClassData(typeof(SearchAlgorithms))]
    public void NullTargetStringTest(IStringSearchAlgorithm algorithm)
    {
        string toFind = "missing data";
        string toSearch = null;

        Xunit.Assert.Throws<ArgumentNullException>(() => algorithm.Search(toFind, toSearch).ToArray());
    }

    [Xunit.Theory]
    [Xunit.ClassData(typeof(SearchAlgorithms))]
    public void EmptyEmptyTest(IStringSearchAlgorithm algorithm)
    {
        string toFind = string.Empty;
        string toSearch = string.Empty;

        ISearchMatch[] matches = algorithm.Search(toFind, toSearch).ToArray();

        Xunit.Assert.NotNull(matches);
        Xunit.Assert.Empty(matches);
    }

    [Xunit.Theory]
    [Xunit.ClassData(typeof(SearchAlgorithms))]
    public void ExactSingleCharMatchTest(IStringSearchAlgorithm algorithm)
    {
        string toFind = "f";
        string toSearch = "f";

        ISearchMatch[] matches = algorithm.Search(toFind, toSearch).ToArray();

        Xunit.Assert.NotNull(matches);
        Xunit.Assert.Single(matches);
        Xunit.Assert.Equal(0, matches[0].Start);
        Xunit.Assert.Equal(toFind.Length, matches[0].Length);
    }

    [Xunit.Theory]
    [Xunit.ClassData(typeof(SearchAlgorithms))]
    public void ExactMatchTest(IStringSearchAlgorithm algorithm)
    {
        string toFind = "found";
        string toSearch = "found";

        ISearchMatch[] matches = algorithm.Search(toFind, toSearch).ToArray();

        Xunit.Assert.NotNull(matches);
        Xunit.Assert.Single(matches);
        Xunit.Assert.Equal(0, matches[0].Start);
        Xunit.Assert.Equal(toFind.Length, matches[0].Length);
    }

    [Xunit.Theory]
    [Xunit.ClassData(typeof(SearchAlgorithms))]
    public void MultipleMatchesExactStringTest(IStringSearchAlgorithm algorithm)
    {
        string toFind = "found";
        string toSearch = "foundfound";

        ISearchMatch[] matches = algorithm.Search(toFind, toSearch).ToArray();

        Xunit.Assert.NotNull(matches);
        Xunit.Assert.Equal(2, matches.Length);

        Xunit.Assert.Equal(0, matches[0].Start);
        Xunit.Assert.Equal(toFind.Length, matches[0].Length);

        Xunit.Assert.Equal(5, matches[1].Start);
        Xunit.Assert.Equal(toFind.Length, matches[1].Length);
    }

    [Xunit.Theory]
    [Xunit.ClassData(typeof(SearchAlgorithms))]
    public void MultipleMatchesLeadingJunkTest(IStringSearchAlgorithm algorithm)
    {
        string toFind = "found";
        string toSearch = "leadingfoundfound";

        ISearchMatch[] matches = algorithm.Search(toFind, toSearch).ToArray();

        Xunit.Assert.NotNull(matches);
        Xunit.Assert.Equal(2, matches.Length);

        Xunit.Assert.Equal(7, matches[0].Start);
        Xunit.Assert.Equal(toFind.Length, matches[0].Length);

        Xunit.Assert.Equal(12, matches[1].Start);
        Xunit.Assert.Equal(toFind.Length, matches[1].Length);
    }

    [Xunit.Theory]
    [Xunit.ClassData(typeof(SearchAlgorithms))]
    public void MultipleMatchesTrailingStringTest(IStringSearchAlgorithm algorithm)
    {
        string toFind = "found";
        string toSearch = "foundfoundtrailing";

        ISearchMatch[] matches = algorithm.Search(toFind, toSearch).ToArray();

        Xunit.Assert.NotNull(matches);
        Xunit.Assert.Equal(2, matches.Length);

        Xunit.Assert.Equal(0, matches[0].Start);
        Xunit.Assert.Equal(toFind.Length, matches[0].Length);

        Xunit.Assert.Equal(5, matches[1].Start);
        Xunit.Assert.Equal(toFind.Length, matches[1].Length);
    }

    [Xunit.Theory]
    [Xunit.ClassData(typeof(SearchAlgorithms))]
    public void MultipleMatchesMiddleStringTest(IStringSearchAlgorithm algorithm)
    {
        string toFind = "found";
        string toSearch = "found and found";

        ISearchMatch[] matches = algorithm.Search(toFind, toSearch).ToArray();

        Xunit.Assert.NotNull(matches);
        Xunit.Assert.Equal(2, matches.Length);

        Xunit.Assert.Equal(0, matches[0].Start);
        Xunit.Assert.Equal(toFind.Length, matches[0].Length);

        Xunit.Assert.Equal(10, matches[1].Start);
        Xunit.Assert.Equal(toFind.Length, matches[1].Length);
    }

    [Xunit.Theory]
    [Xunit.ClassData(typeof(SearchAlgorithms))]
    public void MultipleMatchesLeadingMiddleTrailingTest(IStringSearchAlgorithm algorithm)
    {
        string toFind = "found";
        string toSearch = "leadingfound and foundtrailing";

        ISearchMatch[] matches = algorithm.Search(toFind, toSearch).ToArray();

        Xunit.Assert.NotNull(matches);
        Xunit.Assert.Equal(2, matches.Length);

        Xunit.Assert.Equal(7, matches[0].Start);
        Xunit.Assert.Equal(toFind.Length, matches[0].Length);

        Xunit.Assert.Equal(17, matches[1].Start);
        Xunit.Assert.Equal(toFind.Length, matches[1].Length);
    }

    [Xunit.Theory]
    [Xunit.ClassData(typeof(SearchAlgorithms))]
    public void MatchesMoveToEndOfMatchTest(IStringSearchAlgorithm algorithm)
    {
        string toFind = "aa";
        string toSearch = "aaaaaa";

        ISearchMatch[] matches = algorithm.Search(toFind, toSearch).ToArray();

        Xunit.Assert.NotNull(matches);
        Xunit.Assert.Equal(3, matches.Length);
    }
}

public class SearchAlgorithms : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { new NaiveStringSearch() };
        yield return new object[] { new BoyerMooreStringSearch() };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}