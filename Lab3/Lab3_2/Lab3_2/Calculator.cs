using Lab3_2.Dictionary;

namespace Lab3_2;

//TODO: можно однозначно определить идентефикатор или переменная, прочитав нулевой символ (у значения это цифра)

internal interface ICalculator
{
    // void VariableDeclaration(string variableName);  // Объявление переменной
    // void VariableAssigment(string variableName, string identifier); // Присвоение переменной
    // void FunctionDeclaration(string variableName);
    // void FunctionDeclaration(string variableNameFirst, Operation operation, string variableNameSecond);
    // void PrintVariableValue(string variableName, StringWriter stringWriter);
}

public class Calculator : ICalculator
{
    private IMemory calculatorMemory = new Memory();

}