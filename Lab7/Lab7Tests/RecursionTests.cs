using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7.Tests
{
    [TestClass()]
    public class RecursionTests
    {
        [TestMethod()]
        public void ReverseTest1()
        {
            Stack<int> stack1 = new Stack<int>();
            stack1.Push(3);
            stack1.Push(2);
            stack1.Push(1);
            Stack<int> stack2 = new Stack<int>(); 
            Recursion.Reverse(stack1, stack2);
            Assert.AreEqual(3, stack2.Pop());
            Assert.AreEqual(2, stack2.Pop());
            Assert.AreEqual(1, stack2.Pop());
        }
        [TestMethod()]
        public void ReverseTest2()
        {
            Stack<int> stack1 = new Stack<int>();
            stack1.Push(0);
            stack1.Push(-1);
            stack1.Push(1);
            Stack<int> stack2 = new Stack<int>(); 
            Recursion.Reverse(stack1, stack2);
            Assert.AreEqual(0, stack2.Pop());
            Assert.AreEqual(-1, stack2.Pop());
            Assert.AreEqual(1, stack2.Pop());
        }
        [TestMethod()]
        public void ReverseTest3()
        {
            Stack<int> stack1 = new Stack<int>();
            stack1.Push(10000);
            stack1.Push(-10000);
            Stack<int> stack2 = new Stack<int>(); 
            Recursion.Reverse(stack1, stack2);
            Assert.AreEqual(10000, stack2.Pop());
            Assert.AreEqual(-10000, stack2.Pop());
        }

        [TestMethod()]
        public void SubsetTest1()
        {
            List<int> list1 = new List<int> { 1, 2, 3, 4 };
            List<int> list2 = new List<int> {1, 2, 3};

            Assert.IsTrue(Recursion.IsASubset(list2, list1)); 
        }
        [TestMethod()]
        public void SubsetTest2()
        {
            List<int> list1 = new List<int> {0, 1, -1};
            List<int> list2 = new List<int> {1, -1};

            Assert.IsTrue(Recursion.IsASubset(list2, list1)); 
        }
        [TestMethod()]
        public void SubsetTest3()
        {
            List<int> list1 = new List<int> { 1, 2, 3, 4 };
            List<int> list2 = new List<int> {};

            Assert.IsTrue(Recursion.IsASubset(list2, list1)); 
        }
        [TestMethod()]
        public void SubsetTest4()
        {
            List<int> list1 = new List<int> { 1, 2, 3, 4 };
            List<int> list2 = new List<int> {1, 6};

            Assert.IsFalse(Recursion.IsASubset(list2, list1)); 
        }
        [TestMethod()]
        public void SubsetTest5()
        {
            List<int> list1 = new List<int> {1, 2, 4};
            List<int> list2 = new List<int> {2, 2, 2, 2};

            Assert.IsTrue(Recursion.IsASubset(list2, list1)); 
        }
        [TestMethod()]
        public void SubsetTest6()
        {
            List<int> list1 = new List<int> {1, 2, 4};
            List<int> list2 = new List<int> {2, 2, 3};

            Assert.IsFalse(Recursion.IsASubset(list2, list1)); 
        }

        [TestMethod()]
        public void ToBinaryTest1()
        {
            Assert.AreEqual("1111011", Recursion.ToBinary(123)); 
        }
        [TestMethod()]
        public void ToBinaryTest2()
        {
            Assert.AreEqual("111", Recursion.ToBinary(7)); 
        }
        [TestMethod()]
        public void ToBinaryTest3()
        {
            Assert.AreEqual("10001", Recursion.ToBinary(17)); 
        }
    }
}