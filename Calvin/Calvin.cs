using BotSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calvin
{
    public class Calvin : IBot
    {
        public string Answer(string message)
        {
            if (message.Equals("Hi", StringComparison.InvariantCultureIgnoreCase))
                return "Hi my friend";
            else if (message.Equals("how are you", StringComparison.InvariantCultureIgnoreCase))
                return "i don't want to speak with you";
            else if (message.Equals("why", StringComparison.InvariantCultureIgnoreCase))
                return "because";
            else
                return null;
        }

        public string Name
        {
            get { return "Calvin"; }
        }
    }
}

