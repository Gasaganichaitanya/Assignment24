using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ass24Reflection
{
    internal class Program
    {
        public class Source
        {
            public int num { get; set; }
            public string fName { get; set; }
            public string location {  get; set; }
        }
        public class Destination
        {
            public int num { get; set; }
            public string fName { get; set; }
            public string lName { get; set; }
            public string City { get; set; }


        }
        public static void MapProperties (Source source, Destination destination)
        {
            PropertyInfo[] Sourceprop = typeof(Source).GetProperties();
            PropertyInfo[] Destinationprop = typeof(Destination).GetProperties();

            foreach (var Sprop in Sourceprop) 
            {
                foreach (var Dprop in Destinationprop)
                {
                    if(Dprop.Name == Sprop.Name &&  Sprop.PropertyType==Dprop.PropertyType)
                    {
                        Dprop.SetValue( destination, Sprop.GetValue(source) );
                        break;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            Source S = new Source() 
            { num = 999999, 
                fName= "Abhi", 
                location="Ap" 
            };
            Destination D = new Destination() { num = 918228, fName = "kumar", lName = "sai", City= "Anantapur" };
            MapProperties(S, D);
            Console.WriteLine("Mapped properties in Destination are:");
            Console.WriteLine($"num : {D.num }");
            Console.WriteLine($"fname : {D.fName}");
            Console.WriteLine($"lname : {D.lName}");
            Console.WriteLine($"City : {D.City}");

            Console.ReadKey();
        }
    }
}
