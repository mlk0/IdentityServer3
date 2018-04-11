using IdentityServer3.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ids3.Config
{
    public static class Clients
    {
        public static IEnumerable<Client> Get()
        {
            return new[]
            {
                new Client
                {
                    Enabled = true,
                    ClientName = "JS Client",
                    ClientId = "js",
                    Flow = Flows.Implicit,

                    RedirectUris = new List<string>
                    {
                        "https://localhost/jsOidc/popup.html"
                       // "http://localhost:56668/silent-renew.html"
                    },

                    PostLogoutRedirectUris = new List<string>
                    {
                        "https://localhost/jsOidc/index.html"
                    },

                    AllowedCorsOrigins = new List<string>
                    {
                        "https://localhost/jsOidc",
                        "http://localhost/jsOidc"
                    },

                    AllowAccessToAllScopes = true,
                    AccessTokenLifetime = 60
                }
            };
        }
    }
}