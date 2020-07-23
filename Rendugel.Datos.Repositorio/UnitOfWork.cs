using System;
using System.Collections.Generic;
using System.Linq;
using Rendugel.Datos.Interface;
using Rendugel.Datos.Modelo;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace Rendugel.Datos.Repositorio
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        //private readonly DbContext _context;
        private readonly rendugelDBContext _context;

        //public UnitOfWork(DbContext context)
        public UnitOfWork(rendugelDBContext context)
        {
            _context = context;
        }

        public IEnumerable<T> ExecuteReader<T>(string sqlText, Dictionary<string, object> parameters = null, int? commandTimeout = null)
        {
            return ExecuteReader<T>(sqlText, CommandType.StoredProcedure, parameters, commandTimeout);
        }

        public IEnumerable<T> ExecuteReader<T>(string sqlText, CommandType commandType = CommandType.StoredProcedure, Dictionary<string, object> parameters = null, int? commandTimeout = null)
        {
            var items = new List<T>();
            using (var cmd = _context.Database.GetDbConnection().CreateCommand())
            {
                if (cmd.Connection.State != ConnectionState.Open)
                    cmd.Connection.Open();

                cmd.Parameters.Clear();
                cmd.CommandText = sqlText;
                cmd.CommandType = commandType;
                cmd.CommandTimeout = commandTimeout.HasValue ? commandTimeout.Value : cmd.CommandTimeout;

                if (parameters != null)
                {
                    var arrp = parameters.Select(p => new SqlParameter(p.Key, p.Value ?? (object)DBNull.Value)).ToArray();
                    cmd.Parameters.AddRange(arrp);
                }

                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        int fc = dr.FieldCount;

                        var colums = new Dictionary<int, string>();
                        for (int i = 0; i < fc; i++)
                            colums.Add(i, dr.GetName(i));

                        object[] values = new object[fc];

                        while (dr.Read())
                        {
                            dr.GetValues(values); //Get All Values
                            T item = Activator.CreateInstance<T>();
                            var props = item.GetType().GetProperties();

                            foreach (var p in props)
                            {
                                foreach (var col in colums)
                                {
                                    if (p.Name != col.Value) continue;

                                    var value = values[col.Key];
                                    if (value.GetType() != typeof(DBNull))
                                    {
                                        p.SetValue(item, value, null);
                                    }
                                }
                            }
                            items.Add(item);
                        }
                    }
                }

                cmd.Parameters.Clear();
                cmd.Connection.Close();
            }
            return items;
        }

        public string ExecuteXmlReader(string sqlText, Dictionary<string, object> parameters = null, int? commandTimeout = null)
        {
            string StrXml = "";
            string cnx = _context.Database.GetDbConnection().ConnectionString;

            using (SqlConnection conn = new SqlConnection(cnx))
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                using (SqlCommand cmd = new SqlCommand(sqlText, conn))
                {
                    cmd.Parameters.Clear();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = commandTimeout.HasValue ? commandTimeout.Value : cmd.CommandTimeout;

                    if (parameters != null)
                    {
                        var arrp = parameters.Select(p => new SqlParameter(p.Key, p.Value ?? (object)DBNull.Value)).ToArray();
                        cmd.Parameters.AddRange(arrp);
                    }

                    using (System.Xml.XmlReader reader = cmd.ExecuteXmlReader())
                    {
                        while (reader.Read())
                        {
                            StrXml = reader.ReadOuterXml();
                        }
                    }
                    return StrXml;
                }
            }
        }
        public void Dispose()
        {
            return;
        }
    }
}
