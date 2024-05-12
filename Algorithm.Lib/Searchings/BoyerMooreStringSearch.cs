using System;
using System.Collections.Generic;

namespace Algorithm.Lib
{
    public class BadMatchTable
    {
        private readonly int _defaultValue;
        private readonly Dictionary<int, int> _distances;

        public BadMatchTable(string pattern)
        {
            _defaultValue = pattern.Length;
            _distances = new Dictionary<int, int>();

            for (int i = 0; i < pattern.Length - 1; i++)
            {
                _distances[pattern[i]] = pattern.Length - i - 1;
            }
        }

        public int this[int index]
        {
            get
            {
                return _distances.GetValueOrDefault(index, _defaultValue);
            }
        }
    }

    public class BoyerMooreStringSearch : IStringSearchAlgorithm
    {
        public IEnumerable<ISearchMatch> Search(string pattern, string toSearch)
        {
            if (pattern == null)
            {
                throw new ArgumentNullException(nameof(pattern));
            }

            if (toSearch == null)
            {
                throw new ArgumentNullException(nameof(toSearch));
            }

            if (pattern.Length > 0 && toSearch.Length > 0)
            {
                var badMatchTable = new BadMatchTable(pattern);
                int currentStartIndex = 0;

                while (currentStartIndex <= toSearch.Length - pattern.Length)
                {
                    int charactersLeftToMatch = pattern.Length - 1;

                    while (charactersLeftToMatch >= 0 &&
                           pattern[charactersLeftToMatch] == toSearch[currentStartIndex + charactersLeftToMatch])
                    {
                        charactersLeftToMatch--;
                    }

                    if (charactersLeftToMatch < 0)
                    {
                        yield return new StringSearchMatch(currentStartIndex, pattern.Length);
                        currentStartIndex += pattern.Length;
                    }
                    else
                    {
                        currentStartIndex += badMatchTable[toSearch[currentStartIndex + pattern.Length - 1]];
                    }
                }
            }
        }
    }
}