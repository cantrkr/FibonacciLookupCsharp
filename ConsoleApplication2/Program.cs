using System;
using System.Diagnostics;

namespace ConsoleApplication2
{
    internal class FibonacciLookup
    {
        
        private const int InitSize=20;
        private static long[] _table;
        public static void Main(string[] args)
        {
            _table=new long[InitSize];

            int testNum = 42;
            
            Console.WriteLine("Optimized Fibonacci function's result: {0} (faster)",Fibonacci(testNum));
            Console.WriteLine("Old Fibonacci function's result: {0} (slower)",StandardFibonacci(testNum));
            
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