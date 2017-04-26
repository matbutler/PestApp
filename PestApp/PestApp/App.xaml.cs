using Autofac;
using PestApp.Contacts.ViewModels;
using PestApp.Contacts.Views;
using Prism.Autofac;
using Prism.Autofac.Forms;

namespace PestApp
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer)
        {
        }

        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync("/CustomNavigationPage/Contacts");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<CustomNavigationPage>();
            Container.RegisterTypeForNavigation<ContactsPage, ContactsPageViewModel>("Contacts");
            Container.RegisterTypeForNavigation<VisitsPage, VisitPageViewModel>("Visits");
            Container.RegisterTypeForNavigation<ContactDetailPage, ContactDetailPageViewModel>("ContactDetail");
            Container.RegisterTypeForNavigation<ContactPage, ContactPageViewModel>("ContactPage");
            Container.RegisterTypeForNavigation<NewVisitPage, NewVisitPageViewModel>("NewVisit");

            var builder = new ContainerBuilder();
            builder.RegisterType<ContactsPageViewModel>();
            builder.RegisterType<VisitPageViewModel>();
            builder.RegisterType<ContactDetailPageViewModel>();
            builder.RegisterType<ContactPageViewModel>();

            builder.Register<IAzureDataService>(ctx => new AzureDataService());
            //builder.RegisterModule(new CommonRegistry());
            builder.Update(Container);
        }
    }
}
