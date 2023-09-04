using OBiletCase.Domain.Models;

namespace OBiletCase.WebUI.Helpers
{
    /// <summary>
    /// Provides helper methods to extract client information from HttpRequest and cookies.
    /// </summary>
    public static class ClientInfoHelper
    {
        /// <summary>
        /// Extracts and returns browser information from the given HttpRequest.
        /// </summary>
        /// <param name="request">The HttpRequest containing the User-Agent header.</param>
        /// <returns>An object containing the browser's name and version.</returns>
        public static Browser GetBrowserInfo(HttpRequest request)
        {
            var browser = new Browser();
            string userAgent = request.Headers["User-Agent"].ToString();

            // TODO: a more suitable method for other browsers should be found.
            if (userAgent.Contains("Chrome"))
            {
                browser.Name = "Chrome";
                browser.Version = userAgent.Split("Chrome/")[1].Split(" ")[0];
            }
            else
            {
                browser.Name = "Unknown";
                browser.Version = "Unknown";
            }

            return browser;
        }

        /// <summary>
        /// Extracts and returns session information from the cookies in the request.
        /// </summary>
        /// <param name="cookies">The IRequestCookieCollection containing session cookies.</param>
        /// <returns>An object containing session and device identifiers.</returns>
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
