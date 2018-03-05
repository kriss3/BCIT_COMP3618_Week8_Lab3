using System;
using System.Reflection;
using static System.Console;

namespace ConAppAssemblyDemo
{
    class MyApp
    {
        /// <summary>
        /// BCIT COMP3618 Week 8 Lab 3
        /// Loading assemly and dump its type.
        /// Repo: https://github.com/kriss3/BCIT_COMP3618_Week8_Lab3.git
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            string path = @"C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\System.ServiceProcess.dll";
           
            // Using BindingFlags to only get declared and instance members
            BindingFlags flags = BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance;
            // Load the Assembly from the path
            Assembly theAssembly = Assembly.LoadFrom(path);
            WriteLine(theAssembly.FullName);
            Type[] types = theAssembly.GetTypes();
            foreach (Type t in types)
            {
                WriteLine($" Type: {t.Name}");
                MemberInfo[] members = t.GetMembers(flags);
                foreach (MemberInfo member in members)
                {
                    WriteLine($" {member.MemberType} : {member.Name}");
                }
            }
            Read();
        }
    }
}
