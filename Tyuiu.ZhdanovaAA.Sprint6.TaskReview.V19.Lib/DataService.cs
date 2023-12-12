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
            if (k < 0 || l < k || c < 0 ||c >= array.GetLength(0) || n1 >= n2)
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
                        result++;
                }
            }
            return result;
        }
    }
}
