namespace KatanaAppFunc
{
    public class HelloWorldOptions
    {
        public HelloWorldOptions()
        {
            IncludeTimestamp = true;
            Name = "World";
        }

        public bool IncludeTimestamp { get; set; }
        public string Name { get; set; }
    }
}