using PestApp.Contacts.Models;
using PestApp.Helpers;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System.Collections.ObjectModel;
using System.Linq;

namespace PestApp.Contacts.ViewModels
{
    public class ContactsPageViewModel : BindableBase
    {
        private readonly INavigationService _navigationService;
        private readonly IAzureDataService _azureDataService;

        private ObservableCollection<Grouping<string, Contact>> _contacts;
        public ObservableCollection<Grouping<string, Contact>> Contacts
        {
            get { return _contacts; }
            set { SetProperty(ref _contacts, value); }
        }

        private ObservableCollection<string> _filters;
        public ObservableCollection<string> Filters
        {
            get { return _filters; }
            set { SetProperty(ref _filters, value); }
        }

        public DelegateCommand<Contact> NavigateVisitCommand { get; set; }

        public ContactsPageViewModel(INavigationService navigationService, IAzureDataService azureDataService)
        {
            _navigationService = navigationService;
            _azureDataService = azureDataService;

            _azureDataService.Initialize().Wait();

            _azureDataService.AddContact().Wait();

            Filters = new ObservableCollection<string>
            {
                "All",
                "Test",
            };

            NavigateVisitCommand = new DelegateCommand<Contact>(NavigateVisit);

            var contactData = new ObservableCollection<Contact>()
            {
                new Contact
                {
                    Id = 1,
                    Name = "Mat"
                },
                new Contact
                {
                    Id = 2,
                    Name = "Bob"
                },
            };

            var sorted = from contact in contactData
                         orderby contact.Name
                         group contact by contact.NameSort into contactGroup
                         select new Grouping<string, Contact>(contactGroup.Key, contactGroup);

            Contacts = new ObservableCollection<Grouping<string, Contact>>(sorted);
        }

        private async void NavigateVisit(Contact contact)
        {
            await _navigationService.NavigateAsync($"CustomNavigationPage/ContactPage?contactId={contact.Id}");
        }
    }
}
