using LeagueSpectator.MVVM.IServices;
using LeagueSpectator.MVVM.Models;
using System.Text.Json;

namespace LeagueSpectator.MVVM.Services
{
    public class AppDataService : IAppDataService
    {
        public const string APP_DATA_PATH = "./Assets/AppData.json";
        private AppData m_AppData;

        public event Action<ThemeType> OnThemeChanged;
        public event Action<Language> OnLanguageChanged;

        public AppData AppData => m_AppData;
        public AppDataService()
        {
            string a = File.ReadAllText(APP_DATA_PATH);
            m_AppData = JsonSerializer.Deserialize(File.ReadAllText(APP_DATA_PATH), SourceGenerationContext.Default.AppData) ?? new AppData();
            m_AppData.OnAppDataChanged += OnAppDataChanged;
        }

        public void WriteAppData()
        {
            File.WriteAllText(APP_DATA_PATH, JsonSerializer.Serialize(m_AppData, SourceGenerationContext.Default.AppData));
        }

        private void OnAppDataChanged(AppData appData)
        {
            m_AppData = appData;
            WriteAppData();
        }

        public void SetTheme(ThemeType theme)
        {
            m_AppData.ThemeType = theme;
            OnThemeChanged?.Invoke(theme);
        }

        public void SetLanguage(Language language)
        {
            m_AppData.Language = language;
            OnLanguageChanged?.Invoke(language);
        }
    }
}
