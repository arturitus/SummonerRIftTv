using LeagueSpectator.MVVM.IServices;
using LeagueSpectator.MVVM.IViewModels;
using LeagueSpectator.MVVM.Models;
using LeagueSpectator.MVVM.Services;
using LeagueSpectator.RiotApi.Models;
using ReactiveUI;
using System.Collections.Frozen;

namespace LeagueSpectator.MVVM.ViewModels
{
    public class MainWindowViewModel : ViewModelBase, IMainWindowViewModel
    {
        private readonly IMainWindowService m_MainWindowService;
        //public event Action<ThemeType> OnThemeChange;
        public event Action<bool> IsBusy;
        public event Action<FrozenSet<InfoDialogKeys>> InfoDialog;
        public event Action<ErrorDialogFormat> ErrorDialog;
        private readonly FileSystemWatcher fileSystemWatcher;

        //public ReactiveCommand<IList<object>, Unit> SearchCommand { get; }
        //public ReactiveCommand<Unit, Unit> SpectateCommand { get; }
        //public IEnumerable<Region> Regions => Enum.GetValues<Region>();
        //public IEnumerable<ThemeType> Themes => Enum.GetValues<ThemeType>();
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

        private Region m_SelectedRegion;
        public Region SelectedRegion
        {
            get => m_SelectedRegion;
            set
            {
                m_SelectedRegion = value;
                AppData.Region = value;
            }
        }

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

        private Team m_BlueTeam;
        public Team BlueTeam
        {
            get => m_BlueTeam;
            set => this.RaiseAndSetIfChanged(ref m_BlueTeam, value, nameof(BlueTeam));
        }

        private Team m_RedTeam;
        public Team RedTeam
        {
            get => m_RedTeam;
            set => this.RaiseAndSetIfChanged(ref m_RedTeam, value, nameof(RedTeam));
        }

        public MainWindowViewModel(IAppDataService appDataService, IMainWindowService mainWindowService)
        {
            //SearchCommand = ReactiveCommand.Create<IList<object>>(OnSearchClick);
            //SpectateCommand = ReactiveCommand.Create(OnSpectateClick);
            m_AppDataService = appDataService;
            m_MainWindowService = mainWindowService;
            m_SpectateState = SpectateState.NoneSpectate;
            canSpectate = false;
            m_BlueTeam = new Team();
            m_RedTeam = new Team();
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
            m_MainWindowService.SpectateChanged += OnSpectateStateChanged;
            SelectedRegion = AppData.Region;
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

            this.RaisePropertyChanged(nameof(SelectedRegion));
            this.RaisePropertyChanged(nameof(ThemeIndex));
            //this.RaisePropertyChanged(nameof(LanguageIndex));
            this.RaisePropertyChanged(nameof(SpectateState));

            //this.RaisePropertyChanged(nameof(Themes));
            //this.RaisePropertyChanged(nameof(Regions));
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
            ClearPrevouisMatch();
            await Task.Run(async () =>
            {
                try
                {
                    IsBusy?.Invoke(true);
                    Team[] teams = await m_MainWindowService.SearchSpectableGameAsync(summName, selectedRegion.Value, apiKey);

                    SpectateState = SpectateState.NoneSpectate;
                    CanSpectate = true;

                    BlueTeam = teams[0];
                    RedTeam = teams[1];

                    IsBusy?.Invoke(false);
                }
                catch (MainWindowServiceError e)
                {
                    CanSpectate = false;
                    IsBusy?.Invoke(false);
                    ErrorDialog?.Invoke(e.ErrorFormat);
                }
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
        }

        private void OnSpectateStateChanged(SpectateState spectateState, bool canSpectate)
        {
            SpectateState = spectateState;
            CanSpectate = canSpectate;
        }

        private void ClearPrevouisMatch()
        {
            BlueTeam.Clear();
            RedTeam.Clear();
        }
    }
}
