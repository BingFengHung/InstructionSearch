using System.Windows;

namespace InstructionSearch
{
    /// <summary>
    /// Interaction logic for InstructionContentView.xaml
    /// </summary>
    public partial class InstructionContentView : Window
    {
        public InstructionContentView()
        {
            InitializeComponent();
        }

        public Group Item
        {
            get => ((InstructionContentViewModel)this.DataContext).Item;
            set => ((InstructionContentViewModel)this.DataContext).Item = value;
        }
    }
}
