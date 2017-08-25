using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enroute.Services
{
    public class DebugMailService : IMailservice
    {
        public void SendMail(string to, string from, string subject, string body)
        {
            Debug.WriteLine("sending email");
        }
    }
}
