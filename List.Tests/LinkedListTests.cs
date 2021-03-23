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
    }
}
