namespace Lab2_6;

public class _delete
{
    // public static string ExpandTemplate(string tpl, Dictionary<string, string> dictionary)
    // {
    //     StringBuilder stringBuilder = new();
    //     var bufferSize = dictionary.Keys.Max(key => key.Length);  // ищем самый длинный ключ
    //     var substringStart = 0;
    //     var stringLength = tpl.Length;
    //     while (substringStart < tpl.Length)
    //     {
    //         var varKey = string.Empty;
    //         var varValue = string.Empty;
    //         int substringLength = substringStart + bufferSize > tpl.Length ? tpl.Length - substringStart : bufferSize;
    //         var currentSubstring = tpl.Substring(substringStart, substringLength);
    //         foreach (var (key, value) in dictionary)
    //         {
    //             if (currentSubstring.Contains(key) && (String.CompareOrdinal(value, varValue) > 0))
    //             {
    //                 varKey = key;
    //                 varValue = value;
    //             }
    //         }
    //
    //         if (varKey == string.Empty)
    //         {
    //             stringBuilder.Append(tpl[substringStart]);
    //             substringStart += 1;
    //             continue;
    //         }
    //         // Нужно заменить в исходной подстроке  значение, и сдвинуть индекс РОВНО до конца индекса
    //         int indexOfStartKey = currentSubstring.IndexOf(varKey, StringComparison.Ordinal);
    //         var test = currentSubstring.Remove(indexOfStartKey, varKey.Length).Insert(indexOfStartKey, varValue);
    //         stringBuilder.Append(test);
    //         substringStart += indexOfStartKey + varKey.Length;
    //     }
    //     return stringBuilder.ToString();
    // }
}