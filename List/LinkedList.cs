using System;
using System.Text;

namespace List
{
    public class LinkedList: IList
    {
        private Node _root;
        private Node _tail;
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

        public static LinkedList Create (int[] array)
        {
            if (!(array is null))
            {
                return new LinkedList(array);
            }
            else
            {
                throw new ArgumentNullException("can't create null list");
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
        public void Add(IList list)
        {
            if (!(list is null))
            {
                LinkedList addList = LinkedList.Create(list.ToArray());
                if (Length > 0)
                {
                    this._tail.Next = addList._root;
                    this._tail = addList._tail;
                    Length += addList.Length;
                }
                else
                {
                    this._root = addList._root;
                    this._tail = addList._tail;
                    Length += addList.Length;
                }
            }
            else
            {
                throw new ArgumentNullException("can't create null list");
            }
        }
        public void AddToStart(int value)
        {
            Node first = new Node(value);
            first.Next = _root;
            _root = first;
            ++Length;
        }
        public void AddToStart(IList list)
        {
            if (!(list is null))
            {
                LinkedList addList = LinkedList.Create(list.ToArray());

                if (addList.Length > 0)
                {
                    addList._tail.Next = this._root;
                    _root = addList._root;
                    Length += addList.Length;
                }
            }
            else
            {
                throw new ArgumentNullException("can't add null list");
            }
        }
        public void AddByIndex(int index, int value)
        {
            if((index == 0 && Length == 0)
                || (index >=0 && index < Length))
            {
                if (index > 0)
                {
                    Node current = GetNodeByIndex(index - 1);
                    Node newNode = new Node(value);

                    newNode.Next = current.Next;
                    current.Next = newNode;

                    ++Length;
                }
                else
                {
                    AddToStart(value);
                }
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }
        public void AddByIndex(int index, IList list)
        {
            if (!(list is null))
            {
                if ((index == 0 && Length == 0)
                || (index >= 0 && index < Length))
                {
                    if (list.Length > 0)
                    {
                        LinkedList addList = LinkedList.Create(list.ToArray());

                        if (index > 0 && index < Length)
                        {
                            Node prev = GetNodeByIndex(index - 1);

                            addList._tail.Next = prev.Next;
                            prev.Next = addList._root;

                            Length += addList.Length;
                        }
                        else if (index == 0)
                        {
                            AddToStart(addList);
                        }
                        else
                        {
                            Add(addList);
                        }
                    }
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
            else
            {
                throw new ArgumentNullException("can't add null list");
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
            if (Length > 0)
            {
                --Length;
                _root = _root.Next;
            }
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
            if ((index == 0 && Length == 0)
                || (index >= 0 && index < Length))
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
                        --Length;
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
            if (index >= 0 && index < Length)
            {
                int elementsLeft = Length - index;

                if (quontity <= elementsLeft && quontity >= 0)
                {
                    if (quontity < elementsLeft)
                    {
                        if (quontity > 0)
                        {
                            if (index > 0)
                            {
                                Node prev = GetNodeByIndex(index - 1);
                                Node next = GetNodeByIndex(index + quontity);
                                prev.Next = next;

                                Length -= quontity;
                            }
                            else
                            {
                                RemoveAtStart(quontity);
                            }
                        }
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
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public int FindIndexOf (int value)
        {
            Node current = _root;
            for (int i = 0; i < Length; ++i)
            {
                if (current.Value == value)
                {
                    return i;
                }
                current = current.Next;
            }

            return -1;
        }

        public void Reverse()
        {
            if (!(this is null))
            {
                if (Length > 1)
                {
                    _tail.Next = _root;
                    Node oneStep = _root.Next;
                    Node secondStep = _root.Next.Next;
                    _root.Next = null;

                    while (!(secondStep is null))
                    {
                        if (secondStep.Next is null)
                        {
                            _tail = _tail.Next;
                        }
                        oneStep.Next = _root;
                        _root = oneStep;
                        oneStep = secondStep;
                        secondStep = secondStep.Next;
                    }
                }
            }
        }

        public int FindIndexOfMaximumElement()
        {
            if (Length > 0)
            {
                int max = _root.Value;
                int index = 0;
                Node tmp = _root.Next;
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
                throw new ArgumentException("");
            }
        }

        public int FindIndexOfMinimumElement()
        {
            if (Length > 0)
            {
                int min = _root.Value;
                int index = 0;
                Node tmp = _root.Next;
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
                throw new ArgumentException("");
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
            int index = FindIndexOf(value);
            while (index >= 0)
            {
                RemoveByIndex(index);
                index = FindIndexOf(value);
            }
        }

        public void Sort(bool isAscending)
        {
            if (!(this is null))
            {
                Node new_root = null;
                while (!(_root is null))
                {
                    Node tmp = _root;
                    _root = _root.Next;

                    if (new_root is null
                        || (tmp.Value < new_root.Value && isAscending)
                        || (tmp.Value > new_root.Value && !isAscending))
                    {
                        tmp.Next = new_root;

                        if (tmp.Next is null)
                        {
                            _tail = tmp;
                        }
                        new_root = tmp;
                    }
                    else
                    {
                        Node curent = new_root;

                        while ((!(curent.Next is null) && tmp.Value > curent.Next.Value && isAscending)
                            || !(curent.Next is null) && tmp .Value < curent.Next.Value && !isAscending)
                        {
                            curent = curent.Next;
                        }
                        tmp.Next = curent.Next;
                        if (tmp.Next is null)
                        {
                            _tail = tmp;
                        }
                        curent.Next = tmp;
                    }
                }
                _root = new_root;
            }
            else
            {
                throw new NullReferenceException("List is null");
            }
        }

        public int[] ToArray()
        {
            int[] array = new int[Length];
            int count = 0;
            Node curent = _root;
            while (!(curent is null))
            {
                array[count] = curent.Value;
                ++count;
                curent = curent.Next;
            }
            return array;
        }
        public override string ToString()
        {
            Node curent = _root;
            StringBuilder stringBuilder = new StringBuilder();

            while (!(curent is null))
            {
                stringBuilder.Append($"{curent.Value} ");
                curent = curent.Next;
            }
            return stringBuilder.ToString().Trim();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is null) || obj is LinkedList)
            {
                LinkedList list = (LinkedList)obj;
                bool isEqual = false;

                if (this.Length == list.Length)
                {
                    isEqual = true;
                    Node curentThis = this._root;
                    Node curentList = list._root;

                    while(!(curentThis is null))
                    {
                        if (curentThis.Value != curentList.Value)
                        {
                            isEqual = false;
                            break;
                        }
                        curentThis = curentThis.Next;
                        curentList = curentList.Next;
                    }
                }
                return isEqual;
            }
            throw new ArgumentException("Object is not LinkedList or is null");
        }
        private LinkedList(int[] array)
        {
            Length = 0;
            if (array.Length != 0)
            {
                for (int i = 0; i < array.Length; ++i)
                {
                    Add(array[i]);
                }
            }
            else
            {
                _root = null;
                _tail = null;
            }
        }
        private Node GetNodeByIndex(int index)
        {
            if (index >= 0 && index < Length)
            {
                Node current = _root;

                for (int i = 1; i <= index; i++)
                {
                    current = current.Next;
                }
                return current;
            }
            throw new IndexOutOfRangeException();
        }
    }
}
