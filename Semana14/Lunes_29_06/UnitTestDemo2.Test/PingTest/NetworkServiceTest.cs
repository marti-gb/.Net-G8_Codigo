using FluentAssertions;
using FluentAssertions.Extensions;
using UnitTestDemo2.Ping;

namespace UnitTestDemo2.Test.PingTest
{
    public class NetworkServiceTest
    {
        private readonly NetworkService _networkService;
        public NetworkServiceTest()
        {
            _networkService = new NetworkService();
        }

        [Fact]
        public void NetworkService_SendPing_ReturnString()
        {
            //Arrange

            //Act
            var result = _networkService.SendPing();

            //Assert
            result.Should().NotBeNullOrWhiteSpace();
            result.Should().Be("Success: Ping sent");
            result.Should().Contain("Success", Exactly.Once());
        }

        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(2, 2, 4)]
        public void NetworkService_PingTimeOut_ReturnInt(int a, int b, int expected)
        {
            //Arrange

            //Act
            var result = _networkService.PingTimeOut(a, b);

            //Assert
            result.Should().Be(expected);
            result.Should().BeGreaterThanOrEqualTo(2);
            result.Should().NotBeInRange(-1000, 0);
        }

        [Fact]
        public void NetworkServie_LastPingDate_ReturnDate()
        {
            //Arrange

            //Act
            var result = _networkService.LastPingDate();

            //Assert
            result.Should().BeAfter(1.January(2010));
            result.Should().BeBefore(1.January(2030));

        }
    }
}
