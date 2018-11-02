namespace Omnis.Common
{
    using System.Data;
    using System.Threading.Tasks;

    public interface IDbConnectionFactory
    {
        Task<IDbConnection> CreateAndOpenAsync();
    }
}