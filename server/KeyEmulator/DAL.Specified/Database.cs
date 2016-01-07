using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace DAL.Specified {
  public class Database : IDatabase {
    protected string connectionString { get; set; }

    private int DeclareParameter(MySqlCommand command, string name, MySqlDbType type) {
      if (!command.Parameters.Contains(name)) {
        command.Parameters.Add(new MySqlParameter(name, type));
        return command.Parameters.Count - 1;
      } else throw new ArgumentException();
    }

    private MySqlConnection CreateOpenConnection() {
      MySqlConnection connection = null;
      try {
        connection = new MySqlConnection(connectionString);
        connection.Open();
      }
      catch {
        Console.WriteLine("An Error Occured: Connection to Database");
      }
      return connection;
    }

    public Database(string connectionString) {
      this.connectionString = connectionString;
    }

    public MySqlCommand CreateCommand(string command) {
      return new MySqlCommand(command);
    }

    public void DefineParameter(MySqlCommand command, string name, MySqlDbType type, object value) {
      int index = DeclareParameter(command, name, type);
      command.Parameters[index].Value = value;
    }

    public int ExecuteNonQuery(MySqlCommand command) {
      MySqlConnection connection = null;
      try {
        connection = GetOpenConnection();
        command.Connection = connection;
        return command.ExecuteNonQuery();
      }
      catch {
        return -1;
      }
      finally {
        ReleaseConnection(connection);
      }
    }

    public IDataReader ExecuteReader(MySqlCommand command) {
      MySqlConnection connection = null;
      try {
        connection = GetOpenConnection();
        command.Connection = connection;
        CommandBehavior commandBehavior = CommandBehavior.CloseConnection;
        return command.ExecuteReader(commandBehavior);
      }
      catch {
        if (connection != null)
          ReleaseConnection(connection);
        return null;
      }
    }

    public MySqlConnection GetOpenConnection() {
      return CreateOpenConnection();
    }

    public void ReleaseConnection(MySqlConnection connection) {
      if (connection != null)
        connection.Close();
    }
  }
}
