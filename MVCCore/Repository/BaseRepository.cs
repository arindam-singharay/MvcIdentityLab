
using Dapper;
using System.Data;

namespace MVCCore.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly IDbConnection _dbConnection;
        public BaseRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<T>> LoadDataAsync(string storedProcName, object parameters = null)
        {
            if (_dbConnection.State != ConnectionState.Open)
            {
                _dbConnection.Open();
            }
            var result = await _dbConnection.QueryAsync<T>(
                 storedProcName,
                 parameters,
                 commandType: CommandType.StoredProcedure);
           return result;
        }

        public async Task<T> LoadSingleAsync(string storedProcName, object parameters = null)
        {
            if (_dbConnection.State != ConnectionState.Open)
            {
                _dbConnection.Open();
            }
            var result = await _dbConnection.QueryFirstOrDefaultAsync<T>(
                 storedProcName,
                 parameters,
                 commandType: CommandType.StoredProcedure);
            return result;
        }

        public async Task<int> SaveDataAsync(string storedProcName, object parameters = null)
        {
            if (_dbConnection.State != ConnectionState.Open)
            {
                _dbConnection.Open();
            }
                var result = await _dbConnection.ExecuteAsync(
                storedProcName,
                parameters,
                commandType: CommandType.StoredProcedure
                 );
            return result;
        }
    }
}
