using System.Windows;

namespace InstructionSearch
{
    /// <summary>
    /// Interaction logic for AddInstructionContentView.xaml
    /// </summary>
    public partial class AddInstructionContentView : Window, IDialogResult
    {
        public AddInstructionContentView()
        {
            InitializeComponent();
        }

        public string Result
        {
            get => ((IDialogResult)this.DataContext).Result;
            set => ((IDialogResult)this.DataContext).Result = value;
        }
    }
}
