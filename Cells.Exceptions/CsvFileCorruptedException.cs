using System;
using System.Runtime.Serialization;

namespace Cells.Exceptions
{
    public class CsvFileCorruptedException : Exception
    {
        public CsvFileCorruptedException()
        {
        }

        public CsvFileCorruptedException(string message) : base(message)
        {
        }

        public CsvFileCorruptedException(string message, Exception inner) : base(message, inner)
        {
        }

        protected CsvFileCorruptedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
