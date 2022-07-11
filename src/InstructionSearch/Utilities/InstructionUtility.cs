using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace InstructionSearch
{
    class InstructionUtility
    {
        static string path = @".\InstructionSet";

        static InstructionUtility()
        {
            if (Directory.Exists(path)) return;
            Directory.CreateDirectory(path);
        }

        public static void CreateGroup(string groupName)
        {
            string group = Path.Combine(path, groupName);

            if (Directory.Exists(group)) return;
            Directory.CreateDirectory(group);
        }

        public static void WriteInstruction(string path, List<string> content)
        {
            File.WriteAllLines(path, content);
        }

        public static List<string> ReadInstruciton(string path)
        {
            return File.ReadAllLines(path).ToList();
        }
    }
}
