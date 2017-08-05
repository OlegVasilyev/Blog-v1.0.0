using System.Collections.Specialized;
using System.Web;

namespace NUnitTestEpamBlog.Tests
{
    public class TestHttpRequest : HttpRequestBase
    {
        public TestHttpRequest(NameValueCollection formParams, NameValueCollection queryStringParams, HttpCookieCollection cookies)
        {
            Form = formParams;
            QueryString = queryStringParams;
            Cookies = cookies;
        }

        public override NameValueCollection Form { get; }

        public override NameValueCollection QueryString { get; }

        public override HttpCookieCollection Cookies { get; }
    }
}
