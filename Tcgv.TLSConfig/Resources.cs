namespace Tcgv.TLSConfig
{
    public static class Resources
    {
        public static string InformativeText = @"Best practices outlined in RFC-7525 give reasons why it is discouraged to use
protocol TLS 1.0 and TLS 1.1. PCI-DSS recommends users to switch from
protocol TLS 1.0 and adopt protocol TLS 1.2+.";

        public static string UsageInfo = @"Following table shows for each browser the percentage of connections made to
SSL/TLS servers using protocol TLS 1.0 and TLS 1.1:

Browser/Client Name       Percentage (%) – Both TLS 1.1 and TLS 1.0
Microsoft IE and Edge     0.72%
Mozilla Firefox           1.2%
Safari/Webkit             0.36%
Google Chrome             0.5%
SSL Pulse November 2018   5.84%

(Source: https://blog.qualys.com/)";

        public static string RegistryReference = @"This tool was implemented for use in Windows platforms as instructed in:
- https://docs.microsoft.com/en-us/windows-server/security/tls/tls-registry-settings

Applies to: Windows Server (Semi-Annual Channel), Windows Server 2019, Windows
Server 2016, Windows 10";
    }
}
