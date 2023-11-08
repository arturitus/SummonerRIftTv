using System.Collections.ObjectModel;

namespace LeagueSpectator.Models
{
    public sealed class Team
    {
        public ObservableCollection<Participant> Players { get; }
        public ObservableCollection<BannedChampion> Bans { get; }

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
