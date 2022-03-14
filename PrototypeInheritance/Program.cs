using System;

namespace PrototypeInheritance
{
    public interface IDeepCopyable<T> where T : new()
    {
        void CopyTo(T target);
        public T DeepCopy()
        {
            T t = new T();
            CopyTo(t);
            return t;
        }
    }
    public class Address : IDeepCopyable<Address>
    {
        public string StreetName { set; get; }
        public int HouseNumber { set; get; }
        public Address(string name, int number)
        {
            this.StreetName = name;
            this.HouseNumber = number;
        }
        public Address() { }
        public void CopyTo(Address target)
        {
            target.StreetName = StreetName;
            target.HouseNumber = HouseNumber;
        }
        public override string ToString()
        {
            return $"{HouseNumber},{StreetName}";
        }
    }
    public class Person
    {
        //your code
    }
    public class Employee : Person
    {
        //your code
    }


    public static class DeepCopyExtensions
    {
        public static T DeepCopy<T>(this IDeepCopyable<T> item)
            where T : new()
        {
            return item.DeepCopy();
        }
        
    }
    class Program
    {
        static void Main(string[] args)
        {
            Address d = new Address("VoVanNgan", 1);
            
            var d2 = d.DeepCopy();

            Console.WriteLine(d);
            Console.WriteLine(d2);
            d2.HouseNumber = 10;
            Console.WriteLine("Change");
            Console.WriteLine(d);
            Console.WriteLine(d2);

        }
    }
}
