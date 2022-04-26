using System;

namespace FactoryDesignPattern_1
{
    public interface IEmployeeManager
    {
        decimal GetBonus();
        decimal GetPay();
    }
    public class PEmployee : IEmployeeManager
    {
        public decimal GetBonus()
        {
            return 5;
        }

        public decimal GetPay()
        {
            return 100;
        }
    }
    public class CEmployee : IEmployeeManager
    {
        public decimal GetBonus()
        {
            return 20;
        }

        public decimal GetPay()
        {
            return 200;
        }
    }
    public class IEmployeeManagerFactory
    {
        public IEmployeeManager GetIEmployeeManager(int empType) 
        {
            IEmployeeManager manager = null;
            if (empType == 1)
            {
                manager = new PEmployee();
            }
            else if(empType==2)
            {
                manager = new CEmployee();
            }
            return manager;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            IEmployeeManagerFactory manager = new IEmployeeManagerFactory();
            IEmployeeManager emp = manager.GetIEmployeeManager(1);
            Console.WriteLine("Employee details: bonus: {0}, pay:{1}",emp.GetBonus(),emp.GetPay());
            Console.ReadLine();
        }
    }
}
 