using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [Serializable]
    public class DeliveryException : Exception
    {
        public List<Error> Errors { get; private set; }

        public DeliveryException(List<Error> errors)
        {
            this.Errors = errors;
        }

        //Daqui pra baixo é apenas código que o proprio VS gera 
        //pra gente poder utilizar esta exceção 
        public DeliveryException(string message) : base(message) { }
        public DeliveryException(string message, Exception inner) : base(message, inner) { }
        protected DeliveryException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}