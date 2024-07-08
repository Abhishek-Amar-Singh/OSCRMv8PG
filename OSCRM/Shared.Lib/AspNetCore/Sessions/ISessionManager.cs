using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Lib.AspNetCore.Sessions
{
    public interface ISessionManager
    {
        bool IsUserAuthorized(string key);
        void setSessionOfInt32(string key, int val);

        void setSessionOfString(string key, string val);

        void setSessionOfByteArr(string key, byte[] vals);

        int? getSessionOfInt32(string key);

        string getSessionOfString(string key);

        byte[] getSessionOfByteArr(string key);
    }
}
