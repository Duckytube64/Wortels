using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

class Program
{
    BigInteger m, p, q, a;
    BigInteger[] av;

    static void Main(string[] args)
    {
        Program prog = new Program();
        prog.Start();
        prog.Calculate();
        Console.ReadLine();                         // Prevents the console from immediately closing after finishing calculations
    }

    void Start()
    {
        m = BigInteger.Parse(Console.ReadLine());
        p = BigInteger.Parse(Console.ReadLine());   // = 4-voud - 1
        q = BigInteger.Parse(Console.ReadLine());   // = 4-voud - 1
        a = BigInteger.Parse(Console.ReadLine());
        av = new BigInteger[2];
        av[0] = (a % p) % m;
        av[1] = (a % q) & m;
    }

    void Calculate()
    {
        BigInteger big, small;
        if (p > q)
        {
            big = p;
            small = q;
        }
        else
        {
            big = q;
            small = p;
        }
        BigInteger[] Euclidians = ExtEuclides(big, small);
        BigInteger Wp = Euclidians[1], Wq = Euclidians[0];
        if (Wp < 0)
            Wp = m - Wp;
        if (Wq < 0)
            Wq = m - Wq;
    }

    BigInteger[] ExtEuclides(BigInteger big, BigInteger small)
    {
        BigInteger[] ggd = new BigInteger[2];

        BigInteger x = big, y = small, result = 0, divd, xn = 1, x0 = 1, x1 = 0, yn = 1, y0 = 0, y1 = 1;

        while (result != 1)
        {
            result = x % y;
            divd = x / y;
            xn = x0 - divd * x1;
            yn = y0 - divd * y1;

            x0 = x1;
            y0 = y1;
            x1 = xn;
            y1 = yn;
            x = y;
            y = result;
        }
        ggd[0] = xn * big;
        ggd[1] = yn * small;
        return ggd;
    }
}