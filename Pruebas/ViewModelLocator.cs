using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;


namespace Pruebas
{
    [Windows.UI.Xaml.Data.Bindable]
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            RegisterServices(SimpleIoc.Default);
            RegisterViewModels(SimpleIoc.Default);
        }

        private static void RegisterServices(SimpleIoc ioc)
        {
            ioc.Register<IMessenger, Messenger>();
            ioc.Register<Pruebas.NavigationService>();
            SimpleIoc.Default.Register<IDialogService, DialogService>();
        }

        private static void RegisterViewModels(SimpleIoc ioc)
        {
            ioc.Register<MainViewModel>();
        }

        public MainViewModel MainViewModel => SimpleIoc.Default.GetInstance<MainViewModel>();
    }
}
