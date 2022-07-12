using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Linq;
using System.IO;

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

            AddInstructionContentView addContentView = new AddInstructionContentView();

            if (addContentView.ShowDialog() == true)
            {
                var result = ((IDialogResult)addContentView).Result;

                Groups.Add(new Group
                {
                    Name = result,
                    FullPath = Path.Combine(InstructionUtility.GetCurrentPath(), result)
                });
            }
        });

        public ICommand ItemClickCommand => new RelayCommand(i =>
        {
            var model = i as Group;

            if (model.Type == ItemType.Directory)
            {
                var groups = InstructionUtility.Groups(model.FullPath);
                foreach (var group in groups)
                {
                    var groupName = InstructionUtility.GetGroupName(group);
                    var type = InstructionUtility.GetItemType(group);
                    Groups.Add(new Group
                    {
                        Name = groupName,
                        FullPath = group,
                        Type = type
                    });
                }
            }
            else
            {
                InstructionContentView instructionContentView = new InstructionContentView();
                instructionContentView.Item = model;
                instructionContentView.ShowDialog();

            }
        });
    }
}
