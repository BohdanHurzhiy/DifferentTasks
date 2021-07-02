using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ValidIPAddress
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] s = new string[] { "01.01.01.01", "2001:0db8:85a3:0:0:8A2E:0370:7334", "256.256.256.256", "192.0.0.1" };
            foreach (var str in s) 
            {
                Console.WriteLine(ValidIPAddress(str));               
            }
        }
        static string ValidIPAddress(string IP)
        {
            Regex regexIpv4 = new Regex(@"^(([1-2]?\d?\d\.){3}[1-2]?\d?\d$)",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);
            Regex regexIpv6 = new Regex(@"^(([0-9a-f]{1,4}\:){7}[0-9a-f]{1,4}$)",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);
            
            Match matcheIP = regexIpv4.Match(IP);            
            if (matcheIP.Success)
            {
                string[] arrNum = IP.Split('.');
                int num;
                for (int i = 0; i < arrNum.Length; i++) 
                {
                    if (arrNum[i][0] == '0' && arrNum[i].Length > 1)
                    {
                        return "Neither";
                    }
                    num = int.Parse(arrNum[i]);
                    if ((num < 0) || (num > 255)) 
                    {
                        return "Neither";
                    }
                }
                return "IPv4";
            }

            matcheIP = regexIpv6.Match(IP);
            if (matcheIP.Success)
            {               
                return "IPv6";
            }
            return "Neither!!!";
        }
    }
}
