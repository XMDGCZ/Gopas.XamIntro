using ServiceStack;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedModel.ServiceStackFolderModel
{
    [Route("/ServiceStack")]
    [Route("/ServiceStack/{Name}")]
    public class GetSimpleDTO : IReturn<List<SimpleDTO>>
    {
    }
}
