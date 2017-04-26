using Prism.Mvvm;
using PestApp.Contacts.Models;

namespace PestApp.Contacts.ViewModels
{
    public class ContactDetailPageViewModel : BindableBase
    {
        private Contact _contact;
        public Contact Contact
        {
            get { return _contact; }
            set { SetProperty(ref _contact, value); }
        }
    }
}
