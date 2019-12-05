using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCodeFirst.Global
{
    public static class GlobalStatic
    {
        public static string DBString = "";
        public static DB_CoreCodeFirst DBMgr = new DB_CoreCodeFirst();
    }
}
