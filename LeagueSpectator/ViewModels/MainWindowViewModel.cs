using Avalonia;
using Avalonia.Controls;
using Avalonia.Threading;
using LeagueSpectator.DTOs;
using LeagueSpectator.IServices;
using LeagueSpectator.IViewModels;
using LeagueSpectator.Models;
using LeagueSpectator.RiotApi.IServices;
using LeagueSpectator.RiotApi.Models;
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
    public class MainWindowViewModel : ViewModelBase, IMainWindowViewModel
    {
        private Process leagueGameProcess;
        private string summonerId;
        private readonly IMainWindowService mainWindowService;
        public Action<ThemeType> OnThemeChange;
        private readonly FileSystemWatcher fileSystemWatcher;

        public IEnumerable<RegionDTO> Regions => Enum.GetValues<RegionDTO>();
        public IEnumerable<ThemeType> Themes => Enum.GetValues<ThemeType>();
        public IEnumerable<Language> Languages => Enum.GetValues<Language>();

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
        private readonly IAppDataService m_AppDataService;
        public AppData AppData => m_AppDataService.AppData;
        private int m_ThemeIndex;
        public int ThemeIndex
        {
            get => m_ThemeIndex;
            set
            {
                this.RaiseAndSetIfChanged(ref m_ThemeIndex, value, nameof(ThemeIndex));
                //OnThemeChange?.Invoke((ThemeType)m_ThemeIndex);
                m_AppDataService.SetTheme((ThemeType)m_ThemeIndex);


            }
        }
        private int m_LanguageIndex;
        public int LanguageIndex
        {
            get => m_LanguageIndex;
            set
            {
                this.RaiseAndSetIfChanged(ref m_LanguageIndex, value, nameof(LanguageIndex));
                m_AppDataService.SetLanguage((Language)m_LanguageIndex);
                int index = m_ThemeIndex;
                m_ThemeIndex = -1;
                this.RaisePropertyChanged(nameof(ThemeIndex));
                m_ThemeIndex = index;
                this.RaisePropertyChanged(nameof(ThemeIndex));

                //foreach (var b in BlueTeam.Players)
                //{
                //    //b.Spell1Id = b.Spell1Id;
                //    //b.SummonerSpellTypes[0] = b.SummonerSpellTypes[0];
                //    this.RaisePropertyChanged(nameof(b.SummonerSpellType1));
                //    this.RaisePropertyChanged(nameof(b.SummonerSpellType2));
                //}
                //this.RaisePropertyChanged(nameof(Team));
                //this.RaisePropertyChanged(nameof(Team.Players));
            }
        }

        private Team blueTeam;
        public Team BlueTeam => blueTeam;

        private Team redTeam;
        public Team RedTeam => redTeam;

        public MainWindowViewModel(IAppDataService appDataService)
        {
            m_AppDataService = appDataService;
            m_AppDataService.OnLanguageChanged += OnLanguageChanged;
            mainWindowService = Locator.Current.GetService<IMainWindowService>();
            summonerId = string.Empty;
            message = string.Empty;
            canSpectate = false;
            blueTeam = new Team();
            redTeam = new Team();
            fileSystemWatcher = new("./Assets")
            {
                //fileSystemWatcher.Changed += FileSystemWatcher_Changed;
                EnableRaisingEvents = true,
                IncludeSubdirectories = false,
                Filter = "AppData.json"
            };
            ThemeIndex = (int)AppData.ThemeType;
            LanguageIndex = (int)AppData.Language;
        }
        private void OnLanguageChanged(Language obj)
        {
            //this.RaisePropertyChanged(nameof(SummonerSpellTypes));
            //this.RaisePropertyChanged(nameof(SummonerSpellType1));
            //this.RaisePropertyChanged(nameof(SummonerSpellType2));
            BlueTeam.ChangeLanguage();
            RedTeam.ChangeLanguage();
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
                    await mainWindowService.SearchSummonerAsync(parameters[0].ToString()!, (RegionDTO)parameters[1], parameters[2].ToString()!, out summonerId);
                    await mainWindowService.SearchSpectableGameAsync(summonerId!, (RegionDTO)parameters[1], parameters[2].ToString()!, out blueTeam, out redTeam);

                    //Message = $"{parameters[0]} is in game.";
                    Message = string.Empty;
                    CanSpectate = true;

                    this.RaisePropertyChanged(nameof(BlueTeam));
                    this.RaisePropertyChanged(nameof(RedTeam));
                    return;
                }
                catch (RiotApiError e)
                {
                    if (e.StatusCode == HttpStatusCode.Forbidden || e.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        ClearPrevouisMatch();
                        CanSpectate = false;
                        Message = $"API Key is no longer valid.";

                        return;
                    }
                    switch (e.FunctionName)
                    {
                        case nameof(IRiotApiService.GetSummonerByNameAsync):
                            ClearPrevouisMatch();
                            CanSpectate = false;
                            Message = $"{parameters[0]} doesn't exist";

                            return;
                        case nameof(IRiotApiService.GetActiveGameAsync):
                            Message = $"{parameters[0]} is not in game.";
                            ClearPrevouisMatch();
                            CanSpectate = false;

                            return;
                    }
                }
                catch (Exception e)
                {

                }
                finally
                {
                    ToggleBusyDialog();
                }
            });
        }

        private async void OnSpectateClick()
        {
            if (File.Exists($"{m_AppDataService.AppData.LolFolderPath}/LeagueClient.exe"))
            {
                await mainWindowService.SpectateGameAsync(m_AppDataService.AppData.LolFolderPath!);

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
            Message = $"Couldn't locate lol folder at : {m_AppDataService.AppData.LolFolderPath}.";
        }

        private void LeagueGameProcess_Exited(object sender, EventArgs e)
        {
            leagueGameProcess!.Exited -= LeagueGameProcess_Exited;
            leagueGameProcess.Dispose();
            Message = $"Game ended.";
            CanSpectate = true;
            ClearPrevouisMatch();
        }

        private void ClearPrevouisMatch()
        {
            BlueTeam.Clear();
            RedTeam.Clear();
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
