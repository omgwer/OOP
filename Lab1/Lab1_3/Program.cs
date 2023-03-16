using System.Globalization;

namespace Lab1_3;

/*
 Вариант №2 – invert – 80 баллов
Разработайте приложение invert.exe, выполняющее инвертирование матрицы 3*3, 
т.е. нахождение обратной матрицы  и выводящее коэффициенты результирующей матрицы в стандартный поток вывода. Формат командной строки приложения:
invert.exe <matrix file>
Коэффициенты входной матрицы заданы во входном текстовом файле (смотрите файл matrix.txt в качестве иллюстрации)  в трех строках по 3 элемента.
Коэффициенты результирующей матрицы выводятся с точностью до 3 знаков после запятой.
Используйте двухмерные массивы для хранения коэффициентов матриц.
*/
class Program
{
    const byte MATRIX_SIZE = 3;

    // Про исключение можно выбрасывать наследников, а не сам Exception
    public static int Main(string[] args)
    {
        try
        {
            var pathToFile = ParseCommandLine(args);
            var inputMatrix = ReadMatrixFromFile(pathToFile);
            var inverseMatrix = InverseMatrix(inputMatrix);
            PrintMatrix(inverseMatrix);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return 1;
        }

        return 0;
    }

    private static string ParseCommandLine(string[] args)
    {
        if (args.Length != 1 | !args[0].Contains('.'))
            throw new Exception("Error in parse command line");
        var pathToFile = args[0];
        return pathToFile;
    }

    private static float[][] ReadMatrixFromFile(string pathToFile)
    {
        string[] readStringArrayFromFile = File.ReadAllLines(pathToFile);
        if (readStringArrayFromFile.Length != MATRIX_SIZE)
            throw new Exception("Error, line in matrix file != 3");
        float[][] inputMatrix = CreateEmptyMatrix();

        for (var i = 0; i < MATRIX_SIZE; i++)
        {
            string[] elementsInString = readStringArrayFromFile[i].Split(' ');
            if (elementsInString.Length != MATRIX_SIZE)
                throw new Exception("Error, elements in line != 3");
            for (var j = 0; j < MATRIX_SIZE; j++)
            {
                var isConvertable = float.TryParse(elementsInString[j], NumberStyles.Any, CultureInfo.InvariantCulture,
                    out inputMatrix[i][j]);
                if (!isConvertable)
                    throw new Exception("Error, cant convert to float");
            }
        }

        return inputMatrix;
    }

    private static float[][] InverseMatrix(float[][] inputMatrix)
    {
        // проверить детерминант на равенство 0, лучше вернуть null
        var matrixDeterminant = GetMatrixDeterminant(inputMatrix);
        
        var transposedMatrix = TransposeMatrix(inputMatrix);
        // переименовать функцию, это не инвертированная матрица
        float[][] inversedMatrix = GetInverseMatrix(transposedMatrix);
        float coefficient = 1 / matrixDeterminant;
        float[][] multiplicationMatrix = MatrixMultiplication(inversedMatrix, coefficient);
        //нужно проверить, корректно ли мы инвертировали матрицу
        bool isCorrectInverseMatrix = CheckCorrectInverseMatrix(inputMatrix, inversedMatrix, matrixDeterminant);
        if (!isCorrectInverseMatrix)
            throw new Exception("Error in logic program, inverse matrix error");
        return multiplicationMatrix;
    }

    // ищем определитель матрицы
    private static float GetMatrixDeterminant(float[][] inputMatrix)
    {
        float result = inputMatrix[0][0] * inputMatrix[1][1] * inputMatrix[2][2] +
                       inputMatrix[1][0] * inputMatrix[2][1] * inputMatrix[0][2] +
                       inputMatrix[0][1] * inputMatrix[1][2] * inputMatrix[2][0] -
                       inputMatrix[2][0] * inputMatrix[1][1] * inputMatrix[0][2] -
                       inputMatrix[0][0] * inputMatrix[2][1] * inputMatrix[1][2] -
                       inputMatrix[1][0] * inputMatrix[0][1] * inputMatrix[2][2];
        if (result == 0)
            throw new ArgumentException("This matrix dont have a determinant");
        return result;
    }

    // меняем строки и столбцы местами
    private static float[][] TransposeMatrix(float[][] inputMatrix)
    {
        var result = CreateEmptyMatrix();
        for (var i = 0; i < inputMatrix.Length; i++)
        for (var j = 0; j < inputMatrix[i].Length; j++)
            result[i][j] = inputMatrix[j][i];
        return result;
    }

    // получаем алгебраические дополнения
    // имя должно быть более абстрактным
    private static float[][] GetInverseMatrix(float[][] transposedMatrix)
    {
        var inverseMatrix = CreateEmptyMatrix();
        inverseMatrix[0][0] = transposedMatrix[1][1] * transposedMatrix[2][2] -
                              transposedMatrix[2][1] * transposedMatrix[1][2];
        inverseMatrix[0][1] = -(transposedMatrix[1][0] * transposedMatrix[2][2] -
                                transposedMatrix[2][0] * transposedMatrix[1][2]);
        inverseMatrix[0][2] = transposedMatrix[1][0] * transposedMatrix[2][1] -
                              transposedMatrix[2][0] * transposedMatrix[1][1];
        inverseMatrix[1][0] = -(transposedMatrix[0][1] * transposedMatrix[2][2] -
                                transposedMatrix[2][1] * transposedMatrix[0][2]);
        inverseMatrix[1][1] = transposedMatrix[0][0] * transposedMatrix[2][2] -
                              transposedMatrix[2][0] * transposedMatrix[0][2];
        inverseMatrix[1][2] = -(transposedMatrix[0][0] * transposedMatrix[2][1] -
                                transposedMatrix[2][0] * transposedMatrix[0][1]);
        inverseMatrix[2][0] = transposedMatrix[0][1] * transposedMatrix[1][2] -
                              transposedMatrix[1][1] * transposedMatrix[0][2];
        inverseMatrix[2][1] = -(transposedMatrix[0][0] * transposedMatrix[1][2] -
                                transposedMatrix[1][0] * transposedMatrix[0][2]);
        inverseMatrix[2][2] = transposedMatrix[0][0] * transposedMatrix[1][1] -
                              transposedMatrix[1][0] * transposedMatrix[0][1];
        return inverseMatrix;
    }

    private static float[][] CreateEmptyMatrix()
    {
        var newMatrix = new float[MATRIX_SIZE][];
        for (var i = 0; i < MATRIX_SIZE; i++)
            newMatrix[i] = new float[MATRIX_SIZE];
        return newMatrix;
    }

    // сменить имя на GetInverseMatrix
    // переименовать аргументы
    private static float[][] MatrixMultiplication(float[][] inversedMatrix, float multiplierFactor)
    {
        var multiplicationMatrix = CreateEmptyMatrix();
        for (var i = 0; i < MATRIX_SIZE; i++)
        for (var j = 0; j < MATRIX_SIZE; j++)
            multiplicationMatrix[i][j] = inversedMatrix[i][j] * multiplierFactor;
        return multiplicationMatrix;
    }

    // переименовать аргументы
    private static void PrintMatrix(float[][] inputMatrix)
    {
        for (var i = 0; i < MATRIX_SIZE; i++)
        {
            for (var j = 0; j < MATRIX_SIZE; j++)
                Console.Write(inputMatrix[i][j].ToString("0.000") + "\t");
            Console.WriteLine();
        }
    }

    // для проверки, нужно перемножить исходную матрицу и инверсную, должны получиться везде нули, кроме главной диагонали.
    private static bool CheckCorrectInverseMatrix(float[][] inputMatrix, float[][] inversedMatrix,
        float matrixDeterminant)
    {
        var newMatrix = CreateEmptyMatrix();
        newMatrix[0][0] = inputMatrix[0][0] * inversedMatrix[0][0] + inputMatrix[0][1] * inversedMatrix[1][0] +
                          inputMatrix[0][2] * inversedMatrix[2][0];
        newMatrix[0][1] = inputMatrix[0][0] * inversedMatrix[0][1] + inputMatrix[0][1] * inversedMatrix[1][1] +
                          inputMatrix[0][2] * inversedMatrix[2][1];
        newMatrix[0][2] = inputMatrix[0][0] * inversedMatrix[0][2] + inputMatrix[0][1] * inversedMatrix[1][2] +
                          inputMatrix[0][2] * inversedMatrix[2][2];
        newMatrix[1][0] = inputMatrix[1][0] * inversedMatrix[0][0] + inputMatrix[1][1] * inversedMatrix[1][0] +
                          inputMatrix[1][2] * inversedMatrix[2][0];
        newMatrix[1][1] = inputMatrix[1][0] * inversedMatrix[0][1] + inputMatrix[1][1] * inversedMatrix[1][1] +
                          inputMatrix[1][2] * inversedMatrix[2][1];
        newMatrix[1][2] = inputMatrix[1][0] * inversedMatrix[0][2] + inputMatrix[1][1] * inversedMatrix[1][2] +
                          inputMatrix[1][2] * inversedMatrix[2][2];
        newMatrix[2][0] = inputMatrix[2][0] * inversedMatrix[0][0] + inputMatrix[2][1] * inversedMatrix[1][0] +
                          inputMatrix[2][2] * inversedMatrix[2][0];
        newMatrix[2][1] = inputMatrix[2][0] * inversedMatrix[0][1] + inputMatrix[2][1] * inversedMatrix[1][1] +
                          inputMatrix[2][2] * inversedMatrix[2][1];
        newMatrix[2][2] = inputMatrix[2][0] * inversedMatrix[0][2] + inputMatrix[2][1] * inversedMatrix[1][2] +
                          inputMatrix[2][2] * inversedMatrix[2][2];

        var isInverseCorrect = true;
        for (var i = 0; i < MATRIX_SIZE; i++)
        for (var j = 0; j < MATRIX_SIZE; j++)
        {
            if (i == j)
            {
                if (Math.Abs(newMatrix[i][j] - matrixDeterminant) > 0.1)
                    isInverseCorrect = false;
            }
            else if (newMatrix[i][j] != 0)
                isInverseCorrect = false;
        }

        return isInverseCorrect;
    }
}