using Windows.System;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace HoloSuite.source.features
{
    public sealed partial class Keycodes : Page
    {
        public Keycodes()
        {
            this.InitializeComponent();

            Window.Current.CoreWindow.CharacterReceived += CoreWindow_CharacterReceived;
        }

        private static bool IsCtrlKeyPressed()
        {
            var ctrlState = CoreWindow.GetForCurrentThread().GetKeyState(VirtualKey.Control);
            return (ctrlState & CoreVirtualKeyStates.Down) == CoreVirtualKeyStates.Down;
        }
        private static bool IsWindowsKeyPressed()
        {
            var ctrlState = CoreWindow.GetForCurrentThread().GetKeyState(VirtualKey.LeftWindows);
            return (ctrlState & CoreVirtualKeyStates.Down) == CoreVirtualKeyStates.Down;
        }
        private static bool IsShiftKeyPressed()
        {
            var ctrlState = CoreWindow.GetForCurrentThread().GetKeyState(VirtualKey.Shift);
            return (ctrlState & CoreVirtualKeyStates.Down) == CoreVirtualKeyStates.Down;
        }

        private void CoreWindow_CharacterReceived(CoreWindow sender, CharacterReceivedEventArgs args)
        {
            StartMessage.Visibility = Visibility.Collapsed;
            Content.Visibility = Visibility.Visible; 

            Keycode.Text = args.KeyCode.ToString();
            Key.Text = "�";

            IsCTRL.Text = IsCtrlKeyPressed() ? "Yes" : "No";
            IsWindows.Text = IsWindowsKeyPressed() ? "Yes" : "No";
            IsShift.Text = IsShiftKeyPressed() ? "Yes" : "No";
        }
    }
}
