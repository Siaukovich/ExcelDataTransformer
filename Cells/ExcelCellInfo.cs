namespace Cells
{
    public class ExcelCellInfo
    {
        public ExcelCellInfo(int height, int width, int level, string text)
        {
            this.Height = height;
            this.Width = width;
            this.Level = level;
            this.Text = text;
        }

        public int Width { get; set; }

        public int Height { get; set; }

        public int Level { get; set; }

        public string Text { get; set; }
    }
}
