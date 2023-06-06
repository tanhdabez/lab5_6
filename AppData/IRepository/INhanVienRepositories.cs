using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.IRepository
{
    public interface INhanVienRepositories<T>
    {
        IEnumerable<T> GetAllItem();
        bool CreateItem(T item);
        bool DeleteItem(T item);
        bool UpdateItem(T item);
    }
}
