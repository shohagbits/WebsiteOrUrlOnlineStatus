using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsiteOrUrlOnlineStatus
{
    public static class CommonEnum
    {
        public enum UrlStatusEnum
        {
            [Description("Unknown")]
            Unknown = 0,
            [Description("Success")]
            Success = 1,
            [Description("Failed")]
            Failed = 2,
            [Description("Host Not Found")]
            HostNotFound = 3,
            [Description("URL Not Found")]
            NotFound = 4,
            [Description("Exception Occurred")]
            Exception = 5
        }
        public static string GetEnumDescription(this Enum value)
        {
            var enumType = value.GetType();
            var field = enumType.GetField(value.ToString());
            var attributes = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length == 0 ? value.ToString() : ((DescriptionAttribute)attributes[0]).Description;
        }
    }
}
