using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Microsoft.WindowsAzure.MobileServices.Sync;
using PestApp.Contacts.Models;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace PestApp
{

    public class AzureDataService : IAzureDataService
    {
        public MobileServiceClient MobileService { get; set; }

        IMobileServiceSyncTable<Contact> contactsTable;

        public async Task Initialize()
        {
            //Create MobileService reference with the back-end address:
            MobileService = new MobileServiceClient("https://pestapp.azurewebsites.net");

            var path = "syncstore.db";

            path = Path.Combine(MobileServiceClient.DefaultDatabasePath, path);



            //setup our local sqlite store and intialize our table

            var store = new MobileServiceSQLiteStore(path);
            store.DefineTable<Contact>();

            await MobileService.SyncContext.InitializeAsync(store);

            //Get our sync table that will call out to azure
            contactsTable = MobileService.GetSyncTable<Contact>();
        }

        public async Task<IEnumerable<Contact>> GetContacts()
        {
            await SyncContacts();
            return await contactsTable.ToListAsync();
        }

        public async Task AddContact()
        {
            var contact = new Contact
            {
                Email = "mobileprogrammer@..."
            };

            await contactsTable.InsertAsync(contact);

            //Synchronize coffee
            await SyncContacts();
        }

        public async Task SyncContacts()
        {
            await contactsTable.PullAsync("contacts", contactsTable.CreateQuery());
            await MobileService.SyncContext.PushAsync();
        }
    }
}
