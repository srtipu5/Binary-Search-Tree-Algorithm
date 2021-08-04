using System;
using System.Collections.Generic;

namespace BST
{
    class Program
    {
        public class Node
        {
            public int data;
            public Node left;
            public Node right;
            public Node(int value)
            {
                data = value;
                left = null;
                right = null;
            }
        }
        public class BST
        {
            Node head;
            public BST()
            {
                head = null;
            }
            public void Insert(int value)
            {
                Node newNode = new Node(value);
                if(head == null)
                {
                    head = newNode;
                }
                else
                {
                    Node tempNode = head;
                    while(tempNode != null)
                    {
                        if(tempNode.data >= value)
                        {
                            if(tempNode.left == null)
                            {
                                break;
                            }

                            tempNode = tempNode.left;
                        }
                        else
                        {
                            if(tempNode.right == null)
                            {
                                break;
                            }
                            tempNode = tempNode.right;
                        }
                    }
                    if(tempNode.data >= value)
                    {
                        tempNode.left = newNode;
                    }
                    else
                    {
                        tempNode.right = newNode;
                    }
                }
            }
            public void DeleteRoot()
            {
                if(head == null)
                {
                    Console.WriteLine("Empty Tree.");
                }
               else if(head.right == null && head.left == null)
                {
                    head = null;
                } 
                else
                {
                    Node start = head;
                    Stack<Node> node = new Stack<Node>();
                    node.Push(start);
                    
                    if(start.left != null)
                    {
                        start = start.left;
                        while(start != null)
                        {
                            node.Push(start);
                            start = start.right;
                        }
                        start = node.Pop();
                        Node tempNode = node.Pop();
                       
                        if(tempNode == head)
                        {
                            start.right = head.right;
                            head = start;
                        }
                        else
                        {
                            tempNode.right = null;
                            start.left = head.left;
                            start.right = head.right;
                            head = start;
                        }
                    }
                    else 
                    {
                        start = start.right;
                        while (start != null)
                        {
                            node.Push(start);
                            start = start.left;
                        }
                        start = node.Pop();
                        Node tempNode = node.Pop();

                        if (tempNode == head)
                        {
                            start.left = head.left;
                            head = start;
                        }
                        else
                        {
                            tempNode.left = null;
                            start.left = head.left;
                            start.right = head.right;
                            head = start;
                        }
                    }
                }
            }
            public void Print()
            {
                //BFS algorithm

                if(head == null)
                {
                    Console.WriteLine("Empty.");
                }
                else
                {
                    Queue<Node> inputNode = new Queue<Node>();
                    inputNode.Enqueue(head);

                    while (inputNode.Count > 0)
                    {
                        Node outputNode = inputNode.Dequeue();
                        Console.WriteLine(outputNode.data);
                        if(outputNode.left != null)
                        {
                            inputNode.Enqueue(outputNode.left);
                        }
                        if(outputNode.right != null)
                        {
                            inputNode.Enqueue(outputNode.right);
                        }

                    }

                }


            }
            public void Search(int value)
            {
                if(head == null)
                {
                    Console.WriteLine("Empty Tree.");
                }
                else
                {
                    Node start = head;
                    int count = 1;
                    while(start != null)
                    {
                        if(start.data == value)
                        {
                            Console.WriteLine($"Data found after {count} checking.");
                            return;
                        }
                        else if(start.data >= value)
                        {
                            start = start.left;
                            count++;
                        }
                        else
                        {
                            start = start.right;
                            count++;
                        }
                    }
                    Console.WriteLine($"Data not found.");
                }
            }

        }
        static void Main(string[] args)
        {
            BST myBst = new BST();
            myBst.Insert(10);
            myBst.Insert(30);
            myBst.Insert(20);
            myBst.Insert(50);
            myBst.Insert(7);
            myBst.Insert(9);
            myBst.Print();
            myBst.Search(9);
            myBst.DeleteRoot();
            myBst.Print();
            Console.ReadKey();
        }
    }
}
