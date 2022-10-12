﻿using Avalonia.Platform;
using Avalonia;
using LeagueSpectator.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Media.Imaging;
using Newtonsoft.Json.Linq;
using Rune = LeagueSpectator.Models.Rune;

namespace LeagueSpectator.Helpers
{
    public abstract class BitmapHelper
    {
        const string BASE_URL = "https://raw.communitydragon.org/latest/plugins/rcp-be-lol-game-data/global/default/";
        const string SUMMONER_SPELLS_URL = "data/spells/icons2d";
        const string CHAMPIONS_URL = "v1/champion-icons/";
        const string STATMODS = "/StatMods/";
        const string RUNES = "/Styles/";
        const string RUNES_URL = "v1/perk-images";

        const string SUMMONER_SPELLS_PATH_URL = "v1/summoner-spells.json";       
        const string RUNES_STYLES_PATH_URL = "v1/perkstyles.json";       
        const string RUNES_PATH_URL = "v1/perks.json";       

        public static Bitmap GetSummonerSpell(int id)
        {
            return new Bitmap(AvaloniaLocator.Current.GetService<IAssetLoader>()!.Open(new Uri($"avares://LeagueSpectator/Assets/SummonerSpells/{id}.png")));
        }

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
        public static async Task<Bitmap> GetChampion(int id)
        {
            using (HttpClient httpClient = new() { BaseAddress = new Uri(BASE_URL+CHAMPIONS_URL) })
            {
                using (HttpResponseMessage responseMessage1 = await httpClient.GetAsync($"{id}.png"))
                {
                    if (responseMessage1.IsSuccessStatusCode)
                    {
                        return new Bitmap(await responseMessage1.Content.ReadAsStreamAsync());
                    }
                    return new Bitmap(AvaloniaLocator.Current.GetService<IAssetLoader>()!.Open(new Uri($"avares://LeagueSpectator/Assets/Champions/-1.png")));
                }
            }
        }
        public static Bitmap GetRune(int id)
        {
            return new Bitmap(AvaloniaLocator.Current.GetService<IAssetLoader>()!.Open(new Uri($"avares://LeagueSpectator/Assets/Runes/{id}.png")));
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
