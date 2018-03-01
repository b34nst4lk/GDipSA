using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoRentalCustomerApp
{
    class UnexpectedType : ApplicationException
    {
        public UnexpectedType() { }
        public UnexpectedType(string message): base(message) { }
    }
    class NoSuchTarget : ApplicationException
    {
        public NoSuchTarget() { }
        public NoSuchTarget(string message): base(message){ }
    }
}
