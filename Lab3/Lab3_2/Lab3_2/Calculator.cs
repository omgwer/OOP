using Lab3_2.Dictionary;
using Lab3_2.Infrastructure;
using Lab3_2.Service;

namespace Lab3_2;

public class Calculator
{
    private IMemoryService _memoryService;
    private IStreamWorker _streamWorker;
    private bool _isRun;

    public Calculator(TextReader textReader, TextWriter textWriter, bool cacheIsOn = false)
    {
        _streamWorker = new StreamWorker(textReader, textWriter);
        _memoryService = new MemoryService(cacheIsOn);
    }

    public void Run()
    {
        _isRun = true;
        _streamWorker.WriteLine("Calculator is start");
        while (_isRun)
        {
            var command = ReadCommand();
            if (command != null) 
                HandleProcess(command);
        }
    }
    //TODO: case- let test1=test2  argument exception нужно обрабатывать
    private void HandleProcess(Command command)
    {
        switch (command.CommandType)
        {
            case CommandType.VAR:
                _memoryService.Add(command);
                break;
            case CommandType.LET:
                _memoryService.Add(command);
                break;
            case CommandType.FN:
                _memoryService.Add(command);
                break;
            case CommandType.PRINT:
                _streamWorker.WriteResult(_memoryService.Get(command.Identifier));
                _streamWorker.WriteLine(string.Empty);
                break;
            case CommandType.PRINTVARS:
                var variableResultList = _memoryService.GetAllVars();
                foreach (var (key, value) in variableResultList)
                {
                    _streamWorker.Write(key);
                    _streamWorker.Write(":");
                    _streamWorker.WriteResult(value);
                    _streamWorker.WriteLine(string.Empty);
                }
                break;
            case CommandType.PRINTFNS:
                var variableFunctionsList = _memoryService.GetAllFns();
                foreach (var (key, value) in variableFunctionsList)
                {
                    _streamWorker.Write(key);
                    _streamWorker.Write(":");
                    _streamWorker.WriteResult(value);
                    _streamWorker.WriteLine(string.Empty);
                }
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