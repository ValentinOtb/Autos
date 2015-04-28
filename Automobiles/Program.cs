using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.IO;
using System.ComponentModel;
namespace Automobiles
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 120;
            a = ConvertTo(Console.ReadLine(), a.GetType());
            Console.WriteLine(a);

            double q = 10.9;
            q = ConvertTo(Console.ReadLine(), q.GetType());
            Console.WriteLine(q);

            string d = "Hello";
            d += ConvertTo(Console.ReadLine(), d.GetType());
            Console.WriteLine(d);
        }

        static void DisplayMenu()
        {
            Console.WriteLine("1. Add car to list.");
            Console.WriteLine("2. Remove car from list.");
            Console.WriteLine("3. Change car state.");
            Console.WriteLine("4. Serialize list of cars.");
            Console.WriteLine("5. Deserialize list.");
        }

        static dynamic ConvertTo(string value, Type type)
        {
            dynamic temp = Convert.ChangeType(value, type);
            return temp;
        }

        static string Serialize(object obj)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer(new SimpleTypeResolver());
            return serializer.Serialize(obj);
        }

        static T Deserialize<T>(string json)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer(new SimpleTypeResolver());
            return serializer.Deserialize<T>(json);
        }
    }

    class CustomTypeResolver : JavaScriptTypeResolver
    {
        public override Type ResolveType(string id)
        {
            throw new NotImplementedException();
        }

        public override string ResolveTypeId(Type type)
        {
            throw new NotImplementedException();
        }
    }
}
