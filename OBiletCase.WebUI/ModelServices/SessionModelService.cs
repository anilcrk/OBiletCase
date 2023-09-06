using OBiletCase.Domain.Models;
using OBiletCase.Services.Interfaces;
using OBiletCase.WebUI.Helpers;

namespace OBiletCase.WebUI.ModelServices
{
    /// <summary>
    /// Manages session-related operations for the application.
    /// Serves as an intermediary between the session service and the controller.
    /// </summary>
    public class SessionModelService
    {
        private readonly ISessionService _sessionService;
        private readonly IHttpContextAccessor _contextAccessor;

        public SessionModelService(ISessionService sessionService, IHttpContextAccessor contextAccessor)
        {
            _sessionService = sessionService;
            _contextAccessor = contextAccessor;
        }

        /// <summary>
        /// Fetches the device session information asynchronously.
        /// Collects necessary data like browser info and IP address from the HTTP context.
        /// </summary>
        /// <returns>Device session details.</returns>
        public Task<DeviceSessionModel> GetDeviceSessionAsync()
        {
            var context = _contextAccessor.HttpContext;
            var browserInfo = context.GetBrowserInfo();
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

            return _sessionService.GetDeviceSession(requestModel);
        }
    }
}
