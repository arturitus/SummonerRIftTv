using SummonerRiftTv.MVVM.Helpers;
using SummonerRiftTv.MVVM.Models;
using SummonerRiftTv.RiotApi.Models;

namespace SummonerRiftTv.DTOs
{
    public class PerksDTO
    {
        private int perkStyle;
        private int perkSubStyle;
        private List<int>? perkIds;

        public int PerkStyle
        {
            get => perkStyle;
            set
            {
                perkStyle = value;
                RuneTree[0].RuneType = (RuneType)perkStyle;
                RuneTree[0].Tree = LeagueAssetResolver.GetUri(perkStyle, RuneTree[0].RuneType);
            }
        }

        public int PerkSubStyle
        {
            get => perkSubStyle;
            set
            {
                perkSubStyle = value;
                RuneTree[1].RuneType = (RuneType)perkSubStyle;
                RuneTree[1].Tree = LeagueAssetResolver.GetUri(perkSubStyle, RuneTree[1].RuneType);
            }
        }

        public RuneTree[] RuneTree { get; }

        public List<int>? PerkIds
        {
            get => perkIds;
            set
            {
                perkIds = value;
                if (perkIds != null)
                {
                    foreach (int id in perkIds)
                    {
                        if (RuneTree[0].Runes.Count >= 4 && RuneTree[1].Runes.Count < 2)
                        {
                            RuneTree[1].Runes.Add(new Rune() { Bitmap = LeagueAssetResolver.GetUri(id, (RuneType)id), RuneType = (RuneType)id });
                        }
                        else if (RuneTree[1].Runes.Count >= 2 && RuneTree[2].Runes.Count < 3)
                        {
                            RuneTree[2].Runes.Add(new Rune() { Bitmap = LeagueAssetResolver.GetUri(id, (RuneType)id), RuneType = (RuneType)id });
                        }
                        else
                        {
                            RuneTree[0].Runes.Add(new Rune() { Bitmap = LeagueAssetResolver.GetUri(id, (RuneType)id), RuneType = (RuneType)id });
                        }
                    }
                }
            }
        }

        public PerksDTO()
        {
            RuneTree = new RuneTree[3];
            for (int i = 0; i < RuneTree.Length; i++)
            {
                RuneTree[i] = new RuneTree();
            }
        }

        public void LocalizeObject()
        {
            foreach (RuneTree rune in RuneTree)
            {
                rune.LocalizeObject();
            }
        }

        public static implicit operator PerksDTO(Perks perks)
        {
            return new PerksDTO()
            {
                PerkIds = perks.PerkIds,
                PerkStyle = perks.PerkStyle,
                PerkSubStyle = perks.PerkSubStyle
            };
        }
    }
}
