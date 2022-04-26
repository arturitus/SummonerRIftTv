using LeagueSpectator.Helpers;
using LeagueSpectator.Models;
using LeagueSpectator.Services;
using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace LeagueSpectator.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private string summonerId;
        private readonly IMainWindowService mainWindowService;

        private readonly FileSystemWatcher fileSystemWatcher;

        public IEnumerable<Region> Regions { get; } = EnumHelper.GetEnumValues<Region>();

        private string message;
        public string Message
        {
            get => message;
            set => this.RaiseAndSetIfChanged(ref message, value, nameof(Message));
        }

        private ObservableCollection<int> championIds;
        public ObservableCollection<int> ChampionIds
        {
            get => championIds;
            set => this.RaiseAndSetIfChanged(ref championIds, value, nameof(ChampionIds));
        }

        private bool canSpectate;
        public bool CanSpectate
        {
            get => canSpectate;
            set => this.RaiseAndSetIfChanged(ref canSpectate, value, nameof(CanSpectate));
        }

        private AppData appData;
        public AppData AppData
        {
            get => appData;
            set
            {
                this.RaiseAndSetIfChanged(ref appData, value, nameof(AppData));
            }
        }        

        public MainWindowViewModel()
        {
            mainWindowService = Locator.Current.GetService<IMainWindowService>();
            summonerId = string.Empty;
            message = string.Empty;
            canSpectate = false;
            championIds = new();
            appData = new();
            fileSystemWatcher = new("./Assets");

            fileSystemWatcher.Changed += FileSystemWatcher_Changed;
            fileSystemWatcher.EnableRaisingEvents = true;
            fileSystemWatcher.IncludeSubdirectories = false;
            fileSystemWatcher.Filter = "AppData.json";

            mainWindowService.GetAppData(ref appData);
        }

        private void FileSystemWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            //mainWindowService.GetAppData(ref appData);
            //AppData = appData;
        }

        private async void OnSearchClick(IList<object> parameters)
        {
            if (await mainWindowService.SearchSummonerAsync(parameters[0].ToString()!, (Region)parameters[1], parameters[2].ToString()!, out summonerId))
            {
                if (await mainWindowService.SearchSpectableGameAsync(summonerId!, (Region)parameters[1], parameters[2].ToString()!, out championIds))
                {
                    Message = $"{parameters[0]} is in game";
                    CanSpectate = true;
                    this.RaisePropertyChanged(nameof(ChampionIds));
                    return;
                }
                Message = $"{parameters[0]} is not in game";
                ChampionIds = new();
                CanSpectate = false;
                return;
            }
            ChampionIds = new();
            CanSpectate = false;
            Message = $"{parameters[0]} doesn't exist";
        }

        private async void OnSpectateClick()
        {
            if (await mainWindowService.SpectateGameAsync(appData.LolFolderPath!))
            {

            }
        }
    }
}
