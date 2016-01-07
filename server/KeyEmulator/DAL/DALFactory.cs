using System;
using System.Configuration;
using System.Reflection;

namespace DAL {
  public class DALFactory {
    private static string assemblyName;
    private static Assembly assembly = null;

    static DALFactory() {
      assemblyName = ConfigurationManager.AppSettings["DALAssembly"];
      assembly = Assembly.Load(assemblyName);
    }

    public static IDatabase CreateDatabase() {
      string connectionString = ConfigurationManager.
        ConnectionStrings["DefaultConnectionString"].ConnectionString;
      return CreateDatabase(connectionString);
    }

    public static IDatabase CreateDatabase(string connectionString) {
      string databaseClassName = assemblyName + ".Database";
      Type dbClass = assembly.GetType(databaseClassName);
      return Activator.CreateInstance(dbClass, new object[] { connectionString }) as IDatabase;
    }

    public static IPresetDAO CreatePresetDAO(IDatabase database) {
      Type presetType = assembly.GetType(assemblyName + ".PresetDAO");
      return Activator.CreateInstance(presetType, new object[] { database }) as IPresetDAO;
    }
  }
}
