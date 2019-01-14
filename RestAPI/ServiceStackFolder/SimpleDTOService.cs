using ServiceStack;
using SharedModel.ServiceStackFolderModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPI.ServiceStackFolder
{
    public class SimpleDTOService : Service
    {
        public object Any(SimpleDTO request)
        {
            return new SimpleDTOResponse { Result = "Hello, " + request.MyProperty };
        }
    }
}
