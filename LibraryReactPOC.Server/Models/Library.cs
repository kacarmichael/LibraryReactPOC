namespace LibraryReactPOC.Server.Models
{
    public class Library
    {
        private List<DirectoryInfo> _directories;
        public string Name { get; set; }
        public DateTime CreatedAt { get; }
        public Library(string name) 
        {
            Name = name;
            _directories = new List<DirectoryInfo>();
            CreatedAt = DateTime.Now;
        }


        public override string ToString() { return "Library: " + Name; }
    }
}
