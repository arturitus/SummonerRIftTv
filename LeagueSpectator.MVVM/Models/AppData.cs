﻿using LeagueSpectator.RiotApi.Models;
using System.Drawing;
using System.Text.Json.Serialization;
using Region = LeagueSpectator.RiotApi.Models.Region;

namespace LeagueSpectator.MVVM.Models
{
    public class AppData
    {
        public const string APP_DATA_PATH = "./Assets/AppData.json";
        public event Action<AppData> OnAppDataChanged;
        private string apiKey;
        public string ApiKey
        {
            get
            {
                return apiKey;
            }
            set
            {
                apiKey = value;
                //if (lolFolderPath != null && apiKey != null)
                //{
                //}

                OnAppDataChanged?.Invoke(this);
            }
        }

        private string lolFolderPath;
        public string LolFolderPath
        {
            get
            {
                return lolFolderPath;
            }
            set
            {
                lolFolderPath = value;
                //if (lolFolderPath != null && apiKey != null)
                //{
                //}
                OnAppDataChanged?.Invoke(this);
            }
        }

        private Point position;
        public Point Position
        {
            get => position;
            set
            {
                position = value;
                OnAppDataChanged?.Invoke(this);
            }
        }

        private ThemeType m_ThemeType;
        public ThemeType ThemeType
        {
            get => m_ThemeType;
            set
            {
                m_ThemeType = value;
                OnAppDataChanged?.Invoke(this);
            }
        }
        private Language m_Language;
        public Language Language
        {
            get => m_Language;
            set
            {
                m_Language = value;
                OnAppDataChanged?.Invoke(this);
            }
        }

        private Region m_Region;
        public Region Region
        {
            get => m_Region;
            set
            {
                m_Region = value;
                OnAppDataChanged?.Invoke(this);
            }
        }
    }

    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(AppData))]
    internal partial class SourceGenerationContext : JsonSerializerContext
    {
    }
}
