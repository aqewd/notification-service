using System;
using System.Runtime.Serialization;

namespace WebApi.Exceptions
{
    [Serializable]
    public class AppSettingNotFoundException : Exception
    {
        public AppSettingNotFoundException()
        {
        }

        public AppSettingNotFoundException(string settingName) : base(ToMessage(settingName))
        {
        }

        public AppSettingNotFoundException(string settingName, Exception innerException) : base(ToMessage(settingName), innerException)
        {
        }
        
        protected AppSettingNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        private static string ToMessage(string settingName) => $"{settingName} is not configured";
    }
}
