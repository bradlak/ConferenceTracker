using System.Linq;
using ConferenceTracker.Infrastructure;
using ConferenceTracker.UI;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace ConferenceTracker.ViewModel
{
    public class NavigationViewModel : BaseViewModel
    {
        private MenuItem selectedItem;

        private ICommand itemSelectedCommand;

        public ObservableCollection<MenuItem> MenuItems { get; set; }

        public NavigationViewModel(IServiceCaller caller) : base(caller,false)
        {
            MenuItems = new ObservableCollection<MenuItem>();

            MenuItems.Add(new MenuItem("Feeds", typeof(FeedsPage), MenuItemType.Feeds, "rss.png", true));
            MenuItems.Add(new MenuItem("Sessions", typeof(SessionsPage), MenuItemType.Sessions, "session.png"));
            MenuItems.Add(new MenuItem("Events", typeof(EventsPage), MenuItemType.Events, "event.png"));
            MenuItems.Add(new MenuItem("Speakers", typeof(SpeakersPage), MenuItemType.Speakers, "speaker.png"));

            MenuItems.Add(new MenuItem("Sponsors", typeof(SponsorsPage), MenuItemType.Sponsors, "sponsors.png"));
            MenuItems.Add(new MenuItem("About", typeof(AboutPage), MenuItemType.About, "about.png"));

            SelectedItem = MenuItems.First();
        }


        public MenuItem SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                selectedItem = value;
                if(selectedItem != null) ItemSelectedCommand.Execute(null);
                RaisePropertyChanged();
            }
        }

        public ICommand ItemSelectedCommand
        {
            get
            {
                itemSelectedCommand = itemSelectedCommand ?? new RelayCommand(ItemSelected);
                return itemSelectedCommand;
            }
        }

        private void ItemSelected()
        {
            ChangePageMessage message = new ChangePageMessage(SelectedItem);
            ProcessSelections(SelectedItem.Type);
            Messenger.Default.Send<ChangePageMessage>(message);
        }

        private void ProcessSelections(MenuItemType type)
        {
            foreach (var item in MenuItems)
            {
                item.IsSelected = false;
            }
            MenuItems.Single(z => z.Type == type).IsSelected = true;
        }
    }
}
