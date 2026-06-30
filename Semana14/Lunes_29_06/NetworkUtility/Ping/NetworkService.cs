using NetworkUtility.DNS;

namespace NetworkUtility.Ping
{
    public class NetworkService
    {
        private readonly IDNS _dns;
        public NetworkService(IDNS dns)
        {
            _dns = dns;
        }

        public string SendPing()
        {
            var dnsSuccess = _dns.SendDNS();
            if (dnsSuccess) return "SUCCESS: Ping sent";
            else return "FAILLED: Ping not sent";
        }

       
    }
}
