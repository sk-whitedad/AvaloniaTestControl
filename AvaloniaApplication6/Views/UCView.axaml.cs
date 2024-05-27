using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.ReactiveUI;
using Avalonia.VisualTree;
using AvaloniaApplication6.ViewModels;
using ReactiveUI;
using System.Reactive;
using System.Threading.Tasks;

namespace AvaloniaApplication6.Views
{
    public partial class UCView : ReactiveUserControl<UCViewModel>
    {
        public UCView()
        {
            InitializeComponent();
            DataContext = new UCViewModel();
            this.WhenActivated(action =>
                action(ViewModel!.ShowDialog.RegisterHandler(Handler)));
        }

        private Window _window;
        private void Visual_OnAttachedToVisualTree(object? sender, VisualTreeAttachmentEventArgs e)
        {
            _window = this.FindAncestorOfType<Window>();
        }

        private async Task Handler(InteractionContext<DialogViewModel, Unit> interaction)
        {
            var dialog = new DialogView()
            {
                DataContext = interaction.Input
            };

 
            var result = await dialog.ShowDialog<Unit>(_window);
            interaction.SetOutput(result);
        }
    }
}
