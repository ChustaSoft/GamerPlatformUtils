using System.IO;

namespace ChustaSoft.GamersPlatformUtils.Abstractions
{
    public class GameLink
    {
        public string Name { get; set; }
        public FileInfo Path { get; set; }


        public GameLink() { }

        public GameLink(string name, FileInfo path)
        {
            this.Name = name;
            this.Path = path;
        }

    }
}
