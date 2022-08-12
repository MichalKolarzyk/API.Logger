namespace API.Logger.DataStorage
{
    public interface IDataStorage<T>
    {
        public void Store(T item);

        public T Read();
    }
}
