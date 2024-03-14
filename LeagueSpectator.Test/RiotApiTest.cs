using LeagueSpectator.RiotApi.IServices;
using LeagueSpectator.RiotApi.Models;
using LeagueSpectator.RiotApi.Services;

namespace LeagueSpectator.Test
{
    public class RiotApiServiceFixture : IDisposable
    {
        public IRiotApiService RiotApiService { get; }
        public string EncryptedPuuid { get; set; } = string.Empty;
        public string SummonerId { get; set; } = string.Empty;

        public RiotApiServiceFixture()
        {
            RiotApiService = new RiotApiService(); // Instantiate your implementation of IRiotApiService
                                                   // Additional setup code if needed
        }

        public void Dispose()
        {
            // Clean up resources here if needed
        }
    }

    public class RiotApiTest : IClassFixture<RiotApiServiceFixture>
    {
        private const string SUMMONER_NAME = "arturo238";
        private const string TAG_LINE = "EUW";
        private const Region REGION = Region.EUW1;
        //private const string API_KEY = "RGAPI-1377051c-7ed6-41b3-9793-6b1fa908f03c";
        private const string API_KEY = "RGAPI-7e00c119-71cb-40bb-bd3d-dc511ad68c73";

        private readonly IRiotApiService _RiotApiService;
        private readonly RiotApiServiceFixture _RiotApiServiceFixture;

        public RiotApiTest(RiotApiServiceFixture fixture)
        {
            _RiotApiServiceFixture = fixture;
            _RiotApiService = fixture.RiotApiService;
        }

        [Fact]
        public async Task Get1AccountByNameTag_Should_Return_Account()
        {
            try
            {
                Account account = await _RiotApiService.GetAccountByNameTag(SUMMONER_NAME, TAG_LINE, REGION, API_KEY);

                if (account is not null)
                {
                    _RiotApiServiceFixture.EncryptedPuuid = account.Puuid;
                }
                Assert.NotNull(account);
            }
            catch (SummonerNotFoundException)
            {
                Assert.Fail("Request was successfull, but no summoner was found.");
            }
        }

        [Fact]
        public async Task Get2SummonerByEncryptedPUUID_Should_Return_Summoner()
        {
            if (string.IsNullOrEmpty(_RiotApiServiceFixture.EncryptedPuuid))
            {
                Assert.Fail($"{nameof(_RiotApiServiceFixture.EncryptedPuuid)} was null or empty");
            }
            Summoner summoner = await _RiotApiService.GetSummonerByEncryptedPUUID(_RiotApiServiceFixture.EncryptedPuuid, REGION, API_KEY);

            if (summoner is not null)
            {
                _RiotApiServiceFixture.SummonerId = summoner.Id;
            }
            // Assert
            Assert.NotNull(summoner);
            // Add more assertions as needed
        }

        [Fact]
        public async Task Get3SummonerByNameAsync_Should_Return_Summoner()
        {
            try
            {
                Summoner summoner = await _RiotApiService.GetSummonerByNameAsync(SUMMONER_NAME, REGION, API_KEY);

                if (summoner is not null)
                {
                    _RiotApiServiceFixture.SummonerId = summoner.Id;
                }
                Assert.NotNull(summoner);
            }
            catch (SummonerNotFoundException)
            {
                Assert.Fail("Request was successfull, but no summoner was found.");
            }
        }

        [Fact]
        public async Task Get4ActiveGameAsync_Should_Return_ActiveGame()
        {
            if (string.IsNullOrEmpty(_RiotApiServiceFixture.SummonerId))
            {
                Assert.Fail($"{nameof(_RiotApiServiceFixture.SummonerId)} was null or empty");
            }
            try
            {
                ActiveGame activeGame = await _RiotApiService.GetActiveGameAsync(_RiotApiServiceFixture.SummonerId, REGION, API_KEY);

                Assert.NotNull(activeGame);
            }
            catch (GameNotFoundException)
            {
                Assert.Fail("Request was successfull, but no active game was found.");
            }
        }
    }
}