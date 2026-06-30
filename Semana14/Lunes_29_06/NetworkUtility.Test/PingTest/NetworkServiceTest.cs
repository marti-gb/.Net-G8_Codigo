using FakeItEasy;
using FluentAssertions;
using NetworkUtility.DNS;
using NetworkUtility.Ping;

namespace NetworkUtility.Test.PingTest
{
    public class NetworkServiceTest
    {
        private readonly IDNS _dNS;
        private readonly NetworkService _networkService;
        public NetworkServiceTest()
        {
            _dNS = A.Fake<IDNS>();
            _networkService = new NetworkService(_dNS);
        }

        [Fact]
        public void NetworkService_SendPing_ReturnString()
        {
            //Arrange
            A.CallTo(() => _dNS.SendDNS()).Returns(true);

            //Act
            var result = _networkService.SendPing();

            //Assert
            result.Should().NotBeNullOrWhiteSpace();
            result.Should().Be("SUCCESS: Ping sent");
            result.Should().Contain("SUCCESS", Exactly.Once());

        }
    }
}
