using System.Windows.Input;

namespace InstructionSearch
{
    class AddInstructionGroupViewModel : ViewModelBase, IDialogResult
    {
        public AddInstructionGroupViewModel()
        {
        }

        public string Result { get; set; }

        public string GroupName { get; set; }

        public ICommand ConfirmCommand => new RelayCommand((i) =>
        {
            Result = GroupName;
        });

        public ICommand CancelCommand => new RelayCommand((i) =>
        {

        });
    }
}
