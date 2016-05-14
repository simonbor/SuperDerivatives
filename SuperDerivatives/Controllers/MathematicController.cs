using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using SuperDerivatives.Models;

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
                    var inst = Activator.CreateInstance(Type.GetType(operType.FullName));
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
