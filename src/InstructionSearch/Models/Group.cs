namespace InstructionSearch
{
    public enum ItemType
    {
        Directory,
        File
    }
    public class Group
    {
        public string Name { get; set; }

        public ItemType Type { get; set; }

        public string FullPath { get; set; }
    }
}
