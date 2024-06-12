using System.Text;

namespace Application;

public class TernarySearchTree
{
    class Node
    {
        public char Data;
        public bool End;
        public Node Left, Equal, Right;
        public Node(char data)
        {
            Data = data;
            End = false;
            Left = Equal = Right = null;
        }
    }
    private Node Root;
    public TernarySearchTree()
    {
        this.Root = null;
    }
    public void Insert(string word)
    {
        if (string.IsNullOrEmpty(word)) return;
        Root = Insert(Root, word, 0);
    }
    Node Insert(Node node, string word, int index)
    {
        if (node == null) node = new Node(word[index]);
        if (word[index] < node.Data)
        {
            node.Left = Insert(node.Left, word, index);
        }
        else if (word[index] > node.Data)
        {
            node.Right = Insert(node.Right, word, index);
        }
        else
        {
            if (index < word.Length - 1)
            {
                node.Equal = Insert(node.Equal, word, index + 1);
            }
            else node.End = true;
        }
        return node;
    }
    public bool Search(string word)
    {
        if (string.IsNullOrEmpty(word)) return false;
        return Search(Root, word, 0);
    }
    bool Search(Node node, string word, int index)
    {
        if (node == null) return false;
        if (word[index] < node.Data) return Search(node.Left, word, index);
        else if (word[index] > node.Data) return Search(node.Right, word, index);
        else
        {
            if (index == word.Length - 1) return node.End;
            else return Search(node.Equal, word, index + 1);
        }
    }
    public void Traverse()
    {
        Traverse(Root, "");
    }
    void Traverse(Node node, string buffer)
    {
        if (node == null) return;
        Traverse(node.Left, buffer);
        buffer += node.Data;
        if (node.End) Console.WriteLine(buffer);
        Traverse(node.Equal, buffer.Substring(0, buffer.Length - 1) + node.Data);
        Traverse(node.Right, buffer.Substring(0, buffer.Length - 1) + node.Data);
    }
}