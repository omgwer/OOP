using Lab3_2.Dictionary;
using Lab3_2.Infrastructure;
using Lab3_2.Service;

namespace Lab3_2;

public class Calculator
{
    private IMemoryService _memoryService;
    private IStreamWorker _streamWorker;
    private bool _isRun;
    private CalculatorService _calculatorService;

    public Calculator(TextReader textReader, TextWriter textWriter)
    {
        _streamWorker = new StreamWorker(textReader, textWriter);
        _memoryService = new MemoryService();
        _calculatorService = new CalculatorService(_memoryService);
    }

    public void Run()
    {
        _isRun = true;
        _streamWorker.WriteLine("Calculator is start");
        while (_isRun)
        {
            var command = ReadCommand();
            if (command == null) continue;

            switch (command.CommandType)
            {
                case CommandType.VAR:
                    _calculatorService.VariableDeclaration(command);
                    break;
                case CommandType.LET:
                    _calculatorService.VariableAssigment(command);
                    break;
                case CommandType.FN:
                    _calculatorService.FunctionDeclaration(command);
                    break;
                case CommandType.PRINT:
                    var variableResult = _calculatorService.GetVariable(command);
                    _streamWorker.WriteLine(variableResult);
                    break;
                case CommandType.PRINTVARS:
                    var variableResultList = _calculatorService.GetAllVariables();
                    variableResultList.ForEach(e => _streamWorker.WriteLine(e));
                    break;
                case CommandType.PRINTFNS:
                    var variableFunctionsList = _calculatorService.GetAllFunctions();
                    variableFunctionsList.ForEach(e => _streamWorker.WriteLine(e));
                    break;
                case CommandType.CLOSE:
                    Stop();
                    break;
                case CommandType.HELP:
                    Help();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    private Command? ReadCommand()
    {
        Command? command = null;
        try
        {
            command = _streamWorker.ReadCommand();
        }
        catch (IOException ex)
        {
            Stop();
        }
        catch (ArgumentException ex)
        {
            _streamWorker.WriteLine("Error in command line!");
            command = null;
        }

        return command;
    }

    private void Stop()
    {
        _isRun = false;
        _streamWorker.WriteLine("Calculator is closed");
    }

    private void Help()
    {
        _streamWorker.WriteLine("Commands list: ");
        _streamWorker.WriteLine("   var {identifier} ");
        _streamWorker.WriteLine("   let {identifier} = {float} ");
        _streamWorker.WriteLine("   let {identifier} = {identifier} ");
        _streamWorker.WriteLine("   fn {identifier} = {identifier}");
        _streamWorker.WriteLine("   fn {identifier} = {identifier}{operation}{identifier}");
        _streamWorker.WriteLine("   print {identifier}");
        _streamWorker.WriteLine("   printvars");
        _streamWorker.WriteLine("   printfns");
    }
}