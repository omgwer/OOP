using System.Collections;
using System.Text;

namespace Lab5_2;

public class MyString : IEnumerable
{
    private readonly char END_OF_LINE = '\0';
    private char[] _characters;
    private int _length;

    public MyString()
    {
        _characters = new[] {END_OF_LINE};
    }

    public MyString(char[] charArray)
    {
        _characters = charArray.Concat(new[] {END_OF_LINE}).ToArray();
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

        var newArrayLength = Math.Min(GetLength() - start, length) + 1;
        var newArray = new char[newArrayLength];
        Array.Copy(_characters, start, newArray, 0, newArrayLength - 1);
        return new MyString(newArray);
    }

    public void Clear()
    {
        _characters = new[] {END_OF_LINE}; // TODO: add case clear and get length
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

    // iterators
    public IEnumerator GetEnumerator()
    {
        return new MyStringEnumerator(_characters);
    }

    public IEnumerator Begin()
    {
        return GetEnumerator();
    }

    public IEnumerator End()
    {
        var enumerator = GetEnumerator();
        while (enumerator.MoveNext())
        {
        }

        return enumerator;
    }

    // overloads
    public static MyString operator +(MyString firstVariable, MyString secondVariable)
    {
        var firstString = firstVariable.ToString();
        var secondString = secondVariable.ToString();
        return new MyString(firstString + secondString);
    }

    public static MyString operator +(string firstVariable, MyString secondVariable)
    {
        return new MyString(firstVariable + secondVariable.ToString());
    }

    public static MyString operator +(char[] firstVariable, MyString secondVariable)
    {
        return new MyString(new string(firstVariable) + secondVariable.ToString());
    }

    public static bool operator ==(MyString firstVariable, MyString secondVariable)
    {
        var first = firstVariable.GetStringData();
        var second = secondVariable.GetStringData();
        if (first.Length != second.Length)
            return false;
        for (var i = 0; i < first.Length; i++)
        {
            if (first[i] != second[i])
                return false;
        }

        return true;
    }

    public static bool operator !=(MyString firstVariable, MyString secondVariable)
    {
        var first = firstVariable.GetStringData();
        var second = secondVariable.GetStringData();
        if (first.Length != second.Length)
            return true;
        for (var i = 0; i < first.Length; i++)
        {
            if (first[i] != second[i])
                return true;
        }

        return false;
    }

    public static bool operator >(MyString firstVariable, MyString secondVariable)
    {
        var first = firstVariable.GetStringData();
        var second = secondVariable.GetStringData();
        for (var i = 0; i < first.Length || i < second.Length; i++)  // TODO: добавить проверку выхода за границу массивы, добавить тест
        {
            if (first[i] > second[i])
                return true;
            if (first[i] < second[i])
                return false;
        }

        return false;
    }

    public static bool operator <(MyString firstVariable, MyString secondVariable)
    {
        var first = firstVariable.GetStringData();
        var second = secondVariable.GetStringData();
        for (var i = 0; i < first.Length; i++)
        {
            if (first[i] < second[i])
                return true;
            if (first[i] > second[i])
                return false;
        }

        return false;
    }

    public static bool operator >=(MyString firstVariable, MyString secondVariable)  // добавить тесты
    {
        var first = firstVariable.GetStringData();
        var second = secondVariable.GetStringData();
        for (var i = 0; i < first.Length; i++) 
        {
            if (first[i] > second[i])
                return true;
            if (first[i] < second[i])
                return false;
        }

        return firstVariable == secondVariable;
    }

    public static bool operator <=(MyString firstVariable, MyString secondVariable)
    {
        var first = firstVariable.GetStringData();
        var second = secondVariable.GetStringData();
        for (var i = 0; i < first.Length; i++)
        {
            if (first[i] < second[i])
                return true;
            if (first[i] > second[i])
                return false;
        }

        return firstVariable == secondVariable;
    }

    public char this[int index] => _characters[index];

    // write operator
    public static int operator >>(MyString myString, TextWriter textWriter)
    {
        textWriter.WriteLine(myString.ToString());
        return 0;
    }

    // read operator
    public static MyString operator <<(MyString myString, TextReader textReader)
    {
        var result = textReader.ReadLine();
        if (result == null)
            throw new ArgumentException("Invalid argument");

        return new MyString(result);
    }
}