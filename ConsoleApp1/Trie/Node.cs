namespace ConsoleApp1;

public class Node
{
    static readonly int ALPHABET_SIZE = 26;

    public char? Char;
    public bool EndOfWord = false;

    private Node[] _children = new Node[ALPHABET_SIZE];
    private int _count = 0;

    public void Insert(string key)
    {
        var character = key[0];

        foreach (var node in _children)
        {
            if (node == null) 
                break;

            if (node.Char != character) 
                continue;
            
            if (key.Length > 1)
                node.Insert(key[1..]);
            else
                node.EndOfWord = true;

            return;
        }

        _children[_count++] = new Node()
        {
            Char = character,
            EndOfWord = key.Length == 1
        };

        if (key.Length == 1) return;

        _children[_count - 1].Insert(key[1..]);
    }
}