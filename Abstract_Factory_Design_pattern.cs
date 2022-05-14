using System;

namespace AbstractFactoryDesignPattern
{
    //Business requirements:
    //PEmployee - Manager Apple Laptop, i7, Non Manager - Apple Desktop,i5
    //PEmployee - Manager Dell Laptop i7, Non Manager - Dell Desktop i5
    #region Enum
    public enum Brand
    { 
        Apple,
        Dell
    }
    public enum Processor
    {
        i5,
        i7
    }
    public enum SystemType
    { 
        Laptop,
        Desktop
    }
    #endregion interface
    #region Interface declaration Abstract product
    public interface IBrand
    {
        string GetBrand();
    }
    public interface IProcessor
    {
        string GetProcessor();
    }
    public interface ISystemType
    {
        string GetSystemType();
    }
    #endregion interface end
    #region concrete inteface 
    public interface IComputerFactory
    {
        IBrand Brand();
        IProcessor Processor();
        ISystemType SystemType();
    }
    #endregion 
    #region Concrete product -- Implementing interface individual based on separately enitity property eg. Apple and dell
    public class Dell : IBrand
    {
        public string GetBrand()
        {
            return Brand.Dell.ToString();
        }
    }
    public class Apple : IBrand
    {
        public string GetBrand()
        {
            return Brand.Apple.ToString();
        }
    }
    public class Laptop : ISystemType
    {
        public string GetSystemType() 
        {
            return SystemType.Laptop.ToString();
        }
    }
    public class Desktop : ISystemType
    {
        public string GetSystemType()
        {
            return SystemType.Desktop.ToString();
        }
    }
    public class I5 : IProcessor
    {
        public string GetProcessor() 
        {
            return Processor.i5.ToString();
        }
    }
    public class I7 : IProcessor
    {
        public string GetProcessor()
        {
            return Processor.i7.ToString();
        }
    }
    #endregion
    #region System Factory
    public class MacLaptopFactory : IComputerFactory
    {
        public IBrand Brand()
        {
            IBrand brand = new Apple();
            return brand;
        }

        public virtual IProcessor Processor()
        {
            IProcessor processor = new I7();
            return processor;
        }

        public virtual ISystemType SystemType()
        {
            ISystemType sysType = new Laptop();
            return sysType;
        }
    }
    public class MacDesktopFactory : MacLaptopFactory
    {
        public override IProcessor Processor()
        {
            IProcessor processor = new I7();
            return processor;
        }

        public override ISystemType SystemType()
        {
            ISystemType sysType = new Laptop();
            return sysType;
        }
    }
    public class DellLaptopFactory : IComputerFactory
    {
        public IBrand Brand()
        {
            IBrand brand = new Dell();
            return brand;
        }

        public virtual IProcessor Processor()
        {
            IProcessor processor = new I7();
            return processor;
        }

        public virtual ISystemType SystemType()
        {
            ISystemType sysType = new Laptop();
            return sysType;
        }
    }
    public class DellDesktopFactory : DellLaptopFactory
    {
        public override IProcessor Processor()
        {
            IProcessor processor = new I7();
            return processor;
        }

        public override ISystemType SystemType()
        {
            ISystemType sysType = new Laptop();
            return sysType;
        }
    }
    #endregion
    public class Factory
    {
        public IComputerFactory Create(Employee emp)
        {
            IComputerFactory returnValue = null;
            if (emp.empType == 1)
            {   
                if (emp.role == "manager")
                {
                    returnValue = new MacLaptopFactory();
                }
                else
                {
                    returnValue = new MacDesktopFactory();
                }
                
            }
            else if (emp.empType == 2)
            {
                if (emp.role == "manager")
                {
                    returnValue = new DellLaptopFactory();
                }
                else
                {
                    returnValue = new DellDesktopFactory();
                }
                return returnValue;
            }
            return returnValue;
        }
    }
    public class EmployeeSystemDesign
    {
        IComputerFactory _IComputerFactory;
        public EmployeeSystemDesign(IComputerFactory IComputerFactory)
        {
            _IComputerFactory = IComputerFactory;
        }
        public string GetSystemDetails()
        {
            IBrand brand = _IComputerFactory.Brand();
            IProcessor processor = _IComputerFactory.Processor();
            ISystemType sysType = _IComputerFactory.SystemType();
            string buildConfig = string.Format("{0},{1},{2}", brand.GetBrand(), processor.GetProcessor(), sysType.GetSystemType());
            return buildConfig;
        }
    }
    public class Employee
    {
        public int empType;
        public string role;
    }
    class Program
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee(){ empType=1, role="manager"};
            IComputerFactory factory = new Factory().Create(emp);
            string sysConfig = new EmployeeSystemDesign(factory).GetSystemDetails();
            Console.WriteLine(sysConfig);
            Console.ReadLine();
        }
    }
}
