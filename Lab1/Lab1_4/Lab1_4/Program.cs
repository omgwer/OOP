namespace Lab1_4;

class Program
{
    private struct Command
    {
        public CryptType cryptType;
        public string inputFileName;
        public string outputFileName;
        public byte key;
    }

    public static void Main(string[] args)
    {
        var command = ParseCommand(args);
        if (command.cryptType == CryptType.DECRYPT)
            Crypt.DecryptAndSave(command.inputFileName, command.outputFileName, command.key);
        else 
            Crypt.EncryptAndSave(command.inputFileName, command.outputFileName, command.key);
    }

    private static Command ParseCommand(string[] args)
    {
        if (args.Length != 4)
            throw new ArgumentException("Arguments count is not valid!");
        Command command = new ();

        command.cryptType = args[0] switch
        {
            "crypt" => CryptType.ENCRYPT,
            "decrypt" => CryptType.DECRYPT,
            _ => throw  new ArgumentException($"This is crypt type is not valid!")
        };

        if (args[1].IndexOfAny(Path.GetInvalidFileNameChars()) != -1)
            throw new ArgumentException("Input file name is not valid!");
        
        if (args[2].IndexOfAny(Path.GetInvalidFileNameChars()) != -1)
            throw new ArgumentException("Output file name is not valid!");

        command.inputFileName = args[1];
        command.outputFileName = args[2];

        var isConverted = Byte.TryParse(args[3], out command.key);
        if (!isConverted)
            throw new ArgumentException("Key value is not valid!");

        return command;
    }
}