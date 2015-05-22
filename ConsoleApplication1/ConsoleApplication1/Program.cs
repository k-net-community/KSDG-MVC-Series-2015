using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Base
    {

    }

    class Base2
    {
        public override string ToString()
        {
            return "Base2";
        }
    }

    class Derived1 : Base
    {
        public string GetBaseString() { return base.ToString(); }
    }

    class Derived2 : Base2
    {
        public string GetBaseString() { return base.ToString(); }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var a = new Derived1();
            var b = new Derived2();

            Console.WriteLine("a base.ToString(): {0}", a.GetBaseString());
            Console.WriteLine("b base.ToString(): {0}", b.GetBaseString());
            Console.ReadLine();
        }
    }
}
