﻿using Avalonia.Media.Imaging;
using LeagueSpectator.Helpers;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace LeagueSpectator.Models
{
    public class BannedChampion
    {
        private int championId;
        [JsonProperty("championId")]
        public int ChampionId
        {
            get => championId;
            set
            {
                championId = value;
                bitmap = BitmapHelper.GetChampion(championId).Result;
                championType = (ChampionType)championId;
            }
        }

        [JsonProperty("teamId")]
        public int TeamId { get; set; }

        [JsonProperty("pickTurn")]
        public int PickTurn { get; set; }

        [JsonIgnore]
        private Bitmap? bitmap;
        [JsonIgnore]
        public Bitmap? Bitmap => bitmap;

        [JsonIgnore]
        private ChampionType championType;

        [JsonIgnore]
        public ChampionType ChampionType => championType;
    }
}
