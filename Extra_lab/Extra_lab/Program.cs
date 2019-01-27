using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extra_lab
{
    class Program
    {
        static void Main(string[] args)
        {
            BST b = new BST();
            b.Add(20);
            b.Add(15);
            b.Add(10);
            b.Add(30);
            b.Add(29);
            Console.WriteLine("Printing Inorder\n\n");
            b.Inorder();
            Console.WriteLine("Searching\n\n");
            b.Searchtree(15);
            b.Successor();
            //b.Delete(10,);
            
            
        }
    }
    class Node
    {
        public int data;
        public Node right;
        public Node left;

        public Node()
        { }
        public Node(int data)
        {
            this.data = data;
            this.left = null;
            this.right = null;
        }

    }
    class BST
    {
        public Node root;
        public BST()
        {
            root = null;
        }
        public void Add(int d)
        {
            root = Addroot(d, root);
        }
        private Node Addroot(int e, Node n)
        {
            //if n is empty then add newnode n
            //if val of e is < n, add newnode in leftsubtree
            //if val of e is > n, add mewnode in rightsubtree
            if (n == null)
            {
                Node n1 = new Node();
                n1.data = e;
                return n1;
            }
            else if (e < n.data)
            {
                n.left = Addroot(e, n.left);
                
            }
            else
            {
                n.right = Addroot(e, n.right);
                
            }
            return n;
        }
        private Node Inorder(Node n)
        {
            //goto left
            //print current
            //goto right

            if (n == null)
            {
                return n;
            }
            else
            {
                Inorder(n.left);
                Console.WriteLine(n.data);
                Inorder(n.right);
            }
            return n;
        }
        public void Inorder()
        {
            Inorder(root);
        }

        private Node Preorder(Node n)
        {
            //print current
            //goto left
            //goto right

            if (n == null)
            {
                return n;
            }
            else
            {
                Console.WriteLine(n.data);
                Inorder(n.left);
                //Console.WriteLine(n);
                Inorder(n.right);
            }
            return n;
        }
        public void Preorder()
        {
            Preorder(root);
        }


        private Node Postorder(Node n)
        {

            //goto left
            //goto right
            //print current

            if (n == null)
            {
                return n;
            }
            else
            {
                
                Inorder(n.left);
                //Console.WriteLine(n);
                Inorder(n.right);
                Console.WriteLine(n.data);
            }
            return n;
        }
        public void Postorder()
        {
            Postorder(root);
        }

        private Node Searchtree(Node n,int ele)
        {
            if (n == null)
            {
                return null;
            }
            if (n.data == ele)
            {
                Console.WriteLine("Found");
            }
            else if (ele < n.data)
            {
                Searchtree(n.left, ele);
            }
            else
            {
                Searchtree(n.right, ele);
            }
            return n;

        }
        public void Searchtree(int ele)
        {
            Node m = Searchtree(root, ele);
            
        }
        public void Minimum()
        {
            Node x = Minimum(root);
            Console.WriteLine(x.data);
           
        }

        private Node Minimum(Node n)
        {
            if (n == null)
                return null;
            if (n != null && n.left == null)
            {
                return n;
            }
            return Minimum(n.left);
        }
        public void Successor()
        {
            Node y = Successor(root);
            Console.WriteLine("Successor {0}",y.data);
        }
        private Node Successor(Node n)
        {
                
                if (n == null)
                { return null; }
                else
                    return Minimum(n.right);
            

            //else if (n != null && n.right == null)
            //    return n;
            //else if (n.right.left == null)
            //{
            //    return n.right;
            //}
            //return Successor(n.right.left);


        }

        public Node Delete(int e, Node n)
        {
            //case1: element has no children
            //then return null
            Node f = Searchtree(root,e);
            if (f.left == null && f.right == null)
                return null;



            //case 2: if element has one child
            //if left is empty return right child
            //if right is empty return left child
            if (f.left == null)
                return f.right;
            else
                return f.left;


            //case3:if element has two children
            //find successor of element
            //swap values of successor and element
            //delete element from right subtree

            Node s = Successor(f);
            int t = f.data;
            f.data = s.data;
            s.data = t;
            f.right = Delete(s.data, f.right);




        }

    }
}
