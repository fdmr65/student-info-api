using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace StudentInfo.WebAPI.Extensions.BasicAuth
{
    public class BasicAuthentication : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        //Goto Db check user pass
        private readonly List<Dictionary<string, string>> users = new List<Dictionary<string, string>>()
        {
            new Dictionary<string, string>()
            {
                {"name" , "admin" },
                {"pass","admin" }
            }
        };
        public BasicAuthentication(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
        {
        }

        protected  async override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return AuthenticateResult.Fail("No header found");
           }

            var _headerValue = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
            var bytes = Convert.FromBase64String(_headerValue.Parameter);
            string credentials = Encoding.UTF8.GetString(bytes);

            if (!string.IsNullOrEmpty(credentials))
            {
                string[] array = credentials.Split(":");
                string username = array[0];
                string pass = array[1];
                var user = users.FirstOrDefault(a => a["name"] == username && a["pass"] == pass);
                if(user == null)
                {
                    return AuthenticateResult.Fail("UnAuthorized");
                }

                var claim = new[] { new Claim(ClaimTypes.Name, username) };
                var identity = new ClaimsIdentity(claim, Scheme.Name);
                var principal = new ClaimsPrincipal(identity);
                var ticket = new AuthenticationTicket(principal, Scheme.Name);

                return AuthenticateResult.Success(ticket);
            }
            return AuthenticateResult.Fail("UnAuthorized");
        }
    }
}
