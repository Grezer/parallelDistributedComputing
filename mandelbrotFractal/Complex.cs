using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mandelbrotFractal
{
    public class Complex
    {
        public double a;
        public double b;

        public Complex(double a, double b)
        {
            this.a = a;
            this.b = b;
        }

        public void Square()
        {
            double temp = (a * a) - (b * b);
            b = 2.0 * a * b;
            a = temp;
        }

        public double Magnitude()
        {
            return Math.Sqrt((a * a) + (b * b));
        }

        public void Add(Complex c)
        {
            a += c.a;
            b += c.b;
        }

        public static Complex operator +(Complex c1, Complex c2)
        {
            return new Complex(c1.a + c2.a, c1.b + c2.b);
        }

    }
}
