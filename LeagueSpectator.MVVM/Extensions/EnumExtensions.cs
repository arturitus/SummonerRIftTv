using LeagueSpectator.MVVM.Models;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;

namespace LeagueSpectator.MVVM.Extensions
{
    public static class EnumExtensions
    {
        //public static string GetDescription(this Enum e)
        //{
        //    return e.GetType().GetCustomAttribute<DescriptionAttribute>().Description;
        //}

        //public static string GetDisplayName(this object e, string member)
        //{
        //    if (e.GetType().GetMember(member).FirstOrDefault() is MemberInfo m)
        //    {
        //        if (m.GetCustomAttributes<LocalizationFieldAttribute>() is LocalizationFieldAttribute[] attribute)
        //        {
        //            return attribute.FirstOrDefault(x => x.CultureInfo.Name == CultureInfo.CurrentCulture.Name).DisplayName;
        //        }
        //    }
        //    return e.ToString();
        //}

        //public static string GetDisplayName(this object e, CultureInfo cultureInfo)
        //{
        //    if (e.GetType().GetMember(e.ToString()).FirstOrDefault() is MemberInfo member)
        //    {
        //        if (member.GetCustomAttributes<LocalizationFieldAttribute>() is LocalizationFieldAttribute[] attribute)
        //        {
        //            if (attribute.Length != 0)
        //            {
        //                return attribute.FirstOrDefault(x => x.CultureInfo.Name == cultureInfo.Name).DisplayName;
        //            }
        //        }
        //    }
        //    return e.ToString();
        //}

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
