using System.ComponentModel;
using System.Data;
using System.Reflection;

namespace Modelos.Servicios
{
    public static class DataManager
    {
        public static DataTable ToDataTable<T>(IEnumerable<T> data)
        {
            // Obtener las propiedades del obj
            PropertyDescriptorCollection props =
                TypeDescriptor.GetProperties(typeof(T));

            // Crear el DataTable
            DataTable table = new();

            // Iterar, crear las columnas
            foreach (PropertyDescriptor prop in props)
            {
                // Atributo que se va a mostrar
                var displayNameAttr = (DisplayNameAttribute?)prop.Attributes[typeof(DisplayNameAttribute)];
                // Si existe el display name, se usa ese, de lo contrario el desc_tcli de la propiedad
                string columnName;

                if (displayNameAttr != null)
                {
                    if (displayNameAttr.DisplayName.Trim().Length > 0)
                    {
                        columnName = displayNameAttr.DisplayName;
                    }
                    else
                    {
                        columnName = prop.Name;
                    }
                }
                else
                {
                    columnName = prop.Name;
                }

                // Agregar la columna:
                //              Nombre de la col
                //                            El tipo, si es nulo y no lo acepta, obtiene el por defecto
                table.Columns.Add(columnName, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }

            // Objeto a agregar en forma de fila
            object[] values = new object[props.Count];

            // Va iterando la lista y va agregando fila por cada elemento
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }

        public static IEnumerable<T> DataTableToList<T>(DataTable? table)
        {
            if (table == null)
                return [];
            var list = new List<T>();
            foreach (DataRow row in table.Rows)
            {
                T? value = DataRowToObject<T>(row);
                if (value != null)
                    list.Add(value);
            }

            return list;
        }

        public static T? DataRowToObject<T>(DataRow? dataRow)
        {
            if (dataRow == null) return default;

            // Crea una instancia del tipo de dato
            T? item = (T?)Activator.CreateInstance(typeof(T));

            // Obtiene las propiedades del tipo de dato usando reflexión
            foreach (PropertyInfo prop in typeof(T).GetProperties())
            {
                // Obtiene el atributo DisplayName si existe
                var displayNameAttr = prop.GetCustomAttribute<DisplayNameAttribute>();
                string dtColumnName = displayNameAttr != null && !string.IsNullOrWhiteSpace(displayNameAttr.DisplayName)
                    ? displayNameAttr.DisplayName
                    : prop.Name;

                /**
                 * Verificar si existe el DisplayName como propiedad de manera que
                 * la propiedad se asigne independientemente de la procedencia
                 */
                string columnName = dataRow.Table.Columns.Contains(dtColumnName) ? dtColumnName : prop.Name;

                // Asigna a la propiedad específica
                object? value = dataRow[columnName] == DBNull.Value ? null : dataRow[columnName];
                prop.SetValue(item, value);
            }

            return item;
        }
    }
}
