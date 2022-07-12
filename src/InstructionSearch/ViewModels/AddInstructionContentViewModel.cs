using System.IO;
using System.Windows;
using System.Windows.Input;

namespace InstructionSearch
{
    class AddInstructionContentViewModel : ViewModelBase, IDialogResult
    {
        Window _window;

        public string Title { get; set; }

        public string Content { get; set; }

        public string Result { get; set; }

        public ICommand SaveCommand => new RelayCommand((i) =>
        {
            try
            {
                File.WriteAllText(Path.Combine(InstructionUtility.GetCurrentPath(), $"{Title}.txt"), Content);
                _window.DialogResult = true;
                Result = $"{Title}.txt";
            }
            catch
            {
                MessageBox.Show("儲存失敗");
            }
        });

        public ICommand CancelCommand => new RelayCommand((i) =>
        {
            _window.DialogResult = false;
        });

        public DelegateLoadedAction LoadedAction => new DelegateLoadedAction((o, e) =>
        {
            _window = o as Window;
        });

    }
}
