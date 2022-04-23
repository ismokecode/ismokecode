using System;
using System.Threading.Tasks;

namespace Singelton_DoubleLock
{
    public class Singelton
    {
        //Here private variable can't access outside of the class but return through the public method
        private static Singelton instance = null;
        private static readonly object obj = new object();
        private static int count = 0;
        private Singelton()
        {
            count = count + 1;
            Console.WriteLine("Object count" + count);
        }
        public static Singelton GetInstance
        {
            get
            {
                if (instance == null) 
                { 
                    lock (obj)
                    {
                        if (instance == null)
                            instance = new Singelton();

                    }
            }
                return instance;
            }
                
        }
        private int b = 5;
        public int a()
        {
            return b;
        }
        public void Display(string message)
        {
            Console.WriteLine(message);
        }
    }

    public sealed class SingeltonLazyEagleLoading
    {
        private static int cnts = 0;
        //lazy loading initialization
        public static readonly Lazy<SingeltonLazyEagleLoading> instance2 = new Lazy<SingeltonLazyEagleLoading>(() => new SingeltonLazyEagleLoading());
        //eagle loading initialization
        //private static readonly SingeltonLazyEagleLoading instance = new SingeltonLazyEagleLoading();
        private SingeltonLazyEagleLoading()
        {
            cnts = cnts + 1;
            Console.WriteLine("SingeltonLazyEagleLoading instance count" + cnts);
        }
        public static SingeltonLazyEagleLoading GetInstance
        {
            get 
            {
                return instance2.Value;
            }
        }
        public void display(string message)
        {
            Console.WriteLine(message);
        }

    }
    class Program
    {
        static void Main(string[] args)
     {
            //this code moved to Method1
            //Singelton obj1 = Singelton.GetInstance;
            //obj1.Display("Object 1");

            //this code moved to Method2
            //Singelton obj2 = Singelton.GetInstance;
            //obj2.Display("Object 1");

            Parallel.Invoke(() => Method1(), ()=> Method2());
            Parallel.Invoke(() => Method11(), () => Method22());
            Console.ReadLine();
        }
        public static void Method1()
        {
            Singelton obj1 = Singelton.GetInstance;
            obj1.Display("Object 1");
        }
        public static void Method2()
        {
            Singelton obj1 = Singelton.GetInstance;
            obj1.Display("Object 1");
        }

        public static void Method11()
        {
            SingeltonLazyEagleLoading obj1 = SingeltonLazyEagleLoading.GetInstance;
            obj1.display("Object 11");
        }
        public static void Method22()
        {
            SingeltonLazyEagleLoading obj1 = SingeltonLazyEagleLoading.GetInstance;
            obj1.display("Object 22");
        }
    }
}
