using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace InstructionSearch
{
    class InstructionUtility
    {
        public static string BasePath = @".\InstructionSet";

        static InstructionUtility()
        {
            if (Directory.Exists(BasePath)) return;
            Directory.CreateDirectory(BasePath);
        }

        public static List<string> Groups(string path)
        {
            return Directory.GetDirectories(path).ToList();
        }

        public static string GetGroupName(string path)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            return directoryInfo.Name;
        }

        public static string GetInstructionName(string path)
        {
            FileInfo fileInfo = new FileInfo(path);
            return fileInfo.Name;
        }

        public static List<string> Instructions(string path)
        {
            return Directory.GetFiles(path).ToList();
        }

        public static void CreateGroup(string path, string groupName)
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
