using LeagueSpectator.MVVM.DTOs;
using System.Collections.ObjectModel;

namespace LeagueSpectator.MVVM.Models
{
    public sealed class Team
    {
        public ObservableCollection<ParticipantDTO> Players { get; }
        public ObservableCollection<BannedChampionDTO> Bans { get; }

        public Team()
        {
            Players = new();
            Bans = new();
        }

        public void Clear()
        {
            Players.Clear();
            Bans.Clear();
        }
        public void ChangeLanguage()
        {
            LocalizeCollection(Players);
            LocalizeCollection(Bans);
        }

        private static void LocalizeCollection<T>(ObservableCollection<T> items) where T : LocalizableObject
        {
            foreach (T item in items)
            {
                item.LocalizeObject();
            }
        }
    }
}
