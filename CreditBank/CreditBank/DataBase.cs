using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditBank
{
    public class DataBase
    {
        List<string> listINN;
        public void ListAdd(string iNN)
        {
            listINN.Add(iNN);
        }
    }
}
