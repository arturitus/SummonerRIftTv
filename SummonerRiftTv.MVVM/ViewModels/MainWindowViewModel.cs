using ReactiveUI;
using SummonerRiftTv.MVVM.DTOs;
using SummonerRiftTv.MVVM.IServices;
using SummonerRiftTv.MVVM.IViewModels;
using SummonerRiftTv.MVVM.Models;
using SummonerRiftTv.RiotApi.Extensions;
using SummonerRiftTv.RiotApi.Models;
using System.Collections.Frozen;

namespace SummonerRiftTv.MVVM.ViewModels
{
    public class MainWindowViewModel : ViewModelBase, IMainWindowViewModel
    {
        private readonly IMainWindowService m_MainWindowService;
        //public event Action<ThemeType> OnThemeChange;
        public event Action<bool>? IsBusy;
        public event Action<FrozenSet<InfoDialogKeys>>? InfoDialog;
        public event Action<ErrorDialogFormat>? ErrorDialog;
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
                this.RaisePropertyChanged(nameof(TagLine));
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

        public TagLine TagLine => SelectedRegion.ToTagLine();

        private ActiveGameDTO m_ActiveGame;
        public ActiveGameDTO ActiveGame
        {
            get => m_ActiveGame;
            set => this.RaiseAndSetIfChanged(ref m_ActiveGame, value, nameof(ActiveGame));
        }
        public MainWindowViewModel(IAppDataService appDataService, IMainWindowService mainWindowService)
        {
            //SearchCommand = ReactiveCommand.Create<IList<object>>(OnSearchClick);
            //SpectateCommand = ReactiveCommand.Create(OnSpectateClick);
            m_AppDataService = appDataService;
            m_MainWindowService = mainWindowService;
            m_SpectateState = SpectateState.NoneSpectate;
            canSpectate = false;
            m_ActiveGame = new ActiveGameDTO();
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
            m_ActiveGame.LocalizeObject();

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

        public bool CanSearch(IList<object> parameters, ref string summName, ref Region? selectedRegion)
        {
            List<InfoDialogKeys> keys = new();
            bool canSearch = true;
            if (string.IsNullOrEmpty((string)parameters[0]))
            {
                keys.Add(InfoDialogKeys.EmptySummonerName);
                canSearch = false;
            }
            if (parameters[1] is null || ((int)parameters[1] == -1))
            {
                keys.Add(InfoDialogKeys.EmptyRegion);
                canSearch = false;
            }
            if (!canSearch)
            {
                InfoDialog?.Invoke(keys.ToFrozenSet());
            }
            else
            {
                summName = ((string)parameters[0]).Trim();
                selectedRegion = (Region?)parameters[1];
            }
            return canSearch;
        }

        public async Task OnSearchClick(IList<object> parameters)
        {
            string summName = string.Empty;
            Region? selectedRegion = default;
            string tagLine = string.Empty;


            if (!CanSearch(parameters, ref summName, ref selectedRegion))
            {
                return;
            }
            if (summName.Contains('#'))
            {
                string[] splitName = summName.Split('#');
                summName = splitName[0];
                tagLine = splitName[1];
            }
            if (string.IsNullOrEmpty(tagLine))
            {
                tagLine = selectedRegion.ToTagLine().ToString();
            }

            m_ActiveGame.ClearPrevouisMatch();

            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

            await Task.Run(async () =>
            {
                try
                {
                    IsBusy?.Invoke(true);
                    ActiveGame = await m_MainWindowService.SearchSpectableGameAsync(summName, tagLine, selectedRegion);

                    SpectateState = SpectateState.NoneSpectate;
                    CanSpectate = true;


                    IsBusy?.Invoke(false);
                }
                catch (MainWindowServiceError e)
                {
                    CanSpectate = false;
                    IsBusy?.Invoke(false);
                    ErrorDialog?.Invoke(e.ErrorFormat);
                }
            }, cancellationTokenSource.Token);

            await cancellationTokenSource.CancelAsync();
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

        public async Task OnSpectateClick()
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
    }
}
