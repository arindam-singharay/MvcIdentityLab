namespace MVCCore.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IEnumerable<T>> LoadDataAsync(string storedProcName, object parameters = null);
        Task<T> LoadSingleAsync(string storedProcName, object parameters = null);
        Task<int> SaveDataAsync(string storedProcName, object parameters = null);

    }
}
