using Dapper;
using System.Data;

namespace LaMindsTest.Infrastructure.IRepository
{
    public interface IDapperServices: IDisposable
    {
        T Get<T>(string sp, DynamicParameters parms,
            CommandType commandType=CommandType.StoredProcedure);

        List<T> GetAll<T>(string sp, DynamicParameters parms,
           CommandType commandType = CommandType.StoredProcedure);

        int ExeecuteScaler<T>(string sp, DynamicParameters parms,
           CommandType commandType = CommandType.StoredProcedure);
        List<T> GetAll<T>(string query, CommandType commandType);
        T Get<T>(string query, CommandType commandType);
    }
}
