using System;

namespace List
{
    public class ArrayList
    {
        public int Length { get; private set; }

        private int[] _array;

        public ArrayList()
        {
            Length = 0;
            _array = new int[10];
        }

        public ArrayList(int value)
        {
            Length = 1;
            _array = new int[10];
            _array[0] = value;
        }

        public ArrayList(int[] initArray)
        {
            Length = 0;
            _array = new int[initArray.Length];
            for (int i = 0; i < initArray.Length; ++i)
            {
                Add(initArray[i]);
            }
        }

        public void Add(int value)
        {
            if (Length >= _array.Length)
            {
                Resize(true);
            }

            _array[Length] = value;

            ++Length;
        }

        public void PrintArrayList(ArrayList array)
        {
            for (int i = 0; i < Length; i++)
            {
                Console.Write($"{_array[i]} ");
            }
            Console.WriteLine(Environment.NewLine);
        }
        public void AddArray(int[] addArray)
        {
            int newLength = Length + addArray.Length;

            int[] tmpArray = new int[newLength];
            for (int i = 0; i < Length; ++i)
            {
                tmpArray[i] = _array[i];
            }
            for (int i = Length; i < newLength; ++i)
            {
                tmpArray[i] = addArray[i - Length];
            }

            Length = newLength;
            _array = tmpArray;
        }
        public void AddToStart(int value)
        {
            if (Length >= _array.Length)
            {
                Resize(true);
            }

            for (int i = Length; i >= 0; --i)
            {
                _array[i + 1] = _array[i];
            }

            _array[0] = value;

            ++Length;
        }
        public void AddArrayToStart(int[] addArray)
        {
            int quontity = addArray.Length;

            MoveBy(quontity, 0);

            for (int i = 0; i < quontity; ++i)
            {
                _array[i] = addArray[i];
            }
        }
        public void AddByIndex(int value, int index)
        {
            if (Length >= _array.Length)
            {
                Resize(true);
            }

            MoveBy(1, index);

            _array[index] = value;
        }
        public void AddArrayByIndex(int[] addArray, int index)
        {
            int quontity = addArray.Length;

            MoveBy(quontity, index);

            int count = 0;

            for (int i = index; i < index + quontity; ++i)
            {
                _array[i] = addArray[count];

                count++;
            }
        }
        public void Remove()
        {
            --Length;
        }
        public void Remove(int quontity)
        {
            if (quontity <= Length)
            {
                Length -= quontity;
            }
            else
            {
                throw new ArgumentException("quontity can't be bigger than Length");
            }
        }
        public void RemoveAtStart()
        {
            RemoveByIndex(0);
        }
        public void RemoveAtStart(int quontity)
        {
            RemoveByIndex(0, quontity);
        }
        public void RemoveByIndex(int index)
        {
            if (index >= 0 && index < Length)
            {
                for (int i = index; i < Length - 1; ++i)
                {
                    _array[i] = _array[i + 1];
                }

                --Length;
            }
        }
        public void RemoveByIndex(int index, int quontity)
        {
            if (index >= 0 && index < Length)
            {
                for (int i = index; i < Length - quontity; ++i)
                {
                    _array[i] = _array[i + quontity];
                }

                Length -= quontity;
            }
        }

        public int GetValueByIndex(int index)
        {
            if (index >= 0 && index < Length)
            {
                return _array[index];
            }

            throw new IndexOutOfRangeException("Index is out of range");
        }

        public void SetByIndex(int value, int index)
        {
            if (index >= 0 && index < Length)
            {
                _array[index] = value;
            }
            else
            {
                throw new IndexOutOfRangeException("Index is out of range");
            }
        }

        public int IndexOf(int value)
        {
            for (int i = 0; i < Length; ++i)
            {
                if (_array[i] == value)
                {
                    return i;
                }
            }

            return -1;
        }

        public void RemoveFirstValue(int value)
        {
            int index = IndexOf(value);

            if (index >= 0)
            {
                RemoveByIndex(index);
            }
        }

        public void RemoveAllValues(int value)
        {
            while (IndexOf(value) >= 0)
            {
                RemoveFirstValue(value);
            }
        }

        public void Reverse()
        {
            for (int i = 0; i < Length / 2; i++)
            {
                int temp = _array[i];
                int index = _array.Length - 1 - i;
                _array[i] = _array[index];
                _array[index] = temp;
            }
        }

        public int FindIndexOfMaximumElement()
        {
            int max = _array[0];
            int index = 0;
            for (int i = 1; i < Length; ++i)
            {
                if (_array[i] > max)
                {
                    max = _array[i];
                    index = i;
                }
            }
            return index;
        }

        public int FindIndexOfMinimumElement()
        {
            int min = _array[0];
            int index = 0;
            for (int i = 0; i < Length; ++i)
            {
                if (_array[i] < min)
                {
                    min = _array[i];
                    index = i;
                }
            }
            return index;
        }

        public int FindMaximumElement()
        {
            return _array[FindIndexOfMaximumElement()];
        }

        public int FindMinimumElement()
        {
            return _array[FindIndexOfMinimumElement()];
        }

        public void SortBubbleAscending()
        {
            int temp;
            for (int i = 0; i < Length; ++i)
            {
                for (int j = i + 1; j < Length; ++j)
                {
                    if (_array[i] > _array[j])
                    {
                        temp = _array[i];
                        _array[i] = _array[j];
                        _array[j] = temp;
                    }
                }
            }
        }

        public void SortInsertionDescending()
        {
            for (int i = 1; i < Length; i++)
            {
                int newElement = _array[i];
                int index = i - 1;
                while (index >= 0 && _array[index] < newElement)
                {
                    _array[index + 1] = _array[index];
                    index = index - 1;
                }
                _array[index + 1] = newElement;
            }
        }
        private void MoveBy(int quontity, int index)
        {
            int newLength = Length + quontity;

            MakeBiggerBy(quontity);

            for (int i = newLength - 1; i >= index; --i)
            {
                if (i >= quontity)
                {
                    _array[i] = _array[i - quontity];
                }
                else
                {
                    _array[i] = _array[i];
                }
            }

            Length = newLength;

        }

        private void MakeBiggerBy(int quontity)
        {
            int newLength = _array.Length + quontity;

            Rewrite(newLength);
        }
        private void Resize(bool isSmall)
        {
            int newLength = _array.Length;
            if (isSmall)
            {
                newLength = (int)(newLength * 1.33d + 1);
            }
            else
            {
                newLength = (int)(newLength * 0.87d + 1);
            }

            Rewrite(newLength);

        }

        private void Rewrite(int newLength)
        {
            int[] tmpArray = new int[newLength];

            for (int i = 0; i < Length; ++i)
            {
                tmpArray[i] = _array[i];
            }

            _array = tmpArray;
        }
    }
}
