using ServiceStack;
using SharedModel.Entity;
using SharedModel.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Gopas.XamIntro.Course._4REST.ServiceStack
{
    class APIClient
    {
        IServiceClient client;
        public APIClient(string baseURL)
        {
           client = new JsonServiceClient(baseURL);
        }

        public static Task<bool> IsNetworkAccess(NetworkAccess networkAccess = NetworkAccess.Internet)
        {
            return Task.Run(() =>
            {
                return Connectivity.NetworkAccess == NetworkAccess.Internet;
            });
        }

        public async Task<string> Delete(DeleteSimpleEntityDTO deleteSimpleEntityDTO)
        {
            try
            {
                return await client.DeleteAsync(deleteSimpleEntityDTO);
            }
            catch (WebServiceException webEx)
            {
                Debug.WriteLine(webEx.ToString());
                return string.Empty;
            }
        }


        public async Task<List<SimpleEntity>> Get(GetSimpleEntityDTO getSimpleEntityDTO)
        {
            try
            {
                return await client.GetAsync(getSimpleEntityDTO);
            }
            catch (WebServiceException webEx)
            {
                Debug.WriteLine(webEx.ToString());
                string c = webEx.Message;
                return null;
            }
        }

        public async Task<SimpleEntity> CreateOrUpdate(CreateOrUpdateSimpleEntityDTO createOrUpdatetSimpleEntityDTO)
        {
            try
            { 
                if (createOrUpdatetSimpleEntityDTO.Id != 0)
                {

                    var response = await client.PutAsync(createOrUpdatetSimpleEntityDTO);
                    return response;
                }
                else
                {
                    var response = await client.PostAsync(createOrUpdatetSimpleEntityDTO);
                    return response;
                }

            }
            catch (WebServiceException webEx)
            {
                Debug.WriteLine(webEx.ToString());
                return null;
            }
        }
    }
}
