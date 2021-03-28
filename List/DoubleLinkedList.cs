using System;
using System.Collections.Generic;
using System.Text;

namespace List
{
    public class DoubleLinkedList
    {
        public int Length { get; private set; }
        private DNode _root;
        private DNode _tail;
        private DNode sorted;
        public int this[int index]
        {
            get
            {
                if (index >= 0 && index < Length)
                {
                    return GetDNodeByIndex(index).Value;
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
                    GetDNodeByIndex(index).Value = value;
                }
                else
                {
                    throw new IndexOutOfRangeException("Index is out of range");
                }
            }
        }
        public DNode GetDNodeByIndex(int index)
        {
            DNode current;
            if (index < (int)(Length / 2))
            {
                current = _root;
                for (int i = 1; i <= index; i++)
                {
                    current = current.Next;
                }
            }
            else
            {
                current = _tail;
                int indexBack = Length - 1 - index;
                for (int i = 1; i <= indexBack; ++i)
                {
                    current = current.Previous;
                }
            }
            return current;
        }
        public DoubleLinkedList()
        {
            Length = 0;
            _root = null;
            _tail = null;
        }

        public DoubleLinkedList(int value)
        {
            Length = 1;
            _root = new DNode(value);
            _tail = _root;
        }
        public DoubleLinkedList(int[] values)
        {
            if (!(values is null))
            {
                if (values.Length != 0)
                {
                    _root = new DNode(values[0]);
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
                throw new ArgumentNullException("You can't pass a null");
            }
        }
        public void Add(int value)
        {
            if (Length > 0)
            {
                Length++;
                _tail.Next = new DNode(value, _tail);
                _tail = _tail.Next;
            }
            else
            {
                Length = 1;
                _root = new DNode(value);
                _tail = _root;
            }
        }
        public void AddToStart (int value)
        {
            if (Length > 0)
            {
                DNode newRoot = new DNode(value);
                _root.Previous = newRoot;
                newRoot.Next = _root;
                _root = newRoot;
                Length++;
            } else
            {
                Length = 1;
                _root = new DNode(value);
                _tail = _root;
            }
        }
        public void AddByIndex (int value, int index)
        {
            if (index >= 0 && index <= Length)
            {
                if (Length > 1 && index > 0)
                {
                    if (index < Length)
                    {
                        DNode current = GetDNodeByIndex(index);
                        DNode prevNode = GetDNodeByIndex(index - 1);
                        DNode newNode = new DNode(value);

                        newNode.Next = prevNode.Next;
                        prevNode.Next = newNode;
                        newNode.Previous = current.Previous;
                        current.Previous = newNode;
                        Length++;
                    }
                    else
                    {
                        Add(value);
                    }
                }
                else
                {
                    if (index == 0)
                    {
                        AddToStart(value);
                    }
                    else
                    {
                        Add(value);
                    }
                }
            }
            else
            {
                throw new IndexOutOfRangeException("Index is out of range bla bla");
            }
        }
        public void Remove()
        {
            if (Length > 1)
            {
                DNode penult = GetDNodeByIndex(Length - 2);
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
                    DNode current = GetDNodeByIndex(index);
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
            if (Length > 1)
            {
                Length--;
                _root.Next.Previous = null;
                _root = _root.Next;
            }
            else
            {
                _root = null;
                _tail = null;
                Length = 0;
            }
        }
        public void RemoveAtStart(int quontity)
        {
            if (quontity <= Length)
            {
                if (quontity < Length)
                {
                    DNode current = GetDNodeByIndex(quontity);
                    current.Previous = null;
                    _root = current;

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
                throw new ArgumentException("Quontity can' be bigger than Length");
            }
        }

        public void RemoveByIndex(int index)
        {
            if (index >= 0 && index < Length)
            {
                if (Length > 1)
                {
                    if (index > 0)
                    {
                        if (index == Length - 1)
                        {
                            Remove();
                        }
                        else
                        {
                            DNode current = GetDNodeByIndex(index - 1);
                            current.Next.Next.Previous = current;
                            current.Next = current.Next.Next;
                            Length--;
                        }
                    }
                    else
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
            else
            {
                throw new IndexOutOfRangeException("Out of range bla bla");
            }
        }

        public void RemoveByIndex(int index, int quontity)
        {
            if (index < 0 || index >= Length)
            {
                throw new IndexOutOfRangeException("Out of range bla");
            }
            int elementsLeft = Length - index;
            if (quontity <= elementsLeft)
            {
                if (quontity < elementsLeft)
                {
                    DNode prev = GetDNodeByIndex(index - 1);
                    DNode next = GetDNodeByIndex(index + quontity);
                    next.Previous = prev;
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
            return GetDNodeByIndex(index).Value;
        }

        public int FindIndexOf(int value)
        {
            for (int i = 0; i < Length; ++i)
            {
                DNode current = GetDNodeByIndex(i);
                if (current.Value == value)
                {
                    return i;
                }
            }

            return -1;
        }

        public void SetByIndex(int value, int index)
        {
            DNode current = GetDNodeByIndex(index);
            current.Value = value;
        }

        public void Reverse()
        {
            if (Length < 2)
                return;

            DNode currNode = _root;
            for (int i = 0; i < Length; i++)
            {
                DNode temp = currNode.Next;
                currNode.Next = currNode.Previous;
                currNode.Previous = temp;
                currNode = currNode.Previous;
            }
            DNode tmp = _root;
            _root = _tail;
            _tail = tmp;

        }

        public int FindIndexOfMaximumElement()
        {
            if (Length > 0)
            {
                int max = _root.Value;
                int index = 0;
                DNode tmp = _root.Next;
                for (int i = 1; i < Length; ++i)
                {
                    if (tmp.Value > max)
                    {
                        index = i;
                        max = tmp.Value;
                    }
                    tmp = tmp.Next;
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
                int min = _root.Value;
                int index = 0;
                DNode tmp = _root.Next;
                for (int i = 1; i < Length; ++i)
                {
                    if (tmp.Value < min)
                    {
                        index = i;
                        min = tmp.Value;
                    }
                    tmp = tmp.Next;
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
            return GetDNodeByIndex(FindIndexOfMaximumElement()).Value;
        }

        public int FindMinimumElement()
        {
            return GetDNodeByIndex(FindIndexOfMinimumElement()).Value;
        }

        public void RemoveFirstValue(int value)
        {
            if (Length > 1)
            {
                if (_root.Value == value)
                {
                    RemoveAtStart();
                }
                else
                {
                    DNode tmp = _root.Next;
                    for (int i = 1; i < Length; ++i)
                    {
                        if (tmp.Value == value)
                        {
                            RemoveByIndex(i);
                            break;
                        }
                        tmp = tmp.Next;
                    }
                }
            }
            else if (Length == 1)
            {
                if (_root.Value == value)
                {
                    _root = null;
                    _tail = null;
                    Length = 0;
                }
            }
            else
            {
                _root = null;
                _tail = null;
                Length = 0;
            }
        }

        public void RemoveAllValues(int value)
        {
            if (Length > 1)
            {
                while (_root.Value == value)
                {
                    RemoveAtStart();
                }
                DNode tmp = _root.Next;
                for (int i = 1; i < Length; ++i)
                {
                    if (tmp.Value == value)
                    {
                        RemoveByIndex(i);
                        --i;
                    }
                    tmp = tmp.Next;
                }
            }
            else if (Length == 1)
            {
                if (_root.Value == value)
                {
                    _root = null;
                    _tail = null;
                    Length = 0;
                }
            }
            else
            {
                _root = null;
                _tail = null;
                Length = 0;
            }
        }

        public void AddDoubleLinkedList(DoubleLinkedList list)
        {
            if (list.Length == 0)
            {
                return;
            }
            if (Length > 0)
            {
                this._tail.Next = list._root;
                list._root.Previous = this._tail;
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

        public void AddDoubleLinkedListToStart(DoubleLinkedList list)
        {
            if (Length > 0)
            {
                if (list.Length > 0)
                {
                    list._tail.Next = this._root;
                    this._root.Previous = list._tail;
                    _root = list._root;
                    Length += list.Length;
                }
            }
            else
            {
                _root = list._root;
                _tail = list._tail;
                Length = list.Length;
            }
        }

        public void AddDoubleLinkedListToIndex(DoubleLinkedList list, int index)
        {
            if (index > 0 && index < Length)
            {
                DNode prev = GetDNodeByIndex(index - 1);
                DNode next = GetDNodeByIndex(index);
                prev.Next = list._root;
                list._root.Previous = prev;
                list._tail.Next = next;
                next.Previous = list._tail;
                Length += list.Length;
            }
            else if (index == 0)
            {
                AddDoubleLinkedListToStart(list);
            }
            else if (index == Length)
            {
                AddDoubleLinkedList(list);
            }
            else
            {
                throw new IndexOutOfRangeException("Index can't be bigger than Length");
            }
        }

        public void SortMergeAscending()
        {
            _root = mergeSort(_root);

            DNode sortedMerge(DNode a, DNode b)
            {
                DNode result = null;

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

            DNode mergeSort(DNode root)
            {
                if (root == null || root.Next == null)
                {
                    return root;
                }

                DNode middle = getMiddle(root);
                DNode nextofmiddle = middle.Next;

                middle.Next = null;

                DNode left = mergeSort(root);

                DNode right = mergeSort(nextofmiddle);

                DNode sortedlist = sortedMerge(left, right);
                return sortedlist;
            }


            DNode getMiddle(DNode root)
            {
                if (root == null)
                    return root;
                DNode fastptr = root.Next;
                DNode slowptr = root;

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
        }

        public void SortMergeDescending()
        {
            _root = mergeSort(_root);

            DNode sortedMerge(DNode a, DNode b)
            {
                DNode result = null;

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

            DNode mergeSort(DNode root)
            {
                if (root == null || root.Next == null)
                {
                    return root;
                }

                DNode middle = getMiddle(root);
                DNode nextofmiddle = middle.Next;

                middle.Next = null;

                DNode left = mergeSort(root);

                DNode right = mergeSort(nextofmiddle);

                DNode sortedlist = sortedMerge(left, right);
                return sortedlist;
            }

            DNode getMiddle(DNode root)
            {
                if (root == null)
                    return root;
                DNode fastptr = root.Next;
                DNode slowptr = root;

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

        }

        public void SortInsertionAscending()
        {
            sorted = null;
            DNode current = _root;
            while (current != null)
            {
                DNode next = current.Next;
                InsertSorted(current);
                current = next;
            }
            _root = sorted;
        }
        private void InsertSorted(DNode newnode)
        {
            if (sorted == null || sorted.Value >= newnode.Value)
            {
                newnode.Next = sorted;
                sorted = newnode;
            }
            else
            {
                DNode current = sorted;
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
                DNode current = _root;
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
            DoubleLinkedList list = (DoubleLinkedList)obj;

            if (this.Length != list.Length)
            {
                return false;
            }

            DNode currentThis = this._root;
            DNode currentList = list._root;

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
