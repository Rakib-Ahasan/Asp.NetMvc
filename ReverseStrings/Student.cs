using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseStrings
{
    public class Student
    {
        public string firstName { get; set; }
        public string lastName { get; set; }

        public string GetFullName()
        {
            return firstName + " " + lastName;
        }

        public string GetReverseName()
        {
            string fullName = GetFullName();
            string reverseName = "";

            for (int i = fullName.Length-1; i >=0 ; i--)
            {
                reverseName += fullName.Substring(i, 1);
            }

            return reverseName;
        }
    }

   
}
