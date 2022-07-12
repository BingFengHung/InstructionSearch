namespace InstructionSearch
{
    enum ItemType
    {
        Directory,
        File
    }
    class Group
    {
        public string Name { get; set; }

        public ItemType Type { get; set; }

        public string FullPath { get; set; }
    }
}
