using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Simpleiterationmethod
{
    class SLAU
    {
        private float[,] Matrix;

        //Конструкторы
        public SLAU()
        {
            Matrix = new float[5, 6]
                      {{27, 4, -2, 8, 6, 43}, 
                      {-3, 22, -4, -7, 3, 22}, 
                      {4, -7, 36, -2, 9, 120}, 
                      {-2, -8, -9, 28, -4, 10}, 
                      {-9, 5, -4, 1, 25, 18}};
        }
        public SLAU(ushort RowCol)
        {
            Matrix = new float[RowCol, RowCol + 1];
            for (int i = 0; i < RowCol; i++)
            {
                for (int j = 0; j < RowCol + 1; j++)
                {
                    Console.Write((j < RowCol) ? "M[{0}, {1}] = " : "MResult[{0}, {1}] = ", i + 1, j + 1);
                    Matrix[i, j] = Convert.ToSingle(Console.ReadLine());
                }
            }
        }

        //Метод приближенного решеия
        public float[] SimIterMeth()
        {
            float[] Xnew = new float[Matrix.GetLength(0)],
                    Xold = new float[Xnew.Length];
            
            do
            {
                Xnew.CopyTo(Xold, 0);

                for (int i = 0; i < Xnew.Length; i++)
                    Xnew[i] = elX(Xold, i) / Matrix[i, i];

            } while (!StopIter(Xold, Xnew));

            return Xnew;
        }

        //Проверка на необходимость завершения расчета новых Х
        private bool StopIter(float[] Xold, float[] Xnew)
        {
            const float E = 0.001f;

            for (int i = 0; i < Xnew.Length; i++)
            {
                if ((Math.Abs(Xnew[i] - Xold[i])) > E) return false;
            }
            return true;
        }

        //Поиск элемента х нового
        private float elX(float [] Xold, int index)
        {
            float ResX = Matrix[index, Matrix.GetLength(1) - 1];

            for (int i = 0; i < Xold.Length; i++)
            {
                if (i == index) continue;
                ResX -= Matrix[index, i] * Xold[i];
            }

            return ResX;
        }
    }
}
