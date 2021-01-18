namespace TD.Factory
{
    public interface IFactory<T>
    {
        T Create();
    }
}