using System.Text;

namespace InstructionSearch
{
    class InstructionContentViewModel : ViewModelBase
    {
        private Group _item;

        public string Title { get; set; }

        public string Content { get; set; }

        public Group Item
        {
            get => _item;
            set
            {
                _item = value;
                Title = InstructionUtility.GetInstructionName(_item.FullPath);

                StringBuilder sb = new StringBuilder();
                foreach (var line in InstructionUtility.ReadInstruciton(_item.FullPath))
                {
                    sb.AppendLine(line);
                }

                Content = sb.ToString();
            }
        }
    }
}
