
using DataStructures;

namespace DataStructures.Tests
{
    [TestClass]
    public class DynamicArrayTest
    {
        [TestMethod]
        public void TestDynamicArrayConstructor()
        {
            // Arrange
            int capacity = 10;

            // Act
            var dynamicArray = new DynamicArray<int>(capacity);

            // Assert
            Assert.AreEqual(capacity, dynamicArray.GetCapacity());
            Assert.AreEqual(0, dynamicArray.GetSize());
        }

        [TestMethod]
        public void TestDynamicArrayPushBack()
        {
            // Arrange
            var dynamicArray = new DynamicArray<int>(3);

            // Act
            dynamicArray.PushBack(42);

            // Assert
            Assert.AreEqual(1, dynamicArray.GetSize());
            Assert.AreEqual(3, dynamicArray.GetCapacity()); // Capacity should not change yet
            Assert.AreEqual(42, dynamicArray.Get(0));
        }

        [TestMethod]
        public void TestDynamicArrayResize()
        {
            // Arrange
            var dynamicArray = new DynamicArray<int>(2);

            // Act
            dynamicArray.PushBack(1);
            dynamicArray.PushBack(2);
            dynamicArray.PushBack(3); // This will trigger a resize

            // Assert
            Assert.AreEqual(3, dynamicArray.GetSize());
            Assert.AreEqual(4, dynamicArray.GetCapacity()); // Capacity should double to accommodate the third element
            Assert.AreEqual(1, dynamicArray.Get(0));
            Assert.AreEqual(2, dynamicArray.Get(1));
            Assert.AreEqual(3, dynamicArray.Get(2));
        }

        [TestMethod]
        public void TestDynamicArrayPopBack()
        {
            // Arrange
            var dynamicArray = new DynamicArray<int>(3);
            dynamicArray.PushBack(1);
            dynamicArray.PushBack(2);

            // Act
            int poppedValue = dynamicArray.PopBack();

            // Assert
            Assert.AreEqual(1, dynamicArray.GetSize());
            Assert.AreEqual(2, poppedValue);
        }

    }
}