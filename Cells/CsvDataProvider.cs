using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Cells.Base;
using Cells.Exceptions;

namespace Cells
{
    public class CsvDataProvider : IDataProvider<ExcelCellInfo>
    {
        private readonly string _filePath;

        public CsvDataProvider(string filePath)
        {
            if (filePath == null)
            {
                throw new ArgumentNullException(nameof(filePath));
            }

            //if (!File.Exists(Path.Combine(Directory.GetCurrentDirectory(), filePath)))
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException();
            }

            this._filePath = filePath;
        }

        public IEnumerable<ExcelCellInfo> ProvideData()
        {
            var lines = File.ReadLines(_filePath);

            return lines.Select(l => l.Split(',')).Select(this.ConvertDataArrayToCellInfo);

            //using (var file = new StreamReader(path))
            //{
            //    while (!file.EndOfStream)
            //    {
            //        var line = file.ReadLine();
            //        var values = line.Split(';');
            //        var cellInfo = GetCellInfo(values);

            //        yield return cellInfo;
            //    }
            //}
        }

        private ExcelCellInfo ConvertDataArrayToCellInfo(string[] parts)
        {
            try
            {
                var height = int.Parse(parts[0]);
                var width = int.Parse(parts[1]);
                var level = int.Parse(parts[2]);
                var text = parts[3];

                return new ExcelCellInfo(height, width, level, text);
            }
            catch (Exception ex)
            {
                throw new CsvFileCorruptedException("CSV file has invalid data.", ex);
            }
        }
    }
}
