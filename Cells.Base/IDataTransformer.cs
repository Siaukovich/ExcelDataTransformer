using System.Collections.Generic;

namespace Cells.Base
{
    public interface IDataTransformer<in TSource, out TResult>
    {
        IEnumerable<TResult> Transform(IEnumerable<TSource> source);
    }
}
