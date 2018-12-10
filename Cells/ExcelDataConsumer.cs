using System;
using System.Linq;
using System.Collections.Generic;

using Cells.Base;

using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace Cells
{
    public class ExcelDataConsumer : IDataConsumer<ExcelCell>
    {
        private readonly string _tablePath;

        public ExcelDataConsumer(string tablePath)
        {
            this._tablePath = tablePath ?? throw new ArgumentNullException(nameof(tablePath));
        }

        public void Consume(IEnumerable<ExcelCell> data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            using (var table = CreateTable())
            {
                var cells = data.Select(this.GetMergeCell);
                var mergeCells = new MergeCells(cells);
                InsertMergeCells(table, mergeCells);
                table.Save();
            }
        }

        private MergeCell GetMergeCell(ExcelCell cell)
        {
            var mergeRange = $"{cell.UpperLeft}:{cell.LowerRight}";
            var mergeCell = new MergeCell { Reference = new StringValue(mergeRange) };

            return mergeCell;
        }

        private void InsertMergeCells(SpreadsheetDocument table, MergeCells mergeCells)
        {
            var worksheetPart = table.WorkbookPart.WorksheetParts.First();
            worksheetPart.Worksheet.InsertAfter(mergeCells, worksheetPart.Worksheet.Elements<SheetData>().First());
        }

        private SpreadsheetDocument CreateTable()
        {
            var spreadsheetDocument = SpreadsheetDocument.Create(this._tablePath, SpreadsheetDocumentType.Workbook);
            var workbookPart = spreadsheetDocument.AddWorkbookPart();
            workbookPart.Workbook = new Workbook();

            var worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
            worksheetPart.Worksheet = new Worksheet(new SheetData());

            var sheets = spreadsheetDocument.WorkbookPart.Workbook.AppendChild(new Sheets());

            var sheet = new Sheet
            {
                Id = spreadsheetDocument.WorkbookPart.GetIdOfPart(worksheetPart),
                SheetId = 1,
                Name = "ResultSheet" // TODO?
            };

            sheets.Append(sheet);

            workbookPart.Workbook.Save();

            return spreadsheetDocument;
        }
    }
}
