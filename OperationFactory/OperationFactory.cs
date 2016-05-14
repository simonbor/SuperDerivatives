using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationFactory
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
}
