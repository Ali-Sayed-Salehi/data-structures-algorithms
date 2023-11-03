
namespace DataStructures
{
    /// <summary>
    /// Array data structure that can automatically resize when the array gets full
    /// </summary>
    /// <typeparam name="T"> the type of the elements in the array </typeparam>
    public class DynamicArray<T>
    {
        private T[] array;
        private int size;
        private int capacity;

        public DynamicArray(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentException("Capacity must be greater than 0.");
            }

            this.array = new T[capacity];
            this.size = 0;
            this.capacity = capacity;
        }

        public T Get(int i)
        {
            if (i < 0 || i >= size)
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }
            return array[i];
        }

        public void Set(int i, T n)
        {
            if (i < 0 || i >= size)
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }
            array[i] = n;
        }

        public void PushBack(T n)
        {
            if (size == capacity)
            {
                Resize();
            }
            array[size] = n;
            size++;
        }

        public T PopBack()
        {
            if (size == 0)
            {
                throw new InvalidOperationException("Array is empty.");
            }
            size--;
            return array[size];
        }

        public int GetSize()
        {
            return size;
        }

        public int GetCapacity()
        {
            return capacity;
        }

        /// <summary>
        /// If the array is full, this method will double the size and copy
        /// the lements to the new array.
        /// </summary>
        private void Resize()
        {
            capacity *= 2;
            T[] newArray = new T[capacity];
            for (int i = 0; i < size; i++)
            {
                newArray[i] = array[i];
            }
            array = newArray;
        }
    }
}