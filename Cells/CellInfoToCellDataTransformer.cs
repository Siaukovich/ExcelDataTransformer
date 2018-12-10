using System;
using System.Collections.Generic;

using Cells.Base;

namespace Cells
{
    public class CellInfoToCellDataTransformer : IDataTransformer<ExcelCellInfo, ExcelCell>
    {
        public IEnumerable<ExcelCell> Transform(IEnumerable<ExcelCellInfo> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            return InnerTransform(source);
        }

        private IEnumerable<ExcelCell> InnerTransform(IEnumerable<ExcelCellInfo> source)
        {
            var column = -1; // Zero for "A", 26 for "AA" and so on.
            var row = 1; // First row index in Excel.
            ExcelCellInfo prevInfo = null;

            foreach (var info in source)
            {
                if (info.Level == 0)
                {
                    column++;
                    row = 1;
                }
                else if (info.Level == prevInfo.Level)
                {
                    column += prevInfo.Width;
                }
                else
                {
                    row += prevInfo.Height;
                }

                var upperLeftPosition = ConvertToExcelPosition(column, row);
                var lowerRightPosition = ConvertToExcelPosition(column + info.Width - 1, row + info.Height - 1);

                var cell = GetExcelCell(info, upperLeftPosition, lowerRightPosition);

                yield return cell;

                prevInfo = info;
            }
        }

        private ExcelPosition ConvertToExcelPosition(int columnIndex, int rowIndex)
        {
            return new ExcelPosition
            {
                Column = columnIndex.ToColumnName(),
                Row = rowIndex
            };
        }

        private ExcelCell GetExcelCell(ExcelCellInfo cellInfo, ExcelPosition upperLeftPosition, ExcelPosition lowerRightPosition)
        {
            return new ExcelCell
            {
                UpperLeft = upperLeftPosition,
                LowerRight = lowerRightPosition,
                Text = cellInfo.Text
            };
        }
    }
}
