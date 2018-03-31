using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathStaff
{
    struct Fraction
    {
        private bool IsNegetive { get; set; }
        private int numerator;
        public int Numerator
        {
            get { return numerator; }
            set
            {
                if (Denominator == 0)
                    Denominator = 1;
                IsNegetive = CheckIfNegetive(value, Denominator);
                if (value < 0) { value *= -1; }
                numerator = value;
            }
        }
        private int denominator;
        public int Denominator
        {
            get { return denominator; }
            set
            {
                IsNegetive = CheckIfNegetive(Numerator, value);
                if (value < 0) { value *= -1; }
                denominator = value;
            }
        }

        private static bool CheckIfNegetive(int numerator, int denominator)
        {
            if (denominator == 0)
                throw new DivideByZeroException();
            if (numerator < 0 && denominator < 0)
                return false;
            if (numerator < 0 || denominator < 0)
                return true;
            return false;
        }
        public Fraction(int num, int denom)
        {
            IsNegetive = CheckIfNegetive(num, denom);
            if (num < 0)
                num *= -1;
            if (denom < 0)
                denom *= -1;
            this.denominator = denom;
            this.numerator = num;
        }

        //Convert to other numbers types
        public override string ToString()
        {
            return this.IsNegetive ? "(-" + this.Numerator + ":" + this.Denominator + ")" : "(" + this.Numerator + ":" + this.Denominator + ")";
        }
        public float Result()
        {
            if (IsNegetive)
                return (this.Numerator / this.Denominator) * -1;
            return this.Numerator / this.Denominator;
        }
        public static implicit operator float(Fraction f) => f.Result();
        public static implicit operator double(Fraction f) => f.Result();
        public static implicit operator int(Fraction f)=>(int)f.Result();
        public static implicit operator long(Fraction f)=>(long)f.Result();
        
        public static Fraction ConvertToDouble(double d)
        {
            string str = d.ToString();
            if (!str.Contains('.'))
                str += ".";
            string[] vs = str.Split('.');
            int afterPoint = vs[1].Length + 1;
            int newNumerator; int newDenumrator;
            if (afterPoint <= 8)
            {
                newNumerator = (int)(d * 0.1 * AdvancedCalculator.Power(10, afterPoint));
                newDenumrator = (int)(0.1 * AdvancedCalculator.Power(10, afterPoint));
            }
            else
            {
                newNumerator = (int)(d * AdvancedCalculator.Power(10, 8));
                newDenumrator = AdvancedCalculator.Power(10, 8);
            }
            return new Fraction(newNumerator, newDenumrator);
        }
        public static implicit operator Fraction(double d)
        {
            return ConvertToDouble(d);
        }
        public static implicit operator Fraction(float f)
        {
            return ConvertToDouble(f);
        }

        //basic functions between Fractions
        public static Fraction Add(Fraction f1, Fraction f2)
        {
            if (f1.Denominator != f2.Denominator)
            {
                int sharedBase = f1.Denominator * f2.Denominator;
                int newf1 = f1.IsNegetive ? f1.Numerator * f2.Denominator * -1 : f1.Numerator * f2.Denominator;
                int newf2 = f2.IsNegetive ? f2.Numerator * f1.Denominator * -1 : f2.Numerator * f1.Denominator;
                Fraction Fraction = new Fraction(newf1 + newf2, sharedBase);
                return Fraction;
            }
            else
            {
                return new Fraction(f1.Numerator + f2.Numerator, f1.Denominator);
            }
        }
        public static Fraction operator +(Fraction f1, Fraction f2)
        {
            return Add(f1, f2);
        }

        public static Fraction Subt(Fraction f1, Fraction f2)
        {
            if (f1.Denominator != f2.Denominator)
            {
                int sharedBase = f1.Denominator * f2.Denominator;
                int newf1 = f1.IsNegetive ? f1.Numerator * f2.Denominator * -1 : f1.Numerator * f2.Denominator;
                int newf2 = f2.IsNegetive ? f2.Numerator * f1.Denominator * -1 : f2.Numerator * f1.Denominator;
                Fraction Fraction = new Fraction(newf1 - newf2, sharedBase);
                return Fraction;
            }
            else
            {
                return new Fraction(f1.Numerator - f2.Numerator, f1.Denominator);
            }
        }
        public static Fraction operator -(Fraction f1, Fraction f2)
        {
            return Subt(f1, f2);
        }

        public static Fraction Mul(Fraction f1, Fraction f2)
        {
            int numerator = f1.Numerator * f2.Numerator;
            int denominator = f1.Denominator * f2.Denominator;
            if (f1.IsNegetive && f2.IsNegetive)
                return new Fraction(numerator, denominator);
            if (f1.IsNegetive || f2.IsNegetive)
                return new Fraction(numerator * -1, denominator);
            return new Fraction(numerator, denominator);
        }
        public static Fraction operator *(Fraction f1, Fraction f2)
        {
            return Mul(f1, f2);
        }

        public static Fraction Divi(Fraction f1, Fraction f2)
        {
            Fraction oppsiteF2 = f2.IsNegetive ? new Fraction(f2.Denominator * -1, f2.Numerator) : new Fraction(f2.Denominator, f2.Numerator);
            return Mul(f1, oppsiteF2);
        }
        public static Fraction operator /(Fraction f1, Fraction f2)
        {
            return Divi(f1, f2);
        }

        //basic functions between Fractions and int
        public static Fraction Add(Fraction f1, int num)
        {
            Fraction FractionOfNum = new Fraction(num * f1.Denominator, f1.Denominator);
            return f1 + FractionOfNum;
        }
        public static Fraction operator +(Fraction f1, int num)
        {
            return Add(f1, num);
        }
        public static Fraction operator +(int num, Fraction f1)
        {
            return Add(f1, num);
        }

        public static Fraction Subt(Fraction f1, int num)
        {
            Fraction FractionOfNum = new Fraction(num * f1.Denominator, f1.Denominator);
            return f1 - FractionOfNum;
        }
        public static Fraction operator -(Fraction f1, int num)
        {
            return Subt(f1, num);
        }
        public static Fraction Subt(int num, Fraction f1)
        {
            Fraction FractionOfNum = new Fraction(num * f1.Denominator, f1.Denominator);
            return FractionOfNum - f1;
        }
        public static Fraction operator -(int num, Fraction f1)
        {
            return Subt(num, f1);
        }

        public static Fraction operator *(Fraction f1, int num)
        {
            return new Fraction(f1.Numerator * num, f1.Denominator);
        }
        public static Fraction operator *(int num,Fraction f1)
        {
            return new Fraction(f1.Numerator * num, f1.Denominator);
        }

        public static Fraction Divi(Fraction f1,int num)
        {
            return new Fraction(f1.Numerator, f1.Denominator * num);
        }
        public static Fraction operator /(Fraction f1, int num)
        {
            return Divi(f1, num);
        }
        public static Fraction Divi(int num,Fraction f1)
        {
            Fraction fraction = new Fraction(num, 1);
            return Divi(fraction, f1);
        }
        public static Fraction operator /(int num, Fraction f1)
        {
            return Divi(num,f1);
        }

        /*
        //basic functions between Fractions and double
        public static Fraction Add(Fraction f1, double num)
        {
            Fraction FractionOfNum = new Fraction(num * f1.Denominator, f1.Denominator);
            return f1 + FractionOfNum;
        }
        public static Fraction operator +(Fraction f1, double num)
        {
            return Add(f1, num);
        }
        public static Fraction operator +(double num, Fraction f1)
        {
            return Add(f1, num);
        }

        public static Fraction Subt(Fraction f1, double num)
        {
            Fraction FractionOfNum = new Fraction(num * f1.Denominator, f1.Denominator);
            return f1 - FractionOfNum;
        }
        public static Fraction operator -(Fraction f1, int num)
        {
            return Subt(f1, num);
        }
        public static Fraction Subt(double num, Fraction f1)
        {
            Fraction FractionOfNum = new Fraction(num * f1.Denominator, f1.Denominator);
            return FractionOfNum - f1;
        }
        public static Fraction operator -(double num, Fraction f1)
        {
            return Subt(num, f1);
        }

        public static Fraction operator *(Fraction f1, double num)
        {
            return new Fraction(f1.Numerator * num, f1.Denominator);
        }
        public static Fraction operator *(double num, Fraction f1)
        {
            return new Fraction(f1.Numerator * num, f1.Denominator);
        }

        public static Fraction Divi(Fraction f1, double num)
        {
            return new Fraction(f1.Numerator, f1.Denominator * num);
        }
        public static Fraction operator /(Fraction f1, double num)
        {
            return Divi(f1, num);
        }
        public static Fraction Divi(double num, Fraction f1)
        {
            Fraction fraction = new Fraction(num, 1);
            return Divi(fraction, f1);
        }
        public static Fraction operator /(double num, Fraction f1)
        {
            return Divi(num, f1);
        }
        */
    }
}
