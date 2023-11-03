using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructures.Tests
{
    [TestClass]
    public class LinkedListTests
    {
        [TestMethod]
        public void Get_EmptyList_ReturnsDefault()
        {
            LinkedList<int> list = new LinkedList<int>();
            int result = list.Get(0);

            Assert.AreEqual(default(int), result);
        }

        [TestMethod]
        public void InsertHead_InsertOneElement()
        {
            LinkedList<int> list = new LinkedList<int>();
            list.InsertHead(42);

            int result = list.Get(0);

            Assert.AreEqual(42, result);
        }

        [TestMethod]
        public void InsertTail_InsertOneElement()
        {
            LinkedList<int> list = new LinkedList<int>();
            list.InsertTail(42);

            int result = list.Get(0);

            Assert.AreEqual(42, result);
        }

        [TestMethod]
        public void Remove_EmptyList_ReturnsFalse()
        {
            LinkedList<int> list = new LinkedList<int>();
            bool result = list.Remove(0);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Remove_RemoveHeadElement()
        {
            LinkedList<int> list = new LinkedList<int>();
            list.InsertHead(42);

            bool result = list.Remove(0);

            Assert.IsTrue(result);
            Assert.AreEqual(0, list.GetValues().Length);
        }

        [TestMethod]
        public void GetValues_EmptyList_ReturnsEmptyArray()
        {
            LinkedList<int> list = new LinkedList<int>();
            int[] result = list.GetValues();

            CollectionAssert.AreEqual(new int[0], result);
        }

        [TestMethod]
        public void GetValues_ListWithMultipleElements_ReturnsCorrectArray()
        {
            LinkedList<int> list = new LinkedList<int>();
            list.InsertTail(1);
            list.InsertTail(2);
            list.InsertTail(3);

            int[] result = list.GetValues();

            CollectionAssert.AreEqual(new int[] { 1, 2, 3 }, result);
        }
    }
}