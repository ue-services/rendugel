using System.Collections.Generic;
using System.Data;

namespace Rendugel.Datos.Interface
{
    public interface IUnitOfWork
    {
        IEnumerable<T> ExecuteReader<T>(string sqlText, Dictionary<string, object> parameters = null, int? commandTimeout = null);
        IEnumerable<T> ExecuteReader<T>(string sqlText, CommandType commandType = CommandType.StoredProcedure, Dictionary<string, object> parameters = null, int? commandTimeout = null);
        string ExecuteXmlReader(string sqlText, Dictionary<string, object> parameters = null, int? commandTimeout = default(int?));
    }
}
