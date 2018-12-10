using Cells.Base;
using Cells.Configuration;

using Ninject;

namespace Cells.DI
{
    public static class DependencyResolver
    {
        public static void ResolveDependencies(this IKernel kernel)
        {
            kernel.Bind<IDataProvider<ExcelCellInfo>>()
                  .To<CsvDataProvider>()
                  .WithConstructorArgument("filePath", ConfigValues.CsvFileFullPath);

            kernel.Bind<IDataConsumer<ExcelCell>>()
                  .To<ExcelDataConsumer>()
                  .WithConstructorArgument("tablePath", ConfigValues.ExcelTableFullPath);

            kernel.Bind<IDataTransformer<ExcelCellInfo, ExcelCell>>()
                  .To<CellInfoToCellDataTransformer>();

            kernel.Bind<IDataTransformService>()
                  .To<TransformService<ExcelCellInfo, ExcelCell>>();
        }
    }
}
