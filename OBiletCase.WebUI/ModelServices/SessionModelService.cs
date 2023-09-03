using OBiletCase.Domain.Models;
using OBiletCase.Services.Interfaces;
using OBiletCase.WebUI.Helpers;

namespace OBiletCase.WebUI.ModelServices
{
    public class SessionModelService
    {
        private readonly ISessionService _sessionService;
        private readonly IHttpContextAccessor _contextAccessor;

        public SessionModelService(ISessionService sessionService, IHttpContextAccessor contextAccessor)
        {
            _sessionService = sessionService;
            _contextAccessor = contextAccessor;
        }

        public Task<DeviceSessionModel> GetDeviceSessionAsync()
        {
            var context = _contextAccessor.HttpContext;
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

            return _sessionService.GetDeviceSession(requestModel);
        }
    }
}
