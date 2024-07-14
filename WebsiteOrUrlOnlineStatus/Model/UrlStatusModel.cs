using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WebsiteOrUrlOnlineStatus.CommonEnum;

namespace WebsiteOrUrlOnlineStatus.Model
{
    public class UrlStatusModel
    {
        public string? Url { get; set; }
        public UrlStatusEnum Status { get; set; }
    }
}
