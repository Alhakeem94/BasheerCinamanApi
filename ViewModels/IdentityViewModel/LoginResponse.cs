namespace BasheerCinamanApi.ViewModels.IdentityViewModel
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public bool Success { get; set; }
        public List<string> Errors { get; set; }
        public string UserRole { get; set; }

    }
}
