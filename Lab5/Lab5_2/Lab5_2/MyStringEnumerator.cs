using System.Collections;

namespace Lab5_2;

public class MyStringEnumerator : IEnumerator
{
    private char[] _characters;
    private int _position = -1;
    private int _endPosition;

    public MyStringEnumerator(char[] characters)
    {
        _characters = characters;
        _endPosition = characters.Length;
    }

    
    // TODO:  https://metanit.com/java/tutorial/5.10.php   -- вынести на hasNext() -> MoveNext()
    public bool MoveNext()
    {
        if ()
        _position++;
        return (_position < _endPosition);
    }

    public void Reset()
    {
        _position = -1;
    }

    public object Current
    {
        get
        {
            try
            {
                return _characters[_position];
            }
            catch (IndexOutOfRangeException)
            {
                throw new InvalidOperationException();
            }
        }
    }
    
    public static bool operator ==(MyStringEnumerator firstEnumerator, MyStringEnumerator secondEnumerator)
    {
        return firstEnumerator._position == secondEnumerator._position;
    }

    public static bool operator !=(MyStringEnumerator firstEnumerator, MyStringEnumerator secondEnumerator)
    {
        return firstEnumerator._position != secondEnumerator._position;
    }
}