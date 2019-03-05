using ServiceStack;
using SharedModel.Entity;
using SharedModel.ServiceInterface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gopas.XamIntro.Course._4REST.ASP_ServiceStack.ServiceStack
{
    class SimpleEntityDTOClient
    {
        const string baseURL = "http://10.0.2.2:5080/api/";
        private readonly APIClient client = new APIClient(baseURL);

        public async Task<List<SimpleEntity>> Get(string name = "")
        {
            var simpleEntityDTO = new GetSimpleEntityDTO();

            if(! string.IsNullOrEmpty(name))
            {
                simpleEntityDTO.Name = name;
            }

            var response = await client.Get(simpleEntityDTO);

            if (!response.IsErrorResponse())
            {
                return response;
            }
            else
            {
                return new List<SimpleEntity>();
            }
        }

        public async Task<SimpleEntity> CreateOrUpdate(long id, string name)
        {
            CreateOrUpdateSimpleEntityDTO simpleEntityDTO = new CreateOrUpdateSimpleEntityDTO();

            simpleEntityDTO.Id = id;
            simpleEntityDTO.Name = name;

            var response = await client.CreateOrUpdate(simpleEntityDTO);

            if (response.IsErrorResponse())
            {
                return null;
            }
            else
            {
                return response;
            }
        }

        public async Task<string> Delete(long id)
        {
            DeleteSimpleEntityDTO deleteSimpleEntityDTO = new DeleteSimpleEntityDTO
            {
                Id = id
            };
             return await client.Delete(deleteSimpleEntityDTO);

        }
    }
}
