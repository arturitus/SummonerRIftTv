using LeagueSpectator.Helpers;
using LeagueSpectator.Models;
using LeagueSpectator.Services;
using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;

namespace LeagueSpectator.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        Process? leagueGameProcess;
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

            //fileSystemWatcher.Changed += FileSystemWatcher_Changed;
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
            try
            {
                await mainWindowService.SearchSummonerAsync(parameters[0].ToString()!, (Region)parameters[1], parameters[2].ToString()!, out summonerId);
                await mainWindowService.SearchSpectableGameAsync(summonerId!, (Region)parameters[1], parameters[2].ToString()!, out championIds);   
                
                Message = $"{parameters[0]} is in game.";
                CanSpectate = true;
                this.RaisePropertyChanged(nameof(ChampionIds));

                return;
                    
            }
            catch (RiotApiError e)
            {
                if (e.StatusCode == HttpStatusCode.Forbidden)
                {
                    ChampionIds = new();
                    CanSpectate = false;
                    Message = $"API Key is no longer valid.";

                    return;
                }
                switch (e.FunctionName)
                {
                    case nameof(IRiotApiService.GetSummonerByNameAsync):
                        ChampionIds = new();
                        CanSpectate = false;
                        Message = $"{parameters[0]} doesn't exist";

                        return;
                    case nameof(IRiotApiService.GetActiveGameAsync):
                        Message = $"{parameters[0]} is not in game.";
                        ChampionIds = new();
                        CanSpectate = false;

                        return;
                }
            }
        }

        private async void OnSpectateClick()
        {
            if (File.Exists($"{appData.LolFolderPath}/LeagueClient.exe"))
            {
                await mainWindowService.SpectateGameAsync(appData.LolFolderPath!);

                int timer = 0;
                while (leagueGameProcess == null)
                {
                    leagueGameProcess = Process.GetProcessesByName("League of Legends").FirstOrDefault();
                    if (timer > 5000)
                    {
                        return;
                    }
                    timer += 100;
                    Thread.Sleep(100);
                }

                if (leagueGameProcess != null)
                {
                    Message = $"Spectating game...";
                    leagueGameProcess!.EnableRaisingEvents = true;
                    leagueGameProcess.Exited += LeagueGameProcess_Exited;
                    CanSpectate = false;
                }

                return;
            }
            Message = $"Couldn't locate lol folder at : {appData.LolFolderPath}.";
        }

        private void LeagueGameProcess_Exited(object? sender, EventArgs e)
        {
            leagueGameProcess!.Exited -= LeagueGameProcess_Exited;
            leagueGameProcess.Dispose();
            Message = $"Game ended.";
            CanSpectate = true;
            ChampionIds = new();
        }
    }
}
