using System.Collections.Generic;

namespace Cells.Base
{
    public interface IDataProvider<out TData>
    {
        IEnumerable<TData> ProvideData();
    }
}
