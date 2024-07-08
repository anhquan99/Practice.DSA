using System;

namespace Application;

public enum Color { Red, Black }

public class RedBlackTreeNode<T> where T : IComparable<T>
{
    public T Value { get; set; }
    public Color Color { get; set; } = Color.Red; // New nodes are red by default
    public RedBlackTreeNode<T> Parent { get; set; }
    public RedBlackTreeNode<T> Left { get; set; }
    public RedBlackTreeNode<T> Right { get; set; }

    public RedBlackTreeNode(T value)
    {
        Value = value;
    }

    public RedBlackTreeNode<T> Grandparent => Parent?.Parent;
    public RedBlackTreeNode<T> Sibling => Parent?.Left == this ? Parent.Right : Parent.Left;
    public RedBlackTreeNode<T> Uncle => Parent?.Sibling;
}

public class RedBlackTree<T> where T : IComparable<T>
{
    private RedBlackTreeNode<T> nil = new RedBlackTreeNode<T>(default(T)) { Color = Color.Black }; // NIL node
    private RedBlackTreeNode<T> root = null;

    private void LeftRotate(RedBlackTreeNode<T> x)
    {
        var y = x.Right;
        x.Right = y.Left;
        if (y.Left != null)
        {
            y.Left.Parent = x;
        }
        y.Parent = x.Parent;
        if (x.Parent == null)
        {
            root = y;
        }
        else if (x == x.Parent.Left)
        {
            x.Parent.Left = y;
        }
        else
        {
            x.Parent.Right = y;
        }
        y.Left = x;
        x.Parent = y;
    }

    private void RightRotate(RedBlackTreeNode<T> x)
    {
        var y = x.Left;
        x.Left = y.Right;
        if (y.Right != null)
        {
            y.Right.Parent = x;
        }
        y.Parent = x.Parent;
        if (x.Parent == null)
        {
            root = y;
        }
        else if (x == x.Parent.Right)
        {
            x.Parent.Right = y;
        }
        else
        {
            x.Parent.Left = y;
        }
        y.Right = x;
        x.Parent = y;
    }

    private void FixInsert(RedBlackTreeNode<T> k)
    {
        while (k != root && k.Parent.Color == Color.Red)
        {
            if (k.Parent == k.Grandparent.Left)
            {
                var uncle = k.Grandparent.Right;
                if (uncle != nil && uncle.Color == Color.Red)
                {
                    // Case 1
                    k.Parent.Color = Color.Black;
                    uncle.Color = Color.Black;
                    k.Grandparent.Color = Color.Red;
                    k = k.Grandparent;
                }
                else
                {
                    if (k == k.Parent.Right)
                    {
                        // Case 2
                        k = k.Parent;
                        LeftRotate(k);
                    }
                    // Case 3
                    k.Parent.Color = Color.Black;
                    k.Grandparent.Color = Color.Red;
                    RightRotate(k.Grandparent);
                }
            }
            else // Mirrored cases for when k.Parent is the Right child of its grandparent
            {
                var uncle = k.Grandparent.Left;
                if (uncle != nil && uncle.Color == Color.Red)
                {
                    // Case 1 (mirrored)
                    k.Parent.Color = Color.Black;
                    uncle.Color = Color.Black;
                    k.Grandparent.Color = Color.Red;
                    k = k.Grandparent;
                }
                else
                {
                    if (k == k.Parent.Left)
                    {
                        // Case 2 (mirrored)
                        k = k.Parent;
                        RightRotate(k);
                    }
                    // Case 3 (mirrored)
                    k.Parent.Color = Color.Black;
                    k.Grandparent.Color = Color.Red;
                    LeftRotate(k.Grandparent);
                }
            }
        }
        root.Color = Color.Black;
    }

    public void Insert(T data)
    {
        var newNode = new RedBlackTreeNode<T>(data)
        {
            Left = nil,
            Right = nil
        };

        RedBlackTreeNode<T> parent = null, current = root;
        while (current != nil)
        {
            parent = current;
            if (newNode.Value.CompareTo(current.Value) < 0)
            {
                current = current.Left;
            }
            else
            {
                current = current.Right;
            }
        }

        newNode.Parent = parent;

        if (parent == null)
        {
            root = newNode;
        }
        else if (newNode.Value.CompareTo(parent.Value) < 0)
        {
            parent.Left = newNode;
        }
        else
        {
            parent.Right = newNode;
        }

        if (newNode.Parent == null)
        {
            newNode.Color = Color.Black;
            return;
        }

        if (newNode.Parent.Parent == null)
        {
            return;
        }

        FixInsert(newNode);
    }

    // Inorder traversal
    public void Inorder()
    {
        InorderHelper(root);
    }

    private void InorderHelper(RedBlackTreeNode<T> node)
    {
        if (node != nil)
        {
            InorderHelper(node.Left);
            Console.Write(node.Value + " ");
            InorderHelper(node.Right);
        }
    }

    // Search function
    public RedBlackTreeNode<T> Search(T data)
    {
        return SearchHelper(root, data);
    }

    private RedBlackTreeNode<T> SearchHelper(RedBlackTreeNode<T> node, T data)
    {
        if (node == nil || data.CompareTo(node.Value) == 0)
        {
            return node;
        }
        if (data.CompareTo(node.Value) < 0)
        {
            return SearchHelper(node.Left, data);
        }
        return SearchHelper(node.Right, data);
    }
}
