using ConsoleApp1;

namespace Trie.Test;

public class Tests
{
    static readonly int ALPHABET_SIZE = 26;

    
    [Test]
    public void CheckSingleInsert()
    {
        var root = new Node();
        
        root.Insert("test");
        
        Assert.Multiple(() =>
        {
            Assert.That(root._children['t' - 'a'], Is.Not.Null);
            Assert.That(root._children['t' - 'a']._children['e' - 'a'], Is.Not.Null);
            Assert.That(root._children['t' - 'a']._children['e' - 'a']._children['s' - 'a'], Is.Not.Null);
            Assert.That(root._children['t' - 'a']._children['e' - 'a']._children['s' - 'a']._children['t' - 'a'], Is.Not.Null);
        });
        
        Assert.That(root._children['t' - 'a']._children['e' - 'a']._children['s' - 'a']._children['t' - 'a'].EndOfWord, Is.True);
    }

    [Test]
    public void CheckDoubleInsertWithSameText()
    {
        var root = new Node();
        
        root.Insert("test");
        
        Assert.Multiple(() =>
        {
            Assert.That(root._children['t' - 'a'], Is.Not.Null);
            Assert.That(root._children['t' - 'a']._children['e' - 'a'], Is.Not.Null);
            Assert.That(root._children['t' - 'a']._children['e' - 'a']._children['s' - 'a'], Is.Not.Null);
            Assert.That(root._children['t' - 'a']._children['e' - 'a']._children['s' - 'a']._children['t' - 'a'], Is.Not.Null);
        });
        
        root.Insert("te");
        
        Assert.Multiple(() =>
        {
            Assert.That(root._children['t' - 'a'], Is.Not.Null);
            Assert.That(root._children['t' - 'a']._children['e' - 'a'], Is.Not.Null);
        });
        
        Assert.That(root._children['t' - 'a']._children['e' - 'a']._children['s' - 'a']._children['t' - 'a'].EndOfWord, Is.True);
        Assert.That(root._children['t' - 'a']._children['e' - 'a'].EndOfWord, Is.True);
    }

    [Test]
    public void CheckDoubleInsertWithDifferentTest()
    {
        var root = new Node();
        
        // Insert word test
        root.Insert("test");

        // Check if the indexes for "test" exist.
        Assert.Multiple(() =>
        {
            Assert.That(root._children['t' - 'a'], Is.Not.Null);
            Assert.That(root._children['t' - 'a']._children['e' - 'a'], Is.Not.Null);
            Assert.That(root._children['t' - 'a']._children['e' - 'a']._children['s' - 'a'], Is.Not.Null);
            Assert.That(root._children['t' - 'a']._children['e' - 'a']._children['s' - 'a']._children['t' - 'a'], Is.Not.Null);
        });
        
        // Check if the last 't' in "test" is marked as EndOfWord.
        Assert.That(root._children['t' - 'a']._children['e' - 'a']._children['s' - 'a']._children['t' - 'a'].EndOfWord, Is.True);

        // Check if the indexes for "app" exist.
        root.Insert("app");
        
        // Check if the indexes for "app" exist.
        Assert.Multiple(() =>
        {
            Assert.That(root._children['a' - 'a'], Is.Not.Null);
            Assert.That(root._children['a' - 'a']._children['p' - 'a'], Is.Not.Null);
            Assert.That(root._children['a' - 'a']._children['p' - 'a']._children['p' - 'a'], Is.Not.Null);
        });
        Assert.Multiple(() =>
        {

            // Check if the last 't' in "test" is marked as EndOfWord.
            Assert.That(root._children['t' - 'a']._children['e' - 'a']._children['s' - 'a']._children['t' - 'a'].EndOfWord, Is.True);
            
            // Check if the last 'p' in "app" is marked as EndOfWord.
            Assert.That(root._children['a' - 'a']._children['p' - 'a']._children['p' - 'a'].EndOfWord, Is.True);
        });
    }

    [Test]
    public void SeeIfNotExists()
    {
        var root = new Node();
        
        root.Insert("test");

        Assert.That(root.KeyExists("app"), Is.False);
    }
}