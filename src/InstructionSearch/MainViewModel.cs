using System.Collections.ObjectModel;
using System.Windows.Input;

namespace InstructionSearch
{
    class Group
    {
        public string Name { get; set; }
    }

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
                    Name = groupName
                });
            }
        }

        public ObservableCollection<Group> Groups { get; set; } = new ObservableCollection<Group>();

        public ICommand AddGroupCommand => new RelayCommand((i) =>
        {

        });

        public ICommand AddInstructionCommand => new RelayCommand((i) =>
        {

        });
    }
}
