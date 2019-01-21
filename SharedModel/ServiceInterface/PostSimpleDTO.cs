using ServiceStack;
using SharedModel.Entity;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SharedModel.ServiceInterface
{
    [Route("/ServiceStack", "POST")]
    public class PostSimpleDTO : IReturn<SimpleDTO>
    {
        public SimpleDTO SimpleDTOContent { get; set; }
    }
}
