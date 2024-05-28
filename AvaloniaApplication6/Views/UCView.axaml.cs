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
            this.WhenActivated(action => action(ViewModel!.ShowDialog.RegisterHandler(DoShowDialogAsync)));
        }



        private async Task DoShowDialogAsync(InteractionContext<DialogViewModel, DialogModel?> interaction)
        {
            var dialog = new DialogView();
            dialog.DataContext = interaction.Input;
            var mainWindow = ((IClassicDesktopStyleApplicationLifetime)Application.Current.ApplicationLifetime).MainWindow;
            var result = await dialog.ShowDialog<DialogModel?>(mainWindow);
            interaction.SetOutput(result);
        }

    }
}
