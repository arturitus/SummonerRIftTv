using LeagueSpectator.MVVM.Helpers;
using LeagueSpectator.MVVM.IServices;
using LeagueSpectator.MVVM.Models;
using System.Collections.Frozen;

namespace LeagueSpectator.MVVM.Services
{
    public class FrozenDataService : IFrozenDataService
    {
        private readonly FrozenSet<FrozenLeagueObject<ChampionType>> m_Champions;
        private readonly FrozenSet<FrozenLeagueObject<RuneType>> m_Runes;
        private readonly FrozenSet<FrozenLeagueObject<SummonerSpellType>> m_SummonerSpells;

        //private readonly List<FrozenLeagueObject<ChampionType>> m_Champions;
        //private readonly List<FrozenLeagueObject<RuneType>> m_Runes;
        //private readonly List<FrozenLeagueObject<SummonerSpellType>> m_SummonerSpells;

        public FrozenDataService()
        {
            //m_Champions = new List<FrozenLeagueObject<ChampionType>>();
            //m_Runes = new List<FrozenLeagueObject<RuneType>>();
            //m_SummonerSpells = new List<FrozenLeagueObject<SummonerSpellType>>();
            //PopulateData();

            m_Champions = PopulateData<ChampionType>();
            m_Runes = PopulateData<RuneType>();
            m_SummonerSpells = PopulateData<SummonerSpellType>();
        }

        private void PopulateData()
        {
            //foreach (ChampionType item in Enum.GetValues<ChampionType>())
            //{
            //    m_Champions.Add(new FrozenLeagueObject<ChampionType>((int)item));
            //}

            //foreach (RuneType item in Enum.GetValues<RuneType>())
            //{
            //    m_Runes.Add(new FrozenLeagueObject<RuneType>((int)item));
            //}

            //foreach (SummonerSpellType item in Enum.GetValues<SummonerSpellType>())
            //{
            //    m_SummonerSpells.Add(new FrozenLeagueObject<SummonerSpellType>((int)item));
            //}
        }
        private FrozenSet<FrozenLeagueObject<T>> PopulateData<T>() where T : Enum
        {
            List<FrozenLeagueObject<T>> items = new List<FrozenLeagueObject<T>>();
            foreach (T item in Enum.GetValues(typeof(T)))
            {
                items.Add(new FrozenLeagueObject<T>(Convert.ToInt32(item)));
            }
            return items.ToFrozenSet();
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

    public class FrozenLeagueObject<T> where T : Enum
    {
        public int Id { get; }
        public T ObjectType { get; }
        public Uri Icon { get; }
        public FrozenLeagueObject(int id)
        {
            Id = id;
            Icon = LeagueAssetResolver.GetBitmap(id, ObjectType);
        }
    }
}
