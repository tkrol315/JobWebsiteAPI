namespace JobWebsiteAPI.Entities
{
    public class AccountType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Account> Accounts { get; set; } = new List<Account>();
    }
}
