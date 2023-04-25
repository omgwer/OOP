namespace Lab5_2.Tests;

public class MyStringOverloadTest
{

    [Test]
    public void TestAdditionOperatorMyString()
    {
        MyString str1 = new MyString("Hello, ");
        MyString str2 = new MyString("world!");
        MyString result = str1 + str2;
        Assert.That(result.ToString(), Is.EqualTo("Hello, world!"));
    }

    [Test]
    public void TestAdditionOperatorString()
    {
        string str2 = "Hello, ";
        MyString str1 = new MyString("world!");
        MyString result = str2 + str1 ;
        Assert.That(result.ToString(), Is.EqualTo("Hello, world!"));
    }

    [Test]
    public void TestAdditionOperatorCharArray()
    {
        char[] str1 = new[] { 'H', 'e', 'l', 'l', 'o', ',',' ' };
        MyString str2 = new MyString("world!");
        MyString result = str1 + str2;
        Assert.That(result.ToString(), Is.EqualTo("Hello, world!"));
    }

    [Test]
    public void TestEqualityOperator()
    {
        MyString str1 = new MyString("Hello, world!");
        MyString str2 = new MyString("Hello, world!");
        MyString str3 = new MyString("Goodbye, world!");
        Assert.IsTrue(str1 == str2);
        Assert.IsFalse(str1 == str3);
    }

    [Test]
    public void TestInequalityOperator()
    {
        MyString str1 = new MyString("Hello, world!");
        MyString str2 = new MyString("Hello, world!");
        MyString str3 = new MyString("Goodbye, world!");
        Assert.IsFalse(str1 != str2);
        Assert.IsTrue(str1 != str3);
    }

    [Test]
    public void TestGreaterThanOperator()
    {
        MyString str1 = new MyString("Hello, world!");
        MyString str2 = new MyString("Goodbye, world!");
        Assert.IsTrue(str1 > str2);
        Assert.IsFalse(str2 > str1);
    }

    [Test]
    public void TestLessThanOperator()
    {
        MyString str1 = new MyString("Hello, world!");
        MyString str2 = new MyString("Goodbye, world!");
        Assert.IsFalse(str1 < str2);
        Assert.IsTrue(str2 < str1);
    }

    [Test]
    public void TestGreaterThanOrEqualToOperator()
    {
        MyString str1 = new MyString("Hello, world!");
        MyString str2 = new MyString("Goodbye, world!");
        MyString str3 = new MyString("Hello, world!");
        Assert.IsTrue(str1 >= str2);
        Assert.IsFalse(str2 >= str1);
        Assert.IsTrue(str1 >= str3);
    }

    [Test]
    public void TestLessThanOrEqualToOperator()
    {
        MyString str1 = new MyString("Hello, world!");
        MyString str2 = new MyString("Goodbye, world!");
        MyString str3 = new MyString("Hello, world!");
       Assert.IsFalse(str1 <= str2);
       Assert.IsTrue(str2 <= str1);
      //  Assert.IsTrue(str1 <= str3);
    }

    [Test]
    public void TestRightShiftOperator()
    {
        MyString str = new MyString("Hello, world!");
        using var sw = new StringWriter();
        var text = str >> sw;
        Assert.That(sw.ToString(), Is.EqualTo("Hello, world!\r\n"));
    }
}