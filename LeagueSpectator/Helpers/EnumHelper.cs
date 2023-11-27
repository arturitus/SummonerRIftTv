using LeagueSpectator.Models;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace LeagueSpectator.Helpers
{
    public static class EnumHelper
    {
        public static string GetDescription(this Enum e)
        {
            return e.GetType().GetCustomAttribute<DescriptionAttribute>().Description;
        }

        public static string GetDisplayName(this object e, string member)
        {
            if (e.GetType().GetMember(member).FirstOrDefault() is MemberInfo m)
            {
                if (m.GetCustomAttributes<LocalizationFieldAttribute>() is LocalizationFieldAttribute[] attribute)
                {
                    return attribute.FirstOrDefault(x => x.CultureInfo.Name == CultureInfo.CurrentCulture.Name).DisplayName;
                }
            }
            return e.ToString();
        }

        public static string GetDisplayName(this object e, CultureInfo cultureInfo)
        {
            if (e.GetType().GetMember(e.ToString()).FirstOrDefault() is MemberInfo member)
            {
                if (member.GetCustomAttributes<LocalizationFieldAttribute>() is LocalizationFieldAttribute[] attribute)
                {
                    if (attribute.Any())
                    {
                        return attribute.FirstOrDefault(x => x.CultureInfo.Name == cultureInfo.Name).DisplayName;
                    }
                }
            }
            return e.ToString();
        }

        public static CultureInfo GetCulture(this object e)
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
