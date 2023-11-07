using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CukCuk.Core.Exceptions
{
    public class EmployeeValidException : Exception
    {
        string? MsgErrorValidate = null;
        public EmployeeValidException(string msg)
        {
            this.MsgErrorValidate = msg;
        }

        public override string Message
        {
            get
            {
                return MsgErrorValidate;
            }
        }
    }
}
