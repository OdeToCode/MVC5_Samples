using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace KatanaWebApi
{
    public class GreetingController : ApiController
    {
        public Greeting GetGreeting()
        {
            return new Greeting { Message = "Hello World!" };
        }
    }
}
