using PestApp.Contacts.Models;
using Prism.Mvvm;
using System.Collections.Generic;

namespace PestApp.Contacts.ViewModels
{
    public class VisitPageViewModel : BindableBase
    {
        private List<Visit> _visits;
        public List<Visit> Visits
        {
            get { return _visits; }
            set { SetProperty(ref _visits, value); }
        }
    }
}
