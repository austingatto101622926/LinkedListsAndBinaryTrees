using System;
using System.Threading;
using System.Transactions;

namespace Data_Structures {
    public class LinkedListNode {
        public string Data;
        public LinkedListNode Next;


        public LinkedListNode(string data, LinkedListNode next) {
            this.Data = data;
            this.Next = next;
        }
    }

    public class LinkedList {
        public LinkedListNode Head;

        public LinkedList() {
            Head = null;
        }

        public void AddToEnd(string newData) {
            LinkedListNode newNode = new LinkedListNode(newData, null);
            
            if (Head == null) {
                Head = newNode;
                return;
            } 
            
            LinkedListNode current = Head;

            while (current.Next != null) {
                current = current.Next;
            }
            current.Next = newNode;
        }
        
        public LinkedListNode GetNodeAt(int index) {
            int count = 0;

            if (index < 0) {
                return null;
            }
            
            LinkedListNode current = Head;
            while (count < index) {
                if (current.Next != null) {
                    current = current.Next;
                } else {
                    return null;
                }
                count++;
            }

            return current;
        }

        public bool Find(string searchTerm) {
            LinkedListNode current = Head;

            while (current != null) {
                if (current.Data == searchTerm) {
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        /// <summary>
        /// Returns the number of nodes in the Linked List
        /// </summary>
        /// <returns>int: count</returns>
        public int Count() {
            if (Head == null)
            {
                return 0;
            }
            int count = 0;
            LinkedListNode current = Head;
            while (current != null)
            {
                current = current.Next;
                count++;
            }
            return count;
        }

        /// <summary>
        /// Adds a node to the start of the list.
        /// </summary>
        /// <param name="data"></param>
        /// <returns>success: true</returns>
        public bool AddToStart(string data) {
            Head = new LinkedListNode(data, Head);
            return true;
        }

        public bool AddNodeAt(string data, int index) {
            if (index == 0)
            {
                AddToStart(data);
                return true;
            }
            else
            {
                GetNodeAt(index - 1).Next = new LinkedListNode(data, GetNodeAt(index));
            }
            return true;
        }

        public bool DeleteNodeAt(int index) {
            GetNodeAt(index - 1).Next = GetNodeAt(index + 1);
            return true;
        }

    }
}