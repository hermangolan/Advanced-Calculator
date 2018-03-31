using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathStaff
{
    class AdvancedCalculator
    {
        public static float Power(float basis, int power)
        {
            float returned = basis;
            for (int i = 1; i < power; i++)
            {
                returned *= basis;
            }
            return returned;
        }
        public static int Power(int basis, int power)
        {
            int returned = basis;
            for (int i = 1; i < power; i++)
            {
                returned *= basis;
            }
            return returned;
        }

        public static bool IsPrime(int num) => IsPrime(num, 2);
        private static bool IsPrime(int num, int n)
        {
            if (num == 1)
                return true;
            if (num == n)
                return true;
            else
            {
                if (num % n == 0)
                    return false;
                else
                    return IsPrime(num, n + 1);
            }
        }

        public static int[] PrimeNumbers(int n)
        {
            List<int> vs = new List<int>();
            for (int i = 1; i < n-1; i++)
            {
                if (IsPrime(i))
                {
                    vs.Add(i);
                }
            }
            return vs.ToArray();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static Queue<int[]> PrimeFactorsOfNum(int n)
        {
            int[] PrimeNum = PrimeNumbers(n);
            Queue<int[]> q = new Queue<int[]>();
            //פעולה רקורסיבית בה אני לוקח את הפקטור הגדול ומחפש חילוק שאין לו שארית
            //כאשר הוא מוצא הוא מחפש את המספרים הראשונים שמרכיבים את התוצאה שיצאה בחילוק
            //ובסופו של דבר אמור לצאת אוסף של מספרים ראשוניים שמכפלתם יוצאת התוצאה שרצוייה
            return q;
        }
    }
}