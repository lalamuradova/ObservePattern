using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace ObservePattern
{
    public class ControlMail
    {
      public static  bool Control(string email)
        {           
                Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                Match match = regex.Match(email);
                if (!match.Success)
                {
                  return false;
                }
                else
                {
                    return true;
                }               
        }
    }
}
