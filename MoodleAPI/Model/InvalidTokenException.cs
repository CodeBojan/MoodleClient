using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodleAPI.Model
{
    public class InvalidTokenException : Exception
    {   
        public InvalidTokenException() : base()
        {

        }

        public InvalidTokenException(string message) : base(message)
        {

        }
    }
}
