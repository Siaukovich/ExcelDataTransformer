using System.Collections.Generic;

namespace Cells.Base
{
    public interface IDataConsumer<in TData>
    {
        void Consume(IEnumerable<TData> data);
    }
}
