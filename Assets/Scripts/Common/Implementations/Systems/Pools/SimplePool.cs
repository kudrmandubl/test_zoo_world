
using Common.Interfaces;

namespace Common.Implementations.Systems.Pools
{
    public class SimplePool<T> : BasePool<T>, IPool<T> where T : class, new()
    {
        public SimplePool() : base() { }

        protected override T GetNew()
        {
            return new T();
        }
    }
}