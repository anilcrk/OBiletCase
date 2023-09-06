using Newtonsoft.Json;
using OBiletCase.Domain.Models;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

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

        /// <summary>
        /// Serializes an object and stores it in the session with the specified key.
        /// </summary>
        /// <param name="context">The HttpContext in which the session is accessed.</param>
        /// <param name="key">The key under which the object will be stored in the session.</param>
        /// <param name="obj">The object to be stored in the session.</param>
        public static void SetObjectToSession(this HttpContext context, string key, object obj)
        {
            var serializedObject = JsonConvert.SerializeObject(obj);

            context.Session.SetString(key, serializedObject);
        }

        /// <summary>
        /// Retrieves an object from the session with the specified key and deserializes it to the given type.
        /// </summary>
        /// <typeparam name="T">The type to which the object should be deserialized.</typeparam>
        /// <param name="context">The HttpContext in which the session is accessed.</param>
        /// <param name="key">The key under which the object is stored in the session.</param>
        /// <returns>The deserialized object of the given type, or the type's default value if the key does not exist.</returns>
        public static T GetModelFromSession<T>(this HttpContext context, string key)
        {
            
            var sessionObj = context.Session.GetString(key);
            if(sessionObj != null)
            {
                return JsonConvert.DeserializeObject<T>(sessionObj);
            }

            return default;
        }
    }
}
