// See https://aka.ms/new-console-template for more information

using Lab6_1;

var t = new HttpUrl("http://google.com:1337/file");

Console.WriteLine(t.ToString());
Console.WriteLine(t.GetUrl());