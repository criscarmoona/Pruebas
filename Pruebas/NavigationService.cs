using GalaSoft.MvvmLight;

using System;

using Windows.UI.Xaml.Controls;


namespace Pruebas
{
    public class NavigationService : ObservableObject
    {
        private bool _canGoBack;

        public Frame NavigationFrame { get; private set; }

        public Type RootPageType => typeof(MainPage);

        public Type CurrentPageType => NavigationFrame.CurrentSourcePageType;

        public bool CanGoBack
        {
            get
            {
                return _canGoBack;
            }
            set
            {
                Set(() => CanGoBack, ref _canGoBack, value);
            }
        }

        public void SetNavigationFrame(Frame frame)
        {
            if (frame == null)
            {
                throw new ArgumentNullException(nameof(frame));
            }

            if (NavigationFrame == null)
            {
                NavigationFrame = frame;

                if (RootPageType != null)
                {
                    Navigate(RootPageType);
                }

                CheckCanGoBack();
            }
        }

        public void GoBack()
        {
            if (NavigationFrame.CanGoBack)
            {
                NavigationFrame.GoBack();
            }

            CheckCanGoBack();
        }

        public virtual void Navigate(Type destinationPage)
        {
            Navigate(destinationPage, null);
        }

        public virtual void Navigate(Type destinationPage, object parameter)
        {
            NavigationFrame.Navigate(destinationPage, parameter);
            CheckCanGoBack();
        }

        private void CheckCanGoBack()
        {
            CanGoBack = NavigationFrame.CanGoBack && NavigationFrame.BackStackDepth > 1;
        }
    }
}
