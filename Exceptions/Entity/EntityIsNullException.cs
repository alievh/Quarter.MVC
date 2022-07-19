using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions.Entity
{
    public class EntityIsNullException : Exception
    {
        private static string _message = "Entity: Data not found!";

        public EntityIsNullException() : base(_message) { }
    }
}
