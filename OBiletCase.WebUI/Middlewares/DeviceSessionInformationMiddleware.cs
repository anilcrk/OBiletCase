using OBiletCase.Domain.Models;
using OBiletCase.Services.Interfaces;
using OBiletCase.WebUI.Helpers;

namespace OBiletCase.WebUI.Middlewares
{
    /// <summary>
    /// Middleware to manage session and device identification.
    /// Checks if the client already has session and device IDs stored in cookies.
    /// If not, a new session is requested from the ISessionService and the IDs are stored in cookies.
    /// </summary>
    public class DeviceSessionInformationMiddleware
    {
        private readonly RequestDelegate _next;

        private ISessionService _sessionService;

        public DeviceSessionInformationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, ISessionService sessionService)
        {
            _sessionService = sessionService;

            var cookies = context.Request.Cookies;

            // continue if defined in cookies
            if (cookies.ContainsKey(Constants.CookieName.Session)
                && cookies.ContainsKey(Constants.CookieName.Device))
            {
                await _next(context);
                return;
            }

            var browserInfo = ClientInfoHelper.GetBrowserInfo(context.Request);
            var ipAddress = context.Connection.RemoteIpAddress;
            var port = context.Connection.RemotePort;

            var requestModel = new SessionRequestModel
            {
                Browser = browserInfo,
                Connection = new Connection
                {
                    IpAdress = ipAddress?.ToString(),
                    Port = port.ToString()
                },
                Type = 1
            };

            var deviceSession = await _sessionService.GetSession(requestModel);

            if (deviceSession != null)
            {
                // device session information is added to cookies after receiving
                var sessionCookieOption = new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    Expires = DateTime.Now.AddHours(1),
                    SameSite = SameSiteMode.None
                };

                var deviceCookieOption = new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    Expires = DateTime.Now.AddYears(1),
                    SameSite = SameSiteMode.None
                };

                context.Response.Cookies.Append(Constants.CookieName.Session, deviceSession.SessionId, sessionCookieOption);
                context.Response.Cookies.Append(Constants.CookieName.Device, deviceSession.DeviceId, deviceCookieOption);
            }

            await _next(context);
        }
    }
}
