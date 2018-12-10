namespace Cells
{
    public class ExcelCell
    {
        public ExcelPosition UpperLeft { get; set; }

        public ExcelPosition LowerRight { get; set; }

        public string Text { get; set; }
    }

    public class ExcelPosition
    {
        public string Column { get; set; }

        public int Row { get; set; }

        public override string ToString() => $"{this.Column}{this.Row}";
    }
}
