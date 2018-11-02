namespace Omnis.Common
{
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using System.Threading.Tasks;

    public class SqlConnectionFactory : IDbConnectionFactory
    {
        private readonly string connectionStringName;

        public SqlConnectionFactory(string connectionStringName)
        {
            this.connectionStringName = connectionStringName;
        }

        public async Task<IDbConnection> CreateAndOpenAsync()
        {
            var connection = new SqlConnection(
                ConfigurationManager.ConnectionStrings[this.connectionStringName].ConnectionString);

            await connection.OpenAsync().ConfigureAwait(false);
            return connection;
        }
    }
}