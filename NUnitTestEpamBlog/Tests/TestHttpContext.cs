using System;
using System.Collections.Specialized;
using System.Security.Principal;
using System.Web;
using System.Web.SessionState;

namespace NUnitTestEpamBlog.Tests
{
    public class TestHttpContext : HttpContextBase
    {
        private readonly TestPrincipal _principal;
        private readonly NameValueCollection _formParams;
        private readonly NameValueCollection _queryStringParams;
        private readonly HttpCookieCollection _cookies;
        private readonly SessionStateItemCollection _sessionItems;

        public TestHttpContext(TestPrincipal principal, NameValueCollection formParams,
            NameValueCollection queryStringParams, HttpCookieCollection cookies, SessionStateItemCollection sessionItems)
        {
            _principal = principal;
            _formParams = formParams;
            _queryStringParams = queryStringParams;
            _cookies = cookies;
            _sessionItems = sessionItems;
        }

        public override HttpRequestBase Request => new TestHttpRequest(_formParams, _queryStringParams, _cookies);

        public override IPrincipal User
        {
            get { return _principal; }
            set { throw new NotImplementedException(); }
        }

        public override HttpSessionStateBase Session => new TestHttpSessionState(_sessionItems);

        public override HttpServerUtilityBase Server => new TestHttpServerUtility();
    }
}
