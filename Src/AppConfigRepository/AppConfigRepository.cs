using System;
using System.Configuration;
using BizTalkComponents.Utils.ConfigRepository;

namespace BizTalkComponents.Utils.AppConfigRepository
{
    public class AppConfigRepository : IConfigRepository
    {
        public string ReadConfigValue(params string[] keys)
        {
            if (keys.Length < 1)
            {
                throw new ArgumentException("Number of keys is not correct. Expected 1");
            }

            return ConfigurationManager.AppSettings[keys[0]];
        }
    }
}
