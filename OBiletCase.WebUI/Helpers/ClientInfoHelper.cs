using OBiletCase.Domain.Models;
using System.Runtime.CompilerServices;

namespace OBiletCase.WebUI.Helpers
{
    public static class ClientInfoHelper
    {
        public static Browser GetBrowserInfo(HttpRequest request)
        {
            var browser = new Browser();
            string userAgent = request.Headers["User-Agent"].ToString();

            if (userAgent.Contains("Chrome"))
            {
                browser.Name = "Chrome";
                browser.Version = userAgent.Split("Chrome/")[1].Split(" ")[0];
            }
            else if (userAgent.Contains("Firefox"))
            {
                browser.Name = "Firefox";
                browser.Version = userAgent.Split("Firefox/")[1];
            }
            else if (userAgent.Contains("Safari") && !userAgent.Contains("Chrome"))
            {
                browser.Name = "Safari";
                browser.Version = userAgent.Split("Safari/")[1].Split(" ")[0];
            }
            else if (userAgent.Contains("MSIE") || userAgent.Contains("Trident"))
            {
                browser.Name = "Internet Explorer";

                if (userAgent.Contains("MSIE"))
                {
                    browser.Version = userAgent.Split("MSIE ")[1].Split(";")[0];
                }
                else if (userAgent.Contains("rv:"))
                {
                    browser.Version = userAgent.Split("rv:")[1].Split(")")[0];
                }
            }
            else if (userAgent.Contains("Edg"))
            {
                browser.Name = "Edge";
                browser.Version = userAgent.Split("Edg/")[1].Split(" ")[0];
            }
            else if (userAgent.Contains("Opera"))
            {
                browser.Name = "Opera";

                if (userAgent.Contains("Version/"))
                {
                    browser.Version = userAgent.Split("Version/")[1].Split(" ")[0];
                }
                else if (userAgent.Contains("Opera/"))
                {
                    browser.Version = userAgent.Split("Opera/")[1].Split(" ")[0];
                }
            }
            else
            {
                browser.Name = "Unknown";
                browser.Version = "Unknown";
            }

            return browser;
        }

        public static DeviceSessionModel GetSessionInfo(this IRequestCookieCollection cookies)
        {
            cookies.TryGetValue(Constants.CookieName.Session, out var sessionId);
            cookies.TryGetValue(Constants.CookieName.Device, out var deviceId);

            return new DeviceSessionModel
            {
                SessionId = sessionId,
                DeviceId = deviceId
            };
        }
    }
}
