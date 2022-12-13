using System.Reflection;

namespace OOP.Reflection
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Creating instance of an object
            string epoct = "7hp245d@code.edu.az";


            User obj = Activator.CreateInstance<User>();
            //Setting property values with Reflection
            obj.GetType().GetProperty("UserName").SetValue(obj, "Dilqem");
            obj.GetType().GetProperty("Email").SetValue(obj, epoct);


            PrintPropValues(obj);
            //PrintMethodsValue(obj, "GetEmail", epoct);
        }

        public static void PrintPropValues(object obj)
        {
            Type type = obj.GetType();
            PropertyInfo[] props = type.GetProperties();

            string resultStr = String.Empty;
            foreach (var prop in props)
            {
                resultStr += $"{prop.Name} : {prop.GetValue(obj)}\n";
            }
            Console.WriteLine(resultStr);
        }

        public static void PrintMethodsValue(object obj, string methodName, params object[] parameters)
        {
            Type type = obj.GetType();
            var method = type.GetMethod(methodName);
            Console.WriteLine(method.Invoke(obj, parameters));
        }
    }
}