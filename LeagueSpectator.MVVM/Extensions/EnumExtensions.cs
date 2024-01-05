using LeagueSpectator.MVVM.Models;
using System.Globalization;
using System.Reflection;

namespace LeagueSpectator.MVVM.Extensions
{
    public static class EnumExtensions
    {
        public static CultureInfo GetCulture(this Enum e)
        {
            if (e.GetType().GetMember(e.ToString()).FirstOrDefault() is MemberInfo member)
            {
                if (member.GetCustomAttribute<CultureAttribute>() is CultureAttribute attribute)
                {
                    return attribute.CultureInfo;
                }
            }
            return CultureInfo.CurrentCulture;
        }
    }
}
