using GoodHealth.Application.Localization.Interface;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoodHealth.Application.Localization
{
    public class DefaultJsonLocalization : IJsonLocalization
    {
        private IStringLocalizer<DefaultJsonLocalization> _localizer;
        public DefaultJsonLocalization(IStringLocalizer<DefaultJsonLocalization> localizer)
        {
            _localizer = localizer;
        }

        public string GetResource(string key)
        {
            try
            {
                var resource = _localizer.GetString(key);
                return resource;
            }
            catch
            {
                return string.Empty;
            }
        }

        public string GetResource(string key, params object[] args)
        {
            try
            {
                return string.Format(_localizer.GetString(key), args);
            }
            catch
            {
                return string.Empty;
            }
        }

        public string GetResource(string key, string args)
        {
            try
            {
                var parameters = args.Split(',');

                if (parameters.Count() > 0)
                    return string.Format(_localizer.GetString(key), parameters);
                else
                    return string.Format(_localizer.GetString(key));
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
