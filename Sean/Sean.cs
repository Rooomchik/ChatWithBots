using BotSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sean
{
    public class Sean : IBot
    {
        public string Answer(string message)
        {
            if (message.Equals("Hello", StringComparison.InvariantCultureIgnoreCase))
                return "Hello";
            else if (message.Equals("how do you do", StringComparison.InvariantCultureIgnoreCase))
                return "Too bad and you";
            else if (message.Equals("Why bad", StringComparison.InvariantCultureIgnoreCase))
                return "Because i'm a bot";
            else
                return null;
        }

        public string Name
        {
            get { return "Sean"; }
        }
    }
 
}

