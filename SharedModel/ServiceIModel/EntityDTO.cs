using ServiceStack;
using SharedModel.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedModel.ServiceInterface
{
    [Route("/ServiceStack", "GET")]
    [Route("/ServiceStack/{Name}", "GET")]
    public class GetSimpleEntityDTO : IReturn<List<SimpleEntity>>
    {
        public string Name { get; set; }
    }

    [Route("/ServiceStack", "POST PUT")]
    public class PostSimpleEntityDTO : IReturn<SimpleEntity>
    {
        public SimpleEntity SimpleDTOContent { get; set; }
    }

    [Route("/ServiceStack/{id}", "DELETE")]
    public class DeleteSimpleEntityDTO : IReturn<string>
    {
        public long ID { get; set; }
    }
}
