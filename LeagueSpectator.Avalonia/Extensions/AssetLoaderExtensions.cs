using Avalonia.Media.Imaging;
using Avalonia.Platform;
using System;
using System.Collections.Frozen;
using System.Linq;

namespace LeagueSpectator.Avalonia.Extensions
{
    internal static class AssetLoaderExtensions
    {
        private const string AVA_RES_BASE = "avares://LeagueSpectator.Avalonia/Assets/";
        private static readonly FrozenSet<Uri> m_CachedAssets;
        static AssetLoaderExtensions()
        {
            m_CachedAssets = AssetLoader.GetAssets(new Uri(AVA_RES_BASE), new Uri(AVA_RES_BASE)).ToFrozenSet();
        }

        internal static Bitmap GetCachedBitmap(this Uri uri)
        {
            Uri absoluteUri = new Uri(new Uri(AVA_RES_BASE), uri);
            Uri cachedBitmap = m_CachedAssets.FirstOrDefault(x => x == absoluteUri);
            if (cachedBitmap != null)
            {
                return new Bitmap(AssetLoader.Open(cachedBitmap));
            }
            return new Bitmap(AssetLoader.Open(new Uri($"{AVA_RES_BASE}/Champions/-1.png")));
        }
    }
}
