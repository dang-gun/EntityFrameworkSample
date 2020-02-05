using System;
using System.Collections.Generic;

namespace DBFirst.ModelDB
{
    public partial class TestUserInfo
    {
        public long IdTestUserInfo { get; set; }
        public long? IdTestUserForeignKey { get; set; }
        public long Lv { get; set; }
        public string NickName { get; set; }
        public double Money { get; set; }

        public virtual TestUser IdTestUserForeignKeyNavigation { get; set; }
    }
}
