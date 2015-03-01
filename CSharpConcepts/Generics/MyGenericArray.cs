namespace Generics
{
    public class MyGenericArray<T> : IMyGenericArray<T>
    {
        private T[] array;
        public MyGenericArray(int size)
        {
            array = new T[size + 1];
        }
        public T GetItem(int index)
        {
            return array[index];
        }
        public void SetItem(int index, T value)
        {
            array[index] = value;
        }
    }
}
