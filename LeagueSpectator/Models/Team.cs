using ReactiveUI;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueSpectator.Models
{
    public class Team : ReactiveObject
    {
        private ObservableCollection<Participant> players;
        public ObservableCollection<Participant> Players
        {
            get => players;
            set => this.RaiseAndSetIfChanged(ref players, value, nameof(Players));
        }

        private ObservableCollection<BannedChampion> bans;
        public ObservableCollection<BannedChampion> Bans
        {
            get => bans;
            set => this.RaiseAndSetIfChanged(ref bans, value, nameof(Bans));
        }

        public Team()
        {
            players = new();
            bans = new();
        }
    }
}
