using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using System.Web;


namespace RestAPI.ResponseResult
{
    public class CustomJsonResult : JsonResult
    {
        public CustomJsonResult(object value) : base(value)
        {
        }

        public CustomJsonResult(object value, JsonSerializerSettings serializerSettings) : base(value, serializerSettings)
        {
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override void ExecuteResult(ActionContext context)
        {

        }

        public override Task ExecuteResultAsync(ActionContext context)
        {
            return base.ExecuteResultAsync(context);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
