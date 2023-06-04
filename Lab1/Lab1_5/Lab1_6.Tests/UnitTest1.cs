using Lab1_5;

namespace Lab1_6.Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        string ethalon = "ethalon.txt";
        string[] args = new[] { "input.txt", "output.txt" };
        Program.Main(args);
        
        Assert.That(CompareFileContents(ethalon, "output.txt"), Is.True);
    }
    
    [Test]
    public void EmptyArgumentsList()
    {
        string[] args = Array.Empty<string>();
        
        Assert.Throws<ArgumentException>(    () =>    Program.Main(args));
    }
    
    [Test]
    public void OneArgument()
    {
        string[] args = new[] { "input.txt" };
        
        Assert.Throws<ArgumentException>(    () =>    Program.Main(args));
            
    }
    
    [Test]
    public void ThreeArguments()
    {
        string[] args = new[] { "input.txt", "test.tx", "three.txt" };
        
        Assert.Throws<ArgumentException>(    () =>    Program.Main(args));
            
    }
    
    static bool CompareFileContents(string filePath1, string filePath2)
    {
        var file1Lines = File.ReadAllLines(filePath1);
        var file2Lines = File.ReadAllLines(filePath2);

        if (file1Lines.Length != file2Lines.Length)
        {
            return false;
        }

        for (var i = 0; i < file1Lines.Length; i++)
        {
            if (file1Lines[i] != file2Lines[i])
            {
                return false;
            }
        }

        return true;
    }
}