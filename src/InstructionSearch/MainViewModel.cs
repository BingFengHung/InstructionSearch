using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace InstructionSearch
{
    class MainViewModel : ViewModelBase
    {
        private Stack<string> _backward = new Stack<string>();
        private Stack<string> _forward = new Stack<string>();

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

        private void RefreshItems()
        {
            Groups.Clear();

            var paths = InstructionUtility.GetCurrentPath();
            var groups = InstructionUtility.Groups(paths);

            foreach (var group in groups)
            {
                Groups.Add(new Group
                {
                    Name = InstructionUtility.GetGroupName(group),
                    FullPath = group,
                    Type = InstructionUtility.GetItemType(group)
                });
            }
        }

        public ICommand AddGroupCommand => new RelayCommand((i) =>
        {
            AddInstructionGroupView addGroupView = new AddInstructionGroupView();
            if (addGroupView.ShowDialog() == true)
            {
                var result = ((IDialogResult)addGroupView).Result;
                if (Groups.Any(group => group.Name.Contains(result) || result == string.Empty)) return;

                var path = Path.Combine(InstructionUtility.GetCurrentPath(), result);

                Groups.Add(new Group
                {
                    Name = result,
                    FullPath = path
                });

                Directory.CreateDirectory(path);
            }
        });

        public ICommand AddInstructionCommand => new RelayCommand((i) =>
        {
            if (InstructionUtility.GetCurrentPath() == InstructionUtility.BasePath) return;

            AddInstructionContentView addContentView = new AddInstructionContentView();

            if (addContentView.ShowDialog() == true)
            {
                var result = ((IDialogResult)addContentView).Result;

                string fullPath = Path.Combine(InstructionUtility.GetCurrentPath(), result);
                Groups.Add(new Group
                {
                    Name = result,
                    FullPath = fullPath,
                    Type = InstructionUtility.GetItemType(fullPath)
                });
            }
        });

        public ICommand ItemClickCommand => new RelayCommand(i =>
        {
            var model = i as Group;

            if (model.Type == ItemType.Directory)
            {
                InstructionUtility.PushPath(model.FullPath);
                var groups = InstructionUtility.Groups(model.FullPath);
                _backward.Push(InstructionUtility.GetCurrentPath());

                Groups.Clear();

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


        public ICommand BackwardCommand => new RelayCommand(i =>
        {
            if (_backward.Count == 0) return;
            InstructionUtility.PopPath();
            _forward.Push(_backward.Peek());
            _backward.Pop();
            RefreshItems();
        });

        public ICommand ForwardCommand => new RelayCommand(i =>
        {
            if (_forward.Count == 0) return;
            InstructionUtility.PushPath(_forward.Peek());
            _backward.Push(_forward.Peek());
            _forward.Pop();
            RefreshItems();
        });

        public ICommand HomeCommand => new RelayCommand(i =>
        {
            if (InstructionUtility.GetCurrentPath() == InstructionUtility.BasePath) return;
            _backward.Push(InstructionUtility.BasePath);
            RefreshItems();
        });
    }
}
