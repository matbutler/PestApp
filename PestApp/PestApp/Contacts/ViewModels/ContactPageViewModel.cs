using System;
using Prism.Mvvm;
using Prism.Navigation;
using PestApp.Contacts.Models;
using Prism.Commands;

namespace PestApp.Contacts.ViewModels
{
    public class ContactPageViewModel : BindableBase, INavigationAware
    {
        private Contact _contact;
        private readonly INavigationService _navigationService;

        public VisitPageViewModel VisitPageContext { get; private set; }
        public ContactDetailPageViewModel DetailPageContext { get; private set; }

        public DelegateCommand NavigateNewVisitCommand { get; set; }

        public ContactPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            VisitPageContext = new VisitPageViewModel();
            DetailPageContext = new ContactDetailPageViewModel();

            NavigateNewVisitCommand = new DelegateCommand(NavigateNewVisit);
        }

        private async void NavigateNewVisit()
        {
            await _navigationService.NavigateAsync($"NewVisit?contactId={_contact.Id}");
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            _contact = new Contact()
            {
                Name = "Mat",
                Address = "Addres",
                Email = "ttet@test.com",
                Visits = new System.Collections.Generic.List<Visit>
                {
                    new Visit
                    {
                         Date =DateTime.Now,
                         Title = "Big Job",
                    }
                }
            };

            DetailPageContext.Contact = _contact;
            VisitPageContext.Visits = _contact.Visits;
            // throw new NotImplementedException();
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            // throw new NotImplementedException();
        }
    }
}
