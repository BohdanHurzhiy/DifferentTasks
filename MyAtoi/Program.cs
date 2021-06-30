using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAtoi
{
    class Program
    {
        static void Main(string[] args)
        {

            string s = "-2147483646";
            Console.WriteLine(MyAtoi(s));
        }
        static public int MyAtoi(string s)
        {
            char[] charArrS = s.Trim().ToCharArray();
            bool isNegative = false;
            int retNumber = 0;
            List<char> number = new List<char>();
            for (int i = 0; i < charArrS.Length; i++) 
            {
                if (char.IsDigit(charArrS[i]))
                {
                    if (charArrS[i] == '0')
                    {
                        if (number.Count != 0)
                        {
                            number.Add(charArrS[i]);
                        }
                    }
                    else 
                    {
                        number.Add(charArrS[i]);
                    }
                   
                }
                else if ((i == 0) && (charArrS[i] == '-' || charArrS[i] == '+'))
                {
                    if (charArrS[i] == '-') isNegative = true;
                }
                else 
                {
                    break;
                }                   
            }
            if (number.Count != 0)
            {
                if ((number.Count >= 10))
                {
                    if (!int.TryParse(new string(number.ToArray()), out retNumber))
                    {
                        if (isNegative) retNumber = int.MinValue;
                        else retNumber = int.MaxValue;
                    }
                }
                else
                {
                    retNumber = int.Parse(new string(number.ToArray()));
                }
                if (isNegative) retNumber = -retNumber;                
               
            }
            return retNumber;
        }
    }
}
