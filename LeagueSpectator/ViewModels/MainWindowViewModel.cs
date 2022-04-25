using LeagueSpectator.Helpers;
using LeagueSpectator.Models;
using LeagueSpectator.Services;
using ReactiveUI;
using Splat;
using System.Collections.Generic;

namespace LeagueSpectator.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private string summonerId;
        private readonly IMainWindowService mainWindowService;
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

        public MainWindowViewModel()
        {
            mainWindowService = Locator.Current.GetService<IMainWindowService>();
            summonerId = string.Empty;
            message = string.Empty;
            canSpectate = false;
        }

        private async void OnSearchClick(IList<object> parameters)
        {
            if (await mainWindowService.SearchSummonerAsync(parameters[0].ToString()!, (Region)parameters[1], "RGAPI-6db5a081-4f22-4732-bc6f-bcf3971c36f0", out summonerId))
            {
                if (await mainWindowService.SearchSpectableGameAsync(summonerId!, (Region)parameters[1], "RGAPI-6db5a081-4f22-4732-bc6f-bcf3971c36f0"))
                {
                    Message = $"{parameters[0]} is in game";
                    CanSpectate = true;
                    return;
                }
                Message = $"{parameters[0]} is not in game";
                CanSpectate = false;
                return;
            }
            CanSpectate = false;
            Message = $"{parameters[0]} doesn't exist";
        }
        private async void OnSpectateClick()
        {
            if (await mainWindowService.SpectateGameAsync())
            {

            }
        }
    }
}
