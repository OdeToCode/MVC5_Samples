namespace ModelBinding.Models
{
    public class Account
    {
        public Account(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public decimal Amount { get; set; }
    }
}