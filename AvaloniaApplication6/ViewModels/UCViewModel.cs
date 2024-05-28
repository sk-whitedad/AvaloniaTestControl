using ReactiveUI;
using System.Reactive;
using System.Reactive.Linq;
using System.Windows.Input;

namespace AvaloniaApplication6.ViewModels
{
    public class UCViewModel : ViewModelBase
    {
        public UCViewModel()
        {
            OpenDialog = ReactiveCommand.CreateFromTask(async () =>
            {
                var settings = new DialogViewModel();

                var result = await ShowDialog.Handle(settings);
            });
        }

        public Interaction<DialogViewModel, Unit> ShowDialog { get; } = new();
        public ICommand OpenDialog { get; }

    }
}
