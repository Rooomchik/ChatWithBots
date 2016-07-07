using BotSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace John
{
    public class John : IBot
    {
        public string Answer(string message)
        {
            if (message.Equals("Privet", StringComparison.InvariantCultureIgnoreCase))
                return "Hi brother";
            else if (message.Equals("how is your life", StringComparison.InvariantCultureIgnoreCase))
                return "Good and you";
            else if (message.Equals("Are you a bot", StringComparison.InvariantCultureIgnoreCase))
                return "Just a human like you";
            else
                return null;
        }

        public string Name
        {
            get { return "John"; }
        }
    }
}
