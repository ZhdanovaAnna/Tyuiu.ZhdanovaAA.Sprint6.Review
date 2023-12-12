using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tyuiu.ZhdanovaAA.Sprint6.TaskReview.V19.Lib
{
    public class DataService
    {
        public int GetMatrix(int[,] array, int n1, int n2, int c, int k, int l)
        {
            if (array.GetLength(0) <= 1 || array.GetLength(1) <= 1 || n1 >= n2 ||
                c < 0 || c >= array.GetLength(0) || k < 0 || k >= array.GetLength(1) ||
                l < 0 || l >= array.GetLength(1) || (l - k) % 2 != 0)

            {
                throw new ArgumentException("Некорректные входные данные");
            }

            int result = 0;
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);

            for (int i = 0; i < cols; i += 2)
            {
                if (i >= k && i <= l)
                {
                    if (array[c, i] >= n1 && array[c, i] <= n2)
                    {
                        result++;
                    }
                }
            }
            return result;
        }
    }
}
