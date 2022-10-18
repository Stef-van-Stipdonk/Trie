namespace ConsoleApp1;

public class Node
{
    static readonly int ALPHABET_SIZE = 26;

    public bool EndOfWord = false;

    public Node?[] _children = new Node[ALPHABET_SIZE];
    
    public void Insert(string key)
    {
        key = key.ToLower();
        
        var currentNode = this;
     
        foreach (var character in key)
        {
            var index = character - 'a';
            currentNode._children[index] ??= new Node();
            
            currentNode = currentNode._children[index];
        }
     
        // mark last node as leaf
        currentNode.EndOfWord = true;
    }
    
    public bool KeyExists(string key)
    {
        key = key.ToLower();

        var currentNode = this;
     
        foreach (var character in key)
        {
            var index = character - 'a';
     
            if (currentNode?._children[index] == null)
                return false;
     
            currentNode = currentNode._children[index];
        }
     
        return (currentNode.EndOfWord);
    }
}