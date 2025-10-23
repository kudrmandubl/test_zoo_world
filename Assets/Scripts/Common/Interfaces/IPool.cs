
namespace Common.Interfaces
{
    public interface IPool<T> where T : class, new()
    {
        T GetFreeElement();

        void Free(T element);
    }
}