using System.Collections;
using System.Text;

namespace Lab5_2.Tests;

public class MyStringEnumeratorTest
{
    [Test]
    public void Positive_Enumerator()
    {
        MyString myStr = new MyString("Hello, world!");
        IEnumerator enumerator = myStr.Begin();
        IEnumerator endEnumerator = myStr.End();
        StringBuilder stringBuilder = new StringBuilder();
        
        while (enumerator.MoveNext())
        {
            stringBuilder.Append((char)enumerator.Current);
        }
        Assert.That(stringBuilder.ToString(), Is.EqualTo("Hello, world!\0"));
    }
    
    [Test]
    public void Positive_EnumeratorOperationPlus()
    {
        MyString myStr = new MyString("Hello, world!");
        IEnumerator enumerator = myStr.Begin();
        IEnumerator endEnumerator = myStr.Begin();
        StringBuilder stringBuilder = new StringBuilder();
        endEnumerator.MoveNext();
        endEnumerator.MoveNext();
        endEnumerator.MoveNext();
        endEnumerator.MoveNext();
        
        while (enumerator.MoveNext())
        {
            stringBuilder.Append((char)enumerator.Current);
        }
        Assert.That(stringBuilder.ToString(), Is.EqualTo("Hello, world!\0"));
    }
}