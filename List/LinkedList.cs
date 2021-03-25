using System;
using System.Collections.Generic;
using System.Text;

namespace List
{
    public class LinkedList
    {
        public int Length { get; private set; }
        Node sorted;
        public int this[int index]
        {
            get
            {
                if (index >= 0 && index < Length)
                {
                    return GetNodeByIndex(index).Value;
                }
                else
                {
                    throw new IndexOutOfRangeException("Index is out of range");
                }
            }

            set
            {
                if (index >= 0 && index < Length)
                {
                    GetNodeByIndex(index).Value = value;
                }
                else
                {
                    throw new IndexOutOfRangeException("Index is out of range");
                }
            }
        }

        public Node GetNodeByIndex (int index)
        {
            Node current = _root;

            for (int i = 1; i <= index; i++)
            {
                current = current.Next;
            }
            return current;
        }
        private Node _root;
        private Node _tail;

        public LinkedList()
        {
            Length = 0;
            _root = null;
            _tail = null;
        }

        public LinkedList(int value)
        {
            Length = 1;
            _root = new Node(value);
            _tail = _root;
        }

        public LinkedList(int[] values)
        {
            if (!(values is null))
            {
                if (values.Length != 0)
                {
                    _root = new Node(values[0]);
                    _tail = _root;
                    Length = 1; ;

                    for (int i = 1; i < values.Length; i++)
                    {
                        Add(values[i]);
                    }
                }
                else
                {
                    _root = null;
                    _tail = null;
                    Length = 0;
                }
            }
            else
            {
                throw new ArgumentNullException("You can't pass a null array");
            }
        }

        public void Add(int value)
        {
            if (Length > 0)
            {
                Length++;
                _tail.Next = new Node(value);
                _tail = _tail.Next;
            }
            else
            {
                Length = 1;
                _root = new Node(value);
                _tail = _root;
            }
        }
        public void AddToStart(int value)
        {
            Length++;
            Node first = new Node(value);
            first.Next = _root;
            _root = first;
        }

        public void AddByIndex(int value, int index)
        {
            if (index == 0)
            {
                AddToStart(value);
            }
            else
            {
                Node current = GetNodeByIndex(index - 1);
                Node tmp = new Node(value);
                tmp.Next = current.Next;
                current.Next = tmp;
                Length++;
            }
        }
        
        public void Remove()
        {
            if (Length > 1)
            {
                Node penult = GetNodeByIndex(Length - 2);
                _tail = penult;
                _tail.Next = null;
                Length--;
            }
            else
            {
                _root = null;
                _tail = null;
                Length = 0;
            }
        }

        public void Remove(int quontity)
        {
            if (quontity <= Length)
            {
                if (quontity < Length)
                {
                    int index = Length - quontity - 1;
                    Node current = GetNodeByIndex(index);
                    current.Next = null;
                    _tail = current;
                    Length -= quontity;
                }
                else
                {
                    Length = 0;
                    _root = null;
                    _tail = null;
                }
            }
            else
            {
                throw new ArgumentException("Quontity can't be bigger than length");
            }
        }
        public void RemoveAtStart()
        {
            Length--;
            _root = _root.Next;
        }

        public void RemoveAtStart(int quontity)
        {
            if (quontity <= Length)
            {
                if (quontity < Length)
                {
                    Node current = GetNodeByIndex(quontity);
                    _root = current;

                    Length -= quontity;
                }
                else
                {
                    Length = 0;
                    _root = null;
                    _tail = null;
                }
            } else
            {
                throw new ArgumentException("Quontity can' be bigger than Length");
            }
        }

        public void RemoveByIndex(int index)
        {
            if (Length > 1)
            {
                if (index > 0)
                {
                    Node current = GetNodeByIndex(index - 1);
                    current.Next = current.Next.Next;

                    if (current.Next is null)
                    {
                        _tail = current;
                    }
                    Length--;
                } else
                {
                    RemoveAtStart();
                }
            }
            else
            {
                _root = null;
                _tail = null;
                Length = 0;
            }
        }

        public void RemoveByIndex(int index, int quontity)
        {
            int elementsLeft = Length - index;
            if (quontity <= elementsLeft)
            {
                if (quontity < elementsLeft)
                {
                    Node prev = GetNodeByIndex(index - 1);
                    Node next = GetNodeByIndex(index + quontity);
                    prev.Next = next;
                    
                    Length -= quontity;
                }
                else
                {
                    if (index > 0)
                    {
                        Remove(quontity);
                    }
                    else
                    {
                        Length = 0;
                        _root = null;
                        _tail = null;
                    }
                }
            }
            else
            {
                throw new ArgumentException("Quontity can't be bigger than elements left");
            }
        }

        public int GetValueByIndex(int index)
        {
            return GetNodeByIndex(index).Value;
        }

        public int FindIndexOf (int value)
        {
            for (int i = 0; i < Length; ++i)
            {
                Node current = GetNodeByIndex(i);
                if (current.Value == value)
                {
                    return i;
                }
            }

            return -1;
        }

        public void SetByIndex (int value, int index)
        {
            Node current = GetNodeByIndex(index);
            current.Value = value;
        }

        public void Reverse()
        {
            Node prev = _root;
            Node next = null;
            while (prev != null)
            {
                Node tmp = prev.Next;
                prev.Next = next;
                next = prev;
                prev = tmp;
            }
            _root = next;
        }

        public int FindIndexOfMaximumElement()
        {
            if (Length > 0)
            {
                int max = GetNodeByIndex(0).Value;
                int index = 0;
                for (int i = 1; i < Length; ++i)
                {
                    Node current = GetNodeByIndex(i);
                    if (current.Value >= max)
                    {
                        index = i;
                        max = current.Value;
                    }
                }
                return index;
            }
            else
            {
                throw new ArgumentNullException("");
            }
        }

        public int FindIndexOfMinimumElement()
        {
            if (Length > 0)
            {
                int min = GetNodeByIndex(0).Value;
                int index = 0;
                for (int i = 1; i < Length; ++i)
                {
                    Node current = GetNodeByIndex(i);
                    if (current.Value < min)
                    {
                        index = i;
                        min = current.Value;
                    }
                }
                return index;
            }
            else
            {
                throw new ArgumentNullException("");
            }
        }

        public int FindMaximumElement()
        {
            return GetNodeByIndex(FindIndexOfMaximumElement()).Value;
        }

        public int FindMinimumElement()
        {
            return GetNodeByIndex(FindIndexOfMinimumElement()).Value;
        }

        public void RemoveFirstValue (int value)
        {
            int index = FindIndexOf(value);

            if (index >= 0)
            {
                RemoveByIndex(index);
            }
        }

        public void RemoveAllValues(int value)
        {
            while (FindIndexOf(value) >= 0)
            {
                RemoveFirstValue(value);
            }
        }

        public void AddLinkedList(LinkedList list)
        {
            if (Length > 0)
            {
                this._tail.Next = list._root;
                this._tail = list._tail;
                Length += list.Length;
            }
            else
            {
                this._root = list._root;
                this._tail = list._tail;
                Length += list.Length;
            }
        }

        public void AddLinkedListToStart(LinkedList list)
        {
            if (list.Length > 0)
            {
                list._tail.Next = this._root;
                _root = list._root;
                Length += list.Length;
            }
        }

        public void AddLinkedListToIndex (LinkedList list, int index)
        {
            if (index > 0 && index < Length)
            {
                Node prev = GetNodeByIndex(index - 1);
                Node next = GetNodeByIndex(index);
                prev.Next = list._root;
                list._tail.Next = next;
                Length += list.Length;
            }
            else if (index == 0)
            {
                AddLinkedListToStart(list);
            }
            else if (index == Length)
            {
                AddLinkedList(list);
            }
            else
            {
                throw new IndexOutOfRangeException("Index can't be bigger than Length");
            }
        }

        public void SortMergeAscending()
        {
            Node sortedMerge(Node a, Node b)
            {
                Node result = null;

                if (a == null)
                    return b;
                if (b == null)
                    return a;

                if (a.Value <= b.Value)
                {
                    result = a;
                    result.Next = sortedMerge(a.Next, b);
                }
                else
                {
                    result = b;
                    result.Next = sortedMerge(a, b.Next);
                }
                return result;
            }

            Node mergeSort(Node root)
            {
                if (root == null || root.Next == null)
                {
                    return root;
                }

                Node middle = getMiddle(root);
                Node nextofmiddle = middle.Next;

                middle.Next = null;

                Node left = mergeSort(root);

                Node right = mergeSort(nextofmiddle);

                Node sortedlist = sortedMerge(left, right);
                return sortedlist;
            }


            Node getMiddle(Node root)
            {
                if (root == null)
                    return root;
                Node fastptr = root.Next;
                Node slowptr = root;

                while (fastptr != null)
                {
                    fastptr = fastptr.Next;
                    if (fastptr != null)
                    {
                        slowptr = slowptr.Next;
                        fastptr = fastptr.Next;
                    }
                }
                return slowptr;
            }

            _root = mergeSort(_root);
        }

        public void SortMergeDescending()
        {
            Node sortedMerge(Node a, Node b)
            {
                Node result = null;

                if (a == null)
                    return b;
                if (b == null)
                    return a;

                if (a.Value >= b.Value)
                {
                    result = a;
                    result.Next = sortedMerge(a.Next, b);
                }
                else
                {
                    result = b;
                    result.Next = sortedMerge(a, b.Next);
                }
                return result;
            }

            Node mergeSort(Node root)
            {
                if (root == null || root.Next == null)
                {
                    return root;
                }

                Node middle = getMiddle(root);
                Node nextofmiddle = middle.Next;

                middle.Next = null;

                Node left = mergeSort(root);

                Node right = mergeSort(nextofmiddle);

                Node sortedlist = sortedMerge(left, right);
                return sortedlist;
            }

            Node getMiddle(Node root)
            {
                if (root == null)
                    return root;
                Node fastptr = root.Next;
                Node slowptr = root;

                while (fastptr != null)
                {
                    fastptr = fastptr.Next;
                    if (fastptr != null)
                    {
                        slowptr = slowptr.Next;
                        fastptr = fastptr.Next;
                    }
                }
                return slowptr;
            }

            _root = mergeSort(_root);
        }

        public void SortInsertionAscending()
        {
        // Initialize sorted linked list
            sorted = null;
            Node current = _root;

            // Traverse the given 
            // linked list and insert every
            // node to sorted
            while (current != null)
            {
                // Store next for next iteration
                Node next = current.Next;

                // insert current in sorted linked list
                InsertSorted(current);

                // Update current
                current = next;
            }

            // Update head_ref to point to sorted linked list
            _root = sorted;
        }
        public void SortInsertionDescending()
        {
            SortInsertionAscending();
            Reverse();
        }
        private void InsertSorted(Node newnode)
        {
            /* Special case for the head end */
            if (sorted == null || sorted.Value >= newnode.Value)
            {
                newnode.Next = sorted;
                sorted = newnode;
            }
            else
            {
                Node current = sorted;

                /* Locate the node before the point of insertion */

                while (current.Next != null &&
                    current.Next.Value < newnode.Value)
                {
                    current = current.Next;
                }

                newnode.Next = current.Next;
                current.Next = newnode;
            }
        }

        public override string ToString()
        {
            if (Length != 0)
            {
                Node current = _root;
                string s = current.Value + " ";

                while (!(current.Next is null))
                {
                    current = current.Next;
                    s += current.Value + " ";
                }

                return s;
            }
            else
            {
                return String.Empty;
            }
        }

        public override bool Equals(object obj)
        {
            LinkedList list = (LinkedList)obj;

            if (this.Length != list.Length)
            {
                return false;
            }

            Node currentThis = this._root;
            Node currentList = list._root;

            if (currentList is null && currentThis is null)
            {
                return true;
            }

            do
            {
                if (currentThis.Value != currentList.Value)
                {
                    return false;
                }
                if (currentThis.Next is null && currentList.Next is null)
                {
                    return true;
                }

                currentList = currentList.Next;
                currentThis = currentThis.Next;

            }
            while (!(currentThis.Next is null));

            return true;
        }
    }
}
