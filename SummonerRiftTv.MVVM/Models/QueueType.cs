namespace SummonerRiftTv.MVVM.Models
{
    public enum QueueType
    {
        RANKED_SOLO_5x5,
        RANKED_FLEX_SR, 
        CHERRY
    }
    public enum Tier
    {
        Unranked = 0,
        Challenger = 1 << 0,
        Grandmaster = 1 << 1,
        Master = 1 << 2,
        Diamond = 1 << 3,
        Emerald = 1 << 4,
        Platinum = 1 << 5,
        Gold = 1 << 6,
        Silver = 1 << 7,
        Iron = 1 << 8
    }

    //[Flags]
    public enum Rank
    {
        None = 0,
        I = 1 << 0,
        II = 1 << 1,
        III = 1 << 2,
        IV = 1 << 3
    }

    //[Flags]
    public enum AverageTier
    {
        Unranked = 0,
        Challenger1 = Tier.Challenger | Rank.I,
        Grandmaster1 = Tier.Grandmaster | Rank.I,
        Master1 = Tier.Master | Rank.I,
        Diamond1 = Tier.Diamond | Rank.I,
        Diamond2 = Tier.Diamond | Rank.II,
        Diamond3 = Tier.Diamond | Rank.III,
        Diamond4 = Tier.Diamond | Rank.IV,
        Emerald1 = Tier.Emerald | Rank.I,
        Emerald2 = Tier.Emerald | Rank.II,
        Emerald3 = Tier.Emerald | Rank.III,
        Emerald4 = Tier.Emerald | Rank.IV,
        Platinum1 = Tier.Platinum | Rank.I,
        Platinum2 = Tier.Platinum | Rank.II,
        Platinum3 = Tier.Platinum | Rank.III,
        Platinum4 = Tier.Platinum | Rank.IV,
        Gold1 = Tier.Gold | Rank.I,
        Gold2 = Tier.Gold | Rank.II,
        Gold3 = Tier.Gold | Rank.III,
        Gold4 = Tier.Gold | Rank.IV,
        Silver1 = Tier.Silver | Rank.I,
        Silver2 = Tier.Silver | Rank.II,
        Silver3 = Tier.Silver | Rank.III,
        Silver4 = Tier.Silver | Rank.IV,
        Iron1 = Tier.Iron | Rank.I,
        Iron2 = Tier.Iron | Rank.II,
        Iron3 = Tier.Iron | Rank.III,
        Iron4 = Tier.Iron | Rank.IV
    }
}
