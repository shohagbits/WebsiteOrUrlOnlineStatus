using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static WebsiteOrUrlOnlineStatus.CommonEnum;

namespace WebsiteOrUrlOnlineStatus.Service
{
    public abstract class EndPointIsService
    {
        // Wait 1 seconds for a reply.
        private static readonly int _timeout = 1000;
        public EndPointIsService()
        {

        }
        public static async Task<UrlStatusEnum> IsSuccessPingStatus(string url)
        {
            var ip = GettingIpFromUrl(url);
            if (!string.IsNullOrWhiteSpace(ip))
            {
                using (var ping = new System.Net.NetworkInformation.Ping())
                {
                    var result = await ping.SendPingAsync(ip, _timeout);
                    if (result.Status == System.Net.NetworkInformation.IPStatus.Success)
                        return UrlStatusEnum.Success;
                }
            }
            else
                return UrlStatusEnum.HostNotFound;

            return UrlStatusEnum.Failed;
        }
        public static async Task<UrlStatusEnum> IsSuccessResponseStatus(string url)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        return UrlStatusEnum.Success;
                    }

                    if (response.StatusCode==HttpStatusCode.NotFound)
                    {
                        return UrlStatusEnum.NotFound;
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                return UrlStatusEnum.HostNotFound;
            }
            catch (Exception ex)
            {
                return UrlStatusEnum.Exception;
            }
            return UrlStatusEnum.Failed;
        }

        #region Private Methods
        public static string? GettingIpFromUrl(string url)
        {
            try
            {
                var myUri = new Uri(url);
                IPAddress ipAddress = Dns.GetHostAddresses(myUri.Host)[0];
                if (ipAddress != null)
                {
                    return ipAddress.ToString();
                }
            }
            catch (ArgumentException ex)
            {

            }
            catch (Exception ex)
            {

            }
            return null;
        }
        #endregion
    }
}
