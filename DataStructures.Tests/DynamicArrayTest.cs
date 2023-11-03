
using DataStructures;

namespace DataStructures.Tests
{

    [TestClass]
    public class DynamicArrayTests
    {
        [TestMethod]
        public void Constructor_WithValidCapacity_InitializesDynamicArray()
        {
            int capacity = 10;
            var dynamicArray = new DynamicArray<int>(capacity);

            Assert.AreEqual(capacity, dynamicArray.GetCapacity());
            Assert.AreEqual(0, dynamicArray.GetSize());
        }

        [TestMethod]
        [DataRow(-1)]
        [DataRow(0)]
        public void Constructor_WithInvalidCapacity_ThrowsArgumentException(int capacity)
        {
            Assert.ThrowsException<ArgumentException>(() => new DynamicArray<int>(capacity));
        }

        [TestMethod]
        public void PushBack_WithEnoughCapacity_AddsElement()
        {
            var dynamicArray = new DynamicArray<int>(5);
            dynamicArray.PushBack(1);

            Assert.AreEqual(1, dynamicArray.Get(0));
            Assert.AreEqual(1, dynamicArray.GetSize());
        }

        [TestMethod]
        public void PushBack_WithFullCapacity_ResizesAndAddsElement()
        {
            var dynamicArray = new DynamicArray<int>(1);
            dynamicArray.PushBack(1);

            Assert.AreEqual(1, dynamicArray.Get(0));
            Assert.AreEqual(1, dynamicArray.GetSize());

            dynamicArray.PushBack(2); // This should trigger a resize

            Assert.AreEqual(2, dynamicArray.Get(1));
            Assert.AreEqual(2, dynamicArray.GetCapacity());
            Assert.AreEqual(2, dynamicArray.GetSize());
        }

        [TestMethod]
        public void PopBack_WithElements_RemovesLastElement()
        {
            var dynamicArray = new DynamicArray<int>(5);
            dynamicArray.PushBack(1);
            dynamicArray.PushBack(2);
            dynamicArray.PushBack(3);

            var popped = dynamicArray.PopBack();

            Assert.AreEqual(3, popped);
            Assert.AreEqual(2, dynamicArray.GetSize());
        }

        [TestMethod]
        public void PopBack_WithEmptyArray_ThrowsInvalidOperationException()
        {
            var dynamicArray = new DynamicArray<int>(5);

            Assert.ThrowsException<InvalidOperationException>(() => dynamicArray.PopBack());
        }

        [TestMethod]
        public void Set_WithValidIndex_SetsElement()
        {
            var dynamicArray = new DynamicArray<int>(5);
            dynamicArray.PushBack(1);
            dynamicArray.PushBack(2);

            dynamicArray.Set(1, 42);

            Assert.AreEqual(42, dynamicArray.Get(1));
        }

        [TestMethod]
        [DataRow(-1)]
        [DataRow(2)]
        public void Set_WithInvalidIndex_ThrowsIndexOutOfRangeException(int index)
        {
            var dynamicArray = new DynamicArray<int>(5);
            dynamicArray.PushBack(1);

            Assert.ThrowsException<IndexOutOfRangeException>(() => dynamicArray.Set(index, 42));
        }
    }

}