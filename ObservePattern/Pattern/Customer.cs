using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObservePattern.Pattern
{
    class Customer : IObserver
    {
        public string ProductName { get; set; }
        public string EmailAdress { get; set; }
        public void Update(ISubject subject)
        {
            if ((subject as Store).State == ProductName)
            {
                SendMail.Send(EmailAdress);
            }
        }
    }
}
