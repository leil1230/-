using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahjongGenertorTool
{
    class Program
    {
        static void Main(string[] args)
        {
            PaiXingFactory factory = new PaiXingFactory();
            factory.initAllCombineStr();
            factory.writeAllCombineListToFile();
        }
    }
}
