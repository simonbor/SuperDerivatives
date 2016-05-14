using System;
using System.Web.Http;
using SuperDerivatives.Models;
using OperationFactory;

namespace SuperDerivatives.Controllers
{
    public class MathematicController : ApiController
    {
        public string Calculate(MathExpression exp)
        {
            foreach (var operType in Factory.GetTypes())
            {
                try
                {
                    var inst = Activator.CreateInstance(Type.GetType(operType.AssemblyQualifiedName));
                    if (((IOperation)inst).OperationSymbol == exp.Operation)
                    {
                        return ((IOperation) inst).Calculate(exp.Operand_1.ToString(), exp.Operand_2.ToString());
                    }
                }
                catch (MissingMemberException) {/*do nothing this is interface IOperation */}
            }

            return "NA";
        }
    }
}
