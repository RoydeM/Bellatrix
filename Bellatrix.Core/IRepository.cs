using System.Data;

namespace Bellatrix.Core
{
    public interface IRepository
    {
        IDbDataParameter CreateParameter(string name, object value);
        void Execute(string sql, params IDbDataParameter[] para);
    }
}