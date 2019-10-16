using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

class Program
{
    BigInteger m, p, q, a, ap, aq;

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
        ap = (a % p) % m;
        aq = (a % q) & m;
    }

    void Calculate()
    {
        ap = BigInteger.ModPow(ap, (p + 1) / 4, p);
        aq = BigInteger.ModPow(aq, (q + 1) / 4, q);

        BigInteger[] Euclidians = ExtEuclides(p, q);
        BigInteger Wp = Euclidians[0], Wq = Euclidians[1];
        if (Wp < 0)
            Wp = m + Wp;
        if (Wq < 0)
            Wq = m + Wq;

        List<BigInteger> apaq = new List<BigInteger>();
        apaq.Add((ap * Wp + aq * Wq) % m);
        apaq.Add((ap * Wp - aq * Wq) % m);
        apaq.Add((-ap * Wp + aq * Wq) % m);
        apaq.Add((-ap * Wp - aq * Wq) % m);

        for (int i = 0; i < apaq.Count; i++)
        {
            if (apaq.ElementAt(i) < 0)
                apaq[i] = m + apaq[i];
        }

        apaq.Sort();

        for (int i = 0; i < apaq.Count; i++)
        {
            Console.WriteLine(apaq.ElementAt(i));
        }
    }

    // Gaat hier fout
    BigInteger[] ExtEuclides(BigInteger first, BigInteger second)
    {
        BigInteger[] ggd = new BigInteger[2];

        BigInteger x = BigInteger.Max(first, second), y = BigInteger.Min(first, second), result = 0, divd, xn = 1, x0 = 1, x1 = 0, yn = 1, y0 = 0, y1 = 1;

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
        ggd[0] = yn;
        ggd[1] = xn;        
        return ggd;
    }
}