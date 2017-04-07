namespace Tulpep.PayULibrary.Models.PayU_Exception
{
    public enum ExceptionType
    {
        GeneralException = 1,
        ConnectionException = 2,
        ResponseExeption = 3
    }

    public class PayU_ExceptionManager: System.Exception
    {
        public ExceptionType ExceptionType { get; set; }

        public PayU_ExceptionManager(string message, ExceptionType exceptionType): base(message)
        {
            ExceptionType = exceptionType;
        }
    }
}
