using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharedModel.ServiceStackFolderModel
{
    [Route("/ServiceStack")]
    [Route("/ServiceStack/{Name}")]
    public class SimpleDTO
    {
        public string MyProperty { get; set; }
    }
}
