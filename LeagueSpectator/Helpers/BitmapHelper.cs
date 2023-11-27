using Avalonia;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using LeagueSpectator.IServices;
using LeagueSpectator.Models;
using Splat;
using System;

namespace LeagueSpectator.Helpers
{
    public static class BitmapHelper
    {
        private const string BASE_URL = "https://raw.communitydragon.org/latest/plugins/rcp-be-lol-game-data/global/default/";
        private const string SUMMONER_SPELLS_URL = "data/spells/icons2d";
        private const string CHAMPIONS_URL = "v1/champion-icons/";
        private const string STATMODS = "/StatMods/";
        private const string RUNES = "/Styles/";
        private const string RUNES_URL = "v1/perk-images";
        private const string SUMMONER_SPELLS_PATH_URL = "v1/summoner-spells.json";
        private const string RUNES_STYLES_PATH_URL = "v1/perkstyles.json";
        private const string RUNES_PATH_URL = "v1/perks.json";
        private static IFrozenDataService m_CachedData;
        public static bool Initialized { get; }
        static BitmapHelper()
        {
            m_CachedData = Locator.Current.GetService<IFrozenDataService>();
            Initialized = true;
        }

        public static void Initialize()
        {
            m_CachedData ??= Locator.Current.GetService<IFrozenDataService>();
        }

        //public static Bitmap GetSummonerSpell(int id)
        //{
        //    return new Bitmap(AvaloniaLocator.Current.GetService<IAssetLoader>()!.Open(new Uri($"avares://LeagueSpectator/Assets/SummonerSpells/{id}.png")));
        //}

        //DataDragonRequests
        //public static async Task<Bitmap> GetSummonerSpell(int id)
        //{
        //    using (HttpClient httpClient = new() { BaseAddress = new Uri(BASE_URL) })
        //    {
        //        using (HttpResponseMessage responseMessage1 = await httpClient.GetAsync(SUMMONER_SPELLS_PATH_URL))
        //        {
        //            if (responseMessage1.IsSuccessStatusCode)
        //            {
        //                List<SummonerSpell>? summonerSpells = JsonConvert.DeserializeObject<List<SummonerSpell>>(await responseMessage1.Content.ReadAsStringAsync());
        //                if (summonerSpells != null)
        //                {
        //                    SummonerSpell? summonerSpell = summonerSpells.FirstOrDefault(x => x.Id == id);
        //                    if (summonerSpell != null)
        //                    {
        //                        using (HttpResponseMessage responseMessage2 = await httpClient.GetAsync($"{SUMMONER_SPELLS_URL}{summonerSpell.IconPath![summonerSpell.IconPath!.LastIndexOf("/")..].ToLower()}"))
        //                        {
        //                            if (responseMessage1.IsSuccessStatusCode)
        //                            {
        //                                return new Bitmap(await responseMessage2.Content.ReadAsStreamAsync());
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //            return new Bitmap(AvaloniaLocator.Current.GetService<IAssetLoader>()!.Open(new Uri($"avares://LeagueSpectator/Assets/Champions/-1.png")));
        //        }
        //    }
        //}
        //public static Bitmap GetChampion(int id)
        //{
        //    //using (HttpClient httpClient = new() { BaseAddress = new Uri(BASE_URL+CHAMPIONS_URL) })
        //    //{
        //    //    using (HttpResponseMessage responseMessage1 = await httpClient.GetAsync($"{id}.png"))
        //    //    {
        //    //        if (responseMessage1.IsSuccessStatusCode)
        //    //        {
        //    //            return new Bitmap(await responseMessage1.Content.ReadAsStreamAsync());
        //    //        }
        //    //        return new Bitmap(AvaloniaLocator.Current.GetService<IAssetLoader>()!.Open(new Uri($"avares://LeagueSpectator/Assets/Champions/-1.png")));
        //    //    }
        //    //}

        //    return new Bitmap(AvaloniaLocator.Current.GetService<IAssetLoader>()!.Open(new Uri($"avares://LeagueSpectator/Assets/Champions/{id}.png")));
        //}

        //public static Bitmap GetRune(int id)
        //{
        //    return new Bitmap(AvaloniaLocator.Current.GetService<IAssetLoader>()!.Open(new Uri($"avares://LeagueSpectator/Assets/Runes/{id}.png")));
        //}

        internal static Bitmap Get<T>(int id, T leagueType) where T : Enum
        {
            return leagueType switch
            {
                ChampionType => new Bitmap(AvaloniaLocator.Current.GetService<IAssetLoader>()!.Open(new Uri($"avares://LeagueSpectator/Assets/Champions/{id}.png"))),
                RuneType => new Bitmap(AvaloniaLocator.Current.GetService<IAssetLoader>()!.Open(new Uri($"avares://LeagueSpectator/Assets/Runes/{id}.png"))),
                SummonerSpellType => new Bitmap(AvaloniaLocator.Current.GetService<IAssetLoader>()!.Open(new Uri($"avares://LeagueSpectator/Assets/SummonerSpells/{id}.png"))),
                _ => new Bitmap(AvaloniaLocator.Current.GetService<IAssetLoader>()!.Open(new Uri($"avares://LeagueSpectator/Assets/Champions/-1.png"))),
            };
        }

        internal static Bitmap GetCachedBitmap<T>(int id, T leagueType) where T : Enum
        {
            Services.FrozenLeagueObject<T> a = m_CachedData.GetLeagueObject(id, leagueType);
            Bitmap bitmap = m_CachedData.GetLeagueObject(id, leagueType).Icon;
            return bitmap ?? Get(id, leagueType);
        }
        //DataDragonRequests
        //public static async Task<Bitmap> GetRune(int id)
        //{
        //    using (HttpClient httpClient = new() { BaseAddress = new Uri(BASE_URL) })
        //    {
        //        using (HttpResponseMessage responseMessage1 = await httpClient.GetAsync(RUNES_PATH_URL))
        //        {
        //            if (responseMessage1.IsSuccessStatusCode)
        //            {
        //                List<Rune>? summonerSpells = JsonConvert.DeserializeObject<List<Rune>>(await responseMessage1.Content.ReadAsStringAsync());
        //                if (summonerSpells != null)
        //                {
        //                    Rune? rune = summonerSpells.FirstOrDefault(x => x.Id == id);
        //                    if (rune != null)
        //                    {
        //                        string concat;
        //                        if (rune.IconPath.Contains(RUNES))
        //                        {
        //                            concat = $"{RUNES_URL}{rune.IconPath![rune.IconPath!.IndexOf(RUNES)..].ToLower()}";
        //                        }
        //                        else
        //                        {
        //                            concat = $"{RUNES_URL}{rune.IconPath![rune.IconPath!.IndexOf(STATMODS)..].ToLower()}";
        //                        }
        //                        using (HttpResponseMessage responseMessage2 = await httpClient.GetAsync(concat))
        //                        {
        //                            if (responseMessage1.IsSuccessStatusCode)
        //                            {
        //                                return new Bitmap(await responseMessage2.Content.ReadAsStreamAsync());
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //            return new Bitmap(AvaloniaLocator.Current.GetService<IAssetLoader>()!.Open(new Uri($"avares://LeagueSpectator/Assets/Champions/-1.png")));
        //        }
        //    }
        //}
    }
}
