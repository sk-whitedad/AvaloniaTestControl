using ReactiveUI;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AvaloniaApplication6.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ICommand CommandLoadControl { get; }
        private ViewModelBase _uControl;
        public ViewModelBase UControl
        {
            get { return _uControl; }
            private set { this.RaiseAndSetIfChanged(ref _uControl, value); }
        }
        public MainWindowViewModel()
        {
            CommandLoadControl = ReactiveCommand.Create(ButtonCommandLoadControl);

        }

        private void ButtonCommandLoadControl()
        {
            UControl = new UCViewModel();
        }


    }
}
