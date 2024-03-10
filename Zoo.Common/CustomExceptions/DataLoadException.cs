
namespace Zoo.Common.CustomExceptions
{
    public class DataLoadException : Exception
    {
        public DataLoadException() { }

        public DataLoadException(string message) : base(message) { }

        public DataLoadException(string message, Exception innerException) : base(message, innerException) { }
    }
}
