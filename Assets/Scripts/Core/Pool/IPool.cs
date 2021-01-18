namespace TD.Pool
{
    public interface IPool<T>
    {
        void Prewarm(int amount);
        T Request();
        void Return(T obj);
    }
}