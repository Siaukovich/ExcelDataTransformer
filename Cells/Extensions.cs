namespace Cells
{
    internal static class Extensions
    {
        public static string ToColumnName(this int column)
        {
            var dividend = column + 1;
            var columnName = string.Empty;
            const int ALPHABET_LENGTH = 'z' - 'a' + 1;

            while (dividend > 0)
            {
                var modulo = (dividend - 1) % ALPHABET_LENGTH;
                columnName = (char)('A' + modulo) + columnName;
                dividend = (dividend - modulo) / ALPHABET_LENGTH;
            }

            return columnName;
        }
    }
}
