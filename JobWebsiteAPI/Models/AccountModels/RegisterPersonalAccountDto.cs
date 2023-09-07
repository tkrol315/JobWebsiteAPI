namespace JobWebsiteAPI.Models.AccountModels
{
    public class RegisterPersonalAccountDto : RegisterAccountDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int AccountTypeId { get; set; } = 0;

    }
}
