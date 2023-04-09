namespace Lab3_2.Dictionary;


public class Command
{
    public CommandType CommandType { get; set; }
    public string? Identifier { get; set; }
    public string? FirstVariable { get; set; }
    public Operation? Operation { get; set; }
    public string? SecondVariable { get; set; }
}