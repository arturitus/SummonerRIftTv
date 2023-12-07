using Avalonia.Media.Imaging;
using Avalonia.Platform;
using System;
using System.Collections.Frozen;
using System.Linq;

namespace LeagueSpectator.Avalonia.Extensions
{
    internal static class AssetLoaderExtensions
    {
        private static readonly FrozenSet<Uri> m_CachedAssets;
        static AssetLoaderExtensions()
        {
            m_CachedAssets = AssetLoader.GetAssets(new Uri("avares://LeagueSpectator.Avalonia/"), new Uri("avares://LeagueSpectator.Avalonia/")).ToFrozenSet();
        }

        internal static Bitmap GetCachedBitmap(this Uri uri)
        {
            return new Bitmap(AssetLoader.Open(m_CachedAssets.FirstOrDefault(x => x == uri)));
        }
    }
}
