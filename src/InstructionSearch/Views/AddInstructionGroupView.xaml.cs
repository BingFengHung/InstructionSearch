using System.Windows;

namespace InstructionSearch
{

    /// <summary>
    /// Interaction logic for AddInstructionGroupView.xaml
    /// </summary>
    public partial class AddInstructionGroupView : Window, IDialogResult
    {
        public AddInstructionGroupView()
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