using LeagueSpectator.MVVM.IServices;
using LeagueSpectator.MVVM.IViewModels;
using LeagueSpectator.MVVM.Models;
using LeagueSpectator.RiotApi.IServices;
using LeagueSpectator.RiotApi.Models;
using ReactiveUI;
using System.Collections.Frozen;
using System.Diagnostics;
using System.Net;
using System.Reactive.Linq;

namespace LeagueSpectator.MVVM.ViewModels
{
    public class MainWindowViewModel : ViewModelBase, IMainWindowViewModel
    {
        private Process leagueGameProcess;
        private readonly IMainWindowService m_MainWindowService;
        //public event Action<ThemeType> OnThemeChange;
        public event Action<bool> IsBusy;
        public event Action<FrozenSet<InfoDialogKeys>> InfoDialog;
        public event Action<ErrorDialogFormat> ErrorDialog;
        private readonly FileSystemWatcher fileSystemWatcher;

        //public ReactiveCommand<IList<object>, Unit> SearchCommand { get; }
        //public ReactiveCommand<Unit, Unit> SpectateCommand { get; }
        public IEnumerable<Region> Regions => Enum.GetValues<Region>();
        public IEnumerable<ThemeType> Themes => Enum.GetValues<ThemeType>();
        public IEnumerable<Language> Languages => Enum.GetValues<Language>();

        private SpectateState m_SpectateState;
        public SpectateState SpectateState
        {
            get => m_SpectateState;
            set => this.RaiseAndSetIfChanged(ref m_SpectateState, value, nameof(SpectateState));
        }

        private bool canSpectate;
        public bool CanSpectate
        {
            get => canSpectate;
            set => this.RaiseAndSetIfChanged(ref canSpectate, value, nameof(CanSpectate));
        }
        private readonly IAppDataService m_AppDataService;
        public AppData AppData => m_AppDataService.AppData;
        private ThemeType m_ThemeIndex;
        public ThemeType ThemeIndex
        {
            get => m_ThemeIndex;
            set
            {
                this.RaiseAndSetIfChanged(ref m_ThemeIndex, value, nameof(ThemeIndex));
                //OnThemeChange?.Invoke((ThemeType)m_ThemeIndex);
                m_AppDataService.SetTheme(m_ThemeIndex);


            }
        }
        private Language m_LanguageIndex;
        public Language LanguageIndex
        {
            get => m_LanguageIndex;
            set
            {
                this.RaiseAndSetIfChanged(ref m_LanguageIndex, value, nameof(LanguageIndex));
                m_AppDataService.SetLanguage(m_LanguageIndex);
                //int index = m_ThemeIndex;
                //m_ThemeIndex = -1;
                //this.RaisePropertyChanged(nameof(ThemeIndex));
                //m_ThemeIndex = index;
                //this.RaisePropertyChanged(nameof(ThemeIndex));

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

        public MainWindowViewModel(IAppDataService appDataService, IMainWindowService mainWindowService)
        {
            //SearchCommand = ReactiveCommand.Create<IList<object>>(OnSearchClick);
            //SpectateCommand = ReactiveCommand.Create(OnSpectateClick);
            m_AppDataService = appDataService;
            m_MainWindowService = mainWindowService;
            m_SpectateState = SpectateState.None;
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
            ThemeIndex = AppData.ThemeType;
            LanguageIndex = AppData.Language;
            m_AppDataService.OnLanguageChanged += OnLanguageChanged;
        }


        private IObservable<bool> CanOnSpectate()
        {
            return this.WhenAnyValue(x => x.CanSpectate);
        }


        private void OnLanguageChanged(Language obj)
        {
            //this.RaisePropertyChanged(nameof(SummonerSpellTypes));
            //this.RaisePropertyChanged(nameof(SummonerSpellType1));
            //this.RaisePropertyChanged(nameof(SummonerSpellType2));
            BlueTeam.ChangeLanguage();
            RedTeam.ChangeLanguage();

            //this.RaisePropertyChanged(nameof(ThemeIndex));
            this.RaisePropertyChanged(nameof(SpectateState));
            this.RaisePropertyChanged(nameof(Themes));
            this.RaisePropertyChanged(nameof(Regions));
            this.RaisePropertyChanged(nameof(Languages));
        }

        private void FileSystemWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            //mainWindowService.GetAppData(ref appData);
            //AppData = appData;
        }

        public bool CanSearch(string summName, Region? selectedRegion, string apiKey)
        {
            List<InfoDialogKeys> keys = new();
            bool canSearch = true;
            if (string.IsNullOrEmpty(summName))
            {
                keys.Add(InfoDialogKeys.EmptySummonerName);
                canSearch = false;
            }
            if (selectedRegion == null)
            {
                keys.Add(InfoDialogKeys.EmptyRegion);
                canSearch = false;
            }
            if (string.IsNullOrEmpty(apiKey))
            {
                keys.Add(InfoDialogKeys.EmptyApiKey);
                canSearch = false;
            }
            if (!canSearch)
            {
                InfoDialog?.Invoke(keys.ToFrozenSet());
            }
            return canSearch;
        }

        public async void OnSearchClick(IList<object> parameters)
        {
            string summName = ((string)parameters[0]).Trim();
            Region? selectedRegion = (Region?)parameters[1];
            string apiKey = ((string)parameters[2]).Trim();

            if (!CanSearch(summName, selectedRegion, apiKey))
            {
                return;
            }
            await Task.Run(async () =>
            {
                try
                {
                    //ToggleBusyDialog();
                    IsBusy.Invoke(true);
                    await m_MainWindowService.SearchSummonerAsync(summName, selectedRegion.Value, apiKey, out string summonerId);
                    await m_MainWindowService.SearchSpectableGameAsync(summonerId!, selectedRegion.Value, apiKey, out blueTeam, out redTeam);

                    //Message = $"{parameters[0]} is in game.";
                    SpectateState = SpectateState.None;
                    CanSpectate = true;

                    this.RaisePropertyChanged(nameof(BlueTeam));
                    this.RaisePropertyChanged(nameof(RedTeam));

                    IsBusy.Invoke(false);
                    return;
                }
                catch (RiotApiError e)
                {
                    if (e.StatusCode == HttpStatusCode.Forbidden || e.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        ClearPrevouisMatch();
                        CanSpectate = false;
                        //Message = $"API Key is no longer valid.";
                        IsBusy.Invoke(false);
                        ErrorDialog?.Invoke(new ErrorDialogFormat("", InfoDialogKeys.ApiKeyNotValid));

                        return;
                    }
                    switch (e.FunctionName)
                    {
                        case nameof(IRiotApiService.GetSummonerByNameAsync):
                            ClearPrevouisMatch();
                            CanSpectate = false;
                            //Message = $"{parameters[0]} doesn't exist";
                            IsBusy.Invoke(false);
                            ErrorDialog?.Invoke(new ErrorDialogFormat(summName, InfoDialogKeys.SummonerDoesntExist));

                            return;
                        case nameof(IRiotApiService.GetActiveGameAsync):
                            //Message = $"{parameters[0]} is not in game.";
                            IsBusy.Invoke(false);
                            ErrorDialog?.Invoke(new ErrorDialogFormat(summName, InfoDialogKeys.SummonerIsNotInGame));
                            ClearPrevouisMatch();
                            CanSpectate = false;

                            return;
                    }
                }
                catch (Exception e)
                {

                }
                //finally
                //{
                //    IsBusy.Invoke(false);
                //    //ToggleBusyDialog();
                //}
            });
        }

        private bool CanSpectateClick()
        {
            if (string.IsNullOrEmpty(AppData.LolFolderPath))
            {
                ErrorDialog?.Invoke(new ErrorDialogFormat("", InfoDialogKeys.EmptyLolPathExe));
                return false;
            }
            if (!File.Exists($"{AppData.LolFolderPath}/LeagueClient.exe"))
            {
                ErrorDialog?.Invoke(new ErrorDialogFormat(AppData.LolFolderPath, InfoDialogKeys.CantFindLolExe));
                return false;
            }
            return true;
        }

        public async void OnSpectateClick()
        {
            if (!CanSpectateClick())
            {
                return;
            }

            await m_MainWindowService.SpectateGameAsync(AppData.LolFolderPath);

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
            leagueGameProcess.WaitForInputIdle();

            //if (leagueGameProcess != null)
            //{
            SpectateState = SpectateState.Spectating;
            leagueGameProcess.EnableRaisingEvents = true;
            leagueGameProcess.Exited += LeagueGameProcess_Exited;
            CanSpectate = false;
            //}
        }

        private void LeagueGameProcess_Exited(object sender, EventArgs e)
        {
            leagueGameProcess.Exited -= LeagueGameProcess_Exited;
            leagueGameProcess.Dispose();
            leagueGameProcess = null;
            SpectateState = SpectateState.Ended;
            CanSpectate = true;
            ClearPrevouisMatch();
        }

        private void ClearPrevouisMatch()
        {
            BlueTeam.Clear();
            RedTeam.Clear();
        }
    }
}
