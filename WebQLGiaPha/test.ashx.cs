using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Web;

namespace WebQLGiaPha
{
    /// <summary>
    /// Summary description for test
    /// </summary>
    public class test : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string data = context.Request["txtName"];
            JObject json = new JObject
            {
                { "Ten" , data} 
            };
            context.Response.Write(json);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}