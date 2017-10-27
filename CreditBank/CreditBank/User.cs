using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
namespace CreditBank
{
    public class User
    {

        string[] randoms = new string[5]
        {
            "a",
            "b",
            "c",
            "d",
            "e"
        };
        Random r = new Random();
        private int length = 5;
        private string path = @"C:\Users\закарьянова\Desktop";
        public long Id { get; set; }
        public string INN { get; set; }
        public string Password { get; set; }
        public void GetPassword(string iNN )
        {
            string randstr="";
            for (int i = 0; i < length; i++)
            {
                randstr += randoms[r.Next(0, randoms.Length)];
            }
            Password = randstr;
        }
    }
}
