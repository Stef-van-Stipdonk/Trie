// See https://aka.ms/new-console-template for more information

using ConsoleApp1;

var root = new Node();

root.Insert("te");
root.Insert("test");
root.Insert("app");

var result = root.KeyExists("te");
Console.WriteLine();
