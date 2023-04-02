namespace Lab2_3;

internal interface IMiniDictionary
{
    public string? Translate(string word);
    public bool AskToUpdate(string word);
    public void Update(string word);
}


public class MiniDictionary : IMiniDictionary
{
    public bool IsRun { get; }

    public MiniDictionary()
    {
        IsRun = true;
    }
    
    public MiniDictionary(string path)
    {
        IsRun = true;
    }


    public string? Translate(string word)
    {
        return null;
    }

    public bool AskToUpdate(string word)
    {
        throw new NotImplementedException();
    }
 
    public void Update(string word)
    {
        throw new NotImplementedException();
    }
}