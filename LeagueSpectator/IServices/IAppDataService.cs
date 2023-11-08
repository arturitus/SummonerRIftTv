﻿using LeagueSpectator.Models;
using System;

namespace LeagueSpectator.IServices
{
    public interface IAppDataService
    {
        public AppData AppData { get; }
        public void WriteAppData();

        public event Action<ThemeType> OnThemeChanged;
        public void SetTheme(ThemeType theme);

        public event Action<Language> OnLanguageChanged;
        public void SetLanguage(Language language);
    }
}
