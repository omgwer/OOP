// See https://aka.ms/new-console-template for more information

using System.Collections;
using Lab5_2;


MyString myStr = new MyString("Hello, world!");

IEnumerator enumerator = myStr.Begin();
IEnumerator endEnumerator = myStr.End();

while (enumerator.MoveNext())
{
    char c = (char)enumerator.Current;
    Console.Write(c + " ");
}