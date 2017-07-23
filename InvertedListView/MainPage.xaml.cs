using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation.Collections;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace InvertedListView
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private MessageCollection Messages { get; set; } = new MessageCollection();

        public MainPage()
        {
            this.InitializeComponent();
            this.KeyUp += OnKeyUp;
        }

        private void OnKeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (NameBox.Text == string.Empty || MessageBox.Text == string.Empty) return;

            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                OnSendButtonTapped(null, null);
            }
        }

        private void OnSendButtonTapped(object sender, TappedRoutedEventArgs e)
        {
            if (MessageBox.Text == string.Empty || NameBox.Text == string.Empty) return;

            var message = new MessageInfo
            {
                Name = NameBox.Text,
                Message = MessageBox.Text
            };

            Messages.Add(message);

            MessageBox.Text = string.Empty;
        }
    }
}
