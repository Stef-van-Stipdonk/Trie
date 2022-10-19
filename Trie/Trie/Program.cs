// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using ConsoleApp1;

var root = new Node();

var lines = File.ReadAllLines(@"test.txt").ToList();

foreach (var line in lines)
{
    line.Split(" ").ToList().ForEach(w =>
    {
        root.Insert(w);
    });
}

var timer = new Stopwatch();
string key;
bool exists;


timer.Start();
key = "every";
exists = root.KeyExists(key);
timer.Stop();
Console.WriteLine($"{key} - {exists} - {timer.ElapsedMilliseconds}");

timer.Start();
key = "lesser";
exists = root.KeyExists(key);
timer.Stop();
Console.WriteLine($"{key} - {exists} - {timer.ElapsedMilliseconds}");

timer.Start();
key = "darkness";
exists = root.KeyExists(key);
timer.Stop();
Console.WriteLine($"{key} - {exists} - {timer.ElapsedMilliseconds}");

timer.Start();
key = "kak";
exists = root.KeyExists(key);
timer.Stop();
Console.WriteLine($"{key} - {exists} - {timer.ElapsedMilliseconds}");