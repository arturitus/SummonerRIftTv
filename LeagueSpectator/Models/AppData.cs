using Avalonia;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;

namespace LeagueSpectator.Models
{
    public class AppData
    {
        public const string APP_DATA_PATH = "./Assets/AppData.json";

        private string? apiKey;
        public string? ApiKey
        {
            get
            {
                return apiKey;
            }
            set
            {                
                apiKey = value;
                if (lolFolderPath != null && apiKey != null)
                {
                    SetAppData();
                }
            }
        }

        private string? lolFolderPath;
        public string? LolFolderPath
        {
            get
            {
                return lolFolderPath;
            }
            set
            {
                lolFolderPath = value;
                if (lolFolderPath != null && apiKey != null)
                {
                    SetAppData();
                }
            }
        }

        private PixelPoint position;
        public PixelPoint Position 
        {
            get => position;
            set
            {
                position = value; 
                if (lolFolderPath != null && apiKey != null)
                {
                    SetAppData();
                }
            }
        }

        public Task<bool> SetAppData()
        {
            try
            {
                File.WriteAllText(APP_DATA_PATH, JsonConvert.SerializeObject(this, Formatting.Indented));
                return Task.FromResult(true);
            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }
        }

        Task<bool> GetAppData()
        {
            try
            {
                JsonConvert.DeserializeObject<AppData>(File.ReadAllText(APP_DATA_PATH));
                lolFolderPath = JsonConvert.DeserializeObject<AppData>(File.ReadAllText(APP_DATA_PATH)).lolFolderPath;
                apiKey = JsonConvert.DeserializeObject<AppData>(File.ReadAllText(APP_DATA_PATH)).apiKey;
                return Task.FromResult(true);
            }
            catch (Exception)
            {
                lolFolderPath = string.Empty;
                apiKey = string.Empty;
                return Task.FromResult(false);
            }
        }
    }
}
