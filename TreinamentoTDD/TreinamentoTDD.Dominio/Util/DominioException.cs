using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace TreinamentoTDD.Dominio.Util
{

    public class DominioException : ArgumentException
    {
        public List<string> Mensagens { get; private set; }
        
        public DominioException()
        {
        }

        public DominioException(string message) : base(message)
        {
            Mensagens = message.Split(';').ToList();
        }

        public DominioException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public DominioException(string message, string paramName) : base(message, paramName)
        {
        }

        public DominioException(string message, string paramName, Exception innerException) : base(message, paramName, innerException)
        {
        }

        protected DominioException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}