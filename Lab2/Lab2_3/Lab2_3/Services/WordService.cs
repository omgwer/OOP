using System.Text;

namespace Lab2_3.Services;

public static class WordService
{
    private static readonly HashSet<char> EnglishCharsArray = new()
    {
        'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v',
        'w', 'x', 'y', 'z'
    };

    private static readonly HashSet<char> RussianCharsArray = new()
    {
        'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф',
        'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я'
    };

    public static bool IsEnglishWord(string word)
    {
        for (var i = 0; i < word.Length; i++)
        {
            if (EnglishCharsArray.Contains(word[i])) continue;
            if (i == 0)
                return false;
            throw new ArgumentException($"Word - {word} is not valid. Chars is not only one language");
        }

        return true;
    }

    public static bool IsRussianWord(string word)
    {
        for (var i = 0; i < word.Length; i++)
        {
            if (RussianCharsArray.Contains(word[i])) continue;
            if (i == 0)
                return false;
            throw new ArgumentException($"Word - {word} is not valid. Chars is not only one language");
        }

        return true;
    }

    public static string ConvertStringByMask(string value, bool[] mask)
    {
        var stringBuilder = new StringBuilder();
        for (var i = 0; i < value.Length; i++)
        {
            if (i < mask.Length)
                stringBuilder.Append(mask[i] ? char.ToUpper(value[i]) : char.ToLower(value[i]));
            else
                stringBuilder.Append(value[i]);
        }

        return stringBuilder.ToString();
    }

    public static bool[] GetWordMask(string value)
    {
        bool[] mask = Enumerable.Repeat(false, value.Length).ToArray();
        for (var i = 0; i < value.Length; i++)
            if (char.IsUpper(value[i]))
                mask[i] = true;
        return mask;
    }
}