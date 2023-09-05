using OBiletCase.Domain.Models;
using OBiletCase.Services.Interfaces;
using OBiletCase.WebUI.Helpers;
using OBiletCase.WebUI.ModelServices;

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

        private SessionModelService _sessionModelService;

        public DeviceSessionInformationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, SessionModelService sessionModelService)
        {
            _sessionModelService = sessionModelService;

            var cookies = context.Request.Cookies;

            // continue if defined in cookies
            if (cookies.ContainsKey(Constants.CookieName.Session)
                && cookies.ContainsKey(Constants.CookieName.Device))
            {
                await _next(context);
                return;
            }

            var deviceSession = await _sessionModelService.GetDeviceSessionAsync();

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
