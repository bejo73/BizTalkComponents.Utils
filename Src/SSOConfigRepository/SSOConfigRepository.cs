using System;
using BizTalkComponents.Utils.ConfigRepository;

namespace BizTalkComponents.Utils.SSOConfigRepository
{
    public class SSOConfigRepository : IConfigRepository
    {
        public string ReadConfigValue(params string[] keys)
        {
            if (keys.Length < 2)
            {
                throw new ArgumentException("Number of keys is not correct. Expected 2");
            }

            return SSOClientHelper.Read(keys[0], keys[1]);
        }
    }
}
