using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;

namespace SuperDerivatives
{
    public interface IOperation
    {
        string Calculate(string x, string y);
        string OperationSymbol { get; }
    }

    public class OperationSigma : IOperation
    {
        public string Calculate(string x, string y)
        {
            return (new DataTable()).Compute($"{x} + {y}", "").ToString();
        }
        public string OperationSymbol => "+"; // expression body
    }

    public class OperationSub : IOperation
    {
        public string Calculate(string x, string y)
        {
            return (new DataTable()).Compute($"{x} - {y}", "").ToString();
        }
        public string OperationSymbol => "-"; // expression body
    }

    public static class Factory
    {
        public static List<Type> GetTypes()
        {
            var type = typeof(IOperation);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => GetLoadableTypes(s)) // s.GetTypes();
                .Where(p => type.IsAssignableFrom(p));

            //var types = AppDomain.CurrentDomain.GetAssemblies()
            //    .SelectMany(s => delegate (Assembly s) { return s.GetTypes(); })
            //    .Where(p => type.IsAssignableFrom(p));

            return types.ToList();
        }

        public static IEnumerable<Type> GetLoadableTypes(Assembly assembly)
        {
            try
            {
                return assembly.GetTypes();
            }
            catch (ReflectionTypeLoadException e)
            {
                return e.Types.Where(t => t != null);
            }
        }

        public static Dictionary<string, string> GetOperations()
        {
            var operations = new Dictionary<string, string>();

            foreach (var operType in GetTypes())
            {
                try
                {
                    var inst = Activator.CreateInstance(Type.GetType(operType.FullName));
                    operations.Add(operType.Name, ((IOperation)inst).OperationSymbol);
                }
                catch (MissingMemberException) {/*do nothing this is interface IOperation */}
            }

            return operations;
        }
    }
}