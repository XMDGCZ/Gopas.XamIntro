using ServiceStack;
using SharedModel.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedModel.ServiceInterface
{
    [Route("/ServiceStack", "GET")]
    [Route("/ServiceStack/{Name}", "GET")]
    public class GetSimpleDTO : IReturn<List<SimpleDTO>>
    {
        public string Name { get; set; }
    }


}
