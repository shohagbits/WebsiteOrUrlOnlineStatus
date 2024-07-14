using System.Net.NetworkInformation;
using WebsiteOrUrlOnlineStatus.Model;
using WebsiteOrUrlOnlineStatus.Service;
using WebsiteOrUrlOnlineStatus.Data;

namespace WebsiteOrUrlOnlineStatus
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var model = new List<UrlStatusModel>();

            var urls = DataUrls.Urls();
            foreach (var url in urls)
            {
                //var response = await EndPointIsService.IsSuccessPingStatus(url);
                var response = await EndPointIsService.IsSuccessResponseStatus(url);
                model.Add(new UrlStatusModel { Url = url, Status = response });
            }
            foreach (var url in model)
            {
                var message = $"The alive status code-{(int)url.Status} and Description- {CommonEnum.GetEnumDescription(url.Status)} from the URL- {url.Url}";
                await Console.Out.WriteLineAsync(message);
            }
            Console.ReadKey();
        }
    }
}
