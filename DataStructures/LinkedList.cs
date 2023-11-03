using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStructures
{
    /// <summary>
    /// a singly-linked-list
    /// </summary>
    /// <typeparam name="T">Type of the elements in the list</typeparam>
    public class LinkedList<T>
    {
        private class Node
        {
            public T Value { get; }
            public Node Next { get; set; }

            public Node(T value)
            {
                Value = value;
                Next = null;
            }
        }

        private Node head;
        private int size;

        public LinkedList()
        {
            head = null;
            size = 0;
        }

        public T Get(int i)
        {
            if (i < 0 || i >= size)
                return default(T);

            Node current = head;
            for (int j = 0; j < i; j++)
                current = current.Next;

            return current.Value;
        }

        public void InsertHead(T val)
        {
            Node newNode = new Node(val);
            newNode.Next = head;
            head = newNode;
            size++;
        }

        public void InsertTail(T val)
        {
            Node newNode = new Node(val);
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                Node current = head;
                while (current.Next != null)
                    current = current.Next;
                current.Next = newNode;
            }
            size++;
        }

        public bool Remove(int i)
        {
            if (i < 0 || i >= size)
                return false;

            if (i == 0)
            {
                head = head.Next;
            }
            else
            {
                Node current = head;
                for (int j = 0; j < i - 1; j++)
                    current = current.Next;
                current.Next = current.Next.Next;
            }
            size--;
            return true;
        }

        /// <summary>
        /// return an array of all the values in the linked list, ordered from head to tail.
        /// </summary>
        /// <returns>an array of all the values in the linked list, ordered from head to tail</returns>
        public T[] GetValues()
        {
            T[] values = new T[size];
            Node current = head;
            for (int i = 0; i < size; i++)
            {
                values[i] = current.Value;
                current = current.Next;
            }
            return values;
        }
    }

}