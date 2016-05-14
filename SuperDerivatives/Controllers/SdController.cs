using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SuperDerivatives.Controllers
{
    public class SdController : ApiController
    {
        public IDictionary Operations()
        {
            //var operations = new Dictionary<string, string>();

            //foreach (var operType in Utils.GetOperations())
            //{
            //    try
            //    {
            //        var inst = Activator.CreateInstance(Type.GetType(operType.FullName));
            //        operations.Add(operType.Name, ((IOperation)inst).OperationSymbol);
            //    }
            //    catch (MissingMemberException){/*do nothing this is interface IOperation */}
            //}

            return Factory.GetOperations();
        }
    }
}
