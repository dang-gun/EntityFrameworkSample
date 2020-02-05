using System;
using System.Collections.Generic;

namespace DBFirst.ModelDB
{
    public partial class TestUser
    {
        public TestUser()
        {
            TestUserInfo = new HashSet<TestUserInfo>();
        }

        public long IdTestUser { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string JoinDate { get; set; }
        public long JoinType { get; set; }
        public double Money { get; set; }

        public virtual ICollection<TestUserInfo> TestUserInfo { get; set; }
    }
}
