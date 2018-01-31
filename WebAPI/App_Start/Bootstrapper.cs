using System.Web.Http;

namespace WebAPI
{
    public class Bootstrapper
    {
        public static void Run()  
        {  
            //Configure AutoFac  
            AutofacWebApiConfig.Initialize(GlobalConfiguration.Configuration);  
        }  
    }
}