using System;
using System.Collections.Generic;
using System.Text;

namespace List
{
    public class LinkedList
    {
        public int Length { get; private set; }
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
        public void RemoveAtStart()
        {
            Length--;
            _root = _root.Next;
        }

        public void RemoveByIndex(int index)
        {
            if (Length > 1)
            {
                Node current = GetNodeByIndex(index - 1);
                current.Next = current.Next.Next;

                Length--;
            }
            else
            {
                _root = null;
                _tail = null;
                Length = 0;
            }
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
