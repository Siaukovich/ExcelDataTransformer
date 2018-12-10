using System;

using Cells.Base;
using Cells.DI;

using Ninject;

namespace Cells.ConsolePL
{
    class Program
    {
        private static IKernel kernel;

        static Program()
        {
            kernel = new StandardKernel();
            kernel.ResolveDependencies();
        }

        static void Main()
        {
            var service = kernel.Get<IDataTransformService>();
            service.Transform();

            Console.WriteLine("Done.");

            Console.ReadKey();
        }
    }
}
