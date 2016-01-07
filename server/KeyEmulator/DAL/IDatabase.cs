using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DAL {
  public interface IDatabase {
    MySqlConnection GetOpenConnection();
    void ReleaseConnection(MySqlConnection connection);
    MySqlCommand CreateCommand(string command);
    void DefineParameter(MySqlCommand command, string name, MySqlDbType type, object value);
    int ExecuteNonQuery(MySqlCommand command);
    IDataReader ExecuteReader(MySqlCommand command);
  }
}
