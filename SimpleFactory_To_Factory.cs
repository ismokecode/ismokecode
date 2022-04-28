using System;

namespace ConsoleApp4
{
    //Create method - when two method homeAllowance and medicleAllowance eligible based on EmployeeType then
    //Create this method on class level and base factory class have abstract method and define and call class level
    //and initialized this class to interface to invoke common method and return back to apply salary.

    //Create method separately define by PEmployeeBaseFactory and CEmployeeByBaseFactory and 
    //instance of this class invoke the separate method and assign back to variable and return common  
    //method as by assigning object to inteface and another method use those inteface to assign employee value.
    public interface IManager
    {
        decimal GetPay();
        decimal GetBonus();
    }
    public class PEmployeeManager : IManager
    {
        public decimal GetBonus()
        {
            return 100;
        }

        public decimal GetPay()
        {
            return 50;
        }
        public decimal GetHomeAllowance()
        {
            return 500;
        }
    }
    public class CEmployeeManager : IManager
    {
        public decimal GetBonus()
        {
            return 200;
        }

        public decimal GetPay()
        {
            return 100;
        }
        public decimal GetMedicleAllowance()
        {
            return 200;
        }
    }
    public class Employee
    {
        public decimal type;
        public decimal pay;
        public decimal bonus;
        public decimal medicleAllowance;
        public decimal homeAllowance;
    }
    public abstract class BaseFactory
    {
        public Employee _emp = new Employee();
        public IManager manager = null;
        public BaseFactory(Employee emp)
        {
            this._emp = emp;
        }
        public abstract IManager Create();
        public Employee ApplySalary()
        {
            manager = this.Create();
            _emp.bonus = manager.GetBonus();
            _emp.pay = manager.GetPay();
            return _emp;
        }
    }
    public class PEmployeeBaseFactory : BaseFactory
    {
        public PEmployeeBaseFactory(Employee emp) : base(emp)
        {
        }
        public override IManager Create()
        {
            PEmployeeManager pemp = new PEmployeeManager();
            _emp.homeAllowance = pemp.GetHomeAllowance();
            manager = pemp;
            return manager;
        }
    }
    public class Factory
    {
        IManager manager = null;
        Employee emp = new Employee();
        public IManager GetInstance()
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
        public BaseFactory factoryManager = null;
        public BaseFactory GetInstanceBase(Employee emp)
        {
            if (emp.type == 1)
            {
                factoryManager = new PEmployeeBaseFactory(emp);
            }
            else if (emp.type == 2)
            {
                manager = new CEmployeeManager();
            }
            return factoryManager;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee() { type=1};
            BaseFactory bf = new Factory().GetInstanceBase(emp);
            emp = bf.ApplySalary();
            Console.WriteLine("Hello World!");
        }
    }
}
