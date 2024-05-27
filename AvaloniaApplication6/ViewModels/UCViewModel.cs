using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

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
        public IReactiveCommand<Unit, Unit> OpenDialog { get; }

    }
}
