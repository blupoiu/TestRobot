using System;

using System.Collections.Generic;

namespace RobotCleaner
{

    public class SBBSTNode
    {
        SBBSTNode left, right;
        int data;
        int height;

        public SBBSTNode()
        {
            Left = null;
            Right = null;
            data = 0;
            Height = 0;
        }
        /* Constructor */
        public SBBSTNode(int n)
        {
            Left = null;
            Right = null;
            data = n;
            Height = 0;
        }

        public int Data { get => data; set => data = value; }
        public int Height { get => height; set => height = value; }
        public SBBSTNode Right { get => right; set => right = value; }
        public SBBSTNode Left { get => left; set => left = value; }
    }
    class SelfBalancingBinarySearchTree
    {
        private SBBSTNode root;

        public SelfBalancingBinarySearchTree()
        {
            root = null;
        }

        public bool IsEmpty()
        {
            return root == null;
        }

        /* Make the tree logically empty */
        public void Clear()
        {
            root = null;
        }

        public void Insert(int data)
        {
            root = Insert(data, root);
        }

        private int Height(SBBSTNode t)
        {
            return t == null ? -1 : t.Height;
        }
        /* Function to max of left/right node */
        private int Max(int lhs, int rhs)
        {
            return lhs > rhs ? lhs : rhs;
        }

        /* Rotate binary tree node with left child */
        private SBBSTNode RotateWithLeftChild(SBBSTNode k2)
        {
            SBBSTNode k1 = k2.Left;
            k2.Left = k1.Right;
            k1.Right = k2;
            k2.Height = Max(Height(k2.Left), Height(k2.Right)) + 1;
            k1.Height = Max(Height(k1.Left), k2.Height) + 1;
            return k1;
        }

        /* Rotate binary tree node with right child */
        private SBBSTNode RotateWithRightChild(SBBSTNode k1)
        {
            SBBSTNode k2 = k1.Right;
            k1.Right = k2.Left;
            k2.Left = k1;
            k1.Height = Max(Height(k1.Left), Height(k1.Right)) + 1;
            k2.Height = Max(Height(k2.Right), k1.Height) + 1;
            return k2;
        }
        /* Function to insert data recursively */
        private SBBSTNode Insert(int x, SBBSTNode t)
        {
            if (t == null)
                t = new SBBSTNode(x);
            else if (x < t.Data)
            {
                t.Left = Insert(x, t.Left);
                if (Height(t.Left) - Height(t.Right) == 2)
                    if (x < t.Left.Data)
                        t = RotateWithLeftChild(t);
                    else
                        t = DoubleWithLeftChild(t);
            }
            else if (x > t.Data)
            {
                t.Right = Insert(x, t.Right);
                if (Height(t.Right) - Height(t.Left) == 2)
                    if (x > t.Right.Data)
                        t = RotateWithRightChild(t);
                    else
                        t = DoubleWithRightChild(t);
            }
            else
                ;  // Duplicate; do nothing
            t.Height = Max(Height(t.Left), Height(t.Right)) + 1;
            return t;
        }

        /**
     * Double rotate binary tree node: first left child
     * with its right child; then node k3 with new left child */
        private SBBSTNode DoubleWithLeftChild(SBBSTNode k3)
        {
            k3.Left = RotateWithRightChild(k3.Left);
            return RotateWithLeftChild(k3);
        }
        /**
     * Double rotate binary tree node: first right child
     * with its left child; then node k1 with new right child */
        private SBBSTNode DoubleWithRightChild(SBBSTNode k1)
        {
            k1.Right = RotateWithLeftChild(k1.Right);
            return RotateWithRightChild(k1);
        }

        /* Functions to count number of nodes */
        public int CountNodes()
        {
            return CountNodes(root);
        }
        private int CountNodes(SBBSTNode r)
        {
            if (r == null)
                return 0;
            else
            {
                int l = 1;
                l += CountNodes(r.Left);
                l += CountNodes(r.Right);
                return l;
            }
        }

        /* Functions to search for an element */
        public bool Search(int val)
        {
            return Search(root, val);
        }
        private bool Search(SBBSTNode r, int val)
        {
            bool found = false;
            while ((r != null) && !found)
            {
                int rval = r.Data;
                if (val < rval)
                    r = r.Left;
                else if (val > rval)
                    r = r.Right;
                else
                {
                    found = true;
                    break;
                }
                found = Search(r, val);
            }
            return found;
        }
        public void Inorder()
        {
            Inorder(root);
        }
        private void Inorder(SBBSTNode r)
        {
            if (r != null)
            {
                Inorder(r.Left);
                Inorder(r.Right);
            }
        }
        /* Function for preorder traversal */
        public void Preorder()
        {
            Preorder(root);
        }
        private void Preorder(SBBSTNode r)
        {
            if (r != null)
            {
                Preorder(r.Left);
                Preorder(r.Right);
            }
        }
        /* Function for postorder traversal */
        public void postorder()
        {
            Postorder(root);
        }
        private void Postorder(SBBSTNode r)
        {
            if (r != null)
            {
                Postorder(r.Left);
                Postorder(r.Right);
            }
        }

    }


}
