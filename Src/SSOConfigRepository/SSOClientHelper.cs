using System;
using System.Collections.Specialized;
using Microsoft.BizTalk.SSOClient.Interop;

namespace BizTalkComponents.Utils.SSOConfigRepository
{
   public class ConfigurationPropertyBag : IPropertyBag
    {
        private readonly HybridDictionary _properties;
        internal ConfigurationPropertyBag()
        {
            _properties = new HybridDictionary();
        }
        public void Read(string propName, out object ptrVar, int errLog)
        {
            ptrVar = _properties[propName];
        }
        public void Write(string propName, ref object ptrVar)
        {
            _properties.Add(propName, ptrVar);
        }
        public bool Contains(string key)
        {
            return _properties.Contains(key);
        }
        public void Remove(string key)
        {
            _properties.Remove(key);
        }
    }

    public static class SSOClientHelper
    {
        private const string idenifierGUID = "ConfigProperties";

        /// <summary>
        /// Read method helps get configuration data
        /// </summary>        
        /// <param name="appName">The name of the affiliate application to represent the configuration container to access</param>
        /// <param name="propName">The property name to read</param>
        /// <returns>
        ///  The value of the property stored in the given affiliate application of this component.
        /// </returns>
        public static string Read(string appName, string propName)
        {
            try
            {
                var ssoStore = new SSOConfigStore();
                var appMgmtBag = new ConfigurationPropertyBag();
                ((ISSOConfigStore) ssoStore).GetConfigInfo(appName, idenifierGUID, SSOFlag.SSO_FLAG_RUNTIME, appMgmtBag);
                object propertyValue;
                appMgmtBag.Read(propName, out propertyValue, 0);
                return (string) propertyValue;
            }
            catch (Exception e)
            {
                System.Diagnostics.Trace.WriteLine(e.Message);
                throw;
            }
        }
    }
}