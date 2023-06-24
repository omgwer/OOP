﻿using ExamApp.Abstraction;

namespace ExamApp;

// // Реализация холста, выполняющая вывод информации о рисуемых примитивах в stdout в виде:
// // DrawLine:(<x0>, <y0>) - (<x1>, <y1>)
// class CCanvas : public ICanvas
// {
// // Написать недостающий код
// };
public class CCanvas : ICanvas
{
    public void DrawLine(int x0, int y0, int x1, int y1)
    {
        Console.WriteLine($"({x0}, {y0}) - ({x1}, {y1})");
    }
}