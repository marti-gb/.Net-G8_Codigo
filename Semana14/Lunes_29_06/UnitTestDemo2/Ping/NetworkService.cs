using System.Net.NetworkInformation;

namespace UnitTestDemo2.Ping
{
    public class NetworkService
    {
        public string SendPing()
        {
            return "Success: Ping sent";
        }

        public int PingTimeOut(int a, int b)
        {
            return a + b;
        }

        public DateTime LastPingDate()
        {
            return DateTime.Now;
        }

        public PingOptions GetPingOptions()
        {
            return new PingOptions()
            {
                DontFragment = true,
                Ttl = 1
            };
        }

        public IEnumerable<PingOptions> MostRecentPing()
        {
            return new List<PingOptions>()
            {
                new PingOptions()
                {
                    DontFragment= true,
                    Ttl = 1
                },
                new PingOptions()
                {
                    DontFragment= false,
                    Ttl = 2
                },
                new PingOptions()
                {
                    DontFragment= true,
                    Ttl = 3
                }
            };
        }
    }
}
