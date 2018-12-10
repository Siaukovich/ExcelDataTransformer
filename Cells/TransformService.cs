using System;

using Cells.Base;

namespace Cells
{
    public class TransformService<TSource, TResult> : IDataTransformService
    {
        private readonly IDataProvider<TSource> _provider;

        private readonly IDataConsumer<TResult> _consumer;

        private readonly IDataTransformer<TSource, TResult> _transformer;

        public TransformService(IDataProvider<TSource> provider, IDataConsumer<TResult> consumer, IDataTransformer<TSource, TResult> transformer)
        {
            this._provider = provider ?? throw new ArgumentNullException(nameof(provider));
            this._consumer = consumer ?? throw new ArgumentNullException(nameof(consumer));
            this._transformer = transformer ?? throw new ArgumentNullException(nameof(transformer));
        }

        public void Transform()
        {
            var dataSource = this._provider.ProvideData();
            var transformedData = this._transformer.Transform(dataSource);
            this._consumer.Consume(transformedData);
        }
    }
}
