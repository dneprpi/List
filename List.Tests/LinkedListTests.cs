using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace List.Tests
{
    class LinkedListTests
    {
        [TestCase(100, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5, 100 })]
        [TestCase(-10, new int[] { 0 }, new int[] { 0, -10 })]
        [TestCase(0, new int[] { }, new int[] { 0 })]
        public void Add_WhenValidValuePassed_ShouldAddToListInLastPosition(int value, int[] actualArray, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(actualArray);
            LinkedList expected = new LinkedList(expectedArray);

            actual.Add(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(100, new int[] { 1, 2, 3, 4, 5 }, new int[] { 100, 1, 2, 3, 4, 5, })]
        [TestCase(-10, new int[] { 0 }, new int[] { -10, 0 })]
        [TestCase(0, new int[] { 1 }, new int[] { 0, 1 })]
        public void AddToStart_WhenValidValuePassed_ShouldAddToListInFirstPosition(int value, int[] actualArray, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(actualArray);
            LinkedList expected = new LinkedList(expectedArray);

            actual.AddToStart(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(100, 0, new int[] { 1, 2, 3, 4, 5 }, new int[] { 100, 1, 2, 3, 4, 5 })]
        [TestCase(100, 1, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 100, 2, 3, 4, 5 })]
        [TestCase(100, 3, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 100, 4, 5 })]
        [TestCase(100, 4, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 100, 5 })]
        [TestCase(100, 5, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5, 100 })]
        [TestCase(10, 0, new int[] { }, new int[] { 10 })]
        [TestCase(10, 0, new int[] { 1 }, new int[] { 10, 1 })]
        [TestCase(10, 1, new int[] { 1 }, new int[] { 1, 10 })]
        [TestCase(10, 0, new int[] { 1, 2 }, new int[] { 10, 1, 2 })]
        [TestCase(10, 1, new int[] { 1, 2 }, new int[] { 1, 10, 2 })]
        public void AddByIndex_WhenValidDataPassed_ShouldAddToListInIndexPosition(int value, int index, int[] actualArray, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(actualArray);
            LinkedList expected = new LinkedList(expectedArray);

            actual.AddByIndex(value, index);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 1, 2 }, new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 })]
        [TestCase(new int[] { 1 }, new int[] { })]
        [TestCase(new int[] { }, new int[] { })]


        public void Remove_WhenNothingPassed_ShouldRemoveLastElement(int[] actualArray, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(actualArray);
            LinkedList expected = new LinkedList(expectedArray);

            actual.Remove();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2 }, new int[] { 2 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, new int[] { 2, 3, 4, 5, 6, 7, 8, 9, 10 })]
        [TestCase(new int[] { 1 }, new int[] { })]

        public void RemoveAtStart_WhenNothingPassed_ShouldRemoveFirstElement(int[] actualArray, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(actualArray);
            LinkedList expected = new LinkedList(expectedArray);

            actual.RemoveAtStart();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(4, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, })]
        [TestCase(1, new int[] { 1, 2 }, new int[] { 1 })]
        [TestCase(5, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, new int[] { 1, 2, 3, 4, 5, 7, 8, 9, 10 })]
        [TestCase(0, new int[] { 1 }, new int[] { })]

        public void RemoveByIndex_WhenValidIndexPassed_ShouldRemoveIndexElement(int index, int[] actualArray, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(actualArray);
            LinkedList expected = new LinkedList(expectedArray);

            actual.RemoveByIndex(index);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(3, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2 })]
        [TestCase(2, new int[] { 1, 2 }, new int[] { })]
        [TestCase(7, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, new int[] { 1, 2, 3 })]
        [TestCase(1, new int[] { 1 }, new int[] { })]

        public void RemoveNElements_WhenValidQuontityPassed_ShouldRemoveLastNElements(int quontity, int[] actualArray, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(actualArray);
            LinkedList expected = new LinkedList(expectedArray);

            actual.Remove(quontity);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(3, new int[] { 1, 2, 3, 4, 5 }, new int[] { 4, 5 })]
        [TestCase(2, new int[] { 1, 2 }, new int[] { })]
        [TestCase(9, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, new int[] { 10 })]
        [TestCase(1, new int[] { 1 }, new int[] { })]

        public void RemoveAtStartNElements_WhenValidQuolityPassed_ShouldRemoveFirstNElements(int quontity, int[] actualArray, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(actualArray);
            LinkedList expected = new LinkedList(expectedArray);

            actual.RemoveAtStart(quontity);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(2, 3, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2 })]
        [TestCase(0, 2, new int[] { 1, 2 }, new int[] { })]
        [TestCase(5, 5, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(5, 3, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, new int[] { 1, 2, 3, 4, 5, 9, 10 })]
        [TestCase(0, 1, new int[] { 1 }, new int[] { })]

        public void RemoveByIndexNElements_WhenValidDataPassed_ShouldRemoveFromIndexNElements(int index, int quontity, int[] actualArray, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(actualArray);
            LinkedList expected = new LinkedList(expectedArray);

            actual.RemoveByIndex(index, quontity);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(2, new int[] { 1, 2, 3, 4, 5 }, 3)]
        [TestCase(0, new int[] { 1, 2 }, 1)]
        [TestCase(5, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 6)]
        [TestCase(0, new int[] { 1 }, 1)]

        public void GetValueByIndex_WhenValidIndexPassed_ShouldReturnElementByIndex(int index, int[] array, int expected)
        {
            LinkedList arrayActual = new LinkedList(array);

            int actual = arrayActual.GetValueByIndex(index);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(2, new int[] { 1, 2, 3, 4, 5 }, 1)]
        [TestCase(0, new int[] { 1, 2 }, -1)]
        [TestCase(5, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 5, 10 }, 4)]
        [TestCase(1, new int[] { 1 }, 0)]

        public void FindIndexOf_WhenValidValuePassed_ShouldReturnIndex(int value, int[] array, int expected)
        {
            LinkedList arrayActual = new LinkedList(array);

            int actual = arrayActual.FindIndexOf(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(2, 3, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 2, 5 })]
        [TestCase(0, 1, new int[] { 1, 2 }, new int[] { 1, 0 })]
        [TestCase(5, 5, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, new int[] { 1, 2, 3, 4, 5, 5, 7, 8, 9, 10 })]
        [TestCase(10, 0, new int[] { 1 }, new int[] { 10 })]

        public void SetByIndex_WhenValidDataPassed_ShouldChangeValueByIndex(int value, int index, int[] actualArray, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(actualArray);
            LinkedList expected = new LinkedList(expectedArray);

            actual.SetByIndex(value, index);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 5, 4, 3, 2, 1 })]
        [TestCase(new int[] { 1, 2 }, new int[] { 2, 1 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 })]
        [TestCase(new int[] { 1 }, new int[] { 1 })]
        [TestCase(new int[] { }, new int[] { })]

        public void Reverse_WhenNothingPassed_ShouldReverseArrayList(int[] actualArray, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(actualArray);
            LinkedList expected = new LinkedList(expectedArray);

            actual.Reverse();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4)]
        [TestCase(new int[] { 1, 2 }, 1)]
        [TestCase(new int[] { 1, 2, 3, 4, 15, 6, 7, 8, 9, 10 }, 4)]
        [TestCase(new int[] { 1 }, 0)]

        public void FindIndexOfMaximumElement_WhenNothingPassed_ShouldReturnIndexOfMaximumElement(int[] array, int expected)
        {
            LinkedList arrayActual = new LinkedList(array);

            int actual = arrayActual.FindIndexOfMaximumElement();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0)]
        [TestCase(new int[] { 1, 2 }, 0)]
        [TestCase(new int[] { 15, 22, 3, 4, 15, 6, 7, 3, 9, 10 }, 2)]
        [TestCase(new int[] { 15 }, 0)]

        public void FindIndexOfMinimumElement_WhenNothingPassed_ShouldReturnIndexOfMinimumElement(int[] array, int expected)
        {
            LinkedList arrayActual = new LinkedList(array);

            int actual = arrayActual.FindIndexOfMinimumElement();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 5)]
        [TestCase(new int[] { 1, 2 }, 2)]
        [TestCase(new int[] { 1, 2, 3, 4, 15, 6, 7, 8, 9, 10 }, 15)]
        [TestCase(new int[] { 1 }, 1)]

        public void FindMaximumElement_WhenNothingPassed_ShouldReturnMaximumElement(int[] array, int expected)
        {
            LinkedList arrayActual = new LinkedList(array);

            int actual = arrayActual.FindMaximumElement();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 1)]
        [TestCase(new int[] { 1, 2 }, 1)]
        [TestCase(new int[] { 15, 22, 3, 4, 15, 6, 7, 3, 9, 10 }, 3)]
        [TestCase(new int[] { 15 }, 15)]

        public void FindMinimumElement_WhenNothingPassed_ShouldReturnMinimumElement(int[] array, int expected)
        {
            LinkedList arrayActual = new LinkedList(array);

            int actual = arrayActual.FindMinimumElement();

            Assert.AreEqual(expected, actual);
        }


        [TestCase(22, new int[] { 22, 1, 3, 14, 5 }, new int[] { 1, 3, 14, 5 })]
        [TestCase(22, new int[] { 1, 22, 3, 14, 5 }, new int[] { 1, 3, 14, 5 })]
        [TestCase(22, new int[] { 1, 3, 14, 5, 22 }, new int[] { 1, 3, 14, 5 })]
        [TestCase(2, new int[] { 1, 2 }, new int[] { 1 })]
        [TestCase(3, new int[] { 1, 22, 3, 3, 5, 46, 7, 3, 59, 10 }, new int[] { 1, 22, 3, 5, 46, 7, 3, 59, 10 })]
        [TestCase(1, new int[] { 1 }, new int[] { })]
        [TestCase(22, new int[] { }, new int[] { })]
        [TestCase(22, new int[] { 22 }, new int[] { })]

        public void RemoveFirstValue_WhenValidValuePassed_ShouldRemoveFirstValue(int value, int[] actualArray, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(actualArray);
            LinkedList expected = new LinkedList(expectedArray);

            actual.RemoveFirstValue(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(22, new int[] { 1, 22, 3, 14, 5 }, new int[] { 1, 3, 14, 5 })]
        [TestCase(22, new int[] { 22, 1, 22, 3, 14, 5 }, new int[] { 1, 3, 14, 5 })]
        [TestCase(22, new int[] { 22, 22, 1, 22, 3, 14, 5, 22, 22 }, new int[] { 1, 3, 14, 5 })]
        [TestCase(2, new int[] { 1, 2, 3, 4, 2, 1 }, new int[] { 1, 3, 4, 1 })]
        [TestCase(3, new int[] { 1, 22, 3, 3, 5, 46, 7, 3, 59, 10 }, new int[] { 1, 22, 5, 46, 7, 59, 10 })]
        [TestCase(1, new int[] { 1 }, new int[] { })]
        [TestCase(22, new int[] { }, new int[] { })]

        public void RemoveAllValues_WhenValidValuePassed_ShouldRemoveAllValues(int value, int[] actualArray, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(actualArray);
            LinkedList expected = new LinkedList(expectedArray);

            actual.RemoveAllValues(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 6, 7, 8, 9 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 })]
        [TestCase(new int[] { 1 }, new int[] { 2 }, new int[] { 1, 2 })]
        [TestCase(new int[] { 1, 2, 3, 3, 5 }, new int[] { }, new int[] { 1, 2, 3, 3, 5 })]
        [TestCase(new int[] { 1 }, new int[] { }, new int[] { 1 })]
        [TestCase(new int[] { }, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 })]

        public void AddList_WhenValidListPassed_ShouldAddListInTheEnd(int[] actualArray, int[] addArray, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(actualArray);
            LinkedList addList = new LinkedList(addArray);
            LinkedList expected = new LinkedList(expectedArray);

            actual.AddLinkedList(addList);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 6, 7, 8, 9 }, new int[] { 6, 7, 8, 9, 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1 }, new int[] { 2 }, new int[] { 2, 1 })]
        [TestCase(new int[] { 1, 2, 3, 3, 5 }, new int[] { }, new int[] { 1, 2, 3, 3, 5 })]
        [TestCase(new int[] { 1 }, new int[] { }, new int[] { 1 })]
        [TestCase(new int[] { }, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 })]

        public void AddListToStart_WhenValidListPassed_ShouldAddListToStart(int[] actualArray, int[] addArray, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(actualArray);
            LinkedList addList = new LinkedList(addArray);
            LinkedList expected = new LinkedList(expectedArray);

            actual.AddLinkedListToStart(addList);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(2, new int[] { 1, 2, 3, 4, 5 }, new int[] { 6, 7, 8, 9 }, new int[] { 1, 2, 6, 7, 8, 9, 3, 4, 5 })]
        [TestCase(1, new int[] { 1 }, new int[] { 2 }, new int[] { 1, 2 })]
        [TestCase(3, new int[] { 1, 2, 3, 3, 5 }, new int[] { 0 }, new int[] { 1, 2, 3, 0, 3, 5 })]
        [TestCase(1, new int[] { 1 }, new int[] { }, new int[] { 1 })]
        [TestCase(0, new int[] { }, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 })]

        public void AddListByIndex_WhenValidListPassed_ShouldAddListAfterIndex(int index, int[] actualArray, int[] addArray, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(actualArray);
            LinkedList addList = new LinkedList(addArray);
            LinkedList expected = new LinkedList(expectedArray);

            actual.AddLinkedListToIndex(addList, index);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 22, 3, 14, 5 }, new int[] { 1, 3, 5, 14, 22 })]
        [TestCase(new int[] { 1, 2 }, new int[] { 1, 2 })]
        [TestCase(new int[] { 1, 22, 3, 14, 5, 46, 7, 38, 59, 10 }, new int[] { 1, 3, 5, 7, 10, 14, 22, 38, 46, 59 })]
        [TestCase(new int[] { 1 }, new int[] { 1 })]
        [TestCase(new int[] { }, new int[] { })]

        public void SortAscending_WhenNothingPassed_ShouldSortArrayList(int[] actualArray, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(actualArray);
            LinkedList expected = new LinkedList(expectedArray);

            actual.SortMergeAscending();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 22, 3, 14, 5 }, new int[] { 22, 14, 5, 3, 1 })]
        [TestCase(new int[] { 1, 2 }, new int[] { 2, 1 })]
        [TestCase(new int[] { 1, 22, 3, 14, 5, 46, 7, 38, 59, 10 }, new int[] { 59, 46, 38, 22, 14, 10, 7, 5, 3, 1 })]
        [TestCase(new int[] { 1 }, new int[] { 1 })]
        [TestCase(new int[] { }, new int[] { })]

        public void SortDescending_WhenNothingPassed_ShouldSortArrayList(int[] actualArray, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(actualArray);
            LinkedList expected = new LinkedList(expectedArray);

            actual.SortMergeDescending();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 22, 3, 14, 5 }, new int[] { 1, 3, 5, 14, 22 })]
        [TestCase(new int[] { 1, 2 }, new int[] { 1, 2 })]
        [TestCase(new int[] { 1, 22, 3, 14, 5, 46, 7, 38, 59, 10 }, new int[] { 1, 3, 5, 7, 10, 14, 22, 38, 46, 59 })]
        [TestCase(new int[] { 1 }, new int[] { 1 })]
        [TestCase(new int[] { }, new int[] { })]

        public void SortIsertionAscending_WhenNothingPassed_ShouldSortArrayList(int[] actualArray, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(actualArray);
            LinkedList expected = new LinkedList(expectedArray);

            actual.SortInsertionAscending();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 22, 3, 14, 5 }, new int[] { 22, 14, 5, 3, 1 })]
        [TestCase(new int[] { 1, 2 }, new int[] { 2, 1 })]
        [TestCase(new int[] { 1, 22, 3, 14, 5, 46, 7, 38, 59, 10 }, new int[] { 59, 46, 38, 22, 14, 10, 7, 5, 3, 1 })]
        [TestCase(new int[] { 1 }, new int[] { 1 })]
        [TestCase(new int[] { }, new int[] { })]

        public void SortInsertionDescending_WhenNothingPassed_ShouldSortArrayList(int[] actualArray, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(actualArray);
            LinkedList expected = new LinkedList(expectedArray);

            actual.SortInsertionDescending();

            Assert.AreEqual(expected, actual);
        }
    }
}
