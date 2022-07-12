using System.IO;
using System.Windows;
using System.Windows.Input;

namespace InstructionSearch
{
    class AddInstructionContentViewModel : ViewModelBase
    {
        Window _window;

        public string Title { get; set; }

        public string Content { get; set; }

        public ICommand SaveCommand => new RelayCommand((i) =>
        {
            try
            {
                File.WriteAllText(Path.Combine(InstructionUtility.GetCurrentPath(), $"{Title}.txt"), Content);
                _window.DialogResult = true;
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
