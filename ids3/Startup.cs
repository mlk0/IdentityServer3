using IdentityServer3.Core.Configuration;
using ids3.Config;
using Owin;
using Serilog;
using System;
using System.Security.Cryptography.X509Certificates;


 

namespace ids3
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Log.Logger = new LoggerConfiguration()
                            .MinimumLevel.Debug()
                            .WriteTo.Trace()
                            .CreateLogger();

            app.UseIdentityServer(new IdentityServerOptions
            {
                SiteName = "Embedded IdentityServer",
                SigningCertificate = LoadCertificate("localhost"),

                Factory = new IdentityServerServiceFactory()
                    .UseInMemoryUsers(Users.Get())
                    .UseInMemoryClients(Clients.Get())
                    .UseInMemoryScopes(Scopes.Get())
            });
        }




        private X509Certificate2 LoadCertificate(string certName)
        {
            //Log.Logger.CustomLog_Debug("Startup.LoadCertificate - Certname: {0}", certName);

            try
            {
                X509Store store = new X509Store(StoreLocation.LocalMachine);
                store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);
                var certificate = store.Certificates.Find(X509FindType.FindBySubjectName, certName, false)[0];

                //Log.Logger.CustomLog_Debug("Certificate successfully loaded");
                return certificate;
            }
            catch (Exception ex)
            {
                //Log.Logger.CustomLog_Error("Startup.LoadCertificate - Loading certificate failed. Exception: {0}", ex.ToString());
                return null;
            }
        }
    }
}