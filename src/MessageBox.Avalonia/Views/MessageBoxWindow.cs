using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using MessageBoxSlim.Avalonia.Enums;
using MessageBoxSlim.Avalonia.Extensions;
using MessageBoxSlim.Avalonia.Interfaces;

namespace MessageBoxSlim.Avalonia.Views
{
    public class MessageBoxWindow : Window, IMessageBox<UserResult>
    {
        public MessageBoxWindow()
        {
            InitializeComponent();
        }

        public MessageBoxWindow(BoxStyle style)
        {
            this.SetStyle(style);
            InitializeComponent();
        }

        public UserResult UserResult { get; set; } = UserResult.None;

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public Task<UserResult> ShowAsync()
        {
            var tcs = new TaskCompletionSource<UserResult>();
            Closed += delegate { tcs.TrySetResult(UserResult); };
            Show();
            return tcs.Task;
        }

        public Task<UserResult> ShowDialogAsync(Window ownerWindow)
        {
            var tcs = new TaskCompletionSource<UserResult>();
            Closed += delegate { tcs.TrySetResult(UserResult); };
            ShowDialog(ownerWindow);
            return tcs.Task;
        }
    }
}