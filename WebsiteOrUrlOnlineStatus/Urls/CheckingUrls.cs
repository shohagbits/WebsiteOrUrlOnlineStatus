using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsiteOrUrlOnlineStatus.Urls
{
    public abstract class CheckingUrls
    {
        public static List<string> Urls()
        {
            var urls = new List<string>()
            {
                "https://www.bracbank.com/en", //OK
                "https://www.bracbank.abcd.com", //NOT OK
                "https://www.bracbank.com/en/test", //NOT OK
                "https://www.w3schools.com/cs/index.php", //OK
                "http://services.odata.org/v4/OData/OData.svc/", //OK
                "https://services.odata.org/v4/Northwind/Northwind.svc/", //OK
            };
            return urls;
        }
    }
}
