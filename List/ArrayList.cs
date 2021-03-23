using System;

namespace List
{
    public class ArrayList
    {
        public int Length { get; private set; }
        const double LengthDelta = 1.33d; 

        private int[] _array;
        public int this[int index]
        {
            get
            {
                if (index < 0 || index >= Length)
                {
                    throw new IndexOutOfRangeException("Index is out of range");
                }
                return _array[index];
            }
            set
            {
                if (index < 0 || index >= Length)
                {
                    throw new IndexOutOfRangeException("Index is out of range");
                }
                _array[index] = value;
            }
        }

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
            Length = initArray.Length;
            int realLength = (int)(Length * LengthDelta + 1);
            _array = new int[realLength];
            for (int i = 0; i < Length; ++i)
            {
                _array[i] = initArray[i];
            }
        }

        public void Add(int value)
        {
            if (Length >= _array.Length)
            {
                this.Resize();
            }

            _array[Length] = value;

            ++Length;
        }

        public void AddList(ArrayList addList)
        {
            AddListByIndex(addList, Length);
        }
        public void AddToStart(int value)
        {
            if (Length >= _array.Length)
            {
                this.Resize();
            }

            for (int i = Length-1; i >= 0; --i)
            {
                _array[i + 1] = _array[i];
            }

            _array[0] = value;

            ++Length;
        }
        public void AddListToStart(ArrayList addList)
        {
            AddListByIndex(addList, 0);
        }
        public void AddByIndex(int value, int index)
        {
            if (index > Length || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            if (Length >= _array.Length)
            {
                this.Resize();
            }

            MoveBy(1, index);

            _array[index] = value;
        }
        public void AddListByIndex(ArrayList addList, int index)
        {
            if (index > Length || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            int quontity = addList.Length;

            MoveBy(quontity, index);

            int count = 0;

            for (int i = index; i < index + quontity; ++i)
            {
                _array[i] = addList[count];

                count++;
            }
            if (Length >= _array.Length)
            {
                this.Resize();
            }
        }
        public void Remove()
        {
            if (Length > 0)
            {
                --Length;
            }
            else
            {
                Length = 0;
            }
            if (Length * LengthDelta < _array.Length)
            {
                this.Resize();
            }
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
            if (Length * LengthDelta < _array.Length)
            {
                this.Resize();
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
            } else
            {
                throw new IndexOutOfRangeException();
            }
            if (Length * LengthDelta < _array.Length)
            {
                this.Resize();
            }
        }
        public void RemoveByIndex(int index, int quontity)
        {
            
            if (index >= 0 && index < Length && quontity <= Length - index)
            {
                for (int i = index; i < Length - quontity; ++i)
                {
                    _array[i] = _array[i + quontity];
                }

                Length -= quontity;
            }
            else if (index < 0 || index >= Length)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                throw new ArgumentException("Quontity can't be bigger than elements left");
            }
            if (Length * LengthDelta < _array.Length)
            {
                this.Resize();
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

        public int FindIndexOf(int value)
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
            int index = FindIndexOf(value);

            if (index >= 0)
            {
                RemoveByIndex(index);
            }
            if (Length * LengthDelta < _array.Length)
            {
                this.Resize();
            }
        }

        public void RemoveAllValues(int value)
        {
            while (FindIndexOf(value) >= 0)
            {
                RemoveFirstValue(value);
            }
            if (Length * LengthDelta < _array.Length)
            {
                this.Resize();
            }
        }

        public void Reverse()
        {
            for (int i = 0; i < Length / 2; i++)
            {
                int temp = _array[i];
                int index = Length - 1 - i;
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

        public override string ToString()
        {
            string result = string.Empty;
            for (int i = 0; i < Length; ++i)
            {
                result += _array[i] + " ";
            }
            return result;
        }
        public override bool Equals(object obj)
        {
            if (obj is ArrayList)
            {
                ArrayList list = (ArrayList)obj;
                if(this.Length != list.Length)
                {
                    return false;
                }
                for (int i = 0; i < Length; ++i)
                {
                    if (this._array[i] != list._array[i])
                    {
                        return false;
                    }
                }

                return true;
            } else
            {
                throw new ArgumentException("Wrong type (not comparable)");
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
        private void Resize()
        {
            int newLength = (int)(Length * LengthDelta + 1); 

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

        public override int GetHashCode()
        {
            return HashCode.Combine(Length, _array);
        }
    }
}
