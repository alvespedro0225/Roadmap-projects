namespace TaskBuilder_CSharp;

public static class InputValidator
{
        /// <summary>
        /// Turns a string into a list of strings. Use opening and closing <c>"</c> or <c>'</c>
        /// to keep a word separated by spaces as a single string.
        /// </summary>
        ///  
        /// <param name="input"> The string you want to make into an array </param>
        ///
        /// <returns>A list of strings consisting of the words in the initial string.</returns> 
    public static List<string> MakeList(string input)
    {
    List<string> inputWords = [];
    input = input.Trim();
    var word = string.Empty;
        for (var i = 0; i < input.Length; i++)
        {
            if (inputWords.Count == 3) break;
            if (input[i] == '\'' || input[i] == '\"')
            {
                word += input[i++];
                while (true)
                {
                    if (input[i] == '\'' || input[i] == '\"')
                    {
                        break;
                    }

                    word += input[i++];
                    if (i != input.Length) continue;
                    inputWords.Add(word);
                    throw new FormatException($"Unclosed {word[0]} in {word}.\n");
                }

                if (i == input.Length - 1)
                    inputWords.Add(word[1..]);
                continue;
            }

            if (input[i] != ' ')
            {
                word += input[i];
            }
            else if (input[i] == ' ' && !string.IsNullOrEmpty(word))
            {
                inputWords.Add(word);
                word = string.Empty;
            }

            if (i == (input.Length - 1) && input[i] != ' ')
            {
                inputWords.Add(word);
            }
        }
        return inputWords;
    }
}