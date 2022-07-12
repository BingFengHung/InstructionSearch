using System.Windows;
using System.Windows.Input;

namespace InstructionSearch
{
    class AddInstructionGroupViewModel : ViewModelBase, IDialogResult
    {
        Window _window;

        public AddInstructionGroupViewModel()
        {
        }

        public string Result { get; set; }

        public string GroupName { get; set; }

        public ICommand ConfirmCommand => new RelayCommand((i) =>
        {
            Result = GroupName;
            _window.DialogResult = true;
        });

        public ICommand CancelCommand => new RelayCommand((i) =>
        {
            _window.DialogResult = false;
        });

        public DelegateLoadedAction LoadedAction => new DelegateLoadedAction(LoadedActionExecute);

        private void LoadedActionExecute(object sender, RoutedEventArgs e)
        {
            _window = sender as Window;
        }
    }
}
