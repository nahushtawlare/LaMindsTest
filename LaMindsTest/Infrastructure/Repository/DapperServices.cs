using Dapper;
using LaMindsTest.Infrastructure.IRepository;
using Microsoft.Data.SqlClient;
using System.Data;


namespace LaMindsTest.Infrastructure.Repository
{

    public class DapperServices : IDapperServices
    {
        private readonly IConfiguration config;
        private string Connectionstring = "DefaultConnection";

        public DapperServices(IConfiguration config)
        {
            this.config = config;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public int ExecuteScaler<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            IDbConnection db = new SqlConnection(this.config.GetConnectionString(Connectionstring));
            return db.Execute(sp, parms, commandType: commandType);
        }

        public int ExeecuteScaler<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            throw new NotImplementedException();
        }

        public T Get<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            IDbConnection db = new SqlConnection(this.config.GetConnectionString(Connectionstring));
            return db.Query<T>(sp,parms,  commandType: commandType).FirstOrDefault();
        }

        public T Get<T>(string query, CommandType commandType)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            IDbConnection db = new SqlConnection(this.config.GetConnectionString(Connectionstring));
            return db.Query<T>(sp, parms, commandType: commandType).ToList();
        }

        public List<T> GetAll<T>(string query, CommandType commandType)
        {
            throw new NotImplementedException();
        }
    }
}
