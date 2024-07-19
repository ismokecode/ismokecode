using System;
using System.Threading.Tasks;

namespace Singelton_DoubleLock
{
    // Why sealed if we inherit this Singelton class to another class 
    // Why static - becoz of static members or method only contains static type eg: private static Singelton instance = null;
    // then private constructor restrict to create an object of Singeton class
    // but if we move into the Singelton class then it will allow that's called nested class.
    // 4. eagel loading it self a thread safe, CLR take care of variable initialization:
        //a. private static Singelton instance = null; instead of null create an instance of an Singeton class.
        //b. eg. private static Singelton instance = new 
    //5. Lazy Loading on top no need to check locking for paraller invoke:
        // private static readonly Lazy<Singelton> instance = new Lazy<Singelton>(()=>new Singelton()); GetInstance() method > Get property method return > instance.value;
        //
    public class sealed Singelton
    {
        //Here private variable can't access outside of the class but return through the public method
        private static Singelton instance = null; // if we make readonly then can't initialize later
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
                    lock (obj) // double no needed if we use eager loading on top: private static readonly Singelton instance = new Singelton();
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
    }
}
