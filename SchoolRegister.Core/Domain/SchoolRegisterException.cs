using System;

namespace SchoolRegister.Core.Domain
{
    public abstract class SchoolRegisterException : Exception
    {
        public string Code { get; }

        protected SchoolRegisterException()
        {
        }

        protected SchoolRegisterException(string code)
        {
            Code = code;
        }

        protected SchoolRegisterException(string message, params object[] args) : this(string.Empty, message, args)
        {
        }

        protected SchoolRegisterException(string code, string message, params object[] args) : this(null, code, message, args)
        {
        }

        protected SchoolRegisterException(Exception innerException, string message, params object[] args)
            : this(innerException, string.Empty, message, args)
        {
        }

        protected SchoolRegisterException(Exception innerException, string code, string message, params object[] args)
            : base(string.Format(message, args), innerException)
        {
            Code = code;
        }    
    }
}