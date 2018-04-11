# IdentityServer3
https://identityserver.github.io/Documentation/docsv2/overview/jsGettingStarted.html

- project was named ids3

- project properties were set on SSL Enabled = true

- Owin and IdentityServer nugets were installed with:
Install-Package Microsoft.Owin.Host.SystemWeb -ProjectName IdentityServer
Install-Package IdentityServer3 -ProjectName IdentityServer

- the Startup class was implemented to load a certifiate from the Personal certificates from the computer store. The certificate that will be loaded is with the name of "IdServCert'

- the certificate with a certificate name of "IdServCert" was generated with:
"C:\Program Files (x86)\Windows Kits\10\bin\x64\makecert" -r -pe -n "CN=IdServCert" -b 01/01/2015 -e 01/01/2020 -eku 1.3.6.1.5.5.7.3.3 -sky signature -a sha256 -len 2048 -ss my -sr LocalMachine
This generates certificate for code signing and is storing it in LocalComputer/Personal store

- set the discovery of the Startup class to be Automatic
   <add key="owin:AutomaticAppStartup" value="true" />
  In this mode, the Startup class needs to be idx3.Startup or to follow the convention of [AssemblyName].Startup

  The alternative would be to add the following class Attribute on the Startup class
  [assembly:OwinStartup(typeof(idx3.Startup))] 

