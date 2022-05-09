using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    delegate void MyDelegate1();
    delegate void MyDelegate2(int x);
    delegate int MyDelegate3();
    delegate int MyDelegate4(int x);
    delegate int MyDelegate5(int x, int y);
    public class SimpleDelegates
    {
        public void Function1() { Console.WriteLine("Function 1 Called"); }
        public void Function2(int x) { Console.WriteLine($"Function 2 Called with {x}"); }
        public int Function3() { Console.WriteLine("Function 3 Called"); return 3; }
        public int Function4(int x) { Console.WriteLine($"Function 4 Called with {x}"); return x; }
        public int Function5(int x, int y)
        {
            Console.WriteLine("Function 5 Called" +
                $"with {x} and {y}"); return x + y;
        }

        public void EntryPoint()
        {
            MyDelegate1 d1 = Function1;
            MyDelegate2 d2 = Function2;
            MyDelegate3 d3 = Function3;
            MyDelegate4 d4 = Function4;
            MyDelegate5 d5 = Function5;

            d1();
            d2(100);
            d3();
            d4(300);
            d5(1090, 1900);
        }
    }

    public class DelegatesWithAnonymousAndLamba
    {
        public void EntryPoint()
        {
            MyDelegate1 d1 = delegate ()
            {
                Console.WriteLine("MyDeleagate 1 Called");
            };

            MyDelegate2 d2 = delegate (int x)
            {
                Console.WriteLine($"MyDeleagate with {x} Called");
            };

            MyDelegate3 d3 = delegate ()
            {
                Console.WriteLine("MyDeleagate 1 Called");
                return 3;
            };

            MyDelegate4 d4 = delegate (int x)
            {
                Console.WriteLine("MyDeleagate 1 Called");
                return x;
            };

            MyDelegate5 d5 = delegate (int x, int y)
            { 
                Console.WriteLine("MyDeleagate 1 Called");
                return x + y;
            };

            d1();
            d2(2);
            d3();
            d4(1);
            d5(1,1);

            MyDelegate1 d11 = () => Console.WriteLine("MyDeleagate 1 Called");

            MyDelegate2 d22 = (x) => Console.WriteLine($"MyDeleagate with {x} Called");

            MyDelegate3 d33 = () => {
                Console.WriteLine("MyDeleagate 1 Called");
                return 3;
            };

            MyDelegate4 d44 = (x) => {
                Console.WriteLine("MyDeleagate 1 Called");
                return x;
            };

            MyDelegate5 d55 = (x,y) => {
                Console.WriteLine("MyDeleagate 1 Called");
                return x+y;
            };

            d11();
            d22(2);
            d33();
            d44(1);
            d55(1, 1);

        }
    }

    public class MulticastingDelegates
    {
        public void Function1() { Console.WriteLine("Function 1 Called"); }
        public void Function11() { Console.WriteLine("Function 11 Called"); }
        public void Function111() { Console.WriteLine("Function 111 Called"); }
        public void Function2(int x) { Console.WriteLine($"Function 2 Called with {x}"); }
        public int Function3() { Console.WriteLine("Function 3 Called"); return 3; }
        public void EntryPoint()
        {
            MyDelegate1 d1 = Function1;
            d1 += Function11;
            d1 += Function111;
            d1();

            MyDelegate2 d2 = Function2;
            d2 += (x) => Console.WriteLine("Function 2");
            d2(3);

            MyDelegate3 d3 = Function3;
            d3 += delegate ()
            {
                Console.WriteLine("Function 3");
                return 3;
            };
            d3();
        }
    }

    public class Calculator { 
        public void Add(int x, int y)
        {
            Console.WriteLine($"{x + y}");
        }
        public void Sub(int x, int y)
        {
            Console.WriteLine($"{x - y}");
        }
        public Action<int,int> Operate(char i)
        {
            if (i == 'a') return Add;
            else if (i == 'b') return Sub;
            else return null;
        }

        public int Add2(int x, int y)
        {
            Console.WriteLine($"{x + y}");
            return x + y;
        }
        public int Sub2(int x, int y)
        {
            Console.WriteLine($"{x - y}");
            return x - y;
        }
        public Func<int, int,int> Operate2(char i)
        {
            if (i == 'a') return Add2;
            else if (i == 'b') return Sub2;
            else return null;
        }

        public void EntryPoint()
        {
            char i = 'a';
            var func = Operate(i);
            func(2,2);
            i = 'b';
            func = Operate(i);
            func(2,2);

            i = 'a';
            var func2 = Operate2(i);
            Console.WriteLine(func2(2, 2));
            i = 'b';
            func2 = Operate2(i);
            Console.WriteLine(func2(2, 2));
        }
    }
}
