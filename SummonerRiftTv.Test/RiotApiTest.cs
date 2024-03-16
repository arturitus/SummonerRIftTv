using SummonerRiftTv.RiotApi.IServices;
using SummonerRiftTv.RiotApi.Models;
using SummonerRiftTv.RiotApi.Services;
using Xunit.Abstractions;

namespace SummonerRiftTV.Test
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
        private const string API_KEY = "RGAPI-9ccfed8c-6c04-40e7-a343-92da983cc2b3";

        private readonly ITestOutputHelper _output;
        private readonly IRiotApiService _RiotApiService;
        private readonly RiotApiServiceFixture _RiotApiServiceFixture;

        public RiotApiTest(ITestOutputHelper output, RiotApiServiceFixture fixture)
        {
            _output = output;
            _RiotApiServiceFixture = fixture;
            _RiotApiService = fixture.RiotApiService;
        }

        [Fact]
        public async Task GetAccountByNameTag_Should_Return_Account1()
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
            catch (SummonerNotFoundException ex)
            {
                _output.WriteLine("Warning: Request was successfull, but no summoner was found.");
                Assert.NotNull(ex);
            }
        }

        [Fact]
        public async Task GetSummonerByEncryptedPUUID_Should_Return_Summoner2()
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
            Assert.NotNull(summoner);
        }

        [Fact]
        public async Task GetSummonerByNameAsync_Should_Return_Summoner3()
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
            catch (SummonerNotFoundException ex)
            {
                _output.WriteLine("Warning: was successfull, but no summoner was found.");
                Assert.NotNull(ex);
            }
        }

        [Fact]
        public async Task GetActiveGameAsync_Should_Return_ActiveGame4()
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
            catch (GameNotFoundException ex)
            {
                _output.WriteLine("Warning: was successfull, but no active game was found.");
                Assert.NotNull(ex);
            }
        }
    }
}