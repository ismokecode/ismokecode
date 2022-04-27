using System;

namespace ConsoleApp3
{
    public class Employee
    {
        public int type;
        public decimal houseAllowance;
        public decimal medicleAllowance;
        public decimal bonus;
        public decimal pay;
    }
    public interface IManager
    {
        decimal getPay();
        decimal getBonus();
    }
    public class PEmployeeManager : IManager
    {
        public decimal getBonus()
        {
            return 10;
        }

        public decimal getPay()
        {
            return 100;
        }
        public decimal homeAllowance()
        {
            return 500;
        }
    }
    public class CEmployeeManager : IManager
    {
        public decimal getBonus()
        {
            return 20;
        }

        public decimal getPay()
        {
            return 200;
        }
        public decimal medicleAllowance()
        {
            return 250;
        }
    }
    public class Factory
    {
        public IManager manager = null;
        public BaseFactory baseManager = null;
        public IManager GetInstance(Employee emp)
        {
            if (emp.type == 1)
            {

                manager = new PEmployeeManager();
            }
            else if (emp.type == 2)
            {
                manager = new CEmployeeManager();
            }
            return manager;
        }
        public BaseFactory GetBaseInstance(Employee emp)
        {
            if (emp.type == 1)
            {
                baseManager = new PEmployeeFactory(emp);
            }
            else 
            {
                baseManager = new CEmployeeFactory(emp);
            }
            return baseManager;
        }
    }
    public abstract class BaseFactory
    {
        protected Employee _emp= new Employee();
        public BaseFactory(Employee emp)
        {
            _emp = emp;
        }
        public abstract IManager Create();
        public Employee ApplySalary()
        {
            IManager manager = this.Create();//calling and creating inteface objecte based on condition
            _emp.pay = manager.getPay();//assigning all value here
            _emp.bonus = manager.getBonus();
            return _emp;
        }
        
    }
    public class PEmployeeFactory : BaseFactory
    {
        public PEmployeeFactory(Employee emp):base(emp)
        {

        }
        public override IManager Create()
        {
            PEmployeeManager manager = new PEmployeeManager();
            _emp.houseAllowance = manager.homeAllowance();           
            return manager;
        }
    }
    public class CEmployeeFactory : BaseFactory
    {
        public CEmployeeFactory(Employee emp) : base(emp)
        {

        }
        public override IManager Create()
        {
            CEmployeeManager manager = new CEmployeeManager();
            manager.medicleAllowance();
            return manager;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee();
            emp.type = 1;
            BaseFactory factory = new Factory().GetBaseInstance(emp);
            emp = factory.ApplySalary();
            Console.WriteLine("Hello World!");
        }
    }
}
