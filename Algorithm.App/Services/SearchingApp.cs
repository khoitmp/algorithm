namespace Algorithm.App;

public static class StringReplace
{
    public static string Replace(IStringSearchAlgorithm algorithm,
        string input,
        string pattern,
        string replace)
    {
        var result = new StringBuilder();

        int previousStart = 0;
        foreach (var match in algorithm.Search(pattern, input))
        {
            result.Append(input.Substring(previousStart, match.Start - previousStart));
            result.Append(replace);

            previousStart = match.Start + match.Length;
        }

        result.Append(input.Substring(previousStart));

        return result.ToString();
    }
}

public static class SearchingApp
{
    public static void Run(string[] args)
    {
        var text = new List<string>();
        string find = null;
        string replace = string.Empty;

        foreach (string arg in args)
        {
            string[] command = arg.Trim().TrimStart('-').Split('=', 2);
            switch (command[0].ToLower())
            {
                case "find":
                    find = command[1];
                    break;
                case "replace":
                    replace = command[1];
                    break;
                case "text":
                    text.Add(command[1]);
                    break;
                default:
                    Console.Error.WriteLine($"Unknown command: {command[0]}");
                    return;
            }
        }

        foreach (string input in text)
        {
            string output = StringReplace.Replace(new BoyerMooreStringSearch(), input, find, replace);
            Console.WriteLine(output);
        }
    }
}