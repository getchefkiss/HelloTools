using System;
using Windows.System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;

using muxc = Microsoft.UI.Xaml.Controls;
using HoloSuite.source;
using HoloSuite.source.features;

namespace HoloSuite
{

    public sealed partial class MainPage
    {
        public static Frame frame;
        public static muxc.NavigationView nav;
        private static Windows.ApplicationModel.Package package = Windows.ApplicationModel.Package.Current;

        public MainPage()
        {
            Window.Current.CoreWindow.CharacterReceived += CoreWindow_CharacterReceived;
            this.InitializeComponent();

            TitleBarText.Text = package.DisplayName;

            frame = Content;
            nav = Nav;

            Content.Navigate(typeof(Home));
        }

        private async void Nav_ItemInvoked(muxc.NavigationView sender, muxc.NavigationViewItemInvokedEventArgs args)
        {
            muxc.NavigationViewItem item = (muxc.NavigationViewItem)Nav.SelectedItem;
            string name = item.Name.Replace("_", " ");
            Nav.Header = name;

            switch (name)
            {
                case "Home": Content.Navigate(typeof(Home)); break;
                case "Fake Info": Content.Navigate(typeof(Fake_Info)); break;
                case "Keycodes": Content.Navigate(typeof(Keycodes)); break;
                case "Lorem Ipsum": Content.Navigate(typeof(Lorem_Ipsum)); break;
                case "Symbols": Content.Navigate(typeof(Symbols)); break;

                case "Feedback": await Launcher.LaunchUriAsync(new Uri($"https://bitsoftwareco.github.io/?r=as%20feedback")); break;
            };
        }

        private void CoreWindow_CharacterReceived(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.CharacterReceivedEventArgs args)
        {
            switch (args.KeyCode)
            {
                case 27:
                    Nav.Header = "Home";
                    Content.Navigate(typeof(Home));
                    nav.SelectedItem = nav.MenuItems[0];
                    break;
            }
        }
    }
}