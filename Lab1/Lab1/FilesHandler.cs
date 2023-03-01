namespace Lab1;

public class FilesHandler
{
    public List<int> FindSubstringsIndexesInStream(ref FileStream inputFileStream, ref string substring)
    {
        var streamReader = new StreamReader(inputFileStream); 
        var searchResultIndexes = new List<int>();
        string readString;
        int startIndex = 0;
        
        while ((readString = streamReader.ReadLine()) != null)
        {
            var index = readString.IndexOf(substring, startIndex, StringComparison.Ordinal);
            while (index > -1)
            {
                searchResultIndexes.Add(index);
                index = readString.IndexOf(substring, index + substring.Length, StringComparison.Ordinal);
            }
        }
        return searchResultIndexes;
    }
}