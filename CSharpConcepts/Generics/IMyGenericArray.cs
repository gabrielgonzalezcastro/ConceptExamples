
namespace Generics
{
    public interface IMyGenericArray<T>
    {
        T GetItem(int index);
        void SetItem(int index, T value);
    }
}
