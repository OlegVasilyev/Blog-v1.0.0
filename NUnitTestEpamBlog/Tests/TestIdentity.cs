using System;
using System.Security.Principal;

namespace NUnitTestEpamBlog.Tests
{
    public class TestIdentity : IIdentity
    {
        private readonly string _name;

        public TestIdentity(string userName)
        {
            _name = userName;

        }

        public string AuthenticationType
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsAuthenticated => !String.IsNullOrEmpty(_name);

        public string Name => _name;
    }
}
