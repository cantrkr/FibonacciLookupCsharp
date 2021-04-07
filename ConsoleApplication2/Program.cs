using System;
using System.Diagnostics;

namespace ConsoleApplication2
{
    internal class FibonacciLookup
    {
        
        private const int InitSize=50;
        private static long[] _table;
        public static void Main(string[] args)
        {
            _table=new long[InitSize];
            
            Console.WriteLine("{0}",Fibonacci(40));
            Console.WriteLine("{0}",StandardFibonacci(40));
            
        }

        private static long Fibonacci(int a)
        {
            if (a < 2)
            {
                _table[a] = a;
                return a;
            }

            if (a>=_table.Length)
            {
                    while (a > _table.Length - 1)
                    {
                        long[] newTable=new long[_table.Length*2];
                        _table.CopyTo(newTable,0);
                        _table = newTable;
                    }
            }
            if (_table[a] != 0)
            {
                return _table[a];
            }

            long value = 0;
            try
            {
                 value = checked(Fibonacci(a - 1) + Fibonacci(a - 2));
            }
            catch 
            {
                Console.WriteLine("The number is too big!");
                return 0;
            }
            _table[a] = value;
            return value;
        }

        private static long StandardFibonacci(int a)
        {
            if (a < 2)
            {
                return a;
            }

            return StandardFibonacci(a - 1) + StandardFibonacci(a - 2);
        }
        
    }
}