using System.Collections;

namespace Lab5_2;

public class MyStringEnumerator : IEnumerator
{
    private char[] _characters;
    private int _position = -1;
    private int _endPosition;
    private int _startPosition = -1;

    public MyStringEnumerator(char[] characters)
    {
        _characters = characters;
        _endPosition = characters.Length;
    }

    public bool MoveNext()
    {
        if (!HasNext())
            return false;
        _position++;
        return true;
    }

    public bool HasNext()
    {
        return _position < _endPosition - 1;
    }

    public bool MoveBackward()
    {
        if (!HasBackward())
            return false;
        --_position;
        return true;
    }

    public bool HasBackward()
    {
        return _position > _startPosition;
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
    
    public static MyStringEnumerator operator -(MyStringEnumerator firstEnumerator, MyStringEnumerator secondEnumerator)
    {
        if (secondEnumerator._position == -1 || secondEnumerator._position == 0)
            return firstEnumerator;
        int difference = firstEnumerator._position - secondEnumerator._position;
        if (difference < -1 || difference > firstEnumerator._endPosition)
        {
            throw new Exception("cant run operation -");
        }

        firstEnumerator._position -= difference;
        return firstEnumerator;
    }
    
    public static MyStringEnumerator operator +(MyStringEnumerator firstEnumerator, MyStringEnumerator secondEnumerator)
    {
        if (secondEnumerator._position == 0)
            return firstEnumerator;
        int difference = secondEnumerator._position - firstEnumerator._position;
        if (difference < -1 || difference > (firstEnumerator._endPosition - firstEnumerator._startPosition))
        {
            throw new Exception("cant run operation -");
        }
        firstEnumerator._position += difference;
        return firstEnumerator;
    }
    

    public static bool operator !=(MyStringEnumerator firstEnumerator, MyStringEnumerator secondEnumerator)
    {
        return firstEnumerator._position == secondEnumerator._position;
    }
    
    public bool Equals(MyStringEnumerator other)
    {
        return _characters.Equals(other._characters) && _position == other._position && _endPosition == other._endPosition;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj))
            return false;
        if (ReferenceEquals(this, obj))
            return true;
        if (obj.GetType() != this.GetType())
            return false;
        return Equals((MyStringEnumerator) obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_characters, _position, _endPosition);
    }
}