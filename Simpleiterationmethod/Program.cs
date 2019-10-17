using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodsSLAU
{
    class Program
    {
        static void Main(string[] args)
        {
            SLAU Matr = new SLAU();

            float[] x = Matr.SimIterMeth();
            for (int i = 0; i < x.Length; i++)
            {
                Console.WriteLine(x[i]);
            }

            Console.ReadKey();
        }
    }
}
