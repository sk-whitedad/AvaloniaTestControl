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
            ShowDialog = new Interaction<DialogViewModel, DialogModel?>();

            OpenDialog = ReactiveCommand.CreateFromTask(async () =>
            {
                var store = new DialogViewModel();

                var result = await ShowDialog.Handle(store);
            });
        }
       
        public ICommand OpenDialog { get; }
        public Interaction<DialogViewModel, DialogModel?> ShowDialog { get; }
    }
}
