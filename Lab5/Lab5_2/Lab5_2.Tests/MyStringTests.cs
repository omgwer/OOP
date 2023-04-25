namespace Lab5_2.Tests;

public class Tests
{
    [TestFixture]
    public class MyStringTests
    {
        [Test]
        public void MyString_EmptyConstructor_ReturnsEmptyString()
        {
            // Arrange
            var myString = new MyString();

            // Act
            var result = myString.ToString();

            // Assert
            Assert.That(result, Is.EqualTo(""));
        }

        [Test]
        public void MyString_CharArrayConstructor_ReturnsExpectedString()
        {
            // Arrange
            var input = new char[] {'a', 'b', 'c'};
            var expected = "abc";
            var myString = new MyString(input);

            // Act
            var result = myString.ToString();

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void MyString_CopyConstructor_ReturnsNewInstance()
        {
            // Arrange
            var input = new [] {'a', 'b', 'c'};
            var myString = new MyString(input);

            // Act
            var copy = new MyString(myString);

            // Assert
            Assert.That(copy, Is.Not.SameAs(myString));
        }

        [Test]
        public void MyString_StringConstructor_ReturnsExpectedString()
        {
            // Arrange
            var input = "abc";
            var expected = "abc";
            var myString = new MyString(input);

            // Act
            var result = myString.ToString();

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void GetLength_EmptyString_ReturnsZero()
        {
            // Arrange
            var myString = new MyString();

            // Act
            var result = myString.GetLength();

            // Assert
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void GetLength_NonEmptyString_ReturnsLength()
        {
            // Arrange
            var input = "abc";
            var expected = input.Length;
            var myString = new MyString(input);

            // Act
            var result = myString.GetLength();

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void GetStringData_ReturnsCharArray()
        {
            // Arrange
            var input = "abc";
            var expected = new [] {'a', 'b', 'c', '\0'};
            var myString = new MyString(input);

            // Act
            var result = myString.GetStringData();

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void SubString_StartAndLength_ReturnsExpectedString()
        {
            // Arrange
            var input = "abcdef";
            var start = 2;
            var length = 3;
            var expected = "cde\0";
            var myString = new MyString(input);

            // Act
            var result = myString.SubString(start, length).ToString();

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void SubString_StartOutOfRange_ThrowsArgumentException()
        {
            // Arrange
            var input = "abc";
            var start = 3;
            var myString = new MyString(input);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => myString.SubString(start));
        }
    }

}