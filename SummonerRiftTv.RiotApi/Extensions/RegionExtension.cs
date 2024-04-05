using SummonerRiftTv.RiotApi.Models;

namespace SummonerRiftTv.RiotApi.Extensions
{
    public static class RegionExtension
    {
        public static TagLine ToTagLine(this Region region)
        {
            return region switch
            {
                Region.EUW1 => TagLine.EUW,
                Region.EUN1 => TagLine.EUNE,
                Region.NA1 => TagLine.NA1,
                Region.KR => TagLine.KR1,
                Region.RU => TagLine.RU1,
                Region.BR1 => TagLine.BR1,
                _ => TagLine.EUW,
            };
        }

        public static TagLine ToTagLine(this Region? region)
        {
            return region switch
            {
                Region.EUW1 => TagLine.EUW,
                Region.EUN1 => TagLine.EUNE,
                Region.NA1 => TagLine.NA1,
                Region.KR => TagLine.KR1,
                Region.RU => TagLine.RU1,
                Region.BR1 => TagLine.BR1,
                _ => TagLine.EUW,
            };
        }

        public static RiotServerRegion ToRiotServerRegion(this Region? region)
        {
            return region switch
            {
                Region.EUW1 => RiotServerRegion.Europe,
                Region.EUN1 => RiotServerRegion.Europe,
                Region.NA1 => RiotServerRegion.Americas,
                Region.KR => RiotServerRegion.Asia,
                Region.RU => RiotServerRegion.Asia,
                Region.BR1 => RiotServerRegion.Americas,
                _ => RiotServerRegion.Americas,
            };
        }

        public static RiotServerRegion ToRiotServerRegion(this Region region)
        {
            return region switch
            {
                Region.EUW1 => RiotServerRegion.Europe,
                Region.EUN1 => RiotServerRegion.Europe,
                Region.NA1 => RiotServerRegion.Americas,
                Region.KR => RiotServerRegion.Asia,
                Region.RU => RiotServerRegion.Asia,
                Region.BR1 => RiotServerRegion.Americas,
                _ => RiotServerRegion.Americas,
            };
        }
    }
}
