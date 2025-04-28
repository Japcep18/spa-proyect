using System.Data;

namespace Modelos.Tipos
{
    public interface IConsultableModel<T>
    {
        public DataTable GetDataTable();
        public DataTable GetDataTable(IEnumerable<T> data);
        public T? RetrieveData(DataRow row);
    }
}