using Avalonia.Media.Imaging;
using SummonerRiftTv.MVVM.ViewModels;
using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace SummonerRiftTv.Avalonia.Extensions
{
    internal static class AssetLoaderExtensions
    {
        private const string AVA_RES_BASE = "resm:SummonerRiftTv.MVVM.Assets";
        //private const string AVA_RES_BASE = "avares://SummonerRiftTv.Avalonia/Assets/";

        private const string EMBEDDED_RESOURCES_NAMESPACE = "SummonerRiftTv.MVVM.Assets";
        private static readonly string[] SUBFORLDERS = ["Champions", "Runes", "SummonerSpells"];

        private static readonly Bitmap m_NoneSelected;
        private static readonly FrozenSet<EmbeddedResource> m_CachedAssets;
        //private static readonly FrozenSet<Stream> m_CachedAssets;
        static AssetLoaderExtensions()
        {
            m_NoneSelected = GetEmbeddedNothing<MainWindowViewModel>("Champions.-1.png");
            m_CachedAssets = GetEmbeddedAssets<MainWindowViewModel>(EMBEDDED_RESOURCES_NAMESPACE, SUBFORLDERS).ToFrozenSet();
        }

        internal static Bitmap GetCachedBitmap(this Uri uri)
        {
            //Uri absoluteUri = new Uri($"{AVA_RES_BASE}.{uri}");
            EmbeddedResource cachedBitmap = m_CachedAssets.FirstOrDefault(x => x.Uri == uri);
            if (cachedBitmap != null)
            {
                return cachedBitmap.Bitmap;
            }
            //return new Bitmap(AssetLoader.Open(new Uri($"{AVA_RES_BASE}/Champions/-1.png")));
            return m_NoneSelected;
        }

        internal static void Init()
        {
        }

        private static List<EmbeddedResource> GetEmbeddedAssets<T>(string namespc, string[] subfolders)
        {
            Assembly callingAssembly = Assembly.GetAssembly(typeof(T));
            string[] resourceNames = callingAssembly.GetManifestResourceNames();
            List<EmbeddedResource> embeddeResources = [];

            foreach (string subfolder in subfolders)
            {
                string resourceNamespace = $"{namespc}.{subfolder}";

                foreach (string res in resourceNames.Where(x => x.Contains(resourceNamespace) && x.EndsWith(".png")))
                {
                    string[] a = res.Split('.');
                    string resId = $"{subfolder}.{a[4]}";
                    embeddeResources.Add(new EmbeddedResource(new Uri(resId, UriKind.Relative), callingAssembly.GetManifestResourceStream(res)));
                }
            }
            return embeddeResources;
        }

        private static Bitmap GetEmbeddedNothing<T>(string file)
        {
            Stream stream = Assembly.GetAssembly(typeof(T)).GetManifestResourceStream($"{EMBEDDED_RESOURCES_NAMESPACE}.{file}");
            return new Bitmap(stream);
        }
    }
    internal class EmbeddedResource(Uri uri, Stream stream)
    {
        public Uri Uri { get; } = uri;
        public Bitmap Bitmap { get; } = new Bitmap(stream);
    }
}
