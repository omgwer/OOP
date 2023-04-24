using System.Text;

namespace Lab5_2;

public class MyString
{
    // TODO: добавить нулевой символ
    private readonly char END_OF_LINE = '\0';
    private char[] _characters;
    private int _length;

    public MyString()
    {
        _characters = new[] { END_OF_LINE };
    }

    public MyString(char[] charArray)
    {
        _characters = charArray.Concat(new [] {END_OF_LINE}).ToArray();
    }

    public MyString(MyString myString)
    {
        _characters = myString.GetStringData();
    }
    
    public MyString(string input)
    {
        _characters = new char[input.Length + 1];
        for (var i = 0; i < input.Length; i++)
        {
            _characters[i] = input[i];
        }

        _characters[input.Length] = END_OF_LINE;
    }

    ~MyString()
    {
        Clear();
    }

    public int GetLength()
    {
        return _characters.Length - 1;
    }

    public char[] GetStringData()
    {
        return _characters;
    }

    public MyString SubString(int start, int length = int.MaxValue)
    {
        if (start >= GetLength())
        {
            throw new ArgumentException("Out of range");
        }
        var newArrayLength =Math.Min(GetLength() - start, length) + 1;
        var newArray = new char[newArrayLength];
        Array.Copy(_characters, start, newArray, 0, newArrayLength - 1);
        //newArray[newArrayLength - 1]= END_OF_LINE;
        return new MyString(newArray);
    }

    public void Clear()
    {
        _characters = new[] { END_OF_LINE };
    }

    public override string ToString()
    {
        var stringBuilder = new StringBuilder();
        for (var i = 0; i < GetLength(); i++)
        {
            stringBuilder.Append(_characters[i]);
        }

        return stringBuilder.ToString();
    }
}

//public char this[int index] => _characters[index];