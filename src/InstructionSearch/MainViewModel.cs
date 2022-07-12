using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Linq;

namespace InstructionSearch
{
    class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            var groups = InstructionUtility.Groups(InstructionUtility.BasePath);
            foreach (var group in groups)
            {
                var groupName = InstructionUtility.GetGroupName(group);
                Groups.Add(new Group
                {
                    Name = groupName,
                    FullPath = group,
                    Type = ItemType.Directory
                });
            }
        }

        public ObservableCollection<Group> Groups { get; set; } = new ObservableCollection<Group>();

        public ICommand AddGroupCommand => new RelayCommand((i) =>
        {
            AddInstructionGroupView addGroupView = new AddInstructionGroupView();
            if (addGroupView.ShowDialog() == true)
            {
                var result = ((IDialogResult)addGroupView).Result;
                if (Groups.Any(group => group.Name.Contains(result) || result == string.Empty)) return;

                Groups.Add(new Group
                {
                    Name = result,
                    FullPath = InstructionUtility.GetCurrentPath()
                });
            }
        });

        public ICommand AddInstructionCommand => new RelayCommand((i) =>
        {
            if (InstructionUtility.GetCurrentPath() == InstructionUtility.BasePath) return;


        });

        public ICommand ItemClickCommand => new RelayCommand(i =>
        {
            var model = i as Group;
        });
    }
}
