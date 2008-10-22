using System.Collections.Generic;
using System.Data;
using NHibernate;
using NHibernate.Cfg;

namespace NHibernateInto.App
{
    public static class DatabaseCleaner
    {
        public static void ClearDatabase(Configuration cfg, ISessionFactory factory)
        {
            var tableNames = new List<string>();

            foreach (var clazz in cfg.ClassMappings)
            {
                tableNames.Add(clazz.Table.Name);
            }

            using (IStatelessSession session = factory.OpenStatelessSession())
            {
                using (IDbCommand cmd = session.Connection.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;

                    foreach (var tableName in tableNames)
                    {
                        cmd.CommandText = string.Format("DELETE FROM {0}", tableName);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}