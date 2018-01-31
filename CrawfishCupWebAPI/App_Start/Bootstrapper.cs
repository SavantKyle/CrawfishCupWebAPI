using System.Web.Http;

namespace CrawfishCupWebAPI
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