using ServiceStack;
using SharedModel.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedModel.ServiceInterface
{
    [Route("/ServiceStack")]
    [Route("/ServiceStack/{Name}")]
    public class GetSimpleDTO : IReturn<List<SimpleDTO>>
    {
        public string Name { get; set; }
    }
}
