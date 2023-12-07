namespace Auth.Application.ViewModels.Account
{
    public class RegisterViewModel
    {
        public RegisterViewModel()
        {
            Password = String.Empty;
            Username = String.Empty;
            Domain = string.Empty;
        }

        public string? ConfirmPassword { get; set; }
        public string Domain { get; set; }
        public virtual string? Email { get; set; }
        public virtual bool EmailConfirmed { get; set; }
        public virtual string? Id { get; set; }
        public string Password { get; set; }
        public string? ReturnUrl { get; set; }
        public string Username { get; set; }
    }
}