using BotSDK;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;


namespace Chat
{
    public partial class Chat : Form
    {
        public Chat()
        {
            InitializeComponent();
            GetBotsFromAssembly();
        }
        List<IBot> Bott = new List<IBot>();


        private void SendMessageButton_Click(object sender, EventArgs e)
        {
            if (MessageTextBox.Text != "")
            {
                ChatWindow.Items.Add(Environment.UserName + ": " + MessageTextBox.Text);
                string answer = ReciveAnswer(MessageTextBox.Text);
                if (answer != null)
                {
                    ChatWindow.Items.Add(answer + "\r\n");
                }
            }
            else
            {
                MessageBox.Show("Please enter anything", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageTextBox.Text = "";
            }
        }

        private string ReciveAnswer(string message)
        {
            foreach (IBot bot in Bott)
            {
                string botAnswer = bot.Answer(message);
                if (botAnswer != null)
                {
                    return bot.Name + ": " + botAnswer;
                }
            }
            return null;
        }

        private void GetBotsFromAssembly()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            DirectoryInfo directory = new DirectoryInfo(path);

            try
            {
                foreach (FileInfo file in directory.GetFiles("*.dll"))
                {
                    string assemblyString = Path.Combine(path, file.Name);
                    Assembly asm = Assembly.LoadFrom(assemblyString);
                    foreach (Type type in asm.GetTypes())
                    {
                        if (type.GetInterface("IBot") != null)
                        {
                            IBot newBot = (IBot)Activator.CreateInstance(type);
                            Bott.Add(newBot);

                        }
                    }
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("No Bots", "They are gone", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

