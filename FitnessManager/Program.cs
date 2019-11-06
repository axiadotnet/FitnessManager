
using FitnessManager.Model;
using System;

namespace FitnessManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer C1 = new Customer("mario", "rossi", 20, Gender.Male);
            C1.Age = -19;

            Customer c2 = new Customer("GG01371347019", "Giorgio", "Gori", Gender.Male, DateTime.Now, 25, 1.82, 89);
            Console.WriteLine(c2);
        }
    }
}
