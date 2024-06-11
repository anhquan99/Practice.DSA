namespace Application;
public class Trie
{
    public bool End { get; set; }
    private Trie[] Nodes { get; set; }
    public Trie()
    {
        Nodes = new Trie[26];
        End = false;
    }
    public Trie this[int index]
    {
        get => Nodes[index];
        set => Nodes[index] = value;
    }
}
public static class TrieHelper
{
    public static void Insert(this Trie root, string key)
    {
        var currentNode = root;
        foreach (var ch in key)
        {
            var keyIndex = ch - 'a';
            if (currentNode[keyIndex] == null)
            {
                var newNode = new Trie();
                currentNode[keyIndex] = newNode;
            }
            currentNode = currentNode[keyIndex];
        }
        currentNode.End = true;
    }
    public static bool Search(this Trie root, string key)
    {
        var currentNode = root;
        foreach (var ch in key)
        {
            var keyIndex = ch - 'a';
            if (currentNode[keyIndex] == null) return false;
            currentNode = currentNode[keyIndex];
        }
        return currentNode.End;
    }
    public static bool IsEmpty(this Trie root)
    {
        for (int i = 0; i < 26; i++)
        {
            if (root[i] != null) return false;
        }
        return true;
    }
    public static Trie Remove(this Trie root, string key, int depth)
    {
        // If tree is empty.
        if (root == null)
            return null;

        // If last character of key is being processed.
        if (depth == key.Length)
        {
            // This node is no more end of word after
            // removal of given key.
            if (root.End)
                root.End = false;

            // If given key is not a prefix of any other word.
            if (root.IsEmpty())
                root = null;

            return root;
        }

        // If not last character, recur for the child obtained by
        // indexing into the children array using the current character.
        int index = key[depth] - 'a';
        root[index] = Remove(root[index], key, depth + 1);

        // If root does not have any children (its only child got
        // deleted), and it is not the end of a word.
        if (root.IsEmpty() && !root.End)
            root = null;

        return root;
    }
}