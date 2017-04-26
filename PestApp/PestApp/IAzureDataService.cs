using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using PestApp.Contacts.Models;

namespace PestApp
{
    public interface IAzureDataService
    {
        MobileServiceClient MobileService { get; set; }

        Task AddContact();
        Task<IEnumerable<Contact>> GetContacts();
        Task Initialize();
        Task SyncContacts();
    }
}