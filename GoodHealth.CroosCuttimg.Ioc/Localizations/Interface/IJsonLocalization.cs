using System;
using System.Collections.Generic;
using System.Text;

namespace GoodHealth.CroosCuttimg.Ioc.Localizations.Interface
{
    public interface IJsonLocalization
    {
        string GetResource(string key);
        string GetResource(string key, params object[] args);
        string GetResource(string key, string args);
    }
}
