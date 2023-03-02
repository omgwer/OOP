using System.Data;

namespace Lab1;

public class FilesHandler // подумать над статическим импортом 
{
    private readonly FileStream _fileStream;

    public FilesHandler(ref string fileName)
    {
        _fileStream = OpenFile(ref fileName);
    }

    public List<int> FindSubstringsIndexesInStream(ref string substring) // close file
    {
        // add using for close file
        var streamReader = new StreamReader(_fileStream);
        var searchResultIndexes = new List<int>();
        string readString;
        int startIndex = 0;
        int textLineIndex = 0;
        while ((readString = streamReader.ReadLine()) != null)
        {
            var index = readString.IndexOf(substring, startIndex, StringComparison.Ordinal); // учитывать только первое вхождение в строке
            while (index > -1)
            {
                searchResultIndexes.Add(textLineIndex);
                index = readString.IndexOf(substring, index + substring.Length, StringComparison.Ordinal);
            }
            textLineIndex++;
        }
        return searchResultIndexes;
    }

    private FileStream OpenFile(ref string fileName)
    { // то что файл существует не гарантирует того, что он открыт.  нет смысла в проверке на существование
        if (!File.Exists(fileName))
            throw new DataException("Error! File with name '" + fileName + "' not found ");
        return File.OpenRead(fileName);
    }
}