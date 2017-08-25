using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enroute.Services
{
    public interface IMailservice
    {
        void SendMail(string to, string from, string subject, string body);
    }
}
