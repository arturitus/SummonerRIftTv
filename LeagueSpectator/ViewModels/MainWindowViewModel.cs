using Avalonia;
using Avalonia.Controls;
using Avalonia.Threading;
using LeagueSpectator.Helpers;
using LeagueSpectator.Models;
using LeagueSpectator.Services;
using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

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

        private Team blueTeam;
        public Team BlueTeam => blueTeam;

        private Team redTeam;
        public Team RedTeam => redTeam;

        public MainWindowViewModel()
        {
            mainWindowService = Locator.Current.GetService<IMainWindowService>();
            summonerId = string.Empty;
            message = string.Empty;
            canSpectate = false;
            appData = new();
            blueTeam = new();
            redTeam = new();
            fileSystemWatcher = new("./Assets")
            {
                //fileSystemWatcher.Changed += FileSystemWatcher_Changed;
                EnableRaisingEvents = true,
                IncludeSubdirectories = false,
                Filter = "AppData.json"
            };

            mainWindowService.GetAppData(ref appData);
        }

        private void FileSystemWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            //mainWindowService.GetAppData(ref appData);
            //AppData = appData;
        }

        private async void OnSearchClick(IList<object> parameters)
        {
            await Task.Run(async () =>
            {

                try
                {
                    ToggleBusyDialog();
                    await mainWindowService.SearchSummonerAsync(parameters[0].ToString()!, (Region)parameters[1], parameters[2].ToString()!, out summonerId);
                    await mainWindowService.SearchSpectableGameAsync(summonerId!, (Region)parameters[1], parameters[2].ToString()!, out blueTeam, out redTeam);

                    Message = $"{parameters[0]} is in game.";
                    CanSpectate = true;

                    this.RaisePropertyChanged(nameof(BlueTeam));
                    this.RaisePropertyChanged(nameof(RedTeam));
                    return;

                }
                catch (RiotApiError e)
                {
                    if (e.StatusCode == HttpStatusCode.Forbidden)
                    {
                        BlueTeam.Players = new();
                        CanSpectate = false;
                        Message = $"API Key is no longer valid.";

                        return;
                    }
                    switch (e.FunctionName)
                    {
                        case nameof(IRiotApiService.GetSummonerByNameAsync):
                            BlueTeam.Players = new();
                            RedTeam.Players = new();
                            CanSpectate = false;
                            Message = $"{parameters[0]} doesn't exist";

                            return;
                        case nameof(IRiotApiService.GetActiveGameAsync):
                            Message = $"{parameters[0]} is not in game.";
                            BlueTeam.Players = new();
                            RedTeam.Players = new();
                            CanSpectate = false;

                            return;
                    }
                }
                finally
                {
                    ToggleBusyDialog();
                }
            });
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
            BlueTeam.Players = new();
            RedTeam.Players = new();
        }

        private void ToggleBusyDialog()
        {
            Dispatcher.UIThread.InvokeAsync(() =>
            {
                if (DialogHost.DialogHost.IsDialogOpen("busyDialog"))
                {
                    DialogHost.DialogHost.Close("busyDialog");
                    return;
                }
                StackPanel stackPanel = new StackPanel();
                stackPanel.Children.Add(new ProgressBar()
                {
                    IsIndeterminate = true,
                    Classes = new Classes("Circle"),
                    Width = 30,
                    Height = 30,
                    BorderThickness = new Thickness(30)
                });
                DialogHost.DialogHost.Show(stackPanel);
            });
        }
    }
}
