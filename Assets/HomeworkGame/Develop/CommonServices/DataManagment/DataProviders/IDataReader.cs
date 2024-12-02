public interface IDataReader<TData> where TData : ISaveData
{
    void ReadFrom(TData data);
}