using ConsoleApp1;

namespace Trie.Test;

public class Tests
{
    [Test]
    public void CheckSingleInsert()
    {
        var root = new Node();
        
        root.Insert("test");

        var t1 = root._children[0];
        var e = t1._children[0];
        var s = e._children[0];
        var t2 = s._children[0];

        Assert.That(t1.Char, Is.EqualTo('t'));
        Assert.That(e.Char, Is.EqualTo('e'));
        Assert.That(s.Char, Is.EqualTo('s'));
        Assert.That(t2.Char, Is.EqualTo('t'));
        Assert.True(t2.EndOfWord);
    }
    
    [Test]
    public void CheckDoubleInsert()
    {
        var root = new Node();
        
        root.Insert("test");

        var t1 = root._children[0];
        var e = t1._children[0];
        var s = e._children[0];
        var t2 = s._children[0];

        Assert.That(t1.Char, Is.EqualTo('t'));
        Assert.False(t1.EndOfWord);

        Assert.That(e.Char, Is.EqualTo('e'));
        Assert.False(e.EndOfWord);
        
        Assert.That(s.Char, Is.EqualTo('s'));
        Assert.False(s.EndOfWord);

        Assert.That(t2.Char, Is.EqualTo('t'));
        Assert.True(t2.EndOfWord);
        
        root.Insert("te");
        
        Assert.That(t1.Char, Is.EqualTo('t'));
        Assert.False(t1.EndOfWord);

        Assert.That(e.Char, Is.EqualTo('e'));
        Assert.True(e.EndOfWord);

        Assert.That(s.Char, Is.EqualTo('s'));
        Assert.False(s.EndOfWord);

        Assert.That(t2.Char, Is.EqualTo('t'));
        Assert.True(t2.EndOfWord);
    }

    [Test]
    public void SeeIfExists()
    {
        var root = new Node();
        
        root.Insert("test");

        Assert.True(root.KeyExists("test"));
    }
    
    [Test]
    public void SeeIfNotExists()
    {
        var root = new Node();
        
        root.Insert("test");

        Assert.False(root.KeyExists("app"));
    }
}