using OBiletCase.Domain.Models;

namespace OBiletCase.WebUI.Helpers
{
    /// <summary>
    /// Includes extension methods based on HttpContext.
    /// </summary>
    public static class HttpContextExtentions
    {
        /// <summary>
        /// Gets information about the client's browser based on the User-Agent header.
        /// </summary>
        /// <param name="context">The HttpContext instance.</param>
        /// <returns>A Browser object containing the browser's name and version.</returns>
        public static Browser GetBrowserInfo(this HttpContext context)
        {
            var browser = new Browser();
            string userAgent = context.Request.Headers["User-Agent"].ToString();

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
        /// Gets the session and device information based on cookies.
        /// </summary>
        /// <param name="context">The HttpContext instance.</param>
        /// <returns>A DeviceSessionModel object containing the session and device IDs.</returns>
        public static DeviceSessionModel GetSessionInfo(this HttpContext context)
        {
            context.Request.Cookies.TryGetValue(Constants.CookieName.Session, out var sessionId);
            context.Request.Cookies.TryGetValue(Constants.CookieName.Device, out var deviceId);

            return new DeviceSessionModel
            {
                SessionId = sessionId,
                DeviceId = deviceId
            };
        }
    }
}
