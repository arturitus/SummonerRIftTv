using Avalonia;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using LeagueSpectator.Helpers;
using LeagueSpectator.IServices;
using LeagueSpectator.Models;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace LeagueSpectator.Services
{
    internal class FrozenDataService : IFrozenDataService
    {
        private readonly List<FrozenLeagueObject<ChampionType>> m_Champions;
        private readonly List<FrozenLeagueObject<RuneType>> m_Runes;
        private readonly List<FrozenLeagueObject<SummonerSpellType>> m_SummonerSpells;

        public FrozenDataService()
        {
            m_Champions = new List<FrozenLeagueObject<ChampionType>>();
            m_Runes = new List<FrozenLeagueObject<RuneType>>();
            m_SummonerSpells = new List<FrozenLeagueObject<SummonerSpellType>>();
            PopulateData();
        }

        private void PopulateData()
        {
            foreach (ChampionType item in Enum.GetValues<ChampionType>())
            {
                m_Champions.Add(new FrozenLeagueObject<ChampionType>((int)item));
            }

            foreach (RuneType item in Enum.GetValues<RuneType>())
            {
                m_Runes.Add(new FrozenLeagueObject<RuneType>((int)item));
            }

            foreach (SummonerSpellType item in Enum.GetValues<SummonerSpellType>())
            {
                m_SummonerSpells.Add(new FrozenLeagueObject<SummonerSpellType>((int)item));
            }
        }

        public FrozenLeagueObject<T> GetLeagueObject<T>(int id, T leagueType) where T : Enum
        {
            return leagueType switch
            {
                ChampionType => m_Champions.FirstOrDefault(c => c.Id == id) as FrozenLeagueObject<T>,
                RuneType => m_Runes.FirstOrDefault(c => c.Id == id) as FrozenLeagueObject<T>,
                SummonerSpellType => m_SummonerSpells.FirstOrDefault(c => c.Id == id) as FrozenLeagueObject<T>,
                _ => m_Champions.FirstOrDefault(c => c.Id == -1) as FrozenLeagueObject<T>,
            };
        }
    }

    internal class FrozenLeagueObject<T> where T : Enum
    {
        public int Id { get; }
        public T ObjectType { get; }
        public Bitmap Icon { get; }
        public FrozenLeagueObject(int id)
        {
            Id = id;
            Icon = BitmapHelper.Get(id, ObjectType);
        }
    }
}
