using System.Data;
using System.Reflection;

namespace InventoryManagement.Repository
{
    public class Repository
    {
    }

    public static class DataMapper
    {
        public static List<T> DataReaderMapToList<T>(IDataReader dr)
        {
            List<T> list = new List<T>();
            T obj = default(T);

            var generic = Activator.CreateInstance<T>();
            List<string> Columns = new List<string>();

            foreach (PropertyInfo prop in generic.GetType().GetProperties())
            {
                if (HasColumn(dr, prop.Name))
                {
                    Columns.Add(prop.Name);
                }
            }

            while (dr.Read())
            {
                obj = Activator.CreateInstance<T>();
                foreach (PropertyInfo prop in obj.GetType().GetProperties())
                {
       
                    if (!Columns.Contains(prop.Name))
                    {
                        prop.SetValue(obj, null);
                    }
                    else if (!object.Equals(dr[prop.Name], DBNull.Value))
                    {
                        prop.SetValue(obj, dr[prop.Name], null);
                    }
                }
                list.Add(obj);
            }
            return list;
        }

        public static bool HasColumn(this IDataRecord dr, string columnName)
        {
            for (int i = 0; i < dr.FieldCount; i++)
            {
                if (dr.GetName(i).Equals(columnName, StringComparison.InvariantCultureIgnoreCase))
                    return true;
            }
            return false;
        }
    }
}
