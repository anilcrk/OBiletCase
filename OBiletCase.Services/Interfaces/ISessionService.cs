using OBiletCase.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBiletCase.Services.Interfaces
{
    public interface ISessionService
    {
        /// <summary>
        /// Retrieves a device session based on the provided request model.
        /// </summary>
        /// <param name="request">The session request model containing the necessary information for retrieving a device session.</param>
        /// <returns>A task representing the asynchronous operation, with a DeviceSessionModel as its result.</returns>
        public Task<DeviceSessionModel> GetDeviceSession(SessionRequestModel request);
    }
}
