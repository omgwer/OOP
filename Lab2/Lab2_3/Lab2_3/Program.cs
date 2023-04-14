﻿// See https://aka.ms/new-console-template for more information

using Lab2_3;
using Lab2_3.Services;

/*
Разработайте программу-словарь, осуществляющую перевод слов и словосочетаний, поступающих со стандартного потока ввода, с английского языка на русский с использованием заданного файла словаря и выводящую результат перевода в стандартный поток вывода.
Если вводимое слово или словосочетание, отсутствует в словаре, программа должна попросить пользователя ввести перевод и запомнить его, в случае, если пользователь ввел непустую строку.
Для выхода из диалога с программой пользователь должен ввести строку, состоящую из трех точек. Перед выходом программа спрашивает о необходимости сохранить изменения в файле словаря, в том случае, если в словарь были добавлены фразы во время текущей сессии работы с программой.
Имя файла словаря передается программе с помощью параметра командной строки. Если файл словаря отсутствует, то программа должна считать его пустым и предложить сохранить словарь по окончании работы, если туда были добавлены фразы.
Пример диалога пользователя с программой:
>cat
кот, кошка
>ball
мяч
>meat
Неизвестное слово “meat”. Введите перевод или пустую строку для отказа.
>мясо
Слово “meat” сохранено в словаре как “мясо”.
>meat
мясо
>The Red Square
Неизвестное слово “The Red Square”. Введите перевод или пустую строку для отказа.
>Красная Площадь
Слово “The Red Square” сохранено в словаре как “Красная Площадь”.
>lkkvksmdv
Неизвестное слово “lkkvksmdv”. Введите перевод или пустую строку для отказа.
>
Слово “lkkvksmdv”проигнорировано.
>...
В словарь были внесены изменения. Введите Y или y для сохранения перед выходом.
>y
Изменения сохранены. До свидания.
Бонус 10 баллов за возможность распознавания слов, записанных в разном регистре
Дополнительно можно получить до 10 баллов, если программа будет способна осуществлять перевод английских слов, вводимых пользователем в произвольном регистре символов. Например, слова CaT, при известном переводе для слова cat. Регистр перевода теряться не должен.
Бонус 20 баллов за реализацию двунаправленного перевода
Дополнительно можно получить до 20 баллов, если программа сможет осуществлять и обратный перевод словосочетаний. При этом необходимо поддержать возможность существования нескольких вариантов перевода одного и того же слова.
Например, после добавления слов «кошка»«cat» и «кот»«cat», программа должна иметь возможность перевести слово cat, выдав 2 возможных перевода.
*/

var library = new Library(Console.In, Console.Out);

while (library.IsRun())
    library.HandleInput();

//
// var reader = new StringReader(stringBuilder.ToString());
// var sw = new Stopwatch();
// sw.Start();
//
// new Calculator(reader, Console.Out).Run();
//
// sw.Stop();
// Console.WriteLine($"'time' : {sw.Elapsed}"); // Здесь логируем


