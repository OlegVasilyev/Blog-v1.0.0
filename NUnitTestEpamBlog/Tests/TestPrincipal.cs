using System.Linq;
using System.Security.Principal;

namespace NUnitTestEpamBlog.Tests
{
    public class TestPrincipal : IPrincipal
    {
        private readonly string[] _roles;

        public TestPrincipal(IIdentity identity, string[] roles)
        {
            Identity = identity;
            _roles = roles;
        }

        public IIdentity Identity { get; }

        public bool IsInRole(string role)
        {
            if (_roles == null)
                return false;
            return _roles.Contains(role);
        }
    }
}
