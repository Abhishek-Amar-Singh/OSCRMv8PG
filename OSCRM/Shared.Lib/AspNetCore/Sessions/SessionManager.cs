using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Text.Json;

namespace Shared.Lib.AspNetCore.Sessions
{
    public class SessionManager : ISessionManager
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public SessionManager(IHttpContextAccessor _httpContextAccessor) =>
            this._httpContextAccessor = _httpContextAccessor;

        //Session validation
        public bool IsUserAuthorized(string key)
        {
            int? uid = this._httpContextAccessor.HttpContext.Session.GetInt32(key);

            if (uid != null)
            {
                return true;
            }
            else return false;
        }

        public void setSessionOfInt32(string key, int val) =>
            this._httpContextAccessor.HttpContext.Session.SetInt32(key, val);

        public void setSessionOfString(string key, string val) =>
            this._httpContextAccessor.HttpContext.Session.SetString(key, val);

        public void setSessionOfByteArr(string key, byte[] vals) =>
            this._httpContextAccessor.HttpContext.Session.Set(key, vals);

        public int? getSessionOfInt32(string key) =>
            this._httpContextAccessor.HttpContext.Session.GetInt32(key);

        public string getSessionOfString(string key) =>
            this._httpContextAccessor.HttpContext.Session.GetString(key);

        public byte[] getSessionOfByteArr(string key) =>
            this._httpContextAccessor.HttpContext.Session.Get(key);
    }
}
